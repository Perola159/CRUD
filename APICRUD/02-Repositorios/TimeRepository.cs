using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class TimeRepository
    {
        private readonly string ConnectionString ; //mudar connection string buscar do appsettings 

        public TimeRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConection"); //default mesmo nome que chama a connetion da appsettings 
        }
        public void Adicionar(Time time)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string comandInsert = @"INSERT INTO Times(Nome,AnoCriacao) 
                                    VALUES (@Nome,@AnoCriacao)";

                using (var command = new SQLiteCommand(comandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", time.Nome);
                    command.Parameters.AddWithValue("@AnoCriacao", time.AnoCriacao);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Times WHERE Id = @Id";
                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Editar(int id, string nome, int anoCriacao)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updateCommand = @"UPDATE Times
                                  SET Nome = @Nome, AnoCriacao = @AnoCriacao
                                  WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@AnoCriacao", anoCriacao);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Time> Listar()
        {
            List<Time> lista = new List<Time>();           
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectCommand = "SELECT Id, Nome, AnoCriacao FROM Times;";
                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Time t = new Time();
                            t.Id = int.Parse(reader["Id"].ToString());
                            t.Nome = reader["Nome"].ToString();
                            t.AnoCriacao = int.Parse(reader["AnoCriacao"].ToString());
                            lista.Add(t);
                        }
                    }
                }
            }
            return lista;
        }
        public Time BuscarPorId(int id)
        {
            throw new Exception();
        }
    }
}
