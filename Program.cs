using System;

namespace TicTacToeAI
{
    class Program
    {
		public static int iterations = 0;
		public static int turn = 0;

		public static int[] gameBoard = new int[9];

		public static Random random = new Random();

        static void Main(string[] args)
        {
			Console.Clear();

			if(iterations == 0)
			{
				Console.WriteLine("Heads or Tails?");
				string choice = Console.ReadLine().ToLower();

				Start(choice);
			}
			iterations++;
			Console.Clear();

			switch (turn)
			{
				case 0:
					PlayerTurn();
					break;
				case 1:
					AI.AITurn();
					break;
			}

        }

		public static void Start(string choice)
		{
			int coinFlip = random.Next(1, 3);

			switch (choice)
			{
				case "heads":
					
					if (coinFlip == 1)
					{
						Console.WriteLine("You won the coinflip so you go first.  You are Xs.  Press any key to continue.");
						turn = 0;
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("You lost the coinflip so you go second.  You are Xs.  Press any key to continue.");
						AI.wentFirst = true;
						turn = 1;
						Console.ReadKey();
					}
					break;
				case "tails":
					if (coinFlip == 2)
					{
						Console.WriteLine("You won the coinflip so you go first.  You are Xs.  Press any key to continue.");
						turn = 0;
						Console.ReadKey();
					}
					else
					{
						Console.WriteLine("You lost the coinflip so you go second.  You are Xs.  Press any key to continue.");
						AI.wentFirst = true;
						turn = 1;
						Console.ReadKey();
					}
					break;
				default:
					Console.WriteLine("Please choose heads or tails.  Press any button to continue.");
					Console.ReadKey();
					Main(new string[0]);
					break;
			}
		}

		public static void PlayerTurn()
		{
			Console.Clear();
			Console.WriteLine("Its your turn.");

			PrintGameBoard();
			Console.WriteLine("Which slot would you like to place an x?");

			string choice = Console.ReadLine();
			int a;
			int.TryParse(choice, out a);
			
			if(a <= 0 || a > 9)
			{
				Console.WriteLine("You did not choose a valid place.  Press any key to try again.");
				Console.ReadKey();
				PlayerTurn();
			}
			
			if(gameBoard[int.Parse(choice) - 1] == 0)
				gameBoard[int.Parse(choice)-1] = 1;
			else
			{
				Console.WriteLine("You did not choose a valid place.  Press any key to try again.");
				Console.ReadKey();
				PlayerTurn();
			}
			
			CheckWinConditions();
			AI.AITurn();
		}

		public static void PrintGameBoard()
		{
			string VisualGameBoard = "";

			for (int i = 0; i < gameBoard.Length; i++)
			{
				if (i == 3 || i == 6)
					VisualGameBoard += "\r\n";

				switch (gameBoard[i])
				{
					case 0:
						VisualGameBoard += " _";
						break;
					case 1:
						VisualGameBoard += " X";
						break;
					case 2:
						VisualGameBoard += " O";
						break;

				}
			}
			Console.WriteLine(VisualGameBoard);
		}

		public static void CheckWinConditions()
		{
			int[] b = gameBoard;
			if (b[0] == 1 && b[1] == 1 && b[2] == 1) { Win(1); }//Start of x win conditions
			if (b[3] == 1 && b[4] == 1 && b[5] == 1) { Win(1); }
			if (b[6] == 1 && b[7] == 1 && b[8] == 1) { Win(1); }
			if (b[0] == 1 && b[3] == 1 && b[6] == 1) { Win(1); }
			if (b[1] == 1 && b[4] == 1 && b[7] == 1) { Win(1); }
			if (b[2] == 1 && b[5] == 1 && b[8] == 1) { Win(1); }
			if (b[0] == 1 && b[4] == 1 && b[8] == 1) { Win(1); }
			if (b[2] == 1 && b[4] == 1 && b[6] == 1) { Win(1); }//end of x win conditions

			if (b[0] == 2 && b[1] == 2 && b[2] == 2) { Win(2); }//Start of o win conditions
			if (b[3] == 2 && b[4] == 2 && b[5] == 2) { Win(2); }
			if (b[6] == 2 && b[7] == 2 && b[8] == 2) { Win(2); }
			if (b[0] == 2 && b[3] == 2 && b[6] == 2) { Win(2); }
			if (b[1] == 2 && b[4] == 2 && b[7] == 2) { Win(2); }
			if (b[2] == 2 && b[5] == 2 && b[8] == 2) { Win(2); }
			if (b[0] == 2 && b[4] == 2 && b[8] == 2) { Win(2); }
			if (b[2] == 2 && b[4] == 2 && b[6] == 2) { Win(2); }//end of o win conditions

			int catsGameCounter = 0;

			for (int i = 0; i < b.Length; i++)
			{
				if(b[i] != 0) { catsGameCounter++; }
			}

			if(catsGameCounter == 9) { Win(0); }
		}

		public static void Win(int i)
		{
			Console.Clear();
			if(i == 1)
			{
				PrintGameBoard();
				Console.WriteLine("You won!  Press any key to start again.");
				Console.ReadKey();
				ResetGame();
				iterations = 0;
				Main(new string[0]);
			}
			else if(i == 2)
			{
				PrintGameBoard();
				Console.WriteLine("You lost.  Press any key to start again.");
				Console.ReadKey();
				ResetGame();
				iterations = 0;
				Main(new string[0]);
			}else if(i == 0)
			{
				PrintGameBoard();
				Console.WriteLine("Its a cats game!  Press any key to start again");
				Console.ReadKey();
				ResetGame();
				iterations = 0;
				Main(new string[0]);


			}
		}

		public static void ResetGame()
		{
			for (int i = 0; i < gameBoard.Length; i++)
			{
				gameBoard[i] = 0;
			}

			AI.wentFirst = false;
			AI.moveSuccesful = false;

			AI.move = 0;
			AI.forkNum = 0;
			AI.thirdForkNum = 0;
		}
    }
}