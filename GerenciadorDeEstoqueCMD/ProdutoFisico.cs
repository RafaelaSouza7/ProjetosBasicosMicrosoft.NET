using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoqueCMD
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(      $"Registrar entrada no estoque - Produto {nome}");
            Console.WriteLine("---------------------------------------------------------\n");
            Console.Write($"Digite a quantidade que deseja registrar: ");
            int qtdeEntrada = int.Parse(Console.ReadLine());

            estoque += qtdeEntrada;

            Console.WriteLine($"\nEntrada do produto \"{nome}\" registrada com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(     $"Registrar saída no estoque - Produto {nome}");
            Console.WriteLine("---------------------------------------------------------\n");
            Console.Write($"Digite a quantidade que deseja registrar: ");
            int qtdeSaida = int.Parse(Console.ReadLine());

            estoque -= qtdeSaida;

            Console.WriteLine($"\nSaída do produto \"{nome}\" registrada com sucesso!\n");
            Console.WriteLine("Aperte ENTER para voltar ao menu inicial.");
            Console.ReadLine();
            Console.Clear();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: R${frete}");
            Console.WriteLine($"Preço: R${preco}");
            Console.WriteLine($"Estoque: {estoque}");
        }
    }
}
