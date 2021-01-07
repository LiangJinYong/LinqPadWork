<Query Kind="Statements" />


QueryOverStrings();
Console.WriteLine();
QueryOverStringsWithExtensionMethods();
Console.WriteLine();
QueryOverInts();

ImmediateExecution();

static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
{
	Console.WriteLine($"***** Info about your query using {queryType} *****");
	Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
	Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
}

static void QueryOverStrings()
{
	string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
	
	// Build a query expression to find the items in the array that have an embedded space
	IEnumerable<string> subset = from g in currentVideoGames where g.Contains(" ") orderby g select g;
	
	ReflectOverQueryResults(subset);
	
	foreach(string s in subset)
		Console.WriteLine("Item: {0}", s);
}

static void QueryOverStringsWithExtensionMethods()
{
	string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
	
	IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
	
	ReflectOverQueryResults(subset);
	
	foreach(string s in subset)
		Console.WriteLine("Item: {0}", s);
}

static void QueryOverInts()
{
	int[] numbers = {10, 20, 30, 40, 1, 2, 3, 8};
	
	var subset = from n in numbers where n < 10 select n;
	
	ReflectOverQueryResults(subset);
	
	// LINQ statement evaluated here!
	foreach(var i in subset)
		Console.WriteLine("Item: {0}", i);
	
	Console.WriteLine();
	
	numbers[0] = 4;
	// Evaluated again!
	foreach(var i in subset)
		Console.WriteLine("Item: {0}", i);
}

static void ImmediateExecution()
{
	int[] numbers = {10, 20, 30, 40, 1, 2, 3, 8};
	
	// Get data RIGHT NOW as int[]
	int[] subsetAsIntArray = (from i in numbers where i < 10 select i).ToArray<int>();
	
	// Get data RIGHT NOW as List<int>
	List<int> subsetAsListOfInts = (from i in numbers where i < 10 select i).ToList<int>();
}