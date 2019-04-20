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
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosiçãoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] movimentosPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, movimentosPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosiçãoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                        
                        // #jogada especial promocao
                        if (partida.promocao)
                        {
                            Console.Write("Escolha para qual peça promover: ");
                            Peca promocao = Tela.lerPecaPromocao(partida.tab, partida.jogadorAtual);
                            partida.pecaPromocao(promocao, destino);
                        }

                        partida.finalizaJogada();
                    }

                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("A posição deve conter uma letra e um número!");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
                Console.ReadLine();
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
