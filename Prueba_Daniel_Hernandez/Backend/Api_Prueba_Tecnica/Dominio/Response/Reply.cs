using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Response
{
    public class Reply
    {
        public int Status {  get; set; }
        public string Message { get; set; }
        public bool Ok {  get; set; }
        public object Data { get; set; }
    }
}
