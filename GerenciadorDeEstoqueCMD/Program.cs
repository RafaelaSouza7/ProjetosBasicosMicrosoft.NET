using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoqueCMD
{
    internal class Program
    {
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }

        static List<IEstoque> produtos = new List<IEstoque>();

        static void Main(string[] args)
        {
            CarregarInformacoesNoArquivo();

            Menu opcaoSelecionada;

            do 
            { 
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("      Sistema Gerenciador de Estoque");
                Console.WriteLine("--------------------------------------------\n");
                Console.WriteLine("1 - Listar produtos\n2 - Adicionar produto\n3 - Remover produto\n4 - Registrar entrada de produto\n5 - Registrar saída de produto\n6 - Sair\n");
                Console.Write("Selecione uma opção: ");

                opcaoSelecionada = (Menu)int.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case Menu.Listar:
                        Listar();
                        break;

                    case Menu.Adicionar:
                        Cadastar();
                        break;

                    case Menu.Remover:
                        RemoverProduto();
                        break;

                    case Menu.Entrada:
                        RegistrarEntrada();
                        break;

                    case Menu.Saida:
                        RegistrarSaida();
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            
            } while(opcaoSelecionada != Menu.Sair);
            Console.Clear();

        }

        static void Listar()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Produtos cadastrados");
            Console.WriteLine("-----------------------------------\n");

            int id = 0;

            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine($"ID do produto: {id}");
                produto.Exibir();
                Console.WriteLine("-----------------------------------");
                id++;
            }

            Console.WriteLine("\nAperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        static void ListarParaExcluir()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Produtos cadastrados");
            Console.WriteLine("-----------------------------------\n");

            int id = 0;

            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine($"ID do produto: {id}");
                produto.Exibir();
                Console.WriteLine("-----------------------------------");
                id++;
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Exclusão de produto");
            Console.WriteLine("-----------------------------------");
        }

        static void ListarParaRegistrar()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Produtos cadastrados");
            Console.WriteLine("-----------------------------------\n");

            int id = 0;

            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine($"ID do produto: {id}");
                produto.Exibir();
                Console.WriteLine("-----------------------------------");
                id++;
            }
        }

        static void Cadastar()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("       Cadastro de produto");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Produto físico\n2 - Ebook\n3 - Curso\n");
            Console.Write("Selecione uma opção: ");

            int opcaoSelecionada = int.Parse(Console.ReadLine());

            switch (opcaoSelecionada)
            {
                case 1:
                    CadastrarProdutoFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarProdutoFisico()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("   Cadastro de Produto Físico");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite o nome do produto: ");
            string nomeProduto = Console.ReadLine();
            Console.Write("Digite o preço do produto: R$");
            float precoProduto = float.Parse(Console.ReadLine());
            Console.Write("Digite o valor de frete do produto: R$");
            float freteProduto = float.Parse(Console.ReadLine());

            ProdutoFisico produtoFisico = new ProdutoFisico(nomeProduto, precoProduto, freteProduto);
            produtos.Add(produtoFisico);
            SalvarInformacoesNoArquivo();

            Console.WriteLine($"\nProduto físico \"{nomeProduto}\" cadastrado com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarEbook()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("        Cadastro de Ebook");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite o nome do Ebook: ");
            string nomeEbook = Console.ReadLine();
            Console.Write("Digite o preço do Ebook: R$");
            float precoEbook = float.Parse(Console.ReadLine());
            Console.Write("Digite o autor do Ebook: ");
            string autorEbook = Console.ReadLine();

            Ebook ebook = new Ebook(nomeEbook, precoEbook, autorEbook);
            produtos.Add(ebook);
            SalvarInformacoesNoArquivo();

            Console.WriteLine($"\nEbook \"{nomeEbook}\" cadastrado com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarCurso()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("        Cadastro de Curso");
            Console.WriteLine("---------------------------------");

            Console.Write("Digite o nome do curso: ");
            string nomeCurso = Console.ReadLine();
            Console.Write("Digite o preço do curso: R$");
            float precoCurso = float.Parse(Console.ReadLine());
            Console.Write("Digite o autor do curso: ");
            string autorCurao = Console.ReadLine();

            Curso curso = new Curso(nomeCurso, precoCurso, autorCurao);
            produtos.Add(curso);
            SalvarInformacoesNoArquivo();

            Console.WriteLine($"\nCurso \"{nomeCurso}\" cadastrado com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        static void RemoverProduto()
        {
            ListarParaExcluir();

            Console.Write("\nDigite o ID do produto que deseja excluir: ");
            int idEscolhido = int.Parse(Console.ReadLine());

            if (idEscolhido >= 0 && idEscolhido < produtos.Count)
            {
                produtos.RemoveAt(idEscolhido);
                SalvarInformacoesNoArquivo();
                Console.WriteLine($"\nProduto excluído com sucesso!\n");
                Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nID inexistente! Digite um ID válido.");
                Console.WriteLine("\nAperte ENTER para voltar ao menu inicial.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void RegistrarEntrada()
        {
            ListarParaRegistrar();

            Console.Write("\nDigite o ID do produto que deseja registrar entrada: ");
            int idEscolhido = int.Parse(Console.ReadLine());

            if (idEscolhido >= 0 && idEscolhido < produtos.Count)
            {
                produtos[idEscolhido].AdicionarEntrada();
                SalvarInformacoesNoArquivo();

            }
            else
            {
                Console.WriteLine("\nID inexistente! Digite um ID válido.");
                Console.WriteLine("\nAperte ENTER para voltar ao menu inicial.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void RegistrarSaida()
        {
            ListarParaRegistrar();

            Console.Write("\nDigite o ID do produto que deseja registrar saída: ");
            int idEscolhido = int.Parse(Console.ReadLine());

            if (idEscolhido >= 0 && idEscolhido < produtos.Count)
            {
                produtos[idEscolhido].AdicionarSaida();
                SalvarInformacoesNoArquivo();

            }
            else
            {
                Console.WriteLine("\nID inexistente! Digite um ID válido.");
                Console.WriteLine("\nAperte ENTER para voltar ao menu inicial.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void SalvarInformacoesNoArquivo()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }

        static void CarregarInformacoesNoArquivo()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception ex)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}
