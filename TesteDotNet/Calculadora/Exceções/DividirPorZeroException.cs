using System;

namespace TesteDotNet.Calculadora.Exceções
{
    public class DividirPorZeroException : Exception
    {
        public DividirPorZeroException(double a, double b) : base($"Operação: Divisão - Valor A: {a}, Valor B: {b} - Divisão por zero é proibido!") { }
    }
}
