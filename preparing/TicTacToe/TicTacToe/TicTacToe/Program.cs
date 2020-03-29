using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        const string USER_SYMBOL = "X";
        const string COMPUTER_SYMBOL = "O";
        const string EMPTY = "";

        const int SIZE = 3;

        // constants for the 2 diagonals
        const int TOP_LEFT_TO_BOTTOM_RIGHT = 1;
        const int TOP_RIGHT_TO_BOTTOM_LEFT = 2;

        // constants for IsWinner
        const int NONE = -1;
        const int ROW = 1;
        const int COLUMN = 2;
        const int DIAGONAL = 3;

        static void Main(string[] args)
        {

            int row = -1, column = -1;
            int winningDimension, winningValue;
            bool playersTurn = false;

            /*
            declare the rectangular array board and set it equal to the value returned from CreateBoard

            do
            {
                set playersTurn to the opposite of what it is now
                Call DrawBoard
                if it's the players turn
                    Display a message
                    Call GetRowAndColumn
                    set the cell on the board at row, column = users symbol
                else
                    Display a message
                    You might want to pause here
                    Call GetComputerRowAndColumn
                    set the cell on the board at row, column = users symbol
                }
                Call DrawBoard
            }
            while ( no one has won yet );
            You might want to pause here
            if it's the players turn 
                display a message that they just won
            else
                display a message that the computer won
            */
            // my values
            string[,] board = CreateBoard();
            bool fullboard_check = false;
            bool play_again = false;
            bool play_input_correct = false;

            do   //main game loop
            {
                //Resetting for new game!
                winningDimension = 0;
                winningValue = 0;
                fullboard_check = false;
                play_again = false;
                play_input_correct = false;
                Array.Clear(board, 0, board.Length);
                board = CreateBoard();

                do // Game start!
                {
                    playersTurn = !playersTurn;
                    DrawBoard(board);
                    if (playersTurn)
                    {
                        Console.WriteLine("Your turn!");
                        GetRowAndColumn(board, ref row, ref column);
                        //board[row, column] = USER_SYMBOL;
                    }
                    else
                    {
                        Console.WriteLine("Computer's Turn.");
                        Pause();
                        GetComputerRowAndColumn(board, ref row, ref column);
                        //board[row, column] = COMPUTER_SYMBOL;
                    }
                    DrawBoard(board);
                    fullboard_check = IsFull(board);
                }
                while ((!IsWinner(board, out winningDimension, out winningValue)) && (!fullboard_check));
                Pause();
                if (!fullboard_check)
                {
                    if (playersTurn)
                    {
                        Console.WriteLine("Congratulations, You won!");
                    }
                    else
                    {
                        Console.WriteLine("Muahahahha, I win!");
                    }

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Tie Game!");
                }

                do
                {
                    Console.WriteLine("Would you like to play again?");
                    switch (Console.ReadLine())
                    {
                        case "yes":
                        case "Yes":
                        case "Y":
                        case "y":
                            play_again = true;
                            play_input_correct = true;
                            break;
                        case "no":
                        case "No":
                        case "N":
                        case "n":
                            play_again = false;
                            play_input_correct = true;
                            break;
                        default:
                            play_input_correct = false;
                            break;
                    }
                } while (!play_input_correct);
                

            } while (play_again);
        }

        static string[,] CreateBoard()
        {
            string[,] board = new string[SIZE, SIZE];
            /*
             * for row = 0 to size - 1
             *      for column = 0 to size - 1      
             *      set the value in the cell at row, column to EMPTY
             *      end for column
             *  end for row
            */
            for (int row = 0; row < SIZE; row++)
            {
                for (int column = 0; column < SIZE; column++)
                {
                    board[row, column] = EMPTY;
                }
            }
            
            return board;
        }

        // generic method that gets an integer in the specified range from the user
        static int GetInt(string label, int min, int max)
        {
            bool isInt = false;
            int number = min - 1;
            do
            {
                Console.Write(String.Format("Please enter a whole number between {0} and {1} for {2}: ", min, max, label));
                string input = Console.ReadLine();
                isInt = int.TryParse(input, out number);
            } while (!(isInt && number >= min && number <= max));

            return number;
        }

        static void GetRowAndColumn(string[,] board, ref int row, ref int column)
        {
            /*
            do
                // get the row from the user   
                                              ^ added the "-1 here so user doesnt blow the stack
                // get the column from the user
                                                ^ added the "-1 here so user doesnt blow the stack
            while (the cell at row, column isn't empty);   
                                            ^ is?
            */
            bool first_assigned_to_spot = false; //bug fix for computer or player skipping turn.
            do
            {
                Console.WriteLine("Please Enter the Row : ");
                row = GetInt(USER_SYMBOL, 0, SIZE-1);
                Console.WriteLine("Please Enter the Column :");
                column = GetInt(USER_SYMBOL, 0, SIZE-1);
                if(board[row, column] != EMPTY) //check if anything in it.
                {
                    continue;  // woops already taken, try again.
                }
                board[row, column] = USER_SYMBOL; //asigns it
                first_assigned_to_spot = true; // allows exit now that it's not empty.
            } while (board[row,column] == EMPTY || first_assigned_to_spot == false);
        }

        static void GetComputerRowAndColumn(string[,] board, ref int row, ref int column)
        {
            /*
            do
                // randomly generate the row
                // randomly generate the column
            while (the cell at row, column isn't empty);
            */
            Random rn = new Random();
            bool first_assigned_to_spot = false; //bug fix for computer or player skipping turn.
            do
            {
                row = rn.Next(0, SIZE);
                column = rn.Next(0, SIZE);
                if (board[row, column] != EMPTY) //check if anything in it.
                {
                    continue; // woops already taken, try again.
                }
                board[row, column] = COMPUTER_SYMBOL; //asigns it
                first_assigned_to_spot = true; // allows exit now that it's not empty.
            } while (board[row, column] == EMPTY || first_assigned_to_spot == false);
        }

        // This method takes a row (in the range of 0 - 4) and returns true if 
        //                          ^^shouldn't it be 0 -3?
        // the row on the form contains 5 Xs or 5 Os.
        //                          ^^ for 3Xs or 3Os?
        // Use it as a model for writing IsColumnWinner
        static bool IsRowWinner(string[,] board, int row)
        {
            string symbol = board[row, 0];
            for (int col = 0; col < SIZE; col++)
            {
                if (symbol == EMPTY || board[row, col] != symbol)
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsColumnWinner(string[,] board, int col)
        {
            string symbol = board[0, col];
            for (int row = 0; row < SIZE; row++)
            {
                if(symbol == EMPTY || board[row,col] != symbol)
                    return false;
            }
            return true;
        }

        static bool IsDiagonal1Winner(string[,] board)
        {
            // the row and the column are both the same on diagonal 1
            string symbol = board[0, 0];
            if(symbol != EMPTY)
            {
                if(symbol == board[1,1] && symbol == board[2,2])
                {
                    return true;
                }

            }           
            return false;
        }

        static bool IsDiagonal2Winner(string[,] board)
        {
            // the row gets bigger as the column gets smaller on diagonal 2
            string symbol = board[2, 0];
            if (symbol != EMPTY)
            {
                if (symbol == board[1, 1] && symbol == board[0, 2])
                {
                    return true;
                }

            }
            return false;
        }

        static bool IsFull(string[,] board)
        {
            /*
             * for row = 0 to size - 1
             *      for column = 0 to size - 1
             *          if the cell at row, column is empty
             *              return false
             *      end for column
             *  end for row
            */
            for(int row = 0; row < SIZE; row++)
            {
                for (int column = 0; column < SIZE; column++)
                {
                    if (board[row, column] == EMPTY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // This method determines if any row, column or diagonal on the board is a winner.
        // It returns true or false and the output parameters will contain appropriate values
        // when the method returns true.  See constant definitions at top of the file.
        static bool IsWinner(string[,] board, out int whichDimension, out int whichOne)
        {
            // rows
            for (int row = 0; row < SIZE; row++)
            {
                if (IsRowWinner(board, row))
                {
                    whichDimension = ROW;
                    whichOne = row;
                    return true;
                }
            }
            // columns
            for (int column = 0; column < SIZE; column++)
            {
                if (IsColumnWinner(board, column))
                {
                    whichDimension = COLUMN;
                    whichOne = column;
                    return true;
                }
            }
            // diagonals
            if (IsDiagonal1Winner(board))
            {
                whichDimension = DIAGONAL;
                whichOne = TOP_LEFT_TO_BOTTOM_RIGHT;
                return true;
            }
            if (IsDiagonal2Winner(board))
            {
                whichDimension = DIAGONAL;
                whichOne = TOP_RIGHT_TO_BOTTOM_LEFT;
                return true;
            }
            whichDimension = NONE;
            whichOne = NONE;
            return false;
        }

        // I wrote this method to show you how to call IsWinner
        static bool IsTie(string[,] board)
        {
            int winningDimension, winningValue;
            return (IsFull(board) && !IsWinner(board, out winningDimension, out winningValue));
        }

        // this method can be used to pause
        static void Pause()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        // these 2 methods can be used for drawing the board on the screen
        // center is called by DrawBoard
        static String Center(String text, int len)
        {
            if (len <= text.Length)
                return text.Substring(0, len);
            int before = (len - text.Length) / 2;
            int after = len - text.Length - before;
            return new String(' ', before) + text + new String(' ', after);
        }

        static void DrawBoard(string[,] board)
        {
            Console.Clear();
            int index = 0;
            string top = ".=============";
            string second = "|             ";
            string middle = "|";
            string output;
            ConsoleColor defaultColor = Console.ForegroundColor;

            // column headings
            Console.Write(Center(top, 4));
            for (int c = 0; c < SIZE; c++)
                Console.Write(top);
            Console.Write(".\n");
            Console.Write(Center(second, 4));
            for (int c = 0; c < SIZE; c++)
            {
                output = Center(c.ToString(), 13);
                Console.Write(middle + output);
            }
            Console.Write("|\n");

            for (int r = 0; r < SIZE; r++)
            {
                Console.Write(Center(top, 4));
                for (int c = 0; c < SIZE; c++)
                    Console.Write(top);
                Console.Write(".\n");

                Console.Write(Center(second, 4));
                for (int c = 0; c < SIZE; c++)
                    Console.Write(second);
                Console.Write("|\n");

                Console.Write(middle + Center(r.ToString(), 3));
                for (int c = 0; c < SIZE; c++)
                {
                    output = Center(board[r, c], 13);
                    Console.Write(middle + output);
                    index++;
                }
                Console.Write("|\n");

                Console.Write(Center(second, 4));
                for (int c = 0; c < SIZE; c++)
                    Console.Write(second);
                Console.Write("|\n");
            }
            Console.Write(Center(top, 4));
            for (int c = 0; c < SIZE; c++)
                Console.Write(top);
            Console.Write(".\n");
        }
    }
}
