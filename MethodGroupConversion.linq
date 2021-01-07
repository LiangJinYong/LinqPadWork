<Query Kind="Statements" />


Car c1 = new Car("SlugBug", 100, 10);

// Tell the car which method to call when it wants to send us messages
c1.RegisterWithCarEngine(OnCarEngineEvent);
c1.RegisterWithCarEngine(OnCarEngineEvent2);

Console.WriteLine("***** Speeding up *****");
for(int i = 0; i < 6; i++)
	c1.Accelerate(20);
	
c1.UnRegisterWithCarEngine(OnCarEngineEvent2);	

Console.WriteLine("***** Speeding up *****");
for(int i = 0; i < 6; i++)
	c1.Accelerate(20);
	
static void OnCarEngineEvent(string msg)
{
	Console.WriteLine("\n***** Message From Car Object *****");
	Console.WriteLine("=> {0}", msg);
	Console.WriteLine("**************************************\n");
}

static void OnCarEngineEvent2(string msg)
{
	Console.WriteLine("=> {0}", msg.ToUpper());
}

class Car
{
	// 1) Define a delegate type
	public delegate void CarEngineHandler(string msgForCaller);
	
	// 2) Define a member variable of this delegate
	private CarEngineHandler listOfHandlers;
	
	// 3) Add registration function for the caller
	public void RegisterWithCarEngine(CarEngineHandler methodToCall)
	{
		listOfHandlers += methodToCall;
	}
	
	public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
	{
		listOfHandlers -= methodToCall;
	}

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
			if(listOfHandlers != null)
			{
				listOfHandlers("Sorry, this car is dead...");
			}
		}
		else
		{
			CurrentSpeed += delta;
			
			if(listOfHandlers != null && 10 == (MaxSpeed - CurrentSpeed))
			{
				listOfHandlers("Careful buddy! Gonna blow!");
			}
			
			if(CurrentSpeed >= MaxSpeed)
				carIsDead = true;
			else
				Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
		}
	}
}