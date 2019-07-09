using System;

namespace snake
{
    class GameSnake{
        public static int Xapple { get; set; }
        public static int Yapple { get; set; }

        public static void jogo()
        {
            Console.CursorVisible = false;
            int score = 0;
            int[] Xpos = new int[50];
            Xpos[0] = 35;
            int[] Ypos = new int[50];
            Ypos[0] = 20;
            bool Continuar = true;

            Console.SetCursorPosition(Xpos[0],Ypos[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O");

            quadro();
            maca();

            ConsoleKey comando = Console.ReadKey().Key;

            do{
                switch(comando)
                {
                    case ConsoleKey.A:
                        Console.SetCursorPosition(Xpos[0],Ypos[0]);
                        Console.Write(" ");
                        Xpos[0]--;
                        break;

                    case ConsoleKey.W:
                        Console.SetCursorPosition(Xpos[0],Ypos[0]);
                        Console.Write(" ");
                        Ypos[0]--;
                        break;

                    case ConsoleKey.D:
                        Console.SetCursorPosition(Xpos[0],Ypos[0]);
                        Console.Write(" ");
                        Xpos[0]++;
                        break;

                    case ConsoleKey.S:
                        Console.SetCursorPosition(Xpos[0],Ypos[0]);
                        Console.Write(" ");
                        Ypos[0]++;
                        break;

                    default:
                        break;
                }

                DesenharSnake(score, Xpos,Ypos, out Xpos, out Ypos);

                if(SnakeParede(Xpos[0],Ypos[0]) == true)
                {
                    Continuar = false;
                    Console.Clear();
                    Console.SetCursorPosition(15,10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Cobra Bateu na parede!");
                }
                
                if(Xpos[0] == Xapple && Ypos[0] == Yapple)
                {
                    maca();
                    ++score;
                }

                if(Console.KeyAvailable) comando = Console.ReadKey().Key;

                System.Threading.Thread.Sleep(150);

            }while(Continuar);
        }

        static void DesenharSnake(int tamanho, int[] XposIN, int[] YposIN, out int[] XposOUT, out int[] YposOUT)
        {
            //desenhar cabeca
            Console.SetCursorPosition(XposIN[0],YposIN[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O");

            //desenhar corpo
            for(int i = 1; i < tamanho + 1; i++)
            {
                Console.SetCursorPosition(XposIN[i],YposIN[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("o");
            }

            //eliminar 
            Console.SetCursorPosition(XposIN[tamanho + 1],YposIN[tamanho + 1]);
            Console.WriteLine(" ");

            //localizaçoes
            for(int i = tamanho + 1; i > 0;i--)
            {
                XposIN[i] = XposIN[i - 1];
                YposIN[i] = YposIN[i - 1];
            }



            XposOUT = XposIN;
            YposOUT = YposIN;
        }


        static void maca()
        {
            Random ran = new Random();
            Xapple = ran.Next(2,69);
            Yapple = ran.Next(2,40);

            Console.SetCursorPosition(Xapple,Yapple);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("@");
        }

        static void quadro()
        {
            //verticais
            for(int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1,i);
                Console.Write("#");
                Console.SetCursorPosition(70,i);
                Console.Write("#");
            }

            //horizontais
            for(int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i,1);
                Console.Write("#");
                Console.SetCursorPosition(i,40);
                Console.Write("#");
            }
        }

        static bool SnakeParede(int X, int Y)
        {
            if(X == 1 || X == 70 || Y == 1 || Y == 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    } 
}