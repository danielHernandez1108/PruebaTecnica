using Dominio.Interfaces;
using Dominio.Models;
using Infraestructure.ConnectionBd;
using Dapper;
using System.Data.Common;


namespace Infraestructure.Repositorys
{
    public class LoginRepository :IloginRepository
    {
        private DapperContext _DapperContext;

        public LoginRepository(DapperContext dapperContext)
        {
            _DapperContext = dapperContext;
        }

        public async Task<User> GenerateToken(User user)
        {
            string query = $@"SELECT Id, UserName From Users where UserName=@UserName and Password =@Password";
            try
            {
                using var connection = _DapperContext.CreateConnection();
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { user.UserName, user.Password});
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Error en la consulta: {ex.Message}");
                throw;
            }
        }
    }


}
