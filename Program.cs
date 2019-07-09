using System;

namespace snake
{
    class Program
    {
        public static int Xapple { get; set; }
        public static int Yapple { get; set; }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int score = 0;
            int Xpos = 35;
            int Ypos = 20;
            bool Continuar = true;

            Console.SetCursorPosition(Xpos,Ypos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O");

            quadro();
            maca();

            ConsoleKey comando = Console.ReadKey().Key;

            do{
                switch(comando)
                {
                    case ConsoleKey.A:
                        Console.SetCursorPosition(Xpos,Ypos);
                        Console.Write(" ");
                        Xpos--;
                        break;

                    case ConsoleKey.W:
                        Console.SetCursorPosition(Xpos,Ypos);
                        Console.Write(" ");
                        Ypos--;
                        break;

                    case ConsoleKey.D:
                        Console.SetCursorPosition(Xpos,Ypos);
                        Console.Write(" ");
                        Xpos++;
                        break;

                    case ConsoleKey.S:
                        Console.SetCursorPosition(Xpos,Ypos);
                        Console.Write(" ");
                        Ypos++;
                        break;

                    default:
                        Console.Write("");
                        break;
                }
                
                Console.SetCursorPosition(Xpos,Ypos);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("O");

                if(SnakeParede(Xpos,Ypos) == true)
                {
                    Continuar = false;
                    Console.Clear();
                    Console.SetCursorPosition(15,10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Cobra Bateu na parede!");
                }
                
                if(Xpos == Xapple && Ypos == Yapple)
                {
                    maca();
                    ++score;
                }


                if(Console.KeyAvailable) comando = Console.ReadKey().Key;

                System.Threading.Thread.Sleep(150);

            }while(Continuar);
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
