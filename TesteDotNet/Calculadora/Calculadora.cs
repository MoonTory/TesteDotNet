using System;
using System.Linq;
using System.Threading;

using TesteDotNet.Calculadora.Exceções;
using TesteDotNet.Calculadora.Utils;

namespace TesteDotNet.Calculadora
{
    public class Calculadora
    {
        public bool isRunning;
        private int m_Resultado;
        public Calculadora()
        {
            isRunning = true;
            Init();
        }

        public void Init()
        {
            Console.WriteLine("Sejam bem vindos!!!");
            do
            {
                try
                {
                    Console.WriteLine("Digite o numero da opcao da operacao que deseja realizar:\n");
                    Console.WriteLine("(1) - Soma");
                    Console.WriteLine("(2) - Subtracao");
                    Console.WriteLine("(3) - Multiplacao");
                    Console.WriteLine("(4) - Divisao");
                    Console.WriteLine("(5) - Media");
                    Console.WriteLine("(6) - Soma Numeros Pares\n");

                    Console.Write("Op: ");
                    ConsoleKeyInfo input = Console.ReadKey();

                    Console.WriteLine("\n\nDigite os valores que deseja calcular, separando-os por \";\". EX: \"2;5\" ");

                    int[] parametros = Array.ConvertAll(StringHelpers.FormatarEntrada(Console.ReadLine()), int.Parse);

                    switch (input.KeyChar)
                    {
                        case '1':
                            m_Resultado = Soma(parametros);
                            Console.WriteLine($"\nResultado Soma: {m_Resultado}");
                            break;
                        case '2':
                            m_Resultado = Subtrair(parametros[0], parametros[1]);
                            Console.WriteLine($"\nResultado Subtracao: {m_Resultado}");
                            break;
                        case '3':
                            m_Resultado = Multiplcar(parametros[0], parametros[1]);
                            Console.WriteLine($"\nResultado Multiplcacao: {m_Resultado}");
                            break;
                        case '4':
                            m_Resultado = Dividir(parametros[0], parametros[1]);
                            Console.WriteLine($"\nResultado Divisao: {m_Resultado}");
                            break;
                        case '5':
                            m_Resultado = Media(parametros);
                            Console.WriteLine($"\nResultado: {m_Resultado}");
                            break;
                        case '6':
                            m_Resultado = SomaPares(parametros);
                            Console.WriteLine($"\nResultado: {m_Resultado}");
                            break;
                        default:
                            throw new OperacaoInvalidoException();
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair...");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nExcecao: {ex.Message}\n");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair...");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Exit();
        }

        public int Soma(int a, int b)
        {
            return a + b;
        }

        public int SomaPares(params int[] numbers)
        {
            int resultado = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    resultado += numbers[i];
            }

            return resultado;
        }

        public int Soma(params int[] numbers)
        {
            return numbers.Sum();
        }

        public int Subtrair(int a, int b)
        {
            return a - b;
        }

        public int Media(params int[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }

        public int Multiplcar(int a, int b)
        {
            return a * b;
        }

        public int Dividir(int a, int b)
        {
            if (b == 0)
                throw new DividirPorZeroException(a, b);

            return a / b;
        }

        private void Exit()
        {
            Console.WriteLine("\n\n\n_Obrigado por utilizar nossa calculadora!!!");
            Thread.Sleep(2000);
        }
    }
}
