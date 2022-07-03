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
           
        }

        public void AdicionarSaida()
        {
            
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
