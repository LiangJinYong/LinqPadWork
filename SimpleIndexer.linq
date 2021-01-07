<Query Kind="Statements" />


PersonCollection myPeople = new PersonCollection();

myPeople[0] = new Person("Homer", "Simpson", 40);
myPeople[1] = new Person("JP", "Simpson", 21);
myPeople[2] = new Person("JYP", "Simpson", 32);
myPeople[3] = new Person("Zhou", "Simpson", 12);
myPeople[4] = new Person("WuBai", "Simpson", 13);

for(int i = 0; i < myPeople.Count; i++)
{
	/*
	Console.WriteLine("Person number: {0}", i);
	Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
	Console.WriteLine("Age: {0}", myPeople[i].Age);
	Console.WriteLine();
	*/
	Console.WriteLine(myPeople[i]);
}

class Person
{
    public int Age { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person() { }
    public Person(string firstName, string lastName, int age)
    {
        Age = age;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Age: {Age}";
    }
}

class PersonCollection : IEnumerable
{
	private ArrayList arPeople = new ArrayList();
	
	// Cast for caller
	public Person GetPerson(int pos) => (Person) arPeople[pos];
	
	// Only insert Person types
	public void AddPerson(Person p) => arPeople.Add(p);	
	
	public void ClearPeople() => arPeople.Clear();
	
	public int Count => arPeople.Count;
	
	// Foreach enumeration support
	IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();
	
	// Custom indexer for this class
	public Person this[int index]
	{
		get => (Person)arPeople[index];
		set => arPeople.Insert(index, value);
	}
}