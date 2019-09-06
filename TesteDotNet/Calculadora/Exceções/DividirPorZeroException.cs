using System;

namespace TesteDotNet.Calculadora.Exceções
{
    public class DividirPorZeroException : Exception
    {
        public DividirPorZeroException(double a, double b) : base($"Divisão por zero é proibido!: Valor A: {a}, Valor B: {b}") { }
    }
}
