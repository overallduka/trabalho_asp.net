using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AProf.Repository;
using MySQLConnection;

namespace AProf.Repository
{
    public class ProfessorRepository
    {

        public static List<Professor> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            List<Professor> Professores = new List<Professor>();

            sql.Append("SELECT * FROM Professores");

            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = MyConnection.Get(cmd);

            while (dr.Read())
            {
                Professores.Add(
                    new Professor
                    {
                        id = (int)dr["id"],
                        Nome = (string)dr["nome"],
                        Telefone = (string)dr["telefone"],
                        ValorHoraAula = (float)dr["valor_hora_aula"]

                    }
                );
            }
            dr.Close();
            return Professores;


        }

        public static Professor Get(int id)
        {

            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            Professor Professor = new Professor();

            sql.Append("SELECT * FROM Professores WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = MyConnection.Get(cmd);
            dr.Read();

            Professor = new Professor
            {
                id = (int)dr["id"],
                Nome = (string)dr["nome"],
                Telefone = (string)dr["telefone"],
                ValorHoraAula = (float)dr["valor_hora_aula"]
            };

            return Professor;
        }

        public static void Create(Professor pProfessor)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("INSERT INTO Professores (nome,telefone,valor_hora_aula )");
            sql.Append("VALUES (@nome,@telefone,@valor_hora_aula)");

            cmd.Parameters.AddWithValue("@nome", pProfessor.Nome);
            cmd.Parameters.AddWithValue("@telefone", pProfessor.Telefone);
            cmd.Parameters.AddWithValue("@valor_hora_aula", pProfessor.ValorHoraAula);

            cmd.CommandText = sql.ToString();
            MyConnection.Get(cmd);
        }


        public static void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();


            sql.Append("DELETE FROM Professores WHERE id=@id");
            cmm.Parameters.AddWithValue("@id", pId);
            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);



        }

        public static void Update(int pId, Professor pProfessor)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            sql.Append("UPDATE Professores SET nome=@nome, telefone=@telefone, valor_hora_aula=@valor_hora_aula");
            sql.Append("WHERE id=@id");

            cmm.Parameters.AddWithValue("@id", pId);
            cmm.Parameters.AddWithValue("@nome", pProfessor.Nome);
            cmm.Parameters.AddWithValue("@telefone", pProfessor.Telefone);
            cmm.Parameters.AddWithValue("@valor_hora_aula", pProfessor.ValorHoraAula);

            cmm.CommandText = sql.ToString();
            MyConnection.Get(cmm);

        }
    }
}
