using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoqueCMD
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(          $"Registrar entrada - Curso {nome}");
            Console.WriteLine("---------------------------------------------------------\n");
            Console.Write($"Digite a quantidade de vagas que deseja registrar: ");
            int qtdeEntrada = int.Parse(Console.ReadLine());

            vagas += qtdeEntrada;

            Console.WriteLine($"\nEntrada do curso \"{nome}\" registrada com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(           $"Registrar saída - Curso {nome}");
            Console.WriteLine("---------------------------------------------------------\n");
            Console.Write($"Digite a quantidade de vagas que deseja registrar: ");
            int qtdeEntrada = int.Parse(Console.ReadLine());

            vagas -= qtdeEntrada;

            Console.WriteLine($"\nSaída do curso \"{nome}\" registrada com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: R${preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("--------------------------------------");
                
        }
    }
}
