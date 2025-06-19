using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class Orders
    {
        public string NamePatient { get; set; }
        public string AppointmentDate { get; set; }
        public List<Exams> Exams { get; set; }

    }

    public class Exams
    { 
        public string NameExam { get; set; }
        public string CodExam { get; set; }
    }
}
