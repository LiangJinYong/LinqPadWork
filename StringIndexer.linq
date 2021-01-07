<Query Kind="Statements" />


PersonCollection myPeople = new PersonCollection();

myPeople["Homer"] = new Person("Homer", "Simpson", 40);
myPeople["WuBai"] = new Person("WuBai", "Junlin", 50);

Person wubai = myPeople["WuBai"];
Console.WriteLine(wubai);

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
	private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();
	
	// This indexer returns a person based on a string index
	public Person this[string name]
	{
		get => listPeople[name];
		set => listPeople[name] = value;
	}
	
	public void ClearPeople()
	{
		listPeople.Clear();
	}
	
	public int Count => listPeople.Count;
	
	IEnumerator IEnumerable.GetEnumerator() => listPeople.GetEnumerator();
}