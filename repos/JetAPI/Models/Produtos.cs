using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JetAPI.Models
{
    public class Produtos
    {
        public long Id { get; set; }
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Status { get; set; }

    }
}
