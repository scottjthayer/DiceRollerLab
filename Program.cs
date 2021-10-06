using System;

namespace Casino_Dice_Roller_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Scott's Amazing Casino Dice Roller Application!");
            int sides = GetSides();
            Roll(sides);
            Console.WriteLine("\nThank you for playing!");
        }

        public static bool Roll(int sides)
        {
            bool rollAgain = GetYesOrNo($"Would you like to roll your {sides} sided dice?");
            while (rollAgain == true)
            {
                int roll1 = GetDiceRoll(sides);
                int roll2 = GetDiceRoll(sides);
                Console.WriteLine($"\nYou rolled a {roll1} and a {roll2}. Totaling {roll1 + roll2}.");
                if (sides == 6)
                {
                    Console.WriteLine(SixSided(roll1, roll2));
                }
                rollAgain = GetYesOrNo("Would you like to roll again?");
            }
            return rollAgain;
        }
        public static int GetSides()
        {
            int sides = 0;
            ////used for Alternative TryParse
            //string input = "";
            //bool isInt = false;
            while (true)
            {   
                try
                {
                    Console.WriteLine("Please enter number of sides for your pair of dice.");
                    sides = int.Parse(Console.ReadLine());
                    
                    if (sides <= 0)
                    {
                        throw new Exception("Needs to be greater than 0.");
                    }
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("That wasn't a number. Please enter a number");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ////Alternative with TryParse instead of try catch.
                //Console.WriteLine("Please enter number of sides for the pair of dice.");
                //input = Console.ReadLine();
                //isInt = int.TryParse(input, out sides);
                //if (isInt == true)
                //{
                //    Console.WriteLine($"You chose {sides} sides for your dice pair.");
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine("That is not a valid side count.");
                //    continue;
                //}
                
            }
            return sides;
        }
        public static string SixSided(int r1, int r2)
        {
            string message = "";

            int sumRoll = r1 + r2;
            if (sumRoll == 2 || sumRoll == 3 || sumRoll == 12)
            {
                message = "Craps!";
                if (r1 == 6 && r2 == 6)
                {
                    message = "Boxcars.\nCraps!";
                }
                else if (r1 == 1 && r2 == 1)
                {
                    message = "Craps!\nSnake Eyessss.";
                }
                else if ((r1 == 1 && r2 == 2) || (r1 == 2 && r2 == 1))
                {
                    message = "Craps!\nAce Deuce.";
                }
            }
            else if (sumRoll == 7 || sumRoll == 11)
            {
                message = "Win!";
            }
            return message;
        }
        public static int GetDiceRoll(int sides)
        {
            int roll = 0;

            Random rand = new Random();
            roll = rand.Next(1, sides + 1);

            return roll;
        }
        public static bool GetYesOrNo(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                Console.Write("Y/N? ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("That input is not valid, please try again.");
                }
            }
        }
    }
}
