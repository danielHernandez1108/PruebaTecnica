using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<int> CreateOrders(Orders orders);
        public Task<IEnumerable<Orders>> ConsultOrder();

    }
}
