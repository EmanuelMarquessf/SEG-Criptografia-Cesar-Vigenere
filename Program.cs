using System;

namespace Atividade_Criptografia___Cesar_e_Vigenere___SEGA6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int op;
            string fCrip;
            string senha;

            do
            {
                Console.WriteLine("=====================");
                Console.WriteLine("[1]- Criptografia Cesar \n[2]- Criptografia Vigenere \n[3]- Analise Frequencia\n[0]- Sair\n");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        int chave;
                        string cadeia;
                        string result;

                        Console.WriteLine("[1]- Descriptografar \n[2]- Criptografar \n[0]- Sair\n");
                        op = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a chave:");
                        chave = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a frase");
                        cadeia = Console.ReadLine();
                        cadeia = cadeia.ToUpper();

                        if (op == 2)
                            result = program.DesCesar(chave, cadeia);
                        else if (op == 1)
                            result = program.CripCesar(chave, cadeia);
                        else
                            return;

                        Console.WriteLine(result);

                        break;
                    case 2:

                        Console.WriteLine("[1]- Descriptografar \n[2]- Criptografar \n[0]- Sair\n");
                        op = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite a frase:");
                        fCrip = Console.ReadLine();

                        Console.WriteLine("Digite a senha:");
                        senha = Console.ReadLine();

                        if (op == 1)
                            result = program.DesVigenere(senha.ToUpper(), fCrip.ToUpper());
                        else if (op == 2)
                            result = program.CripVigenere(senha.ToUpper(), fCrip.ToUpper());
                        else
                            return;

                        Console.WriteLine(result);

                        break;
                    case 3:

                        Console.WriteLine("Digite a frase:");
                        fCrip = Console.ReadLine();
                        fCrip = fCrip.ToUpper();

                        chave = program.Chave(fCrip, 0);

                        result = program.DesCesar(chave, fCrip);

                        Console.WriteLine(result);

                        Console.WriteLine("Resposta certa?\n[1]- Sim \n[2]- Nao");
                        op = int.Parse(Console.ReadLine());

                        if (op == 2)
                        {
                            chave = program.Chave(fCrip, 4);

                            result = program.DesCesar(chave, fCrip);
                            Console.WriteLine(result);
                        }

                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            } while ((op != 0));
        }

        public string DesCesar(int chave, string cadeia)
        {
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string cadeiaFinal = "";


            foreach (char c in cadeia)
            {
                if (c == ' ')
                {
                    cadeiaFinal += c;
                }
                else
                {
                    int x = (Convert.ToChar((Convert.ToInt32(c) - chave)) - 65);
                    if (x < 0)
                    {
                        x = 26 + x;
                    }
                    else
                    {
                        x = x % 26;
                    }
                    cadeiaFinal += alpha[x];
                }
            }
            return cadeiaFinal;
        }

        public string CripCesar(int chave, string cadeia)
        {
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string cadeiaFinal = "";


            foreach (char c in cadeia)
            {
                if (c == ' ')
                {
                    cadeiaFinal += ' ';
                }
                else
                {
                    cadeiaFinal += alpha[(Convert.ToChar((Convert.ToInt32(c) + chave)) - 65) % 26];
                }
            }
            return cadeiaFinal;
        }

        public string CripVigenere(string senha, string fCrip)
        {
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string palavraFinal = "";
            int x = 0;

            foreach (var c in fCrip)
            {
                if (x == senha.Length)
                {
                    x = 0;
                }

                int j = 0;
                while (senha[x] != alpha[j])
                {
                    j++;
                }
                if (c == ' ')
                {
                    palavraFinal += " ";
                }
                else
                {
                    palavraFinal += alpha[(Convert.ToChar((Convert.ToInt32(c) + j)) - 65) % 26];
                }
                x++;
            }

            return palavraFinal;
        }

        public string DesVigenere(string senha, string fCrip)
        {
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string palavraFinal = "";
            int chave = 0;
            int x = 0;

            foreach (var c in fCrip)
            {
                if (x == senha.Length)
                {
                    x = 0;
                }

                int j = 0;
                while (senha[x] != alpha[j])
                {
                    j++;
                }
                chave = Convert.ToChar((Convert.ToInt32(c) - j)) - 65;
                if (chave < 0)
                {
                    chave = 26 + chave;
                }
                else
                {
                    chave = chave % 26;
                }
                if (c == ' ')
                {
                    palavraFinal += " ";
                }
                else
                {
                    palavraFinal += alpha[chave];
                }
                x++;
            }

            return palavraFinal;
        }


        public int Chave(string fCrip, int letra)
        {
            int sumFim = 0;
            char bestCaracter = ' ';

            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            while (fCrip.Length > 0)
            {
                int sum = 0;
                for (int i = 0; i < fCrip.Length; i++)
                {
                    if (fCrip[0] == fCrip[i] && fCrip[0] != ' ')
                    {
                        sum++;
                    }
                    if (sum > sumFim)
                    {
                        sumFim = sum;
                        bestCaracter = fCrip[i];
                    }
                }
                fCrip = fCrip.Replace(fCrip[0].ToString(), string.Empty);
            }

            int chave = 0;


            while (alpha[chave] != bestCaracter)
            {
                chave++;
            }
            if (letra != 0)
            {
                chave -= letra;
            }

            return chave;
        }
    }
}
