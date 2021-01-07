<Query Kind="Statements" />


MyGenericDelegate<string> strTarget = StringTarget;
strTarget("Some string data");

MyGenericDelegate<int> intTarget = IntTarget;
intTarget(9);


static void StringTarget(string arg)
{
	Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
}

static void IntTarget(int arg)
{
	Console.WriteLine("++arg is: {0}", ++arg);
}

delegate void MyGenericDelegate<T>(T arg);