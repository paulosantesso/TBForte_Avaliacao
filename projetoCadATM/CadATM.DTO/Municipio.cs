using System;
using System.Collections.Generic;
using System.Text;

namespace CadATM.DTO
{
    public class Municipio
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public UF UF { get; set; }

        public string ISS { get; set; }

        public string ICMS { get; set; }

        public string ICMSInterno { get; set; }
    }
}
