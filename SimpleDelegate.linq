<Query Kind="Statements" />

using SimpleDelegate;

BinaryOp b = new BinaryOp(SimpleMath.Add);
int sum = b(10, 2);

SimpleMath sm = new SimpleMath();
b = new BinaryOp(sm.Subtract);
int diff = b.Invoke(10, 2);

Console.WriteLine($"Sum = {sum}");
Console.WriteLine($"Difference = {diff}");

// new BinaryOp(SimpleMath.SquareNumber);

DisplayDelegateInfo(b);

static void DisplayDelegateInfo(Delegate delObj)
{
	foreach(Delegate d in delObj.GetInvocationList())
	{
		Console.WriteLine("Method Name: {0}", d.Method);
		Console.WriteLine("Type Name: {0}", d.Target);
	}
}

public delegate int BinaryOp(int x, int y);

namespace SimpleDelegate
{
	class SimpleMath
	{
		public static int Add(int x, int y) => x + y;
		public int Subtract(int x, int y) => x - y;
		public static int SquareNumber(int a) => a * a;
	}
}
