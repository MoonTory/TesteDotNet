using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.Calculadora.Exceções
{
    class ParametroInvalidoException : Exception
    {
        public ParametroInvalidoException() : base("Parametro invalido!") { }
    }
}
