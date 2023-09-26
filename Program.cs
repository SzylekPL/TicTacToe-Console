class Program
{
	public static class Board
	{
		private enum Field {O, X, E};
		private static readonly Field[] Fields = Enumerable.Repeat(Field.E, 9).ToArray();
		public static bool Refresh(bool edit = false, byte Title = 1, byte Player = 1)
		{
			if (Fields[(uint)Title - 1] == Field.O || Fields[(uint)Title - 1] == Field.X)
				return true;
			Console.Clear();
			if (edit)
				Fields[Title-1] = (Field)Player;
			Console.WriteLine($"{Fields[0]}|{Fields[1]}|{Fields[2]}\n-----\n{Fields[3]}|{Fields[4]}|{Fields[5]}\n-----\n{Fields[6]}|{Fields[7]}|{Fields[8]}");
			return false;
		}
		public static bool WinCheck(ushort a)
		{
			if ((Fields[0] == (Field)a && Fields[1] == (Field)a && Fields[2] == (Field)a) ||
				(Fields[3] == (Field)a && Fields[4] == (Field)a && Fields[5] == (Field)a) ||
				(Fields[6] == (Field)a && Fields[7] == (Field)a && Fields[8] == (Field)a) ||
				(Fields[0] == (Field)a && Fields[3] == (Field)a && Fields[6] == (Field)a) ||
				(Fields[1] == (Field)a && Fields[4] == (Field)a && Fields[7] == (Field)a) ||
				(Fields[2] == (Field)a && Fields[5] == (Field)a && Fields[8] == (Field)a) ||
				(Fields[0] == (Field)a && Fields[4] == (Field)a && Fields[8] == (Field)a) ||
				(Fields[2] == (Field)a && Fields[4] == (Field)a && Fields[6] == (Field)a))
				return true;
			else return false;

		}
	}
	public static void Main()
	{
		bool Player = true, ErrorOccured = false;
		byte FieldChoosen, PlayerInt = 1, Counter = 0;
		string? UserInput;
		Board.Refresh();
		while (!Board.WinCheck(PlayerInt) && Counter < 9)
		{
			Player = !Player;
			PlayerInt=Convert.ToByte(Player);
			Console.WriteLine($"Player {PlayerInt+1}'s move: ");
			do
			{
				if (ErrorOccured) Console.WriteLine("Try again: ");
				UserInput = Console.ReadLine();
				while (!Byte.TryParse(UserInput, out FieldChoosen) || FieldChoosen>9)
				{
					Console.WriteLine("Incorrect value, type again:");
					UserInput = Console.ReadLine();
				}
				ErrorOccured = Board.Refresh(true,FieldChoosen, PlayerInt);
			} while (ErrorOccured);
			Counter++;
		}
		if (Counter == 9)
			Console.WriteLine("Draw");
		else
			Console.WriteLine($"Player {PlayerInt + 1} won!");
	}
}
 