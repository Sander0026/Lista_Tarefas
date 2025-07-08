using Lista_Tarefas.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_Tarefas.Models
{
    public class Menus
    {
        
        private readonly TarefaRepository _tarefaRepository = new TarefaRepository();
        
        public void DisplayMenu()
        {
            

            string opcao = " ";
            while (opcao != "0")
            {
                Console.WriteLine("********Menu************");
                Console.WriteLine("*****LIsta de Tarefas****");
                Console.WriteLine("Escolha uma opção\n" +
                                  "0 - Sair\n" +
                                  "1 - Criar uma tarefa\n" +
                                  "2 - Visualizar Tarefas\n" +
                                  "3 - Altera Tarefa\n" +
                                  "4 - Deletar Tarefa\n" +
                                  "5 - Marca tarefa como concluida");

                opcao = Console.ReadLine();

                Console.WriteLine("");
                switch(opcao)
                {
                    case "0":
                        Console.WriteLine("Saindo...");
                        break;

                    case "1":
                        
                       
                            Console.WriteLine("Informe a tarefa: ");
                            String titulo = Console.ReadLine();
                        
                            if(!string.IsNullOrEmpty(titulo))
                            {
                                var tarefa = new Tarefa();
                                tarefa.Titulo = titulo;
                                tarefa.HoraData = DateTime.Now;
                                _tarefaRepository.CriarTarefa(tarefa);
                                Console.WriteLine("Tarefa criada com sucesso.");
                                Console.WriteLine("");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A tarefa nao pode ficar em branco!");
                            }
                           

                        break;

                    case "2":

                        var listaTarefas = _tarefaRepository.ObterTodas();

                        if (listaTarefas.Count > 0)
                        {
                            var texto = new StringBuilder();

                            texto.AppendLine("---------------------Lista de Tarefas--------------------------");

                            foreach (var itemTarefa in listaTarefas)
                            {
                                texto.AppendLine("---------------------------------------------------------------");
                                texto.AppendLine($"\nID: {itemTarefa.Id}");
                                texto.AppendLine($"Titulo: {itemTarefa.Titulo}");
                                texto.AppendLine($"Concluida: {(itemTarefa.Concluido ? "Sim" : "Não")}");
                                texto.AppendLine($"Data: {itemTarefa.HoraData: dd/MM/yyyy hh:mm}");
                                texto.AppendLine($"---------------------------------------------------------------");
                            }
                            Console.WriteLine(texto);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A lista de tarefas esta vazia");
                        }
                        break;

                    case "3":
                        
                        Console.WriteLine("Qual tarefa que sera editada?");
                        string resposta = Console.ReadLine();

                        Tarefa tarefaEcontrada = _tarefaRepository.BuscarPorTitulo(resposta);

                        
                        if(tarefaEcontrada != null )
                        {
                            Console.WriteLine("Tarefa localizada.");
                            Console.WriteLine("Informe o novo nome da tarefa: ");
                            string novoTitulo = Console.ReadLine();

                            Tarefa novaTarefa = tarefaEcontrada;
                            if(novoTitulo != null )
                            {
                                novaTarefa.Titulo = novoTitulo;
                                if(_tarefaRepository.EditarTarefa(novaTarefa))
                                {
                                    Console.WriteLine("Tarefa atualizada com sucesso");
                                }
                                else
                                {
                                    Console.WriteLine("Erro ao atualizar tarefa.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("O novo titulo não pode ser em branco!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Não foi possivel localizar essa tarefa.");
                        }

                        break;

                    case "4":

                        Console.WriteLine("Qual tarefa ira deletar?");
                        string tituloTarefa = Console.ReadLine();

                        if (tituloTarefa != null)
                        {
                            var tarefa = _tarefaRepository.BuscarPorTitulo(tituloTarefa);
                            _tarefaRepository.DeletarTarefa(tarefa);
                            Console.WriteLine("Tarefa deletado com sucesso");
                        }

                        break;

                    case "5":

                        listaTarefas = _tarefaRepository.ObterTodas();

                        Console.WriteLine("Qual Tarefa foi concluida?");
                        string tarefaConcluida = Console.ReadLine();

                        Tarefa tarefaLocalizadaConcluida = _tarefaRepository.BuscarPorTitulo(tarefaConcluida);

                        int indexTarefaConcluida = listaTarefas.IndexOf(tarefaLocalizadaConcluida);

                        if (tarefaLocalizadaConcluida != null)
                        {
                            Tarefa novaTarefa = tarefaLocalizadaConcluida;

                            Console.WriteLine("1 - Concluida");
                            Console.WriteLine("2 - Não concluida");
                            string op = Console.ReadLine();

                            switch(op)
                            {
                                case "1":
                                    novaTarefa.Concluido = true;
                                    break;

                                case "2":
                                    novaTarefa.Concluido = false;
                                    break;
                            }

                            _tarefaRepository.EditarTarefa(novaTarefa);
                        }

                        break;

                    default:
                        Console.WriteLine("Opção invalida!");

                        break;
                }
            }
        }
    }
}
