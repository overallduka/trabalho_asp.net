using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Repository
{
    public class Curso
    {
        public int id { get; set; }
        public string CargaHoraria { get; set; }
        public string ConteudoProg { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }

        public List<Turma> Turmas {get; set; }

    }
}
