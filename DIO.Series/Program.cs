﻿using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine("----------");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie =  int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            if(serie != null){
                Console.WriteLine(serie);
            }else{
                Console.WriteLine("Não existe uma serie para esse id");
            }
            
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie =  int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            if (indiceSerie >= 0 && serie != null){
                Console.WriteLine("Realmente deseja excluir a serie {0} ? digite S = sim ou N = não." , serie);
                string resposta = Console.ReadLine().ToUpper();
                if( resposta == "S")
                {
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("A serie {0} foi excluida. " , serie);
                    return;
                }else{
                    return;
                }
            }else{
                Console.WriteLine("Não existe uma serie para esse id");
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Atualiza(indiceSerie, PegaDadosInsercao(indiceSerie));
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie: ");
            repositorio.Insere(PegaDadosInsercao(repositorio.ProximoId()));
        }

        private static Serie PegaDadosInsercao(int id)
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o genero entre as opcções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo =  Console.ReadLine();

            Console.Write("Digite o Ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao =  Console.ReadLine();

            Serie novaSerie = new Serie(
                id: id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );
            return novaSerie;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "**Excluido**" : ""));
            }
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
