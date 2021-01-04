<Query Kind="Statements" />

// ICloneable Interface
Point p1 = new Point(50, 50);
Point p2 = p1;
p2.X = 0;
//Console.WriteLine(p1);
//Console.WriteLine(p2);

Point p3 = new Point(100, 100, "Jane");
Point p4 = (Point)p3.Clone();

Console.WriteLine("Before modification:");
Console.WriteLine(p3);
Console.WriteLine(p4);

p4.desc.PetName = "My new Point";
p4.X = 9;

Console.WriteLine("Changed p4.desc.petName and p4.X");
Console.WriteLine("After modification:");
Console.WriteLine(p3);
Console.WriteLine(p4);

public class Point : ICloneable
{
	public int X { get; set; }
	public int Y { get; set; }
	public PointDescription desc = new PointDescription();
	
	
	public Point() {}
	public Point(int xPos, int yPos) { X = xPos; Y = yPos; }
	
	public Point(int xPos, int yPos, string petName) 
	{ 
		X = xPos; Y = yPos;
		desc.PetName = petName;
	}
	
	public override string ToString() => $"X = {X}; Y = {Y}; Name = {desc.PetName};\nID = {desc.PointID}";
	
	//public object Clone() => new Point(this.X, this.Y);
	public object Clone()
	{
		Point newPoint = (Point)this.MemberwiseClone();
		
		PointDescription currentDesc = new PointDescription();
		currentDesc.PetName = this.desc.PetName;
		newPoint.desc = currentDesc;
		return newPoint;
	}
}

public class PointDescription
{
	public string PetName { get; set; }
	public Guid PointID { get; set; }
	
	public PointDescription()
	{
		PetName = "No-name";
		PointID = Guid.NewGuid();
	}
}