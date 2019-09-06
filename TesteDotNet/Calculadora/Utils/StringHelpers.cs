using System.Linq;

namespace TesteDotNet.Calculadora.Utils
{
    public static class StringHelpers
    {
        public static string[] FormatarEntrada(string input)
        {
            return input.Split(';').Select(sValue => sValue.Trim()).ToArray();
        }
    }
}
