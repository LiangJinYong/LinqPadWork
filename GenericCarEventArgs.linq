<Query Kind="Statements" />


Car c1 = new Car();
c1.AboutToBlow += CarAboutToBlow;

for(int i = 0; i < 6; i++)
	c1.Accelerate(20);


static void CarAboutToBlow(object sender, CarEventArgs e)
{
	Console.WriteLine("{0} says: {1}", sender, e.msg);
}

class Car
{
	public event EventHandler<CarEventArgs> Exploded;
	public event EventHandler<CarEventArgs> AboutToBlow;
	
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