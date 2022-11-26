namespace Task1
{
    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("HARD SORT", "на входе размерность двумерного массива, на выходе двумерный массив случайных целых чисел и он же, но отсортированный по возрастанию слева направо и сверху вниз.");

            int rowsCount = InputInt("Введите кол-во строк");
            int columnsCount = InputInt("Введите кол-во столбцов");

            int[,] array = TwoDimensionalArrayRandom(rowsCount, columnsCount, 0, 99);

            Console.WriteLine();
            Console.WriteLine("Сформированная таблица:");
            TwoDimensionalArrayPrint(array); //вывод

            TwoDimensionalArraySort(array); //сортировка

            Console.WriteLine();
            Console.WriteLine("Отсортированная таблица:");
            TwoDimensionalArrayPrint(array); //вывод

            PrintFinishTask();
        } // === FINISH ===


        // Функция ввода и проверки данных числа int.
        static int InputInt(string inputText)
        {
            int rezult;

            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write(inputText + ": ");

                string str = Console.ReadLine()!.Trim();

                if (int.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: неcоответствие типу Integer!");

                    continue;
                }

                if (rezult <= 0) // доп проверка
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: количество должно быть натуральным числом!");

                    continue;
                }

                break;
            } while (true);

            return rezult;
        }


        //функция формирования двумерного массива со случайными элеменатми в задаваемом дипазоне
        static int[,] TwoDimensionalArrayRandom(int rowsCount, int columnsCount, int min = 0, int max = 1)
        {
            int[,] rezult = new int[rowsCount, columnsCount];

            Random rnd = new();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    rezult[i, j] = rnd.Next(min, max + 1);
                }
            }

            return rezult;
        }

        void TwoDimensionalArrayPrint(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                if (i != 0) Console.WriteLine();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    string str = array[i, j].ToString();
                    Console.Write(" " + str + ((str.Length < 2) ? "   " : "  "));
                }
            }
            Console.WriteLine();
        }

        //процедура сортировки двумерно массива
        void TwoDimensionalArraySort(int[,] array)
        {
            int[] tempArray = new int[array.Length];
            int i = 0;

            foreach (int value in array) // в одномерный
            {
                tempArray[i] = value;
                i++;
            }

            Array.Sort(tempArray); // сортировка

            i = 0;
            int j = 0;
            foreach (int value in tempArray) // перезапись двумерного
            {
                if (j == array.GetLength(1))
                {
                    i++;
                    j = 0;
                }
                array[i, j] = value;
                j++;
            }
        }


        // отрисовка заголовка задачи
        static void PrintStartTask(string taskNumber, string taskText, string infoText = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ЗАДАЧА {taskNumber}: " + taskText);
            if (infoText != "")
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("info: " + infoText);
            }

            Console.ResetColor();
        }

        // отрисовка завершения задачи
        static void PrintFinishTask()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }







    //На случай запуска как самостоятельно проекта, не из под Главного Меню
    class Program
    {
        static void Main()
        {
            Task task = new();
            task.Start();
        }
    }
}