using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IGenericRepository
    {
        public Task<IEnumerable<Exams>> GetExams();
    }
}
