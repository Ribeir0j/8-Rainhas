using System;

class Program
{

    static int[,] matriz = new int[8, 8];
    static Random random = new Random();

    static void Main()
    {
        ColocarRainhas(matriz);

    }
    static bool VerificarDiagonais(int[,] matriz)
    {
        for (int l = 0; l < 8; l++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (matriz[l, c] == 1)
                {
                    for (int l2 = l + 1; l2 < 8; l2++)
                    {
                        for (int c2 = 0; c2 < 8; c2++)
                        {
                            if (matriz[l2, c2] == 1)
                            {
                                if (l + c == l2 + c2 || l - c == l2 - c2)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return false; //não há rainhas em diagonais
    }

    static bool PosicaoValida(int[,] matriz)
    {
        if (!VerificarColunas(matriz) && !VerificarDiagonais(matriz))
        {
            return true;
        }
        return false;
    }

    static bool VerificarColunas(int[,] matriz)
    {
        for (int c = 0; c < 8; c++)
        {
            int rainhas = 0;
            for (int l = 0; l < 8; l++)
            {
                if (matriz[l, c] == 1)
                {
                    rainhas++;
                }
            }
            if (rainhas > 1)
            {
                return true;
            }
        }
        return false; //não tem mais de uma rainha em cada coluna
    }

    static void LimparMatriz(int[,] matriz)
    {
        for (int l = 0; l < 8; l++)
        {
            for (int c = 0; c < 8; c++)
            {
                matriz[l, c] = 0;
            }
        }
    }

    static void ColocarRainhas(int[,] matriz)
    {
        bool posicaoCorreta = false;

        while (!posicaoCorreta)
        {
            LimparMatriz(matriz);

            for (int l = 0; l < 8; l++)
            {
                int posicaoRainha = random.Next(0, 8);
                matriz[l, posicaoRainha] = 1;
            }

            if (!VerificarColunas(matriz) && !VerificarDiagonais(matriz))
            {
                posicaoCorreta = true;
            }
        }


        ExibirMatriz(matriz);
    }
    static void ExibirMatriz(int[,] matriz)
    {
        for (int l = 0; l < 8; l++)
        {
            for (int c = 0; c < 8; c++)
            {
                Console.Write(matriz[l, c] + " ");
            }
            Console.WriteLine();
        }
    }
}
