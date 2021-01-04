<Query Kind="Statements" />


Garage g = new Garage();

foreach(Car c in g)
{
	Console.WriteLine($"{c.PetName} -- {c.CurrSpeed}");
}

IEnumerable ie = (IEnumerable) g;
IEnumerator i = ie.GetEnumerator();
i.MoveNext();
Car myCar = (Car)i.Current;
Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrSpeed);
/*
IEnumerator i = g.GetEnumerator();
i.MoveNext();
Car myCar = (Car)i.Current;
Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrSpeed);

i.MoveNext();
myCar = (Car)i.Current;
Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrSpeed);

i.MoveNext();
myCar = (Car)i.Current;
Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrSpeed);
*/

class Car
{
	public string PetName { get; set; }
	public int CurrSpeed { get; set; }
	
	public Car(string pn, int cs) 
	{
		PetName = pn;
		CurrSpeed = cs;
	}
}

class Garage : IEnumerable
{
	private Car[] carArray = new Car[4];
	
	public Garage()
	{
		carArray[0] = new Car("A", 100);
		carArray[1] = new Car("B", 200);
		carArray[2] = new Car("C", 300);
		carArray[3] = new Car("D", 400);
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return carArray.GetEnumerator();
	}
}