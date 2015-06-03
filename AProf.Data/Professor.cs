using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Repository
{
    public class Professor
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public float ValorHoraAula { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}
