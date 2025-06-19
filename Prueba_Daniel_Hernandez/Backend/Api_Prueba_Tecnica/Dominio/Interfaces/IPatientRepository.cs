using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetPatiens();
        public Task<Patient> ConsultPatientId(int idPatient);
        public Task<bool> UpdatePatientId(Patient patient);
        public Task<bool> DeletePatient(int idPatient);
        public Task<string> CreatePatient(Patient patient);
    }
}
