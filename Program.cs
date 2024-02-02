

using System.ComponentModel.Design;

namespace Algorithmus_Abgabe

{
    internal class Program
    {
        private static int amount;
        private static int min;
        private static int max;
        
        private static int[] mixedNumbersA;
        
        private static int showAmount = 0;

        private static int algorithmIndex;
        private enum EAlgorithmIndex
        {
            BubbleSort = 1,
            SelectionSort,
            InsertionSort
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            NumberInput();
            ChooseList();

            WantToSort();

        }

        private static void NumberInput()
        {
            bool choose = false;

            Console.Write("Gib an wie viele Zahlen sortiert werden sollen [Mit Pfeiltasten] :  ");


            while (!choose)
            {
                Console.SetCursorPosition(67, 0);
                Console.Write(amount);
                ConsoleKeyInfo getArrow = Console.ReadKey();


                switch (getArrow.Key)
                {
                    case ConsoleKey.UpArrow:

                        amount++;

                        break;

                    case ConsoleKey.DownArrow:
                        if (amount > 0)
                        {
                            amount--;
                        }

                        break;

                    case ConsoleKey.Enter:

                        showAmount = amount;
                        mixedNumbersA = new int[amount];
                        choose = true;
                        Console.Clear();
                        break;
                }
            }
        }
        private static void ChooseList()
        {
            Console.WriteLine("Zufällig generierte Zahlen sortieren lassen [Z] ? Oder eigene Auswählen? [A]");

            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Z:
                    Console.Clear();
                    GetMinAndMax();
                    GetRandomNumbers();

                    break;


                case ConsoleKey.A:
                    Console.Clear();
                    GetNumbers();

                    break;
            }

        }
        private static void GetNumbers()
        {
            int tempX = 0;
            int tempY = 1;
            Console.Write("Zahl/en benötigt :  ");
            for (int i = 0; i < amount; i++)
            {
                Console.SetCursorPosition(20, 0);
                Console.Write(showAmount);
                Console.SetCursorPosition(tempX, tempY);


                int temp = int.Parse(Console.ReadLine());

                mixedNumbersA[i] = temp;
                showAmount--;
                tempY++;
            }

            Console.Clear();
            Console.WriteLine("Deine Liste lautet :");

            PrintArray(mixedNumbersA);
        }
        private static void GetMinAndMax()
        {
            Console.WriteLine("Was soll der Mindestwert sein?");
            min = int.Parse(Console.ReadLine());


            Console.WriteLine("Was soll der Maxmialwert sein?");
            max = int.Parse(Console.ReadLine());
        }
        private static void GetRandomNumbers()
        {
            Random rnd = new Random();

            for (int i = 0; i < amount; i++)
            {
                int temp = rnd.Next(min, max + 1);

                mixedNumbersA[i] = temp;
            }
            Console.Clear();
            Console.WriteLine("Alles klar deine Liste ist :");

            PrintArray(mixedNumbersA);

        }
        private static void WantToSort()
        {
            Console.ReadKey(true);
            Console.Clear();
            bool validInput = false;
            do
            {
                Console.Clear();

                Console.WriteLine("\nWomit willst du Sortieren?");

                Console.WriteLine("-------------------------");

                Console.WriteLine("\nBubbleSort [1]\n");

                Console.WriteLine("-------------------------");

                Console.WriteLine("\nSelectionSort [2]\n");

                Console.WriteLine("-------------------------");

                Console.WriteLine("\nInsertionSort [3] \n");

                int input = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        validInput = true;
                        algorithmIndex = (int)EAlgorithmIndex.BubbleSort;
                        WayToSort();
                        break;

                    case 2:
                        Console.Clear();
                        validInput = true;
                        algorithmIndex = (int)EAlgorithmIndex.SelectionSort;
                        WayToSort();
                        break;

                    case 3:
                        Console.Clear();
                        validInput = true;
                        algorithmIndex = (int)EAlgorithmIndex.InsertionSort;
                        WayToSort();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ungültige angabe");
                        Console.ReadKey(true);
                        break;
                }


            } while (!validInput);
        }
        private static void WayToSort()
        {
            bool validInput = false;
            do
            {
                Console.WriteLine("Wie soll der BubbleSort für dich sortieren ?");

                Console.WriteLine("\n \n");

                Console.WriteLine("Von groß nach klein [1]");

                Console.WriteLine("\n \n");

                Console.WriteLine("Von klein nach groß [2]");

                Console.WriteLine("\n \n");

                Console.WriteLine("Im Zick-Zack Muster [3]");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        validInput = true;
                        Console.Clear();
                        if (algorithmIndex == (int)EAlgorithmIndex.BubbleSort)
                        {
                            Console.ReadKey();
                            Console.WriteLine("Deine Liste von groß nach klein :");
                            PrintArray(BubbleHighToLow());
                        }
                        else if (algorithmIndex == (int)EAlgorithmIndex.SelectionSort)
                        {
                            Console.ReadKey();
                            Console.WriteLine("Deine Liste von groß nach klein :");
                            PrintArray(SelectionHighToLow());
                        }
                        else if(algorithmIndex == (int)EAlgorithmIndex.InsertionSort)
                        {
                            Console.ReadKey();
                            Console.WriteLine("Deine Liste von groß nach klein :");
                            PrintArray(InsertionHighToLow());
                        }

                     break;

                    case 2:
                        validInput = true;
                        if (algorithmIndex == (int)EAlgorithmIndex.BubbleSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste von klein nach groß : ");
                            BubbleLowToHigh();
                        }
                        else if (algorithmIndex == (int)EAlgorithmIndex.SelectionSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste von klein nach groß : ");
                            SelectionLowToHigh();
                        }
                        else if (algorithmIndex == (int)EAlgorithmIndex.InsertionSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste von klein nach groß : ");
                            InsertionLowToHigh();
                        }

                        break;

                    case 3:

                        validInput = true;
                        if (algorithmIndex == (int)EAlgorithmIndex.BubbleSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste im Zick Zack");
                            PrintArray(BubbleZickZack());
                        }
                        else if (algorithmIndex == (int)EAlgorithmIndex.SelectionSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste im Zick Zack");
                            SelectionZickZack();
                        }
                        else if (algorithmIndex == (int)EAlgorithmIndex.InsertionSort)
                        {
                            Console.Clear();
                            Console.WriteLine("Deine Liste im Zick Zack");
                            InsertionZickZack();
                        }


                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ungültige Angabe!!");
                        Console.ReadKey(true);
                        break;

                }
            } while (!validInput);
        }
       
        #region BubbleSortMethods
        private static int[] BubbleHighToLow()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            for (int i = 0; i < tempA.Length - 1; i++)
            {
                for (int x = 0; x < tempA.Length - 1 - i; x++)
                {
                    if (tempA[x] > tempA[x + 1])
                    {
                        int value = tempA[x];
                        tempA[x] = tempA[x + 1];
                        tempA[x + 1] = value;
                    }
                }
            }

            return tempA;
        }

        private static int[] BubbleLowToHigh()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            for (int i = 0; i < tempA.Length - 1; i++)
            {
                for (int x = 0; x < tempA.Length - 1 - i; x++)
                {
                    if (tempA[x] > tempA[x + 1])
                    {
                        int value = tempA[x];
                        tempA[x] = tempA[x + 1];
                        tempA[x + 1] = value;
                    }
                }         
            }

            return tempA;
        }

        private static int[] BubbleZickZack()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            for (int i = 0; i < tempA.Length - 1; i++)
            {
                for (int x = 0; x < tempA.Length - 1 - i; x++)
                {
                    if (i % 2 == 0)        
                    {
                        if (tempA[x] > tempA[x + 1])
                        {
                            int value = tempA[x];
                            tempA[x] = tempA[x + 1];
                            tempA[x + 1] = value;
                        }
                    }


                    if (i % 2 != 0)
                    {
                        if (tempA[x] < tempA[x + 1])
                        {
                            int value = tempA[x];
                            tempA[x] = tempA[x + 1];
                            tempA[x + 1] = value;
                        }

                    }
                }

            }



            Array.Reverse(tempA);
            return tempA;
        }



        #endregion

        #region SelectionSortMethods

        private static int[] SelectionHighToLow()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            int highestNumber;

            for (int i = 0; i < tempA.Length; i++)
            {
                highestNumber = i;

                for (int x = i + 1; x < tempA.Length; x++)
                {
                    if (tempA[x] > tempA[highestNumber]   )
                    {
                        highestNumber = x;

                    }
                }

                int value = tempA[i];
                tempA[i] = tempA[highestNumber];
                tempA[highestNumber] = value;

            }


            return tempA;
        }

        private static int[] SelectionLowToHigh()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            int lowestNumber;

            for (int i = 0; i < tempA.Length; i++)
            {
                lowestNumber = i;

                for (int x = 1 + i; x < tempA.Length; x++)
                {

                    if (tempA[x] > tempA[lowestNumber])
                    {
                        lowestNumber = x; 


                    }
                }

                int temp = tempA[i];
                tempA[i] = tempA[lowestNumber];
                tempA[lowestNumber] = temp;
            }



            return tempA;
        }

        private static int[] SelectionZickZack()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            int smallestNumber;
            int highestNumber;

            for (int i = 0; i < tempA.Length; i++)
            {
                smallestNumber = i;
                highestNumber = i;

                for (int x = 1 + i; x < tempA.Length; x++)
                {

                    if (i % 2 != 0)
                    {
                        if (tempA[x] < tempA[smallestNumber])
                        {
                            smallestNumber = x;

                        }

                    }

                    if (i % 2 == 0)
                    {
                        if (tempA[x] > tempA[highestNumber])
                        {
                            highestNumber = x;

                        }
                    }

                }

                int temp = tempA[i];
                tempA[i] = tempA[smallestNumber];
                tempA[smallestNumber] = temp;

                int value = tempA[i];
                tempA[i] = tempA[highestNumber];
                tempA[highestNumber] = value;
            }



            return tempA;
        }

        #endregion

        #region InsertionSortMethods

        private static int[] InsertionHighToLow()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            int x;
            int value;

            for (int i = 1; i < tempA.Length; i++)
            {
                x = i - 1;
                value = tempA[i];

                while (x >= 0 && tempA[x] < value)
                {
                    tempA[x + 1] = tempA[x];

                    x--;
                }

                tempA[x + 1] = value;
            }


            return tempA;
        }

        private static int[] InsertionLowToHigh()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            int x;
            int value;

            for (int i = 1; i < tempA.Length; i++)
            {
                x = i - 1;
                value = tempA[i];

                while (x >= 0 && tempA[x] > value)
                {
                    tempA[x + 1] = tempA[x];

                    x--;
                }

                tempA[x + 1] = value;
            }


            return tempA;
        }

        private static int[] InsertionZickZack()
        {
            int[] tempA = new int[mixedNumbersA.Length];
            Array.Copy(mixedNumbersA, tempA, mixedNumbersA.Length);

            


            return tempA;
        }
        #endregion

        public static void PrintArray(int[] _arr)
        {

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine(_arr[i]);
            }

        }
    }
}