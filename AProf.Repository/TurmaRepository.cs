using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AProf.Repository;
using MySql.Data.MySqlClient;
using MySQLConnection;

namespace AProf.Repository
{
    public class TurmaRepository
    {
        public static List<Turma> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Turma> Turmas  = new List<Turma>();

            sql.Append("SELECT * FROM Turmas");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = MyConnection.Get(cmd);

            while (dr.Read())
            {
                Turmas.Add(
                    new Turma
                    {
                        id = (int)dr["id"],
                        DataInicio = (string)dr["data_inicio"],
                        DataTermino = (string)dr["data_fim"],
                        HoraInicio = (string)dr["hora_inicio"],
                        HoraTermino = (string)dr["hora_fim"],
                        curso_id = (int)dr["cursos_id"],
                        professor_id = (int)dr["professores_id"]
                    }
                );
            }
            dr.Close();

            foreach(Turma turma in Turmas){
                turma.curso = CursoRepository.Get(turma.curso_id);
                turma.professor = ProfessorRepository.Get(turma.professor_id);
            }

            return Turmas;
        }

        public static Turma Get(int id){
            
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            Turma Turma  = new Turma();

            sql.Append("SELECT * FROM Turmas WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sql.ToString();
            
            MySqlDataReader dr = MyConnection.Get(cmd);
            dr.Read();

            Turma = new Turma{
                id = (int)dr["id"],
                DataInicio = (string)dr["data_inicio"],
                DataTermino = (string)dr["data_fim"],
                HoraInicio = (string)dr["hora_inicio"],
                HoraTermino = (string)dr["hora_fim"],
                curso_id = (int)dr["cursos_id"],
                professor_id = (int)dr["professores_id"]
            };
            dr.Close();

            Turma.curso = CursoRepository.Get(Turma.curso_id);
            Turma.professor = ProfessorRepository.Get(Turma.professor_id);

            return Turma;
        }

        public static void Create(Turma pTurma)
        {
            StringBuilder sql = new StringBuilder();      
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Turmas (data_inicio,data_fim,hora_inicio,hora_fim, cursos_id, professores_id)");
            sql.Append("VALUES (@data_inicio,@data_fim,@hora_inicio,@hora_fim, @curso_id, @professor_id)");

            cmd.Parameters.AddWithValue("@data_inicio", pTurma.DataInicio);
            cmd.Parameters.AddWithValue("@data_fim", pTurma.DataTermino);
            cmd.Parameters.AddWithValue("@hora_inicio", pTurma.HoraInicio);
            cmd.Parameters.AddWithValue("@hora_fim", pTurma.HoraTermino);
            cmd.Parameters.AddWithValue("@curso_id", pTurma.curso_id);
            cmd.Parameters.AddWithValue("@professor_id", pTurma.professor_id);


            cmd.CommandText = sql.ToString();
            MyConnection.Get(cmd);         
        }
        

        public static void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM Turmas WHERE id=@id");
            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);
            


        }

        public static void Update(int pId, Turma pTurma)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("UPDATE Turmas SET data_inicio=@data_inicio, data_fim=@data_fim, hora_inicio=@hora_inicio, hora_fim=@hora_fim ");
            sql.Append("WHERE id=@id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.Parameters.AddWithValue("@data_inicio", pTurma.DataInicio);
            cmm.Parameters.AddWithValue("@data_fim", pTurma.DataTermino);
            cmm.Parameters.AddWithValue("@hora_inicio", pTurma.HoraInicio);
            cmm.Parameters.AddWithValue("@hora_fim", pTurma.HoraTermino);

            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);

        }


    }
}
