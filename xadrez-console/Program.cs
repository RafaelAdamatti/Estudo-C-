using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.WriteLine();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosiçãoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosiçãoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);

                }

            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
