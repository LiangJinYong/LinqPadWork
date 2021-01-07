<Query Kind="Statements" />


int myInt = 12345678;
myInt.DisplayDefiningAssembly();

System.Data.DataSet d = new System.Data.DataSet();
d.DisplayDefiningAssembly();

System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
sp.DisplayDefiningAssembly();

Console.WriteLine("Value of myInt: {0}", myInt);
Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigit());

static class MyExtensions
{
	// This method allows any object to display the assembly it is defined in
	public static void DisplayDefiningAssembly(this object obj)
	{
		Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
	}
	
	// This method allows any integer to reverse its digits. For example, 56 would be 65
	public static int ReverseDigit(this int i)
	{
		char[] digits = i.ToString().ToCharArray();
		
		Array.Reverse(digits);
		
		string newDigits = new string(digits);
		
		return int.Parse(newDigits);
	}
}

