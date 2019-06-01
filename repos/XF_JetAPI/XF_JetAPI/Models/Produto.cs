using System;
using System.Collections.Generic;
using System.Text;

namespace XF_JetAPI.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Status { get; set; }
    }
}
