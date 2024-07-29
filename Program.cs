using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Channels;

namespace TicTacToe
{

    
    internal class Program
    {
        public static bool Checker(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++) { 
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, 0] == board[i, 1] &&
                        board[i, 0] == board[i, 2]
                        )
                    {
                        return true;
                    }
                    //Vertical win
                    else if (board[0, j] == board[1, j] && board[0, j] == board[2, j])
                    {
                        return true;
                    }
                    else if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])|| (board[1, 1] == board[0,2] && board[1, 1] == board[2,0])) 
                    {
                        return true;
                    
                    }
                }        
            }
            //Default 
            return false;
        }

        public static bool InputChecker(string[,] board, string boardPosition)

        {
            bool openPosition;
            switch (boardPosition)
            {
                case "1" when board[0, 0] == "1":
                    openPosition = true;
                    break;
                case "2" when board[0, 1] == "2":
                    openPosition = true;
                    break;
                case "3" when board[0, 2] == "3":
                    openPosition = true;
                    break;
                case "4" when board[1, 0] == "4":
                    openPosition = true;
                    break;
                case "5" when board[1, 1] == "5":
                    openPosition = true;
                    break;
                case "6" when board[1, 2] == "6":
                    openPosition = true;
                    break;
                case "7" when board[2, 0] == "7":
                    openPosition = true;
                    break;
                case "8" when board[2, 1] == "8":
                    openPosition = true;
                    break;
                case "9" when board[2, 2] == "9":
                    openPosition = true;
                    break;

                default:
                    openPosition = false;

                    break;
            }

            return openPosition;
        }

        public static string[,] PostionUpdater(string[,] board, string boardPosition, string player) 

        {
            string[,] updatedBoard = board;

            switch (boardPosition)
            {
                case "1" when updatedBoard[0, 0] == "1":
                    updatedBoard[0, 0] = player;
                    break;
                case "2" when updatedBoard[0, 1] == "2":
                    updatedBoard[0, 1] = player;
                    break;
                case "3" when updatedBoard[0, 2] == "3":
                    updatedBoard[0, 2] = player;
                    break;
                case "4" when updatedBoard[1, 0] == "4":
                    updatedBoard[1, 0] = player;
                    break;
                case "5" when updatedBoard[1, 1] == "5":
                    updatedBoard[1, 1] = player;
                    break;
                case "6" when updatedBoard[1, 2] == "6":
                    updatedBoard[1, 2] = player;
                    break;
                case "7" when updatedBoard[2, 0] == "7":
                    updatedBoard[2, 0] = player;
                    break;
                case "8" when updatedBoard[2, 1] == "8":
                    updatedBoard[2, 1] = player;
                    break;
                case "9" when updatedBoard[2, 2] == "9":
                    updatedBoard[2, 2] = player;
                    break;

                default:
                    updatedBoard[0, 0] = updatedBoard[0, 0];
                   
                    break;
            }

            return updatedBoard;
        }

        public static string[,] ClearBoard() {
           string[,] gameBoard = new string[,]
           {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
           };

            return gameBoard;
        }
      
       
        
        
        public static void DisplayBoard(string[,] board)
        {
            Console.Clear();
            //Display board
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)

                {
                    Console.Write(board[i, j] + " ");

                }
                Console.WriteLine(" ");
            }
            Console.WriteLine();


        }
        static void Main(string[] args)
        {

            //Start an active board
            string[,] activeBoard = ClearBoard();
            string[] numberedPositions = {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
          
            //Players
            string playerOne = "Player 1";
            string playerTwo = "Player 2";
            string player;
            //Assign player tokens
            string playerOneX = "X";
            string playerTwoO = "O";
            string playerToken;
            bool winner = false;

            string position = "n";
            string letsPlay = "y";
            bool game = true;

            while(game)
            {
                //Start a new active board
                activeBoard = ClearBoard();
                player = playerOne;
                playerToken = playerOneX;
                
                //Display active Board
                while (winner == false)
                {
                    DisplayBoard(activeBoard);
                    //Start turn
                    bool validPosition = false;
                    while (validPosition == false)
                    {
                        Console.WriteLine(player + ": Choose your field");
                        position = Console.ReadLine();
                        validPosition = InputChecker(activeBoard, position);
                     }
                    
                   // Console.WriteLine("Out of position validating loop, updating board");
                    //UpdateBoard
                    activeBoard = PostionUpdater(activeBoard, position, playerToken);
                    DisplayBoard(activeBoard);
                    //Check for winner

                    winner = Checker(activeBoard);

                    if (winner == true)
                    {
                        Console.WriteLine("Congrats on the win! " + player);
                    }
                    else
                    {
                        int total = 0;
                        //Check that there are open positions in the boardstring
                        foreach (string spot in numberedPositions) 
                        { 
                            validPosition =InputChecker(activeBoard, spot);
                            if (validPosition == true)
                            {
                                total = total + 1;
                            }
                            else {
                                total = total;
                            
                            }
                        
                        }
                        if (total == 0) {
                            winner = true;
                            Console.WriteLine("There are no more positions in the board, there is no winner");
                        }

                    
                    }


                    if(player == playerOne)
                    {
                        player = playerTwo;
                        playerToken = playerTwoO;
                    }
                    else
                    {
                        player = playerOne;
                        playerToken = playerOneX;
                    }

                   
                   
                }


               // Console.WriteLine("Out of the while loop");
                Console.WriteLine("Let's play again, press 'N' to end the game");
                letsPlay = Console.ReadLine();
                if(letsPlay == "N")
                {
                        game = false;
                }else 
                { 
                        game = true;
                        winner = false;
                 }
            }


            DisplayBoard(activeBoard);
            Console.WriteLine("Good Bye!");
            


            Console.ReadKey();

        }

      
        
    }
}
