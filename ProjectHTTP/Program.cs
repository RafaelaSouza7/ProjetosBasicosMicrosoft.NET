using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectHTTP
{
    internal class Program
    {
        enum Menu { FetchAll = 1, FetchOne, Exit }
        static void Main(string[] args)
        {
            Menu opcaoSelecionada;

            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("      Buscar informações via HTTP");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("1 - Buscar todas as tarefas\n2 - Buscar uma tarefa específica\n3 - Sair\n");
                Console.Write("Selecione uma opção: ");

                opcaoSelecionada = (Menu)int.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case Menu.FetchAll:
                        RequestAll();
                        break;

                    case Menu.FetchOne:
                        RequestOne();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


            } while (opcaoSelecionada != Menu.Exit);
            Console.Clear();
        }
        static void RequestAll()
        {
            var request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            request.Method = "GET";
            var response = request.GetResponse();

            using (response)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                object data = reader.ReadToEnd();

                //Console.WriteLine(data.ToString());

                List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(data.ToString()); //Transformando os dados recebidos em JSON em objeto C#

                foreach (Task task in tasks)
                {
                    task.Show();
                }

                stream.Close();
                response.Close();

                Console.WriteLine("\nAperte ENTER para voltar ao menu inicial");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void RequestOne()
        {
            Console.Write("Digite o ID da tarefa que deseja buscar: ");
            int idChosen = int.Parse(Console.ReadLine());

            var request = WebRequest.Create($"https://jsonplaceholder.typicode.com/todos/{idChosen}");
            request.Method = "GET";
            var response = request.GetResponse();

            using (response)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                object data = reader.ReadToEnd();

                //Console.WriteLine(data.ToString());

                Task task = JsonConvert.DeserializeObject<Task>(data.ToString()); //Transformando os dados recebidos em JSON em objeto C#
                
                task.Show();

                stream.Close();
                response.Close();

                Console.WriteLine("\nAperte ENTER para voltar ao menu inicial");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

