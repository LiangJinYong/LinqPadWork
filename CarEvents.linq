<Query Kind="Statements" />


Car c1 = new Car("SlugBug", 100, 10);
//c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
//c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);
c1.AboutToBlow += CarIsAlmostDoomed;
c1.AboutToBlow += CarAboutToBlow;

//Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploded);
//c1.Exploded += d;

c1.Exploded += CarExploded;

Console.WriteLine("***** Speeding up *****");
for(int i = 0; i < 6; i++)
	c1.Accelerate(20);

// c1.Exploded -= d;
c1.Exploded -= CarExploded;
for(int i = 0; i < 6; i++)
	c1.Accelerate(20);

static void CarIsAlmostDoomed(string msg)
{
	Console.WriteLine("=> Critical Message from Car: {0}", msg);
}

static void CarAboutToBlow(string msg)
{
	Console.WriteLine("#{0}", msg);
}

static void CarExploded(string msg)
{
	Console.WriteLine("~{0}", msg);
}

class Car
{
	// This delegate works in conjunction with the Car's events
	public delegate void CarEngineHandler(string msg);
	
	// This car can send these events
	public event CarEngineHandler Exploded;
	public event CarEngineHandler AboutToBlow;
	
	public int CurrentSpeed { get; set; }
	public int MaxSpeed { get; set; }
	public string PetName { get; set; }
	
	private bool carIsDead;
	
	public Car() {}
	
	public Car(string name, int maxSp, int currSp)
	{
		CurrentSpeed = currSp;
		MaxSpeed = maxSp;
		PetName = name;
	}
	
	// 4) Implement the Accelerate() method to invoke the delegate's invocation list under the correct circumstances
	public void Accelerate(int delta)
	{
		if(carIsDead)
		{
			/*
			if(Exploded != null)
			{
				Exploded("Sorry, this car is dead...");
			}
			*/
			// When using the null conditional operator(?), you must manually call the Invoke() method of the underlying delegate
			Exploded?.Invoke("Sorry, this car is dead...");
		}
		else
		{
			CurrentSpeed += delta;
			
			/*
			if(AboutToBlow != null && 10 == (MaxSpeed - CurrentSpeed))
			{
				AboutToBlow("Careful buddy! Gonna blow!");
			}
			*/
			if(10 == (MaxSpeed - CurrentSpeed))
			{
				AboutToBlow?.Invoke("Careful buddy! Gonna blow!");
			}
			
			if(CurrentSpeed >= MaxSpeed)
				carIsDead = true;
			else
				Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
		}
	}
}