using static Kondratiev4.Methods;

namespace Kondratiev4
{
    internal class Program
    {
        static int currentPosition = 0;
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            // Save the current background and foreground colors.
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            currentForeground = ConsoleColor.Red;

            Console.WriteLine("Console " + currentForeground);
            ShowMenu();
        }

        static private void ShowMenu()
        {
            string[] allLines = { "Нормализация ФИО", "Из чего состоит текст", "Инициалы", "Маска телефона",
            "Ровная таблица", "Запись и чтение файла", "Сумма чисел из файла", "Основное задание. Обработчик анкет"};

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Добро пожаловать в программу! Выберите задание, которое вам надо посмотреть");

                for (int i = 0; i < allLines.Length; i++)
                {
                    if (i == currentPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("> " + allLines[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {allLines[i]}");
                    }
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.DownArrow)
                {
                    currentPosition++;

                    if (currentPosition >= allLines.Length)
                    {
                        currentPosition = 0;
                    }
                }
                if (key == ConsoleKey.UpArrow)
                {
                    currentPosition--;

                    if (currentPosition < 0)
                    {
                        currentPosition = allLines.Length - 1;
                    }
                }

                else if (key == ConsoleKey.Enter)
                {
                    switch (currentPosition)
                    {
                        case 0:
                            Console.Clear();
                            Normalized();
                            Console.ReadKey(true);
                            break;
                        case 1:
                            Console.Clear();
                            EverythingIsCounted();
                            Console.ReadKey(true);
                            break;
                        case 2:
                            Console.Clear();
                            FullName();
                            Console.ReadKey(true);
                            break;
                        case 3:
                            Console.Clear();
                            PhoneNumber();
                            Console.ReadKey(true);
                            break;
                        case 4:
                            Console.Clear();
                            StraightTable();
                            Console.ReadKey(true);
                            break;
                        case 5:
                            Console.Clear();
                            ReadAndWrite();
                            Console.ReadKey(true);
                            break;
                        case 6:
                            Console.Clear();
                            SumOfNumbersFromFile();
                            Console.ReadKey(true);
                            break;
                        case 7:
                            Console.Clear();
                            MainTask();
                            Console.ReadKey(true);
                            break;


                    }
                }

            }

        }


    }


}
