namespace TicTacToe
{
	internal static class Board
	{
		private static readonly Player[] Fields = Enumerable.Repeat(Player._, 9).ToArray();
		internal static bool Refresh(Player player, byte playerInput)
		{
			if (Fields[playerInput - 1] != Player._)
			{
				Console.WriteLine("This field is already occupied, try again.");
				return false;
			}
			Fields[playerInput - 1] = player;
			Console.Clear();
			Console.WriteLine($"{Fields[0]}|{Fields[1]}|{Fields[2]}\n-----\n{Fields[3]}|{Fields[4]}|{Fields[5]}\n-----\n{Fields[6]}|{Fields[7]}|{Fields[8]}");
			return true;
		}
		internal static void Refresh()
		{
			Console.Clear();
			Console.WriteLine($"{Fields[0]}|{Fields[1]}|{Fields[2]}\n-----\n{Fields[3]}|{Fields[4]}|{Fields[5]}\n-----\n{Fields[6]}|{Fields[7]}|{Fields[8]}");
		}
		internal static bool WinCheck(Player player)
		{
			if ((Fields[0] == player && Fields[1] == player && Fields[2] == player) ||
				(Fields[3] == player && Fields[4] == player && Fields[5] == player) ||
				(Fields[6] == player && Fields[7] == player && Fields[8] == player) ||
				(Fields[0] == player && Fields[3] == player && Fields[6] == player) ||
				(Fields[1] == player && Fields[4] == player && Fields[7] == player) ||
				(Fields[2] == player && Fields[5] == player && Fields[8] == player) ||
				(Fields[0] == player && Fields[4] == player && Fields[8] == player) ||
				(Fields[2] == player && Fields[4] == player && Fields[6] == player))
				return true;
			return false;

		}
		internal static bool SoftlockCheck()
		{
			foreach (Player field in Fields)
			{
				if (field == Player._)
					return false;
			}
			return true;
		}
	}
}
