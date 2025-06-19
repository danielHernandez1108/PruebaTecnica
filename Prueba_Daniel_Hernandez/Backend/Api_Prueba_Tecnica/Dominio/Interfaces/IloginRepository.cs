using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IloginRepository
    {
        public Task<User> GenerateToken(User user);
  

    }
}
