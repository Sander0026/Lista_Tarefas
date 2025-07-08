using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_Tarefas.Models
{
    internal class Menus
    {
        public static List<Tarefa> listaTarefas = new List<Tarefa>();
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
                        
                        while (true)
                        { 
                            Console.WriteLine("Informe a tarefa: ");
                            String titulo = Console.ReadLine();
                        
                            if(Tarefa.CriarTarefa(titulo))
                            {
                                Console.WriteLine("Tarefa criada com sucesso.");
                                Console.WriteLine("");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A tarefa nao pode ficar em branco!");
                            }
                        }    

                        break;

                    case "2":

                        if(listaTarefas.Count > 0)
                        {
                            string dadosTarefa =Tarefa.ExibirListaTarefas(listaTarefas);
                            Console.WriteLine(dadosTarefa);
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

                        Tarefa tarefaEcontrada = Tarefa.BuscarTarefa(resposta);
                        int indexTarefa = listaTarefas.IndexOf(tarefaEcontrada);

                        if(tarefaEcontrada != null )
                        {
                            Console.WriteLine("Tarefa localizada.");
                            Console.WriteLine("Informe o novo nome da tarefa: ");
                            string novoTitulo = Console.ReadLine();

                            Tarefa novaTarefa = new Tarefa();
                            if(novoTitulo != null )
                            {
                                novaTarefa.Titulo = novoTitulo;
                                if(Tarefa.EditarTarefa(indexTarefa, novaTarefa))
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
                            Tarefa tarefaLocalizada =Tarefa.BuscarTarefa(tituloTarefa);
                            Tarefa.DeletarTarefa(tarefaLocalizada);
                            Console.WriteLine("Tarefa deletado com sucesso");
                        }

                        break;

                    case "5":

                        Console.WriteLine("Qual Tarefa foi concluida?");
                        string tarefaConcluida = Console.ReadLine();

                        Tarefa tarefaLocalizadaConcluida = Tarefa.BuscarTarefa(tarefaConcluida);
                        int indexTarefaConcluida = listaTarefas.IndexOf(tarefaLocalizadaConcluida);

                        if (tarefaLocalizadaConcluida != null)
                        {
                            Tarefa novaTarefa = new Tarefa();

                            Console.WriteLine("1 - Concluida");
                            Console.WriteLine("2 - Não concluida");
                            string op = Console.ReadLine();

                            switch(op)
                            {
                                case "1":
                                    novaTarefa = tarefaLocalizadaConcluida;
                                    novaTarefa.Concluida = true;
                                    break;

                                case "2":
                                    novaTarefa = tarefaLocalizadaConcluida;
                                    novaTarefa.Concluida = false;
                                    break;
                            }

                            Tarefa.EditarTarefa(indexTarefaConcluida, novaTarefa);
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
