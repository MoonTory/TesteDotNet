using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.Calculadora.Exceções
{
    public class OperacaoInvalidoException : Exception
    {
        public OperacaoInvalidoException() : base("Operacao Invalido!") { }
    }
}
