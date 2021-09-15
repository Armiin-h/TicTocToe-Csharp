using System;

namespace TicTacToeAI
{
	public static class AI
	{
		public static bool wentFirst = false;
		public static bool moveSuccesful = false;

		public static int move = 0;
		public static int forkNum = 0;
		public static int thirdForkNum = 0;

        public static void AITurn()
        {
			Console.Clear();
            Console.WriteLine("It is the computers turn.");
            Program.PrintGameBoard();

            StrategyLoop();
			

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
			Program.CheckWinConditions();
            Program.PlayerTurn();
        }

        public static void StrategyLoop()
        {
			moveSuccesful = false;

            Win();
			if (moveSuccesful) { move++; return; }

            Block();
			if (moveSuccesful) { move++; return; }

			Fork();
			if (moveSuccesful) { move++; return; }

			BlockFork();
			if (moveSuccesful) {move++; return; }

			PlayCenter();
			if (moveSuccesful) { move++; return; }

			PlayOppositeCorner();
			if (moveSuccesful) { move++; return; }

			PlayEmptyCorner();
			if (moveSuccesful) { move++; return; }

			PlayEmptySide();
			if (moveSuccesful) { move++; return; }

		}

        public static void PlayEmptySide()
        {
			int[] b = Program.gameBoard;

			if (b[1] == 0) { b[1] = 2; moveSuccesful = true; return; }//top middle

			if (b[3] == 0) { b[3] = 2; moveSuccesful = true; return; }//middle left

			if (b[5] == 0) { b[5] = 2; moveSuccesful = true; return; }//middle right

			if (b[7] == 0) { b[7] = 2; moveSuccesful = true; return; }//bottom middle
		}

        public static void PlayEmptyCorner()
        {
			int[] b = Program.gameBoard;

            if (b[0] == 0) { b[0] = 2; moveSuccesful = true; return; }//top left

			if (b[2] == 0) { b[2] = 2; moveSuccesful = true; return; }//top right

			if (b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }//bottom left

			if (b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }//bottom right
		}

        public static void PlayOppositeCorner()
        {
			int[] b = Program.gameBoard;

			//top left, bottom right
            if (b[0] == 1 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }
			if (b[8] == 1 && b[0] == 0) { b[0] = 2; moveSuccesful = true; return; }

			//top right, bottom left
			if (b[2] == 1 && b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }
			if (b[6] == 1 && b[2] == 6) { b[8] = 2; moveSuccesful = true; return; }
		}

        public static void PlayCenter()
        {
			int[] b = Program.gameBoard;

            if(b [4] == 0) { b[4] = 2; moveSuccesful = true; return; }
        }

        public static void BlockFork()
        {
			int[] b = Program.gameBoard;

            if(move == 1)
			{
				if(b[0] == 1 && b[8] == 1 && b[4] == 2)
				{
					PlayEmptySide();
				}

				if (b[2] == 1 && b[6] == 1 && b[4] == 2)
				{
					PlayEmptySide();
				}
			}
        }

        public static void Fork()
        {
			int[] b = Program.gameBoard;
			Random random = new Random();

			if (wentFirst)
			{
				if (move == 0)
				{
					forkNum = random.Next(0, 4);

					if (forkNum == 0 && b[0] == 0) //top left first move
					{
						b[0] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 1 && b[2] == 0) //top right first move
					{
						b[2] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 2 && b[6] == 0)//bottom right first move
					{
						b[6] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 3 && b[8] == 0)
					{
						b[8] = 2;
						moveSuccesful = true;
						return;
					}
				}

				if (move == 1)
				{
					#region 1st option
					if (forkNum == 0 && b[8] == 0) //bottom right second move
					{
						b[8] = 2;
						moveSuccesful = true;
						return;
					}
					else if(forkNum == 0 && b[6] == 0)
					{
						b[6] = 2;
						moveSuccesful = true;
						return;
					}
					else if(forkNum == 0 && b[2] == 0)
					{
						b[2] = 2;
						moveSuccesful = true;
						return;
					}
					#endregion

					#region 2nd option
					if (forkNum == 1 && b[6] == 0) //bottom left second move
					{
						b[6] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[0] == 0)
					{
						b[0] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[8] == 0)
					{
						b[8] = 2;
						moveSuccesful = true;
						return;
					}
					#endregion

					#region 3rd option
					if (forkNum == 2 && b[2] == 0)//top right second move
					{
						b[2] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[0] == 0)
					{
						b[0] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[8] == 0)
					{
						b[8] = 2;
						moveSuccesful = true;
						return;
					}
					#endregion

					#region 4th option
					if (forkNum == 3 && b[0] == 0)//top left second move
					{
						b[0] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[6] == 0)
					{
						b[6] = 2;
						moveSuccesful = true;
						return;
					}
					else if (forkNum == 0 && b[2] == 0)
					{
						b[2] = 2;
						moveSuccesful = true;
						return;
					}
					#endregion
				}

				if (move == 2)
				{
					thirdForkNum = random.Next(0, 2);

					if (forkNum == 0 && thirdForkNum == 0 && b[2] == 0 || forkNum == 2 && thirdForkNum == 0 && b[2] == 0)// 1/2 first fork option
					{
						b[2] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 0 && thirdForkNum == 1 && b[6] == 0 || forkNum == 2 && thirdForkNum == 1 && b[6] == 0)// 2/2 second fork option
					{
						b[6] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 1 && thirdForkNum == 0 && b[0] == 0 || forkNum == 3 && thirdForkNum == 0 && b[0] == 0)// 1/2 first fork option
					{
						b[0] = 2;
						moveSuccesful = true;
						return;
					}

					if (forkNum == 1 && thirdForkNum == 1 && b[8] == 0 || forkNum == 3 && thirdForkNum == 1 && b[8] == 0)// 2/2 second fork option
					{
						b[8] = 2;
						moveSuccesful = true;
						return;
					}
				}
			}
        }

        public static void Block()
        {
			int[] b = Program.gameBoard;

			//Start of across
			if (b[0] == 0 && b[1] == 1 && b[2] == 1) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[1] == 0 && b[2] == 1) { b[1] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[1] == 1 && b[2] == 0) { b[2] = 2; moveSuccesful = true; return; }

			if (b[3] == 0 && b[4] == 1 && b[5] == 1) { b[3] = 2; moveSuccesful = true; return; }
			if (b[3] == 1 && b[4] == 0 && b[5] == 1) { b[4] = 2; moveSuccesful = true; return; }
			if (b[3] == 1 && b[4] == 1 && b[5] == 0) { b[5] = 2; moveSuccesful = true; return; }

			if (b[6] == 0 && b[7] == 1 && b[8] == 1) { b[6] = 2; moveSuccesful = true; return; }
			if (b[6] == 1 && b[7] == 0 && b[8] == 1) { b[7] = 2; moveSuccesful = true; return; }
			if (b[6] == 1 && b[7] == 1 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }
			//end of across

			//Start of vertical
			if (b[0] == 0 && b[3] == 1 && b[6] == 1) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[3] == 0 && b[6] == 1) { b[3] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[3] == 1 && b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }

			if (b[1] == 0 && b[4] == 1 && b[7] == 1) { b[1] = 2; moveSuccesful = true; return; }
			if (b[1] == 1 && b[4] == 0 && b[7] == 1) { b[4] = 2; moveSuccesful = true; return; }
			if (b[1] == 1 && b[4] == 1 && b[7] == 0) { b[7] = 2; moveSuccesful = true; return; }

			if (b[2] == 0 && b[5] == 1 && b[8] == 1) { b[2] = 2; moveSuccesful = true; return; }
			if (b[2] == 1 && b[5] == 0 && b[8] == 1) { b[5] = 2; moveSuccesful = true; return; }
			if (b[2] == 1 && b[5] == 1 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }
			//end of vertical

			//start of diagonal
			if (b[0] == 0 && b[4] == 1 && b[8] == 1) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[4] == 0 && b[8] == 1) { b[4] = 2; moveSuccesful = true; return; }
			if (b[0] == 1 && b[4] == 1 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }

			if (b[2] == 0 && b[4] == 1 && b[6] == 1) { b[2] = 2; moveSuccesful = true; return; }
			if (b[2] == 1 && b[4] == 0 && b[6] == 1) { b[4] = 2; moveSuccesful = true; return; }
			if (b[2] == 1 && b[4] == 1 && b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }//end of diagonal
		}

        public static void Win()
        {
			int[] b = Program.gameBoard;

			//Start of across
			if (b[0] == 0 && b[1] == 2 && b[2] == 2) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[1] == 0 && b[2] == 2) { b[1] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[1] == 2 && b[2] == 0) { b[2] = 2; moveSuccesful = true; return; }

			if (b[3] == 0 && b[4] == 2 && b[5] == 2) { b[3] = 2; moveSuccesful = true; return; }
			if (b[3] == 2 && b[4] == 0 && b[5] == 2) { b[4] = 2; moveSuccesful = true; return; }
			if (b[3] == 2 && b[4] == 2 && b[5] == 0) { b[5] = 2; moveSuccesful = true; return; }

			if (b[6] == 0 && b[7] == 2 && b[8] == 2) { b[6] = 2; moveSuccesful = true; return; }
			if (b[6] == 2 && b[7] == 0 && b[8] == 2) { b[7] = 2; moveSuccesful = true; return; }
			if (b[6] == 2 && b[7] == 2 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }
			//end of across

			//Start of vertical
			if (b[0] == 0 && b[3] == 2 && b[6] == 2) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[3] == 0 && b[6] == 2) { b[3] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[3] == 2 && b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }

			if (b[1] == 0 && b[4] == 2 && b[7] == 2) { b[1] = 2; moveSuccesful = true; return; }
			if (b[1] == 2 && b[4] == 0 && b[7] == 2) { b[4] = 2; moveSuccesful = true; return; }
			if (b[1] == 2 && b[4] == 2 && b[7] == 0) { b[7] = 2; moveSuccesful = true; return; }

			if (b[2] == 0 && b[5] == 2 && b[8] == 2) { b[2] = 2; moveSuccesful = true; return; }
			if (b[2] == 2 && b[5] == 0 && b[8] == 2) { b[5] = 2; moveSuccesful = true; return; }
			if (b[2] == 2 && b[5] == 2 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }
			//end of vertical

			//start of diagonal
			if (b[0] == 0 && b[4] == 2 && b[8] == 2) { b[0] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[4] == 0 && b[8] == 2) { b[4] = 2; moveSuccesful = true; return; }
			if (b[0] == 2 && b[4] == 2 && b[8] == 0) { b[8] = 2; moveSuccesful = true; return; }

			if (b[2] == 0 && b[4] == 2 && b[6] == 2) { b[2] = 2; moveSuccesful = true; return; }
			if (b[2] == 2 && b[4] == 0 && b[6] == 2) { b[4] = 2; moveSuccesful = true; return; }
			if (b[2] == 2 && b[4] == 2 && b[6] == 0) { b[6] = 2; moveSuccesful = true; return; }
			//end of diagonal
		}
    }
}