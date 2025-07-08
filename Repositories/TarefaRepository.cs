using Lista_Tarefas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_Tarefas.Repositories
{
    public class TarefaRepository
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=DB_ListaTarefas;Trusted_Connection=True;TrustServerCertificate=True;";
                
        public List<Tarefa> ObterTodas()
        {
            var listaDeTarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(_connectionString)) 
            {
                conexao.Open();
                using (var comando = new SqlCommand("SELECT id, titulo, concluido, data_tarefa FROM tarefas", conexao))
                {
                    using (var leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            var tarefa = new Tarefa
                            {
                                Id = Convert.ToInt32(leitor["id"]),
                                Titulo = leitor["titulo"].ToString(),
                                Concluido = Convert.ToBoolean(leitor["concluido"]),
                                HoraData = Convert.ToDateTime(leitor["data_tarefa"])
                            };
                            listaDeTarefas.Add(tarefa);
                        }
                    }
                }
            }
            return listaDeTarefas;
        }

        public void CriarTarefa(Tarefa novaTarefa)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                string sql = "INSERT INTO Tarefas(titulo, concluido, data_tarefa) VALUES(@Titulo, @Concluido, @HoraTarefa)";
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Titulo", novaTarefa.Titulo);
                    comando.Parameters.AddWithValue("@Concluido", false);
                    comando.Parameters.AddWithValue("@HoraTarefa", novaTarefa.HoraData);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public bool EditarTarefa(Tarefa tarefaParaAtualizar)
        {
            if (tarefaParaAtualizar != null)
            {
                using (var conexao = new SqlConnection(_connectionString))
                {
                    conexao.Open();

                    string sql = "UPDATE tarefas SET titulo = @Titulo, concluido = @Concluido WHERE id = @Id";
                    using (var comando = new SqlCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue("@Titulo", tarefaParaAtualizar.Titulo);
                        comando.Parameters.AddWithValue("@Concluido", tarefaParaAtualizar.Concluido);
                        comando.Parameters.AddWithValue("@Id", tarefaParaAtualizar.Id);

                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void DeletarTarefa(Tarefa tarefaParaDeletar)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                string sql = "DELETE FROM tarefas " +
                             "WHERE id = @Id";
                using (var comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", tarefaParaDeletar.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public Tarefa BuscarPorTitulo(string titulo)
        {
            var tarefa = new Tarefa();
            var listaTarefas = ObterTodas();

            foreach(var item in listaTarefas)
            {
                if(item.Titulo.ToLower().Equals(titulo))
                {
                    tarefa = item;
                }
            }
            return tarefa;
        }
    }
}
