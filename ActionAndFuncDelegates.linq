<Query Kind="Statements" />

//Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
Action<string, ConsoleColor, int> actionTarget = DisplayMessage;
actionTarget("Action Message!", ConsoleColor.Yellow, 5);

//Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
Func<int, int, int> funcTarget = Add;
int result = funcTarget.Invoke(10, 30);
Console.WriteLine($"Sum = {result}");

//Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
Func<int, int, string> funcTarget2 = SumToString;
string sum = funcTarget2.Invoke(100, 200);
Console.WriteLine($"SumToString = {sum}");

static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
{
	// Set color of console text
	ConsoleColor previous = Console.ForegroundColor;
	Console.ForegroundColor = txtColor;
	
	for(int i = 0; i < printCount; i++)
	{
		Console.WriteLine(msg);
	}
	
	Console.ForegroundColor = previous;
}

static int Add(int x, int y)
{
	return x + y;
}

static string SumToString(int x, int y)
{
	return (x + y).ToString();
}