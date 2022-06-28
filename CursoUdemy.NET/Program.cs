using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCompletaCMD
{
    internal class Program
    {
        enum Menu { Soma = 1, Subtracao, Multiplicacao, Divisao, Potencia, Raiz, Sair}
        static void Main(string[] args)
        {
            Menu opcaoSelecionada;

            do
            {
                Console.WriteLine("Seja bem-vindo à Calculadora CMD\n");
                Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Multiplicação\n4 - Divisão\n5 - Potência\n6 - Raiz\n7 - Sair\n");
                Console.Write("Selecione uma opção: ");
                opcaoSelecionada = (Menu)int.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case Menu.Soma:
                        Somar();
                        break;

                    case Menu.Subtracao:
                        Subtrair();
                        break;

                    case Menu.Multiplicacao:
                        Multiplicar();
                        break;

                    case Menu.Divisao:
                        Dividir();
                        break;

                    case Menu.Potencia:
                        calcularPotencia();
                        break;

                    case Menu.Raiz:
                        calcularRaiz();
                        break;

                     default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.Clear();
            } while (opcaoSelecionada != Menu.Sair);
        }

        //Métodos
        static void Somar()
        {
            Console.WriteLine("Você deseja fazer o somatório de quantos números? ");
            int qtdeNumeros = int.Parse(Console.ReadLine());

            List<double> numeros = new List<double>(qtdeNumeros);

            for (int i = 0; i < qtdeNumeros; i++)
            {
                Console.WriteLine($"Digite o {i + 1}º número: ");
                double numeroDigitado = double.Parse(Console.ReadLine());
                numeros.Add(numeroDigitado);
            }

            Console.WriteLine($"A soma dos números digitados é igual a { numeros.Sum()}");
            Console.ReadLine();
            
        }

        static void Subtrair()
        {
            Console.WriteLine($"Digite o 1º número: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o 2º número: ");
            double b = double.Parse(Console.ReadLine());

            double resultado = a - b;
            Console.WriteLine($"A subtração dos números digitados é igual a {resultado}");
            Console.ReadLine();
        }

        static void Multiplicar()
        {
            Console.WriteLine($"Digite o 1º número: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o 2º número: ");
            double b = double.Parse(Console.ReadLine());

            double resultado = a * b;
            Console.WriteLine($"A multiplicação dos números digitados é igual a {resultado}");
            Console.ReadLine();
        }
        static void Dividir()
        {
            Console.WriteLine($"Digite o 1º número: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o 2º número: ");
            double b = double.Parse(Console.ReadLine());

            double resultado = a / b;
            Console.WriteLine($"A divisão dos números digitados é igual a {resultado}");
            Console.ReadLine();
        }
        static void calcularPotencia()
        {
            Console.WriteLine($"Digite a base: ");
            int a = int.Parse(Console.ReadLine());

            if ( a != 0)
            {
                Console.WriteLine($"Digite o expoente: ");
                int b = int.Parse(Console.ReadLine());

                double resultado = Math.Pow(a, b);
                Console.WriteLine($"O resultado da potência é igual a {resultado}");
                Console.ReadLine();

            } else {
                Console.WriteLine("Não é possível calcular a potência de uma base igual a 0");
            }
        }
        static void calcularRaiz()
        {
            Console.WriteLine($"Digite o radicando: ");
            int a = int.Parse(Console.ReadLine());

            double resultado = Math.Sqrt(a);
            Console.WriteLine($"A raiz quadrada de {a} é igual a {resultado}");
            Console.ReadLine();
        }
    }

}
