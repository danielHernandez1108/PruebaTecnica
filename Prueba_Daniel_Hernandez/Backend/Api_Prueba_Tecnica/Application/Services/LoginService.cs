using Dominio.Interfaces;
using Dominio.Models;
using Dominio.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService
    {
        private IloginRepository _Repository;

        public LoginService(IloginRepository _repsotiory)
        {
            this._Repository = _repsotiory;

        }

        public async Task<Reply> Login(User user)
        {
            try
            {
                var response = await _Repository.GenerateToken(user);
                if (response != null)
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 200,
                        Data = GenerateToken(),
                        Message = $""
                    };
                }


                return new Reply
                {
                    Ok = true,
                    Status = 400,
                    Message = $"Usuario no encontrado"
                };

            }
            catch (Exception ex)
            {
                return new Reply
                {
                    Ok = false,
                    Status = 500,
                    Message = $"Error al obtener los pacientes: {ex.Message}"
                };
            }
        }


        public static string GenerateToken()
        {
            string Caracters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!#$%*_+";
            int Long = 20;
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[Long];
                rng.GetBytes(bytes);
                StringBuilder contrasenia = new StringBuilder(Long);
                foreach (byte byteValor in bytes)
                {
                    contrasenia.Append(Caracters[byteValor % Caracters.Length]);
                }
                return contrasenia.ToString();
            }
        }
    }
}
