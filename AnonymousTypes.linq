<Query Kind="Statements" />


// Make an anomymous type representing a car
var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 53 };

// Show the color and make
Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

BuildAnonType("BMW", "Black", 90);

ReflectOverAnonymousType(myCar);
Console.WriteLine();

var purchaseItem = new 
{
	TimeBought = DateTime.Now,
	ItemBought = new {Color = "Red", Make = "Saab", CurrentSpeed = 55},
	Price = 34.000
};
ReflectOverAnonymousType(purchaseItem);
Console.WriteLine();		

EqualityTest();

static void ReflectOverAnonymousType(object obj)
{
	Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
	Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
	Console.WriteLine("obj.ToString() == {0}", obj.ToString());
	Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
}

static void EqualityTest()
{
	// Make 2 anonymous classes with identical name/value pairs
	var firstCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
	var secondCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
	
	if(firstCar.Equals(secondCar))
		Console.WriteLine("Same anonymous object!");
	else
		Console.WriteLine("Not the same anonymous object!");
		
	if(firstCar == secondCar)
		Console.WriteLine("Same anonymous object!");
	else
		Console.WriteLine("Not the same anonymous object!");
		
	if(firstCar.GetType().Name == secondCar.GetType().Name)
		Console.WriteLine("We are both the same type!");
	else
		Console.WriteLine("We are both different types!");		
		
	Console.WriteLine();		
	
	ReflectOverAnonymousType(firstCar);
	Console.WriteLine("==========");
	ReflectOverAnonymousType(secondCar);
		
}


static void BuildAnonType(string make, string color, int currSp)
{
	// Build anonymous type using incoming args
	var car = new { Make = make, Color = color, Speed = currSp };
	
	// Use this type to get the property data
	Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
	
	// Anonymous types have custom implementations of each virtual method of System.Object. For example:
	Console.WriteLine("ToString() == {0}", car.ToString());
}