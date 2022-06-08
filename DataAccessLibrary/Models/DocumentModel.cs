using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StatusCode { get; set; }
        public int Freeze { get; set; }

    }
}
