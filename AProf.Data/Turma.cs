using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Repository
{
    public class Turma
    {
        public int id { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public int professor_id { get; set; }
        public int curso_id { get; set; }

        public Professor professor { get; set; }
        public Curso curso { get; set; }


    }
}
