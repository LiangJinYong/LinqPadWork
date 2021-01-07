<Query Kind="Statements" />


TraditionalDelegateSyntax();
Console.WriteLine();
AnonymousMethodSyntax();
Console.WriteLine();
LambdaExpressionSyntax();

static void TraditionalDelegateSyntax()
{
	List<int> list = new List<int>();
	list.AddRange(new int[] {20, 1, 3, 6, 8, 17});
	
	Predicate<int> callback = IsEvenNumber;
	List<int> evenNumbers = list.FindAll(callback);
	
	Console.WriteLine("Here are your even numbers using traditional delegate syntax:");
	foreach(int evenNumber in evenNumbers)
	{
		Console.Write("{0}\t", evenNumber);
	}
}

static bool IsEvenNumber(int i)
{
	return (i % 2) == 0;
}

static void AnonymousMethodSyntax()
{
	List<int> list = new List<int>();
	list.AddRange(new int[] {20, 1, 3, 6, 8, 17});
	
	List<int> evenNumbers = list.FindAll(delegate(int num)
	{
		return (num % 2) == 0;
	});
	
	Console.WriteLine("Here are your even numbers using anonymous method syntax:");
	foreach(int evenNumber in evenNumbers)
	{
		Console.Write("{0}\t", evenNumber);
	}
}

static void LambdaExpressionSyntax()
{
	List<int> list = new List<int>();
	list.AddRange(new int[] {20, 1, 3, 6, 8, 17});
	
	List<int> evenNumbers = list.FindAll(i => 
	{
		Console.WriteLine("value of i is currently: " + i +", it is " + (i % 2 == 0 ? "even" : "odd"));
		return (i % 2) == 0;
	});
	
	Console.WriteLine("Here are your even numbers using lambda expression syntax:");
	foreach(int evenNumber in evenNumbers)
	{
		Console.Write("{0}\t", evenNumber);
	}
}

