using System;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Snake");
            Console.WriteLine();
            begin:
            Console.WriteLine("1: Jogar");

            ConsoleKey escolher = Console.ReadKey().Key;

            switch(escolher)
            {
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    GameSnake.jogo();
                    break;
                
                default:
                    Console.WriteLine("Tecla nao existe!");
                    goto begin;
            }
        }
    }
}
