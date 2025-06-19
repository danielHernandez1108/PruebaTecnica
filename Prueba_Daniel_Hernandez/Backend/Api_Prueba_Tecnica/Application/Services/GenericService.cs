using Dominio.Interfaces;
using Dominio.Models;
using Dominio.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService
    {
        private IGenericRepository _Repository;

        public GenericService(IGenericRepository _repsotiory)
        {
            this._Repository = _repsotiory;

        }

        public async Task<Reply> GetExams()
        {
            try
            {
                var response = await _Repository.GetExams();
                if (response.Any())
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 200,
                        Data = response,
                        Message = $""
                    };
                }


                return new Reply
                {
                    Ok = true,
                    Status = 400,
                    Message = $"No se encuentran examenes registrados"
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
    }
}
