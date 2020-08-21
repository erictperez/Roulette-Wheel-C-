using System;

namespace Roulette
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //Random ran = new Random();
        //var r = new Random();
        //string[] color = { "Red", "Black" };
        //string guess;
        //int attempts = 0;
        //int bet;
        //int money = 500;
        //while (money != 0)
        //{
        //Console.WriteLine("Roulette\n");
        //Console.WriteLine("Money:$" + money + "                  Attempts: " + attempts);
        //Console.WriteLine("Type in any off the following letters below:");
        //Console.WriteLine("a.Even    b.Odd    c.1 to 18    d.19 to 36");
        //Console.WriteLine("e.Red     f.Black  g.1st 12     h.2nd 12");
        //Console.WriteLine("i.3rd 12");
        //guess = (Console.ReadLine());
        ////guess verifier
        //guess.ToLower();
        //bool check = guess == "a" || guess == "b" || guess == "c" || guess == "d" || guess == "e" || guess == "f" || guess == "g" || guess == "h" || guess == "i";
        //if (check == false)
        //{
        //Console.WriteLine("You did not enter the correct input value(even/odd)");
        //Console.ReadKey();
        //Console.Clear();
        //continue;
        //}
        //else
        //{
        //bet:
        //Console.WriteLine("Enter an amount to bet");
        //bet = Convert.ToInt32(Console.ReadLine());
        ////bet verifier
        //if (bet > money)
        //{
        //Console.WriteLine("You dont have enough money!");
        //Console.WriteLine("Press enter to try again.");
        //Console.ReadKey();
        //goto bet;
        //}
        //else
        //{
        //money -= bet;
        //int roll = ran.Next(0, 37);
        //string ranColor = color[r.Next(color.Length)];
        //bool even = roll % 2 == 0;
        //if ((((guess == "a") && (even == true))) || (((guess == "b") && (even == false))) || ((guess == "e") && (ranColor == "Red") || (guess == "f") && (ranColor == "Black")))
        //{
        //Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
        //Console.WriteLine("You won! +$" + bet * 2 + "!");
        //Console.WriteLine("<Press enter to continue>");
        //money += bet * 2;
        //attempts += 1;
        //Console.ReadKey();
        //}
        //else if ((guess == "c") && ((roll > 0) && (roll < 19)))
        //{
        //Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
        //Console.WriteLine("You won! +$" + bet * 2 + "!");
        //Console.WriteLine("<Press enter to continue>");
        //money += bet * 2;
        //attempts += 1;
        //Console.ReadKey();
        //}
        //else if ((guess == "d") && ((roll > 18) && (roll < 37)))
        //{
        //Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
        //Console.WriteLine("You won! +$" + bet * 2 + "!");
        //Console.WriteLine("<Press enter to continue>");
        //money += bet * 2;
        //attempts += 1;
        //Console.ReadKey();
        //}
        //else if ((guess == "g") && (roll > 0 && roll < 13) || (guess == "h") && (roll > 12 && roll < 25) || (guess == "i") && (roll > 24 && roll < 37))
        //{
        //Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
        //Console.WriteLine("You won! +$" + bet * 2 + "!");
        //Console.WriteLine("<Press enter to continue>");
        //money += bet * 3;
        //attempts += 1;
        //Console.ReadKey();
        //}
        //else
        //{
        //Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
        //Console.WriteLine("You lost! -$" + bet + "!");
        //Console.WriteLine("<Press enter to continue>");
        //attempts += 1;
        //Console.ReadKey();
        //if (money == 0)
        //{
        //Console.WriteLine("You are out of money.");
        //Console.WriteLine("<Press enter to continue>");
        //Console.ReadKey();
        //}
        //}
        //}
        //}
        //Console.Clear();
        //}
        //}
        enum Bin { Black, Red };

        static void Main(string[] args)
        {
            for (int i = 2; i < 70; i++)
            {
                Console.SetWindowSize(i, i);
                System.Threading.Thread.Sleep(50);
            }
            Console.ForegroundColor = ConsoleColor.White;
            string[] color = { "Red", "Black" };
            string guess;

            while (true)
            {
                Console.WriteLine("Roulette\n");

                Console.WriteLine("You will need to Annotate Your Choice on a Piece of Paper & Compare it to the Dealer's Results\n");

                Console.WriteLine("Press Enter for The Dealer's Results!\n");

                Console.WriteLine("Thank You for Playing!\n");

                guess = (Console.ReadLine());

                Action<string> Wins = s =>

                Console.WriteLine($"{s} Wins! Congrats.");

                var rnd = new Random();

                var board = new Bin[12, 3]
                {
                 { Bin.Red,   Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Red,   Bin.Black },
                 { Bin.Red,   Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Red,   Bin.Black },
                 { Bin.Red,   Bin.Black, Bin.Red },
                 { Bin.Red,   Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Red,   Bin.Black },
                 { Bin.Red,   Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Black, Bin.Red },
                 { Bin.Black, Bin.Red,   Bin.Black },
                 { Bin.Red,   Bin.Black, Bin.Red }
                };
                Console.WriteLine("Dealer's Results ");
                var r = rnd.Next(38);
                Console.WriteLine($"Num = {r}");

                switch (r)
                {
                    case 0:
                        Wins("0");
                        Wins("Row");
                        Wins("Basket");
                        break;

                    case 37:
                        Wins("00");
                        Wins("Row");
                        Wins("Basket");
                        break;

                    default:
                        var i = r - 1;

                        var row = i / 3;
                        var col = i % 3;

                        // Numbers: the number of the bin

                        Wins(r.ToString());

                        // Evens/Odds: even or odd numbers
                        switch (r % 2)
                        {
                            case 0:
                                Wins("Even");
                                break;
                            case 1:
                                Wins("Odd");
                                break;
                        }

                        // Reds/Blacks: red or black colored numbers
                        switch (board[row, col])
                        {
                            case Bin.Black:
                                Wins("Black");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case Bin.Red:
                                Wins("Red");
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }

                        // Lows/Highs: Low (1 - 18) or high (19 - 38) Numbers.
                        if (row < 6)
                        {
                            Wins("Low");

                        }
                        else
                        {
                            Wins("High");

                        }

                        // Dozens: row thirds, 1 - 12, 13 - 24, 25 - 36
                        Wins($"Dozen {1 + (i / 12)}");

                        // Columns: first, second, or third columns
                        Wins($"Column {col + 1}");

                        // Street: rows, e.g., 1/2/3 or 22/23/24
                        Wins($"Street {row + 1}");

                        // 6 Numbers: double rows, e.g., 1/2/3/4/5/6 or 22/23/24/25/26/26
                        if (row == 0)
                        {
                            Wins("Basket");
                            Wins("'6th' Line #1");
                        }
                        else if (row == 11)
                        {
                            Wins($"'6th' Line #11");
                        }
                        else
                        {
                            Wins($"'6th' Line #{row}");
                            Wins($"'6th' Line #{row + 1}");
                        }

                        // Split: at the edge of any two contiguous numbers, e.g., 1/2, 11/14, and 35/36
                        if (row > 0)
                        {
                            Wins($"{r - 3}/{r} Split");
                        }

                        if (row < 11)
                        {
                            Wins($"{r}/{r + 3} Split");
                        }

                        // Left
                        if (col > 0)
                        {
                            Wins($"{r - 1}/{r} Split");
                        }

                        // Right
                        if (col < 2)
                        {
                            Wins($"{r}/{r + 1} Split");
                        }

                        // Corner: at the intersection of any four contiguous numbers, e.g., 1/2/4/5, or 23/24/26/27
                        // UL
                        if (row > 0 && col > 0)
                        {
                            Wins($"{r - 4}/{r - 3}/{r - 1}/{r} Corner");
                        }

                        // UR
                        if (row > 0 && col < 2)
                        {
                            Wins($"{r - 3}/{r - 2}/{r}/{r + 1} Corner");
                        }

                        // DL
                        if (row < 11 && col > 0)
                        {
                            Wins($"{r - 1}/{r}/{r + 2}/{r + 3} Corner");
                        }

                        // DR
                        if (row < 11 && col < 2)
                        {
                            Wins($"{r}/{r + 1}/{r + 3}/{r + 4} Corner");
                        }

                        break;
                }

                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
