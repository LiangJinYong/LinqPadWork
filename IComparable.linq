<Query Kind="Statements" />

Car[] myAutos = new Car[5];
myAutos[0] = new Car("Rusty", 80, 1);
myAutos[1] = new Car("Harry", 40, 234);
myAutos[2] = new Car("Alex", 20, 34);
myAutos[3] = new Car("Hagrid", 30, 4);
myAutos[4] = new Car("LaoLiang", 91, 5);

foreach(Car c in myAutos)
	Console.WriteLine(c);
	
// Sort by ID
Array.Sort(myAutos);
Console.WriteLine("============");
foreach(Car c in myAutos)
	Console.WriteLine(c);

// Sort by PetName
//Array.Sort(myAutos, new PetNameComparer());
Array.Sort(myAutos, Car.SortByPetName);
Console.WriteLine("============");
foreach(Car c in myAutos)
	Console.WriteLine(c);
	
// Sort by CurrentSpeed
Array.Sort(myAutos, Car.SortByCurrentSpeed);
Console.WriteLine("============");
foreach(Car c in myAutos)
	Console.WriteLine(c);
	
class Car : IComparable
{
	public string PetName { get; set; }
	public int CurrentSpeed { get; set; }
	public int CarID{ get; set; }
	
	public static IComparer SortByPetName 
	{
		get 
		{
			return new PetNameComparer();
		}
	}
	
	public static IComparer SortByCurrentSpeed
	{
		get
		{
			return new CurrentSpeedComparer();
		}
	}
	
	public Car(string name, int currSp, int id)
	{
		PetName = name;
		CurrentSpeed = currSp;
		CarID = id;
	}
	
	int IComparable.CompareTo(object obj)
	{
		if(obj is Car c)
		{
			if(this.CarID > c.CarID)
				return 1;
			else if (this.CarID < c.CarID)
				return -1;
			else
				return 0;
		}
		else
			throw new ArgumentException("Parameter is not a Car!");
	}
	
	public override string ToString() => $"ID: {CarID}, Pet Name: {PetName}, Current Speed: {CurrentSpeed}";
}

class PetNameComparer : IComparer
{
	int IComparer.Compare(object o1, object o2)
	{
		if(o1 is Car c1 && o2 is Car c2)
		{
			return String.Compare(c1.PetName, c2.PetName);
		}
		else
		 throw new ArgumentException("Parameter is not a Car!");
	}
}

class CurrentSpeedComparer : IComparer
{
	int IComparer.Compare(object o1, object o2)
	{
		if(o1 is Car c1 && o2 is Car c2)
		{
			return -c1.CurrentSpeed.CompareTo(c2.CurrentSpeed);
		}
		else
		 throw new ArgumentException("Parameter is not a Car!");
	}
}