using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeClientesCMD
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> listClientes = new List<Cliente>();
        public enum Menu { Listagem = 1, Adicionar, Excluir, Sair }

        public static Menu opcaoMenu;

        static void Main(string[] args)
        {
            CarregarInformacoesDoArquivo();

            do
            {
                Console.WriteLine("Seja bem-vindo ao Sistema Gerenciador de Clientes\n");
                Console.WriteLine("1 - Listagem de clientes\n2 - Adicionar cliente\n3 - Excluir cliente\n4 - Sair\n");
                Console.Write("Selecione uma opção para começar: ");
                int opcaoSelecionada = int.Parse(Console.ReadLine());

                opcaoMenu = (Menu)opcaoSelecionada;

                switch (opcaoMenu)
                {
                    case Menu.Listagem:
                        ListarClientes();
                        break;

                    case Menu.Adicionar:
                        AdicionarCliente();
                        break;

                    case Menu.Excluir:
                        ExcluirCliente();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Console.Clear();

            } while (opcaoMenu != Menu.Sair);
        }

        static void AdicionarCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("--------------------------");
            Console.WriteLine("   Cadastro de clientes   ");
            Console.WriteLine("--------------------------\n");

            Console.Write("Digite o nome do cliente: ");
            cliente.nome = Console.ReadLine();
            Console.Write("Digite o e-mail do cliente: ");
            cliente.email = Console.ReadLine();
            Console.Write("Digite o CPF do cliente: ");
            cliente.cpf = Console.ReadLine();

            listClientes.Add(cliente);
            SalvarAlteracaoNoArquivo();

            Console.WriteLine("\nCliente cadastrado com sucesso!");
            Console.WriteLine("\nPressione enter para voltar ao menu inicial");
            Console.ReadLine();
        }

        static void ExcluirCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("--------------------------");
            Console.WriteLine("   Exclusão de clientes   ");
            Console.WriteLine("--------------------------\n");

            Console.Write("Digite o CPF do cliente que deseja excluir: ");
            cliente.cpf = Console.ReadLine();

            listClientes.RemoveAll(clientes => clientes.cpf == cliente.cpf);
            SalvarAlteracaoNoArquivo();

            Console.WriteLine("\nCliente excluído com sucesso!");
            Console.WriteLine("\nPressione enter para voltar ao menu inicial");
            Console.ReadLine();
        }

        static void ListarClientes()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("        Listagem de clientes        ");
            Console.WriteLine("------------------------------------\n");

            foreach (Cliente cliente in listClientes) {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Nome do cliente: {cliente.nome}");
                Console.WriteLine($"E-mail do cliente: {cliente.email}");
                Console.WriteLine($"CPF do cliente: {cliente.cpf}");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine("\nPressione enter para voltar ao menu inicial");
            Console.ReadLine();
        }

        static void SalvarAlteracaoNoArquivo()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, listClientes);
            stream.Close();
        }

        static void CarregarInformacoesDoArquivo()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                listClientes = (List<Cliente>)encoder.Deserialize(stream);

                if (listClientes == null)
                {
                    List<Cliente> list = new List<Cliente>();
                }
                stream.Close();
            }
            catch(Exception ex)
            {
                List<Cliente> list = new List<Cliente>();
            }

            stream.Close();
        }


    }
}
