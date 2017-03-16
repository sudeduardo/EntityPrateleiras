using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_1.Model
{
    public class Prateleira
    {
        public  int ID { get; set; }

        public String Setor { get; set; }

        public List<Produto> Produtos = new List<Produto>();
    }
}
