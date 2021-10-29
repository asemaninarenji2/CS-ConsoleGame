using System;

namespace Game
{
    class Program
    {
        static string[] players = new string[2];
        static int activePlayer = 0;
        static string[,] gameData = new string[,] { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };
        static int gameCounter = 0;

        //current location
        static int xParsed;
        static int YParsed;


        static void Main(string[] args)
        {
            PlayersInitiation();

            //LOOP START
            do
            {
                GameBoard();
                
                do
                {
                    AskNewLocation();

                } while (!CheckValidXY());

                UpdateTheBoard();
                
                if (!CheckWinner()) 
                    ActivePlayerToggle();
                else 
                    break;

            } while (gameCounter<9);
            // LOOP END
            // 

            if (gameCounter > 8)
            {
                Console.WriteLine("\n<<< NO WINNWER THIS TIME! TRY AGAIN>>>\n Any key to terminate");

            }
            else
            {
                ShowWinner();
                Console.WriteLine("Any key to terminate");
                Console.ReadKey();
            }
        }


        public static void PlayersInitiation()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.WriteLine("WELCOME TO X-O GAME");

            Console.Write("Player1's name Please: ");
            players[0] = Console.ReadLine();

            Console.Write("Player2's name Please: ");
            players[1] = Console.ReadLine();

            Console.WriteLine($"{players[0]}: X   AND   {players[1]}:O");

        }


        // 2.Draw the game graphics  -> 9 squars in a big squar with "0" in their centers
        public static void GameBoard()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.SetCursorPosition(0,5);
            Console.WriteLine($"{players[0]}:X       VS.     {players[1]}:O");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine($"|    {gameData[0, 0]}     |     {gameData[0, 1]}    |     {gameData[0, 2]}    |");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine($"|    {gameData[1, 0]}     |     {gameData[1, 1]}    |     {gameData[1, 2]}    |");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine($"|    {gameData[2, 0]}     |     {gameData[2, 1]}    |     {gameData[2, 2]}    |");
            Console.WriteLine("|          |          |          |");
            Console.WriteLine(" --------------------------------");
        }
        // 3.show the active player and ask for a location to mark
        // ex: Alen =>x=   ,y=

        public static void AskNewLocation()
        {
            Console.Write($"{players[activePlayer]} X:");
            int x = Console.ReadKey().KeyChar;
            Console.Write("  AND Y: ");
            int y = Console.ReadKey().KeyChar;

            //TODO: CHECK IF THE RIGHT (CHAR | NUMBER) ENTERED
            xParsed = Convert.ToUInt16(Convert.ToChar(x) + "");
            YParsed = Convert.ToUInt16(Convert.ToChar(y) + "");

            
        }

        public static Boolean CheckValidXY()
        {
            if (gameData[xParsed, YParsed] != "-")
            {
                Console.WriteLine("the squar is already TAKEN! TRY AGAIN");
                //Console.ReadKey();
                return false;
            }
            //CHECK IF THE ENTERED ARE WITHIN RANGE
            //if (){  return false;}

            return true;
            
        }

        public static void UpdateTheBoard()
        {
            string fit = activePlayer == 0 ? "X" : "O";
            gameData[xParsed, YParsed] = fit;
            gameCounter++;


        }

        public static Boolean CheckWinner()
        {
            //
            bool firstRow  = gameData[0, 0] == gameData[0, 1] && gameData[0, 0] == gameData[0, 2] && gameData[0,0] != "-";
            bool secondRow = gameData[1, 0] == gameData[1, 1] && gameData[1, 0] == gameData[1, 2] && gameData[1, 0] != "-";
            bool thirdRow  = gameData[2, 0] == gameData[2, 1] && gameData[2, 0] == gameData[2, 2] && gameData[2, 0] != "-";

            //
            bool firstColumn  = gameData[0, 0] == gameData[1, 0] && gameData[0, 0] == gameData[2, 0] && gameData[2, 0]!= "-";
            bool secondColumn = gameData[0, 1] == gameData[1, 1] && gameData[0, 1] == gameData[2, 1] && gameData[2, 1] != "-";
            bool thirdColumn  = gameData[0, 2] == gameData[1, 2] && gameData[0, 2] == gameData[2, 2] && gameData[2, 2] != "-";

            //main diag
            bool mainDiag = gameData[0, 0] == gameData[1, 1] && gameData[0, 0] == gameData[2, 2] && gameData[2, 2] != "-";
            //second diag
            bool secondDiag = gameData[0, 2] == gameData[1, 1] && gameData[0, 2] == gameData[2, 0] && gameData[2, 0] != "-";
            
            /*Console.WriteLine("{0}{1}{2}", firstRow, secondRow, thirdRow);
            Console.WriteLine("{0}{1}{2}", firstColumn, secondColumn, thirdColumn);
            Console.WriteLine("{0}{1}", mainDiag, secondDiag);
            */

            if (firstRow || secondRow || thirdRow ||
                    firstColumn || secondColumn || thirdColumn ||
                        mainDiag || secondDiag)

            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

        public static void ShowWinner()
        {
            GameBoard();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("the winner is: {0}", players[activePlayer]);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void ActivePlayerToggle()
        {
            activePlayer = activePlayer == 0 ? 1 : 0;
        }


        // 4.Check winner:
        //          a. Winning conditions satisfied: --> show the winner
        //                                      game ends
        //          b. No winnig yet  --> SWAP the active player and GO to STEP 3 

    }
}
