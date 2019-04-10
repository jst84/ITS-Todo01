using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DAL;
namespace TodoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL d = new DAL(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            var todos = d.GetTodos();

            foreach (var todo in todos)
            {
                Console.WriteLine(todo.Task);
                Console.WriteLine(todo.DueDate);
                Console.WriteLine(todo.ToJson());
            }

            Console.WriteLine(todos.ToJson());
            Console.ReadLine();
        }


    }
}
