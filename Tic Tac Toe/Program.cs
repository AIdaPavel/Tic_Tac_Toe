using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        private static bool startGame = true;
        private static int axicX;
        private static int axicY;
        private static string[,] field;
        private static int positionX, positionY;
        private static bool winner = true;
        private static bool firstInit = true;

        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            while (startGame)
            {
                SetAxicX();
                SetAxicY();

                field = new string[axicY, axicX];

                PrintField();

                while (startGame)
                {
                    if (winner) {
                        Player1();
                        PrintField(positionX, positionY);
                        LogicGame();
                    }
                    else
                    {
                        Player2();
                        PrintField(positionX, positionY);
                        LogicGame();
                    }
                }

                RestartGame();
            }
        }

        private static void SetAxicX()
        {
            Console.Write("Выберите размер полеля по оси \"X\" от 3 до 9: ");
            try
            {
                axicX = Convert.ToInt32(Console.ReadLine()) + 1;

                if (axicX <= 10 && axicX >= 4)
                { }
                else
                {
                    Console.WriteLine("Выбрано число вне диапазона, пожалуйста, введите подходящее.");
                    SetAxicX();
                }
            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                SetAxicX();
            }
        }

        private static void SetAxicY()
        {
            Console.Write("Выберите размер полеля по оси \"Y\" от 3 до 9: ");
            try
            {
                axicY = Convert.ToInt32(Console.ReadLine()) + 1;

                if (axicY <= 10 && axicY >= 4)
                { }
                else
                {
                    Console.WriteLine("Выбрано число вне диапазона, пожалуйста, введите подходящее.");
                    SetAxicY();
                }
            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                SetAxicY();
            }
        }

        private static void PrintField(int a = 0, int b = 0)
        {
            Console.WriteLine();
            if (firstInit)
            {
                for (int y = 0; y < axicY; y++)
                {
                    for (int x = 0; x < axicX; x++)
                    {
                        if (y == 0)
                        {
                            field[y, x] = x + " ";
                            Console.Write(field[y, x]);
                        }
                        else if (x == 0)
                        {
                            field[y, x] = y + " ";
                            Console.Write(field[y, x]);
                        }
                        else
                        {
                            Console.Write(field[y, x] ?? "- ");
                        }
                    }
                    Console.WriteLine();
                }

                firstInit = false;
            }
            else
            {
                for (int y = 0; y < axicY; y++)
                {
                    for (int x = 0; x < axicX; x++)
                    {
                        Console.Write(field[y, x] ?? "- ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        private static void Player1()
        {
            Console.Write("Игрок 1:\nВыберете координаты по оси \"X\": ");
            try
            {
                positionX = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player1();
            }

            Console.Write("Выберете координаты по оси \"Y\": ");
            try
            {
                positionY = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player1();
            }

            if (field[positionY, positionX] == null)
            {
                field[positionY, positionX] = "X ";
            }
            else
            {
                Console.WriteLine("\nНельзя выбрать это поле, выберете другое.");
                Player1();
            }

            winner = false;
        }

        private static void Player2()
        {
            Console.Write("Игрок 2:\nВыберете координаты по оси \"X\": ");
            try
            {
                positionX = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player2();
            }

            Console.Write("Выберете координаты по оси \"Y\": ");
            try
            {
                positionY = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player2();
            }

            if (field[positionY, positionX] == null)
            {
                field[positionY, positionX] = "O ";
            }
            else
            {
                Console.WriteLine("\nНельзя выбрать это поле, выберете другое.");
                Player2();
            }

            winner = true;
        }

        private static void LogicGame()
        {
            for (int y = 0; y < axicY - 2; y++)
            {
                for (int x = 0; x < axicX - 2; x++)
                { 
                    if (field[y, x] != null && field[y, x].Equals(field[y, x + 1]) && field[y, x].Equals(field[y, x + 2]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                    else if (field[y, x] != null && field[y, x].Equals(field[y + 1, x]) && field[y, x].Equals(field[y + 2, x]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                    else if (field[y, x] != null && field[y, x].Equals(field[y + 1, x + 1]) && field[y, x].Equals(field[y + 2, x + 2]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                }
            }

            for (int y = axicY - 1; y > 1; y--)
            {
                for (int x = axicX - 1; x > 1; x--)
                {
                    if (field[y, x] != null && field[y, x].Equals(field[y, x - 1]) && field[y, x].Equals(field[y, x - 2]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                    else if (field[y, x] != null && field[y, x].Equals(field[y - 1, x]) && field[y, x].Equals(field[y - 2, x]))
                    {
                        startGame = false;
                        PrintWinner();
                    }

                    if (x < axicX - 1)
                    {
                        if (field[y, x - 1] != null && field[y, x - 1].Equals(field[y - 1, x]) && field[y, x - 1].Equals(field[y - 2, x + 1]))
                        {
                            startGame = false;
                            PrintWinner();
                        }
                    }
                }
            }
        }

        private static void PrintWinner()
        {
            if (!winner)
            {
                Console.WriteLine("Победель: Игрок 1!");
            }
            else {
                Console.WriteLine("Победель: Игрок 2!");
            }
        }

        private static void RestartGame()
        {
            Console.Write("\nХотите сыграть еще раз?\nНажмите: \"Y\" - если ДА, \"N\" - если НЕТ: ");
            string userSelection = Console.ReadLine();

            if (userSelection.Equals("y") || userSelection.Equals("Y"))
            {
                startGame = true;
                firstInit = true;
                Console.WriteLine();
            } 
            else if (userSelection.Equals("n") || userSelection.Equals("N"))
            {
                startGame = false;
            }
            else
            {
                Console.WriteLine("\nВведен неверный символ, повторите ввод.");
                RestartGame();
            }
        }
    }
}
