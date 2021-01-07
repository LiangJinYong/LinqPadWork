<Query Kind="Statements" />


Car c1 = new Car("SlugBug", 100, 10);

c1.AboutToBlow += CarAboutToBlow;
c1.Exploded += CarExploded;

for(int i = 0; i < 6; i++)
	c1.Accelerate(20);

static void CarAboutToBlow(object sender, CarEventArgs e)
{
	if(sender is Car c)
		Console.WriteLine("{0} says: {1}", c.PetName, e.msg);
}

static void CarExploded(object sender, CarEventArgs e)
{
	if(sender is Car c)
		Console.WriteLine("{0} says: {1}, byebye!", c.PetName, e.msg);
}

class Car
{
	
	public delegate void CarEngineHandler(object sender, CarEventArgs e);
		
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
	
	
	public void Accelerate(int delta)
	{
		if(carIsDead)
		{
			Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
		}
		else
		{
			CurrentSpeed += delta;
			
			if(10 == (MaxSpeed - CurrentSpeed))
			{
				AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
			}
			
			if(CurrentSpeed >= MaxSpeed)
				carIsDead = true;
			else
				Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
		}
	}
}

class CarEventArgs : EventArgs
{
	public readonly string msg;
	public CarEventArgs(string message)
	{
		msg = message;
	}
}