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
            
        }

        public void AdicionarSaida()
        {
            
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
