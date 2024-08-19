using System;
namespace tictactoe
{

    class Program
    {
        static int playerx = 1;
        static int playery = 1;
        static void Print (int x, int y, string s)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(s);
        }

        static void DrawGame(Tictactoe game)
        {
            for (int i = 0; i < game.Board.GetLength(0); i++)
            {
                for (int j = 0; j < game.Board.GetLength(1); j++)
                {
                    if(game.Board[i, j] == 0)
                    {
                        Print(i, j, "*");
                    }
                    else if(game.Board[i, j] == 1)
                    {
                        Print(i, j, "X");
                    }
                    else
                    {
                        Print(i, j, "O");
                    }
                }
            }
            Print(playerx, playery, "");
        }

        static void Move(int dx, int dy)
        {
            if(playerx + dx < 0 || playerx + dx > 2)
                return;
            if (playery + dy < 0 || playery + dy > 2)
                return;

            playerx += dx;
            playery += dy;
        }

        static void Main(string[] args)
        {
            Tictactoe game = new();

            while(!game.GameOver)
            {
                DrawGame(game);
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(1, 0);
                        break;
                    case ConsoleKey.Enter:
                        game.SetCell(playerx, playery, game.CurrentPlayer);
                        break;
                }
            }
            DrawGame(game);
            Print(10,10, "Game Over");
            Console.ReadKey(true);
        }
    }

}

