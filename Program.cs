namespace TicTacToe
{
	internal enum Player { O, X, _ };

	internal class Program
	{
		internal static void Main()
		{
			Player player = Player.X;
			byte playerInput;
			bool isWin;
			Board.Refresh();
			do
			{
				player = player == Player.O ? Player.X : Player.O;
				Console.WriteLine($"Player {player} move: ");
				do
				{
					while (!byte.TryParse(Console.ReadLine(), out playerInput) || playerInput == 0 || playerInput > 9) ;
					Console.WriteLine("Incorrect value, try again.");
				}
				while (!Board.Refresh(player, playerInput));
			}
			while (!((isWin = Board.WinCheck(player)) || Board.SoftlockCheck()));
			if (isWin)
				Console.WriteLine($"Player {player}  won!");
			else
				Console.WriteLine("Softlock detected, draw!");
		}
	}

}