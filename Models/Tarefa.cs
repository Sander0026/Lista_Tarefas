using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lista_Tarefas.Models;

namespace Lista_Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set;}
        public string Titulo { get; set;}
        public bool Concluido { get; set;}

        public DateTime HoraData { get; set;}

        /*public static int GeraId()
        {
            int maior = 0;

            if (Menus.listaTarefas.Count < 0)
            {
                return 1;
            }
            else
            {
                foreach(var item in Menus.listaTarefas)
                {
                    if(item.Id >= maior)
                    {
                        maior= item.Id;
                    }
                }
            }
            return maior+1;
        }

        public static Tarefa BuscarTarefa(string resposta)
        {
            Tarefa tarefa = new Tarefa();

            foreach (var item in Menus.listaTarefas)
            {
                if (item.Titulo.ToLower().Equals(resposta))
                {
                    tarefa = item;
                    return tarefa;
                }
            }
            return null;           
        }

        public static bool CriarTarefa(string titulo)
        {
            Tarefa tarefa = new Tarefa();

            if (titulo != null)
            {
                tarefa.Id = GeraId();
                tarefa.Titulo = titulo;
                tarefa.HoraData = DateTime.Now;
                Menus.listaTarefas.Add(tarefa);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ExibirListaTarefas(List<Tarefa> listaTarefa)
        {
            var texto = new StringBuilder();

            texto.AppendLine("---------------------Lista de Tarefas--------------------------");

            foreach (var itemTarefa in listaTarefa)
            {
                texto.AppendLine("---------------------------------------------------------------");
                texto.AppendLine($"\nID: {itemTarefa.Id}");
                texto.AppendLine($"Titulo: {itemTarefa.Titulo}");
                texto.AppendLine($"Concluida: {(itemTarefa.Concluida ? "Sim" : "Não")}");
                texto.AppendLine($"Data: {itemTarefa.HoraData: dd/mm/yyyy hh:mm}");
                texto.AppendLine($"---------------------------------------------------------------");
            }
            return texto.ToString();
        }

        public static bool EditarTarefa(int indexTarefa, Tarefa tarefaNova)
        {
            if (indexTarefa >= 0 && tarefaNova != null)
            {
                Menus.listaTarefas[indexTarefa] = tarefaNova;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DeletarTarefa(Tarefa tarefa)
        {
            Menus.listaTarefas.Remove(tarefa);
        }
        */
       
    }
}
