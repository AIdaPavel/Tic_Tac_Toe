using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        private static bool winner = true;
        private static bool firstInit = true;
        private static bool startGame = true;
        private static bool setGame;
        private static byte axicX, axicY, positionX, positionY, gameLevel;
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

            setGameLevel();

            field = new string[axicY, axicX];

            PrintField();

            while (startGame)
            {
                if (winner)
                {
                    ChoosingCoordinates(winner);
                    setAxic();
                    PrintField(positionX, positionY);
                    switch (gameLevel)
                    {
                        case 1:
                            LogicGameForLvl1();
                            break;
                        case 2:
                            LogicGameForLvl2();
                            break;
                        default:
                            LogicGameForLvl3();
                            break;
                    }
                }
                else
                {
                    ChoosingCoordinates(winner);
                    setAxic();
                    PrintField(positionX, positionY);
                    switch (gameLevel)
                    {
                        case 1:
                            LogicGameForLvl1();
                            break;
                        case 2:
                            LogicGameForLvl2();
                            break;
                        default:
                            LogicGameForLvl3();
                            break;
                    }
                }
            }
        }

        private static void StartGameVsCompucter()
        {
            SetAxicX();
            SetAxicY();

            setGameLevel();

            field = new string[axicY, axicX];

            PrintField();

            while (startGame)
            {
                if (winner)
                {
                    ChoosingCoordinates(winner);
                    setAxic();
                    PrintField(positionX, positionY);
                    switch (gameLevel)
                    {
                        case 1:
                            LogicGameForLvl1();
                            break;
                        case 2:
                            LogicGameForLvl2();
                            break;
                        default:
                            LogicGameForLvl3();
                            break;
                    }
                }
                else
                {
                    Compucter();
                    setAxic();
                    PrintField(positionX, positionY);
                    switch (gameLevel)
                    {
                        case 1:
                            LogicGameForLvl1();
                            break;
                        case 2:
                            LogicGameForLvl2();
                            break;
                        default:
                            LogicGameForLvl3();
                            break;
                    }
                }
            }
        }

        private static bool SetGame()
        {
            byte setGamneTemp = 0;
            bool success = false;

            Console.WriteLine("Выберете режим игры:\n1. Игрок против Игрока.\n2. Игрок против Компьютера.");

            while (!success)
            {
                try
                {
                    setGamneTemp = Convert.ToByte(Console.ReadLine());

                    switch (setGamneTemp)
                    {
                        case 1:
                            return true;

                        case 2:
                            return false;
                        default:
                            Console.WriteLine("Введено неверное значение, повторите ввод.");
                            break;

                    }
                }
                catch
                {
                    Console.WriteLine("Введены неверные символы, повторите ввод.");
                }
            }

            return false;
        }

        private static void SetAxicX()
        {
            Console.Write("Выберите размер полеля по оси \"X\" от 3 до 9: ");
            bool success = false;

            while(!success)
            {
                try
                {
                    axicX = Convert.ToByte(Console.ReadLine());
                    axicX++;

                    if (axicX <= 10 && axicX >= 4)
                    {
                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("Выбрано число вне диапазона, пожалуйста, введите подходящее.");
                    }
                }
                catch
                {
                    Console.WriteLine("Введены неверные символы, повторите ввод.");
                }
            }
        }

        private static void SetAxicY()
        {
            Console.Write("Выберите размер полеля по оси \"Y\" от 3 до 9: ");
            bool success = false;

            while (!success)
            {
                try
                {
                    axicY = Convert.ToByte(Console.ReadLine());
                    axicY++;

                    if (axicY <= 10 && axicY >= 4)
                    {
                        success = true;
                    }
                    else
                    {
                        Console.WriteLine("Выбрано число вне диапазона, пожалуйста, введите подходящее.");
                    }
                }
                catch
                {
                    Console.WriteLine("Введены неверные символы, повторите ввод.");
                }
            }
        }

        private static void setGameLevel()
        {
            if (axicX < 6 || axicY < 6)
            {
                gameLevel = 1;
            }
            else if (axicX < 8 && axicY < 8)
            {
                gameLevel = 2;
            }
            else
            {
                gameLevel = 3;
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
                        ChoosingCoordinates(winner);
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

        private static void ChoosingCoordinates(bool user)
        {
            bool successX = false;
            bool successY = false;

            if (user)
            {
                Console.Write("Игрок 1:\nВыберете координаты по оси \"X\": ");
            }
            else
            {
                Console.Write("Игрок 2:\nВыберете координаты по оси \"X\": ");
            }

            while (!successX)
            {
                try
                {
                    positionX = Convert.ToByte(Console.ReadLine());
                    if (positionX > 0 && positionX < axicX)
                    {
                        successX = true;
                    }
                    else
                    {
                        Console.WriteLine("Выбрано значение превышающее ширину поля, повторите ввод.");
                    }

                }
                catch
                {
                    Console.WriteLine("Введены неверные символы, повторите ввод.");
                }
            }

            Console.Write("Выберете координаты по оси \"Y\": ");

            while (!successY)
            {
                try
                {
                    positionY = Convert.ToByte(Console.ReadLine());

                    if (positionY > 0 && positionY < axicY)
                    {
                        successY = true;
                    }
                    else
                    {
                        Console.WriteLine("Выбрано значение превышающее высоту поля, повторите ввод.");
                    }
                }
                catch
                {
                    Console.WriteLine("Введены неверные символы, повторите ввод.");
                }
            }
        }

        private static void Compucter()
        {
            positionX = (byte)random.Next(axicX);
            positionY = (byte)random.Next(axicY);
        }
        
        private static void LogicGameForLvl1()
        {
            byte count = 0;
            bool success = false;

            while (!success)
            {
                // Проверка по вертикали
                for (int y = 0; y < axicY; y++)
                {
                    for (int x = 0; x < axicX - 2; x++)
                    {
                        if (field[y, x] != null && field[y, x].Equals(field[y, x + 1]) && field[y, x].Equals(field[y, x + 2]))
                        {
                            startGame = false;
                            PrintWinner();
                            success = true;
                            return;
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
                            success = true;
                            return;
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
                            success = true;
                            return;
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
                success = true;
            }
        }

        private static void LogicGameForLvl2()
        {
            byte count = 0;

            while (true)
            {
                // Проверка по вертикали
                for (int y = 0; y < axicY; y++)
                {
                    for (int x = 0; x < axicX - 3; x++)
                    {
                        if (field[y, x] != null && 
                            field[y, x].Equals(field[y, x + 1]) && 
                            field[y, x].Equals(field[y, x + 2]) &&
                            field[y, x].Equals(field[y, x + 3]))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
                        }
                    }
                }

                // Проверка по горизонтали
                for (int y = 0; y < axicY - 3; y++)
                {
                    for (int x = 0; x < axicX; x++)
                    {
                        if (field[y, x] != null && 
                            field[y, x].Equals(field[y + 1, x]) && 
                            field[y, x].Equals(field[y + 2, x]) &&
                            field[y, x].Equals(field[y + 3, x]))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
                        }
                    }
                }

                // Проверка по диагонали слева направо
                for (int y = 1; y < axicY - 1; y++)
                {
                    for (int x = 1; x < axicX - 1; x++)
                    {
                        if ((field[y, x] != null && field[y, x].Equals(field[y + 1, x + 1]) && 
                            field[y, x].Equals(field[y - 1, x - 1]) && field[y, x].Equals(field[y + 2, x + 2])))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
                        }
                    }
                }

                // Проверка по диагонали справа налево
                for (int y = axicY - 3; y > 0; y--)
                {
                    for (int x = 2; x < axicX - 1; x++)
                    {
                        if (field[y, x] != null && field[y, x].Equals(field[y - 1, x + 1]) &&
                            field[y, x].Equals(field[y + 1, x - 1]) && field[y, x].Equals(field[y + 2, x - 2]))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
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
                return;
            }
        }

        private static void LogicGameForLvl3()
        {
            byte count = 0;

            while (true)
            {
                // Проверка по вертикали
                for (int y = 0; y < axicY; y++)
                {
                    for (int x = 0; x < axicX - 4; x++)
                    {
                        if (field[y, x] != null &&
                            field[y, x].Equals(field[y, x + 1]) &&
                            field[y, x].Equals(field[y, x + 2]) &&
                            field[y, x].Equals(field[y, x + 3]) &&
                            field[y, x].Equals(field[y, x + 4]))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
                        }
                    }
                }

                // Проверка по горизонтали
                for (int y = 0; y < axicY - 4; y++)
                {
                    for (int x = 0; x < axicX; x++)
                    {
                        if (field[y, x] != null &&
                            field[y, x].Equals(field[y + 1, x]) &&
                            field[y, x].Equals(field[y + 2, x]) &&
                            field[y, x].Equals(field[y + 3, x]) &&
                            field[y, x].Equals(field[y + 4, x]))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
                        }
                    }
                }

                // Проверка по диагоналям
                for (int y = 2; y < axicY - 2; y++)
                {
                    for (int x = 2; x < axicX - 2; x++)
                    {
                        if ((field[y, x] != null && 
                            field[y, x].Equals(field[y + 1, x + 1]) && field[y, x].Equals(field[y - 1, x - 1]) &&
                            field[y, x].Equals(field[y + 2, x + 2]) && field[y, x].Equals(field[y - 2, x - 2])) 
                            ||
                            (field[y, x] != null && 
                            field[y, x].Equals(field[y - 1, x + 1]) && field[y, x].Equals(field[y + 1, x - 1]) &&
                            field[y, x].Equals(field[y - 2, x + 2]) && field[y, x].Equals(field[y + 2, x - 2])))
                        {
                            startGame = false;
                            PrintWinner();
                            return;
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
                return;
            }
        }

        private static void PrintWinner()
        {
            if (!winner)
            {
                Console.WriteLine("Победель: Игрок 1!");
            } 
            else if (winner && setGame)
            {
                Console.WriteLine("Победель: Игрок 2!");
            }
            else {
                Console.WriteLine("Победель: Компуктер!");
            }
        }

        private static void RestartGame()
        {
            bool success = false;

            while (!success)
            {
                Console.Write("\nХотите сыграть еще раз?\nНажмите: \"Y\" - если ДА, \"N\" - если НЕТ: ");
                string userSelection = Console.ReadLine();

                if (userSelection.Equals("y") || userSelection.Equals("Y"))
                {
                    startGame = true;
                    firstInit = true;
                    Console.WriteLine();
                    success = true;
                }
                else if (userSelection.Equals("n") || userSelection.Equals("N"))
                {
                    startGame = false;
                    success = true;
                }
                else
                {
                    Console.WriteLine("\nВведен неверный символ, повторите ввод.");
                }
            }
        }
    }
}
