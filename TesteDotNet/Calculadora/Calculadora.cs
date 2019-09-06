using System;
using System.Threading;
using TesteDotNet.Calculadora.Exceções;

namespace TesteDotNet.Calculadora
{
    public class Calculadora
    {
        public bool isRunning;
        public Calculadora()
        {
            isRunning = true;
        }

        public void Init()
        {
            Console.WriteLine("Sejam bem vindos!!!");
            while (isRunning)
            {

            }
            Exit();
        }

        public double Soma(double a, double b)
        {
            return a + b;
        }

        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        public double Multiplcar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DividirPorZeroException(a, b);

            return a / b;
        }

        private void Exit()
        {

            Thread.Sleep(2000);
        }
    }
}
