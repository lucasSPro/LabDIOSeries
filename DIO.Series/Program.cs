using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Hello World!");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("----------");
            Console.WriteLine("DIO Series a seu dispor");
            Console.WriteLine("Informe a apcao desejada:");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("----------");

            string opcaoUsuario =  Console.ReadLine().ToUpper();
            Console.WriteLine("----------");

            return opcaoUsuario;
        }
    }
}
