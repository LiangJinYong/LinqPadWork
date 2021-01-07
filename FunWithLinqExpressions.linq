<Query Kind="Statements" />


ProductInfo[] itemsInStock = new[] {
	new ProductInfo{ Name = "Mac's Coffee",
	                Description = "Coffee with TEETH",
	                NumberInStock = 24},
	new ProductInfo{ Name = "Milk Maid Milk",
	                Description = "Milk cow's love",
	                NumberInStock = 100},
	new ProductInfo{ Name = "Pure Silk Tofu",
	                Description = "Bland as Possible",
	                NumberInStock = 120},
	new ProductInfo{ Name = "Cruchy Pops",
	                Description = "Cheezy, peppery goodness",
	                NumberInStock = 2},
	new ProductInfo{ Name = "RipOff Water",
	                Description = "From the tap to your wallet",
	                NumberInStock = 100},
	new ProductInfo{ Name = "Classic Valpo Pizza",
	                Description = "Everyone loves pizza!",
	                NumberInStock = 73}
};

SelectEverything(itemsInStock);
ListProductNames(itemsInStock);
GetOverstock(itemsInStock);
GetNamesAndDescriptions(itemsInStock);
GetCountFromQuery();
ReverseEverything(itemsInStock);
AlphabetizeProductNames(itemsInStock);
DisplayDiff();
DisplayIntersection();
DisplayUnion();
DisplayConcat();
DisplayConcatNoDups();
AggregateOps();

static void SelectEverything(ProductInfo[] products)
{
	// Get everything!
	Console.WriteLine("All product details:");
	
	var allProducts = from p in products select p;
	
	foreach(var prod in allProducts)
	{
		Console.WriteLine(prod.ToString());
	}
}

static void ListProductNames(ProductInfo[] products)
{
	// Now get only the names of the products
	Console.WriteLine("Only product names:");
	var names = from p in products select p.Name;
	
	foreach(var n in names)
		Console.WriteLine("Name: {0}", n);
}

static void GetOverstock(ProductInfo[] products)
{
	Console.WriteLine("The overstock items:");
	
	// Get only the items where we have more than 25 in stock
	var overstock = from p in products where p.NumberInStock > 25 select p;
	
	foreach(ProductInfo c in overstock)
		Console.WriteLine(c);
}

static void GetNamesAndDescriptions(ProductInfo[] products)
{
	Console.WriteLine("Names and Descriptions:");
	var nameDesc = from p in products select new {p.Name, p.Description};
	
	foreach(var item in nameDesc)
		Console.WriteLine(item.ToString());
}

static void GetCountFromQuery()
{
	string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                                "Fallout 3", "Daxter", "System Shock 2"};

	// Get count from the query
	int numb = (from g in currentVideoGames where g.Length > 6 select g).Count();
	
	Console.WriteLine("{0} items honor the LINQ query.", numb);
}

static void ReverseEverything(ProductInfo[] products)
{
	Console.WriteLine("Products in reverse:");
	var allProductsInReverse = (from p in products select p).Reverse();
	
	foreach(var prod in allProductsInReverse)
		Console.WriteLine(prod);
}

static void AlphabetizeProductNames(ProductInfo[] products)
{
	// Get names of products, alphabetized
	var subset = from p in products orderby p.Name descending select p;
	
	Console.WriteLine("Order by Name:");
	foreach(var p in subset)
		Console.WriteLine(p);
}

static void DisplayDiff()
{
	List<string> myCars = new List<string> {"Yugo", "Aztec", "BMW"};
	List<string> yourCars = new List<string> {"BMW", "Saab", "Aztec"};
	
	var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
	
	Console.WriteLine("Here is what you don't have, but I do:");
	foreach(string s in carDiff)
		Console.WriteLine(s);
}

static void DisplayIntersection()
{
	List<string> myCars = new List<string> {"Yugo", "Aztec", "BMW"};
	List<string> yourCars = new List<string> {"BMW", "Saab", "Aztec"};
	
	// Get the comman members
	var carIntersect = (from c in myCars select c).Intersect(from c2 in yourCars select c2);
	Console.WriteLine("Here is what we have in common:");
	foreach(string s in carIntersect)
		Console.WriteLine(s);
}

static void DisplayUnion()
{
	List<string> myCars = new List<string> {"Yugo", "Aztec", "BMW"};
	List<string> yourCars = new List<string> {"BMW", "Saab", "Aztec"};
	
	// Get the union of these containers
	var carUnion = (from c in myCars select c).Union(from c2 in yourCars select c2);
	
	Console.WriteLine("Here is everything:");
	foreach(string s in carUnion)
		Console.WriteLine(s);
}

static void DisplayConcat()
{
	List<string> myCars = new List<string> {"Yugo", "Aztec", "BMW"};
	List<string> yourCars = new List<string> {"BMW", "Saab", "Aztec"};
	
	var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
	Console.WriteLine("Here is everything (including duplicate):");
	foreach(string s in carConcat)
		Console.WriteLine(s);
	
}

static void DisplayConcatNoDups()
{
	List<string> myCars = new List<string> {"Yugo", "Aztec", "BMW"};
	List<string> yourCars = new List<string> {"BMW", "Saab", "Aztec"};
	
	var carConcat = (from c in myCars select c).Concat(from c2 in yourCars select c2);
	Console.WriteLine("Here is everything (Removing duplicate):");
	foreach(string s in carConcat.Distinct())
		Console.WriteLine(s);
}

static void AggregateOps()
{
	double[] winterTemps = {2.0, -21.3, 8, -4, 0, 8.2};
	
	// Various aggregation examples
	Console.WriteLine("Max temp: {0}", (from t in winterTemps select t).Max());
	Console.WriteLine("Min temp: {0}", (from t in winterTemps select t).Min());
	Console.WriteLine("Average temp: {0}", (from t in winterTemps select t).Average());
	Console.WriteLine("Sum of all temps: {0}", (from t in winterTemps select t).Sum());
}

class ProductInfo
{
    public string Name { get; set; } = "";
    public string Description { get; set; }= "";
    public int NumberInStock { get; set; }

    public override string ToString() => $"Name={Name}, Description={Description}, Number in Stock={NumberInStock}";
}