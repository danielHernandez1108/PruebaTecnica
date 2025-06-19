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
    public class OrderService
    {

        private IOrdersRepository _Repository;

        public OrderService(IOrdersRepository _repsotiory)
        {
            this._Repository = _repsotiory;

        }


        public async Task<Reply> CreateOrders(Orders Order)
        {
            try
            {

                if (string.IsNullOrEmpty(Order.NamePatient))
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 500,
                        Data = null,
                        Message = $"El nombre paciente no puede ser null"
                    };
                }
            

                DateTime parsedDate;
                if (!DateTime.TryParse(Order.AppointmentDate, out parsedDate))
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 500,
                        Data = null,
                        Message = $"Fecha de registro Invalida"
                    };
                }
                else if (parsedDate > DateTime.Today)
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 500,
                        Data = null,
                        Message = $"La fecha no puede ser mayor a hoy"
                    };
                }



                var response = await _Repository.CreateOrders(Order);
                if (response != 0)
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 200,
                        Data = null,
                        Message = $"Registro de Orden registrada exitosamente"
                    };
                }

                return new Reply
                {
                    Ok = true,
                    Status = 500,
                    Data = null,
                    Message = $"Ocurrio un error inesperado al registrar la orden"
                };
            }
            catch (Exception ex)
            {
                return new Reply
                {
                    Ok = false,
                    Status = 500,
                    Message = $"Error al registrar las ordenes: {ex.Message}"
                };
            }
        }


        public async Task<Reply> ConsultOrder()
        {
            try
            {
                var response = await _Repository.ConsultOrder();
                if (response.Any())
                {
                    return new Reply
                    {
                        Ok = true,
                        Status = 200,
                        Data = response,
                        Message = $"Registro de Orden registrada exitosamente"
                    };
                }

                return new Reply
                {
                    Ok = true,
                    Status = 400,
                    Data = null,
                    Message = $"Ocurrio un error inesperado al registrar la orden"
                };
            }
            catch (Exception ex)
            {
                return new Reply
                {
                    Ok = false,
                    Status = 500,
                    Message = $"Error al registrar las ordenes: {ex.Message}"
                };
            }
        }
    }
}