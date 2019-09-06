using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

using TesteDotNet.Calculadora.Exceções;
using TesteDotNet.Calculadora.Utils;

namespace TesteDotNet.Calculadora
{
    public class Calculadora
    {
        public bool isRunning;
        private double m_Resultado;
        private double[] m_Parametros;
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
                    Console.WriteLine("Digite o numero da opção da operação que deseja realizar:\n");
                    Console.WriteLine("(1) - Soma");
                    Console.WriteLine("(2) - Subtraço");
                    Console.WriteLine("(3) - Multiplicação");
                    Console.WriteLine("(4) - Divisão");
                    Console.WriteLine("(5) - Média");
                    Console.WriteLine("(6) - Soma numeros pares");
                    Console.WriteLine("(7) - Calcular valores armazendado em arquivo\n");

                    Console.Write("Opção: ");
                    ConsoleKeyInfo input = Console.ReadKey();

                    if (input.KeyChar !=  '7')
                    {
                        Console.WriteLine("\n\nDigite os valores que deseja calcular, separando-os por \";\". EX: \"2;5\" ");
                        m_Parametros = Array.ConvertAll(StringHelpers.FormatarEntrada(Console.ReadLine()), double.Parse);
                    }

                    switch (input.KeyChar)
                    {
                        case '1':
                            m_Resultado = Soma(m_Parametros);
                            Console.WriteLine($"\nResultado Soma: {m_Resultado}");
                            break;
                        case '2':
                            m_Resultado = Subtrair(m_Parametros[0], m_Parametros[1]);
                            Console.WriteLine($"\nResultado Subtração: {m_Resultado}");
                            break;
                        case '3':
                            m_Resultado = Multiplicar(m_Parametros[0], m_Parametros[1]);
                            Console.WriteLine($"\nResultado Multiplcação: {m_Resultado}");
                            break;
                        case '4':
                            m_Resultado = Dividir(m_Parametros[0], m_Parametros[1]);
                            Console.WriteLine($"\nResultado Divisão: {m_Resultado}");
                            break;
                        case '5':
                            m_Resultado = Media(m_Parametros);
                            Console.WriteLine($"\nResultado Média: {m_Resultado}");
                            break;
                        case '6':
                            m_Resultado = SomaPares(m_Parametros);
                            Console.WriteLine($"\nResultado Soma dos Pares: {m_Resultado}");
                            break;
                        case '7':
                            CalcularValoresArmazenado();
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

        public double Soma(double a, double b)
        {
            return a + b;
        }

        public double SomaPares(params double[] numbers)
        {
            double resultado = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                    resultado += numbers[i];
            }

            return resultado;
        }

        public double Soma(params double[] numbers)
        {
            return numbers.Sum();
        }

        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        public double Media(params double[] numbers)
        {
            return numbers.Sum() / numbers.Length;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DividirPorZeroException(a, b);

            return a / b;
        }

        public void CalcularValoresArmazenado()
        {
            var dictionario = new Dictionary<string, double>();
            using (StreamReader reader = new StreamReader("dados.txt"))
            {
                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                   if (!String.IsNullOrEmpty(line))
                    {
                        string[] values = StringHelpers.FormatarEntrada(line);

                        List<string> temp = new List<string>();

                        for (int i = 2; i < values.Length; i++)
                        {
                            var index = i - 2;
                            temp.Add(values[i]);
                        }

                        double[] parametros = Array.ConvertAll(temp.ToArray(), double.Parse);

                        switch (values[1].ToLower())
                        {
                            case "soma":
                                m_Resultado = Soma(parametros);
                                dictionario.Add(values[0], m_Resultado);
                                break;
                            case "subtração":
                                m_Resultado = Subtrair(parametros[0], parametros[1]);
                                dictionario.Add(values[0], m_Resultado);
                                break;
                            case "multiplicação":
                                m_Resultado = Multiplicar(parametros[0], parametros[1]);
                                dictionario.Add(values[0], m_Resultado);
                                break;
                            case "divisão":
                                m_Resultado = Dividir(parametros[0], parametros[1]);
                                dictionario.Add(values[0], m_Resultado);
                                break;
                            default:
                                break;
                        }

                    }
                }

                Console.WriteLine("\nResultados armazenado no dictionario\n");

                foreach (var par in dictionario)
                {
                    Console.WriteLine($"Nome={par.Key} -> Resultado={par.Value}");
                }
            }
        }
    

        private void Exit()
        {
            Console.WriteLine("\n\n\n_Obrigado por utilizar nossa calculadora!!!");
            Thread.Sleep(2000);
        }
    }
}
