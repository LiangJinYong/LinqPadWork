<Query Kind="Statements" />


Garage g = new Garage();

IEnumerator carEnumerator = g.GetEnumerator();
//carEnumerator.MoveNext();

foreach(Car c in g)
{
	Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrSpeed);
}

Console.WriteLine();

foreach(Car c in g.GetTheCars(true))
{
	Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrSpeed);
}


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
	
	public IEnumerator GetEnumerator()
	{
		// This will net get thrown until MoveNext() is called
		//throw new Exception("This won't get called!");
		
		return actualImplementation();
		
		IEnumerator actualImplementation()
		{
			foreach(Car c in carArray)
			{
				yield return c;
			}	
		}
		
	}
	
	// Named Iterator
	public IEnumerable GetTheCars(bool returnReversed)
	{
		return actualImplementation();
		
		IEnumerable actualImplementation()
		{
			if(returnReversed)
			{
				for(int i = carArray.Length; i != 0; i--)
				{
					yield return carArray[i - 1];
				}
			}
			else
			{
				foreach(Car c in carArray)
				{
					yield return c;
				}
			}
		}
	}
}