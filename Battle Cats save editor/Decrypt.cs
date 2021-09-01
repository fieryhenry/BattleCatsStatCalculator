using System;

namespace Decrypt
{

    class Decrypt
    {
        [STAThread]
        static void Main()
        {
            CatSats();
        }
        static void ColouredText(string input, ConsoleColor Base, ConsoleColor New)
        {
            char[] chars = { '&' };

            string[] split = new string[input.Length];
            try { split = input.Split(chars); }
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nNo & characters in inputed string!");
            }
            try
            {
                Console.ForegroundColor = New;
                for (int i = 0; i < split.Length; i += 2)
                {
                    Console.ForegroundColor = New;
                    Console.Write(split[i]);
                    Console.ForegroundColor = Base;
                    Console.Write(split[i + 1]);

                }
                Console.ForegroundColor = Base;
            }
            catch (IndexOutOfRangeException) { }
        }

        static void CalculateMed(int level, int firstRedPoint)
        {
            Console.WriteLine("Enter the base Stat value of a unit");
            int health = int.Parse(Console.ReadLine());

            ColouredText("&What treasure multiplier do you want? &100%& = &1&,& 200%& = &2&,& 300%& =& 3&, &no treasure& =& 0\n", ConsoleColor.White, ConsoleColor.DarkYellow);
            decimal treasureMultBase = decimal.Parse(Console.ReadLine());
            decimal treasureMult = (treasureMultBase / 2) + 1;
            double mult1 = (double)(firstRedPoint -1)/ 5;
            mult1++;
            double mult2 = (double)(level - firstRedPoint) / 10;
            decimal healthNew = Math.Floor(decimal.Round((decimal)(health * (mult1+mult2)))*treasureMult);

            ColouredText($"&Stat at &{healthNew}& at level &{level}& with &{treasureMultBase * 100}%& treasures\n", ConsoleColor.White, ConsoleColor.DarkYellow);
            stop = true;
        }
        static void CalculateHigh(int level, int firstRedPoint, int secondRedPoint)
        {
            Console.WriteLine("Enter the base Stat value of a unit");
            int health = int.Parse(Console.ReadLine());

            ColouredText("&What treasure multiplier do you want? &100%& = &1&,& 200%& = &2&,& 300%& =& 3&, &no treasure& =& 0\n", ConsoleColor.White, ConsoleColor.DarkYellow);
            decimal treasureMultBase = decimal.Parse(Console.ReadLine());
            decimal treasureMult = (treasureMultBase / 2) + 1;
            decimal mult1 = (decimal)(firstRedPoint - 1) / 5;
            decimal mult2 = (decimal)(secondRedPoint - firstRedPoint) / 10;
            decimal mult3 = (decimal)(level - secondRedPoint) / 20;

            decimal healthNew = Math.Floor(health * (1 + mult1 + mult2 + mult3) * treasureMult);

            ColouredText($"&Stat at &{healthNew}& at level &{level}& with &{treasureMultBase * 100}%& treasures\n", ConsoleColor.White, ConsoleColor.DarkYellow);
            stop = true;
        }

        static void CalculateLow(int level)
        {
            Console.WriteLine("Enter the base stat value of a unit");
            int health = int.Parse(Console.ReadLine());

            ColouredText("&What treasure multiplier do you want? &100%& = &1&,& 200%& = &2&,& 300%& =& 3&, &no treasure& =& 0\n",ConsoleColor.White, ConsoleColor.DarkYellow);
            decimal treasureMultBase = decimal.Parse(Console.ReadLine());
            decimal treasureMult = (treasureMultBase / 2) + 1;
            level -= 1;
            double mult = (double)level / 5;
            mult++;
            decimal healthNew = Math.Floor(decimal.Round((decimal)(health * mult) * treasureMult));

            ColouredText($"&Stat at &{healthNew}& at level &{level}& with &{treasureMultBase * 100}%& treasures\n", ConsoleColor.White, ConsoleColor.DarkYellow);
            stop = true;
        }
        static bool stop = false;
        static void CatSats()
        {
            Console.WriteLine("Enter the level that you want");
            int level = int.Parse(Console.ReadLine());
            if (level > 20)
            {
                Console.WriteLine("Is your cat a crazed cat?(y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    CalculateMed(level, 20);
                }
                if (level > 30 && !stop)
                {
                    Console.WriteLine("Is your cat Bahamut Cat?(y/n)");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        CalculateMed(level, 30);
                    }
                }
                if (level > 60 && !stop)
                {
                    Console.WriteLine("Is your cat rare?(y/n)");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y" && level < 90)
                    {
                        CalculateMed(level, 70);
                    }
                    else if (level > 90 && answer == "y")
                    {
                        CalculateHigh(level, 70, 90);
                    }
                    else if (level < 80) 
                    {
                        CalculateMed(level, 60);
                    }
                    if (!stop)
                    {
                        Console.WriteLine("Is your cat normal/special?(y/n)");
                        string answer2 = Console.ReadLine().ToLower();
                        if (answer2 == "y")
                        {
                            CalculateMed(level, 60);
                        }
                        else
                        {
                            CalculateHigh(level, 60, 80);
                        }
                    }
                }
                else
                {
                    if (!stop)
                    {
                        CalculateLow(level);
                    }
                }
            }
            else
            {
                CalculateLow(level);
            }
            Console.WriteLine("\nPress enter to enter new cat stats");
            Console.ReadLine();
            stop = false;
            CatSats();
        }
    }
}
