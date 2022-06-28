using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacaoDeArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter escritor = new StreamWriter("teste.txt"); //Apaga o conteúdo anterior e adiciona o novo
            //StreamWriter escritor = File.AppendText("teste.txt"); //Mantém o conteúdo anterior e adiciona o novo
            escritor.WriteLine("Rafaela Souza");
            escritor.WriteLine("Curso de C#");
            escritor.Close();

            StreamReader leitor = new StreamReader("teste.txt");
            string conteudo = leitor.ReadToEnd();
            Console.WriteLine(conteudo);
            leitor.Close();

            Console.ReadLine();
        }
    }
}
