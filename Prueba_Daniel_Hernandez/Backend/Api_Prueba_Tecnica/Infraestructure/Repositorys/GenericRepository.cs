using Dominio.Interfaces;
using Dominio.Models;
using Infraestructure.ConnectionBd;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infraestructure.Repositorys
{
    public class GenericRepository : IGenericRepository
    {

        private DapperContext _DapperContext;

        public GenericRepository(DapperContext dapperContext)
        {
            _DapperContext = dapperContext;
        }
        public async Task<IEnumerable<Exams>> GetExams()
        {
            string query = $@"SELECT Id, NameExam , CodExam FROM Exams";
            try
            {
                using var connection = _DapperContext.CreateConnection();
                connection.Open();
                return await connection.QueryAsync<Exams>(query);
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Error en la consulta: {ex.Message}");
                throw;
            }
        }
    }
}
