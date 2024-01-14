Console.WriteLine("Design Patterns");
Console.WriteLine();

//Strategy Pattern
Console.WriteLine("Strategy Pattern");

Func<string, string> reverseStringStrategy1  = s => new string(s.Reverse().ToArray());

Func<string, string> reverseStringStrategy2 = s =>
{
    var sArray = s.ToCharArray();
    Array.Reverse(sArray);
    return new string(sArray);
};

var input = "Hello World";
Console.WriteLine($"Input String: { input}");

var  strategyPattern = new StrategyPattern<string>(reverseStringStrategy1, input);

var reversedString = "Reverse String Strategy 1: " + strategyPattern.ExecuteStrategy();
Console.WriteLine(reversedString);

strategyPattern.ChangeStrategy(reverseStringStrategy2);

reversedString = "Reverse String Strategy 2: " + strategyPattern.ExecuteStrategy();

Console.WriteLine(reversedString);

Console.WriteLine();

// Observer Pattern
Console.WriteLine("Observer Pattern");
var publisher = new Publisher();
var observer1 = new Observer();
var observer2 = new Observer();
publisher.AddObserver(observer1);
publisher.AddObserver(observer2);
publisher.NotifyObservers();
observer1.ProcessMessage();
observer1.RemoveSubscription(publisher); // Alternatively publisher.RemoveObserver(observer1)
observer1.ProcessMessage();

//Event Example for Observer Pattern
var eventPublisher= new EventPublisher(); //Never used in real world projects
eventPublisher.AddObserver(observer1);
eventPublisher.AddObserver(observer2);
eventPublisher.NotifyObservers();
observer1.ProcessMessage();
observer1.RemoveSubscription(); //Here passing publisher is not necessary as it is passed to the observer while notifying.
observer1.ProcessMessage();
Console.WriteLine();

//Decorator Pattern
Console.WriteLine("Decorator Pattern");
var original = new Original();
var decoratedOriginal = new DecoratedOriginal(original); //does not change original object, better than inheritance
var doubleDecoratedOriginal = new DecoratedOriginal(decoratedOriginal); // no need to create new classes for double decoration or multiple decorations
Console.WriteLine(original.DoWork());
Console.WriteLine(decoratedOriginal.DoWork());
Console.WriteLine(doubleDecoratedOriginal.DoWork());
Console.WriteLine();

//Factory Patterns
Console.WriteLine("Factory Patterns");

//Simple Factory using generics (instead of parameters, old way)
Console.WriteLine("Simple Factory");
var simpleFactory = new SimpleFactory();
var product = simpleFactory.CreateProduct<Product2>();
Console.WriteLine(product);
var product1 = simpleFactory.CreateProduct<Product1>();
Console.WriteLine(product1);
Console.WriteLine();

//Factory Method Pattern (No. of classes = No.of factories * No. of Products)
Console.WriteLine("Factory Method Patttern");
IFactory factory1 = new Factory1();
IFactory factory2 = new Factory2();
var factory1product1 = factory1.CreateProduct("Product1");
var factory1product2 = factory1.CreateProduct("Product2");
Console.WriteLine(factory1product1);
Console.WriteLine(factory1product2);
var factory2product2 = factory2.CreateProduct("Product2");
Console.WriteLine(factory2product2);
Console.WriteLine();

//Abstract Factory Pattern (No. of classes = No. of factories + No. of Products)
Console.WriteLine("Abstract Factory Pattern");
var factory1Product1 = factory1.CreateProduct<Product1>();
Console.WriteLine(factory1Product1);
var factory1Product2 = factory1.CreateProduct<Product2>();
Console.WriteLine(factory1Product2);
var factory2Product2 = factory2.CreateProduct<Product2>();
Console.WriteLine(factory2Product2);
Console.WriteLine();

//Singleton Pattern
//https://csharpindepth.com/articles/singleton
// Command Pattern using delegates instead of ICommand {Execute, Undo}

Func<int, int, int > AddCommand = (x, y) => x + y; 
Func<int, int, int > SubtractCommand = (x, y) => x - y;
Func<int, int, int> MultiplyCommand = (x, y) => x * y;
Func<int, int, int> DivideCommand = (x, y) => x / y;

Dictionary<string, Func<int, int, int>> commands = new Dictionary<string, Func<int, int, int>>
{
    { "+", AddCommand },
    { "-", SubtractCommand },
    { "*", MultiplyCommand },
    { "/", DivideCommand },
};

var result = commands["+"].Invoke(1, 2); //Invoke can be considered as ICommand.Execute
Console.WriteLine(result);
Console.WriteLine();


//Adapter Pattern

Console.WriteLine("Adapter Pattern");
IAdaptee adaptee = new Adaptee();
Console.WriteLine(adaptee.AdapteeMethod());
IAdapter adapter = new Adapter(adaptee);
Console.WriteLine(adapter.AdaptedMethoad());
Console.WriteLine();

//Facade Pattern
Console.WriteLine("Facade Pattern");
var adaptees = new List<IAdaptee>() { adaptee, new Adaptee(), new Adaptee()};
var facade = new Facade(adaptees);
Console.WriteLine(facade.ShowFacade());
Console.WriteLine();

//Template Method pattern - a method with some virtual and shared method.
Console.WriteLine("Template Method Pattern");
Template template1 = new Template1(()=>"body1"); 
Console.WriteLine(template1.TemplateMethod());
Template template2 = new Template1(() => "body2"); //Templated method combined with strategy pattern
Console.WriteLine(template2.TemplateMethod());

//Iterator Pattern

int[] array = [1, 2, 3, 4, 5, 6];

var iterator =array.GetEnumerator();
while (iterator.MoveNext())
{
    Console.WriteLine(iterator.Current);
}

Console.WriteLine();

//Composite Pattern 

//Here both item and item array implements the same interface for add, remove, etc. and hence can be the part of same list and traversed

//State Pattern
Console.WriteLine("State Pattern");
IState state1 = new State1();
IState state2 = new State2();
Context context = new Context(state1, state2);
context.DoWork1();
context.DoWork2();

Console.WriteLine();

//Bridge Pattern
Console.WriteLine("Bridge Pattern");
//Same as strategy but context is also abstract
IImplementation implementation = new Implementation1();
IAbstraction abstraction = new Abstraction1(implementation);
Console.WriteLine(abstraction.DoWork());
implementation = new Implementation2();
abstraction = new Abstraction2(implementation);
Console.WriteLine(abstraction.DoWork());
Console.WriteLine();

//Builder Pattern (Fluent)
Console.WriteLine("Builder Pattern"); //Increases readability
Builder builder = new Builder();
builder = builder.SetProperty1("Property1")
    .SetProperty2("Property2");

Console.WriteLine(builder);
Console.WriteLine(builder.SetProperty3("Property3"));
Console.WriteLine();

//Chain Of Responsibility 
Console.WriteLine("Chain of Responsibility");
var chain = new Chain(2);
chain.Handle();
chain.HandleLikeMiddleWares(); //done similar to .net core middlewares
Console.WriteLine();

//Flyweight Pattern



 
