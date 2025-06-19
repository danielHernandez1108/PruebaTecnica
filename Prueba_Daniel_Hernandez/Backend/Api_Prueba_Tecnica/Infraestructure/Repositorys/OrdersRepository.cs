using Dapper;
using Dominio.Interfaces;
using Dominio.Models;
using Infraestructure.ConnectionBd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositorys
{
    public class OrdersRepository : IOrdersRepository
    {
        private DapperContext _DapperContext;

        public OrdersRepository(DapperContext dapperContext)
        {
            _DapperContext = dapperContext;
        }

        public async Task<int> CreateOrders(Orders orders)
        {
            int orderId = 0;
            int patientId = 0;
            using var connection = _DapperContext.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {

                string query = @"SELECT Id FROM Patient WHERE Name = @NamePatient";
                var id = await connection.QueryFirstOrDefaultAsync<int?>(query, new
                {
                    orders.NamePatient
                }, transaction);

                if (id == null)
                {
                    string insertPatientQuery = @"INSERT INTO Patient (Name) VALUES (@NamePatient); SELECT CAST(SCOPE_IDENTITY() as int);";
                    patientId = await connection.ExecuteScalarAsync<int>(insertPatientQuery, new
                    {
                        orders.NamePatient
                    }, transaction);
                }
                else
                {
                    patientId = id.Value;
                }


                query = @"INSERT INTO Orders (IdPatient, AppointmentDate,OrderDate) VALUES (@IdPatient, @AppointmentDate, GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int);";
                orderId = await connection.ExecuteScalarAsync<int>(query, new
                {
                    IdPatient = patientId,
                    orders.AppointmentDate
                }, transaction);

                query = @"INSERT INTO ExamsOrder (IdOrder, NameExam,CodExam) VALUES (@OrderId, @NameExam, @CodExam);";

                foreach (var exam in orders.Exams)
                {
                    await connection.ExecuteAsync(query, new
                    {
                        OrderId = orderId,
                        exam.NameExam,
                        exam.CodExam
                    }, transaction);
                }

                transaction.Commit();
                return orderId;
            }
            catch (Exception ex)
            {

                transaction.Rollback();
                return 0;
                throw new Exception($"Error inserting order and exams: {ex.Message}");
            }
        }


        public async Task<IEnumerable<Orders>> ConsultOrder()
        {
            using var connection = _DapperContext.CreateConnection();
            connection.Open();

            var sql = @"
            SELECT 
                O.Id AS OrderId,
                P.Name AS NamePatient,
                O.AppointmentDate,
                EO.NameExam,
                EO.CodExam
            FROM Orders O
            INNER JOIN Patient P ON P.Id = O.IdPatient
           INNER JOIN ExamsOrder EO ON EO.IdOrder = O.Id";

            var result = await connection.QueryAsync(sql);

            var listOrders = new List<Orders>();

            foreach (var row in result)
            {

                var order = new Orders
                {
                    NamePatient = row.NamePatient,
                    Exams = new List<Exams>()
                };

                listOrders.Add(order);


                order.Exams.Add(new Exams
                {
                    NameExam = row.NameExam,
                    CodExam = row.CodExam
                });
            }

            return listOrders;
        }



    }
}
