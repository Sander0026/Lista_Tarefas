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

    }
}
