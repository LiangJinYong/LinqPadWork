<Query Kind="Statements" />

Car c1 = new Car("Harry", 100, 10);
int aboutToBlowCounter = 0;

c1.AboutToBlow += delegate
{
	aboutToBlowCounter++;
	Console.WriteLine("Eek! Going too fast!");
};

c1.AboutToBlow += delegate(object sender, CarEventArgs e)
{
	aboutToBlowCounter++;
	Console.WriteLine("Critical Message from Car: {0}", e.msg);
};

for(int i = 0; i < 6; i++)
	c1.Accelerate(20);
	
Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);

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