using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoqueCMD
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Produto digital. Não é possível registrar uma entrada.\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(            $"Registrar saída - Ebook {nome}");
            Console.WriteLine("---------------------------------------------------------\n");
            Console.Write($"Digite a quantidade de vendas que deseja registrar: ");
            int qtdeEntrada = int.Parse(Console.ReadLine());

            vendas += qtdeEntrada;

            Console.WriteLine($"\nSaída do Ebook \"{nome}\" registrada com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: R${preco}");
            Console.WriteLine($"Vendas: {vendas}");
        }
    }
}
