using MySql.Data.MySqlClient;
using MySQLConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Repository
{
   public  class CursoRepository
    {
        public static List<Curso> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Curso> Cursos = new List<Curso>();

            sql.Append("SELECT * FROM Cursos");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = MyConnection.Get(cmd);

            while (dr.Read())
            {
                Cursos.Add(
                    new Curso
                    {
                        id = (int)dr["id"],
                        CargaHoraria = (string)dr["carga_horaria"],
                        ConteudoProg = (string)dr["conteudo"],
                        Nome = (string)dr["nome"]

                    }
                );
            }
            dr.Close();
            return Cursos;


        }

        public static Curso Get(int id)
        {

            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            Curso Curso = new Curso();

            sql.Append("SELECT * FROM Cursos WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = MyConnection.Get(cmd);
            dr.Read();

            Curso = new Curso
            {
                id = (int)dr["id"],
                CargaHoraria = (string)dr["carga_horaria"],
                ConteudoProg = (string)dr["conteudo"],
                Nome = (string)dr["nome"]
            };

            return Curso;
        }

        public static void Create(Curso pCurso)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Cursos (carga_horaria,conteudo,nome )");
            sql.Append("VALUES (@carga_horaria,@conteudo,@nome)");

            cmd.Parameters.AddWithValue("@carga_horaria", pCurso.CargaHoraria);
            cmd.Parameters.AddWithValue("@conteudo", pCurso.ConteudoProg);
            cmd.Parameters.AddWithValue("@nome", pCurso.Nome);

            cmd.CommandText = sql.ToString();
            MyConnection.Get(cmd);
        }


        public static void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM Cursos WHERE id=@id");
            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);



        }

        public static void Update(int pId, Curso pCurso)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("UPDATE Cursos SET carga_horaria=@carga_horaria, conteudo=@conteudo, nome=@nome");
            sql.Append("WHERE id=@id");

            cmm.Parameters.AddWithValue("@carga_horaria", pCurso.CargaHoraria);
            cmm.Parameters.AddWithValue("@conteudo", pCurso.ConteudoProg);
            cmm.Parameters.AddWithValue("@nome", pCurso.Nome);

            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);

        }
    }
}
