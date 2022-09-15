using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        private static bool winner = true;
        private static bool firstInit = true;
        private static bool startGame = true;
        private static bool setGame;
        private static byte axicX, axicY, positionX, positionY;
        private static string[,] field;
        private static Random random = new Random();

        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            while (startGame)
            {
                setGame = SetGame();
                if (setGame)
                {
                    StartGameVsPlauer();
                }
                else
                {
                    StartGameVsCompucter();
                }

                RestartGame();
            }
        }

        private static void StartGameVsPlauer()
        {
            SetAxicX();
            SetAxicY();

            field = new string[axicY, axicX];

            PrintField();

            while (startGame)
            {
                if (winner)
                {
                    Player1();
                    setAxic();
                    PrintField(positionX, positionY);
                    LogicGame();
                }
                else
                {
                    Player2();
                    setAxic();
                    PrintField(positionX, positionY);
                    LogicGame();
                }
            }

            RestartGame();
        }

        private static void StartGameVsCompucter()
        {
            SetAxicX();
            SetAxicY();

            field = new string[axicY, axicX];

            PrintField();

            while (startGame)
            {
                if (winner)
                {
                    Player1();
                    setAxic();
                    PrintField(positionX, positionY);
                    LogicGame();
                }
                else
                {
                    Compucter();
                    setAxic();
                    PrintField(positionX, positionY);
                    LogicGame();
                }
            }
        }

        private static bool SetGame()
        {
            byte setGamneTemp = 0;

            Console.WriteLine("Выберете режим игры:\n1. Игрок против Игрока.\n2. Игрок против Компьютера.");
            
            try
            {
                setGamneTemp = Convert.ToByte(Console.ReadLine());            
            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                SetGame();
            }

            switch (setGamneTemp)
            {
                case 1:
                    return true;

                case 2:
                    return false;

                default:
                    Console.WriteLine("Выбран неизвестный режим игры, попробуйте выбрать другой.");
                    SetGame();
                    return false;
            }
        }

        private static void SetAxicX()
        {
            Console.Write("Выберите размер полеля по оси \"X\" от 3 до 9: ");
            try
            {
                axicX = Convert.ToByte(Console.ReadLine());
                axicX++;

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
                axicY = Convert.ToByte(Console.ReadLine());
                axicY++;

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


        private static void setAxic() {
            if (winner)
            {
                if (field[positionY, positionX] == null)
                {
                    field[positionY, positionX] = "X ";

                    winner = !winner;
                }
                else
                {
                    Console.WriteLine("\nНельзя выбрать это поле, выберете другое.");
                    Player1();
                    setAxic();
                }
            }
            else
            {
                if (field[positionY, positionX] == null)
                {
                    field[positionY, positionX] = "O ";

                    winner = !winner;
                }
                else
                {
                    if (setGame)
                    {
                        Console.WriteLine("\nНельзя выбрать это поле, выберете другое.");
                        Player2();
                        setAxic();
                    }
                    else
                    {
                        Compucter();
                        setAxic();
                    }
                }
            }
        }

        private static void Compucter()
        {
            positionX = (byte)random.Next(axicX);
            positionY = (byte)random.Next(axicY);
        }
        private static void Player1()
        {
            Console.Write("Игрок 1:\nВыберете координаты по оси \"X\": ");
            try
            {
                positionX = Convert.ToByte(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player1();
            }

            Console.Write("Выберете координаты по оси \"Y\": ");
            try
            {
                positionY = Convert.ToByte(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player1();
            }
        }

        private static void Player2()
        {
            Console.Write("Игрок 2:\nВыберете координаты по оси \"X\": ");
            try
            {
                positionX = Convert.ToByte(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player2();
            }

            Console.Write("Выберете координаты по оси \"Y\": ");
            try
            {
                positionY = Convert.ToByte(Console.ReadLine());                               
            }
            catch
            {
                Console.WriteLine("Введены неверные символы, повторите ввод.");
                Player2();
            }
        }

        private static void LogicGame()
        {
            byte count = 0;

            // Проверка по вертикали
            for (int y = 0; y < axicY; y++)
            {
                for (int x = 0; x < axicX - 2; x++)
                { 
                    if (field[y, x] != null && field[y, x].Equals(field[y, x + 1]) && field[y, x].Equals(field[y, x + 2]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                }
            }

            // Проверка по горизонтали
            for (int y = 0; y < axicY - 2; y++)
            {
                for (int x = 0; x < axicX; x++)
                {
                    if (field[y, x] != null && field[y, x].Equals(field[y + 1, x]) && field[y, x].Equals(field[y + 2, x]))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                }
            }

            // Проверка по диагоналям
            for (int y = 1; y < axicY - 1; y++)
            {
                for (int x = 1; x < axicX - 1; x++)
                {
                    if ((field[y, x] != null && field[y, x].Equals(field[y + 1, x + 1]) && field[y, x].Equals(field[y - 1, x - 1])) ||
                        (field[y, x] != null && field[y, x].Equals(field[y - 1, x + 1]) && field[y, x].Equals(field[y + 1, x - 1])))
                    {
                        startGame = false;
                        PrintWinner();
                    }
                }
            }

            // Проверка на нечью
            for (int y = 0; y < axicY; y++)
            {                
                for (int x = 0; x < axicX; x++)
                {
                    if (field[y, x] != null)
                    {
                        count++;
                        if (count == axicX * axicY)
                        {
                            Console.WriteLine("Ничья!");
                            startGame = false;
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
            else if (!winner && setGame)
            {
                Console.WriteLine("Победель: Игрок 2!");
            }
            else {
                Console.WriteLine("Победель: Компуктер!");
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
