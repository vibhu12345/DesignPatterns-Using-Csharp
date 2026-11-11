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

//Abstract Factory Pattern (No. of classes = No. of factories + No. of Products: composition, the product asks its injected factory for its parts)
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

//handle using classes
var handler1 = new Handler1();
handler1.Next = new Handler2();
Console.WriteLine(handler1.HandleRequest(2));

//handle using delegates like .net core middlewares
var chain = new Chain();

chain.Use(async (requestNo, next) =>
{
    Console.WriteLine($"Logger: before request {requestNo}");
    await next();                                    // the rest of the chain runs here
    Console.WriteLine($"Logger: after request {requestNo}");
});
chain.Use(async (requestNo, next) =>
{
    if (requestNo == 1) Console.WriteLine($"Handler {requestNo} handled the request");
    else await next();
});
chain.Use(async (requestNo, next) =>
{
    if (requestNo == 2) Console.WriteLine($"Handler {requestNo} handled the request");
    else await next();
});
chain.Run(requestNo =>
{
    Console.WriteLine($"No Handler handled the request {requestNo}");
    return Task.CompletedTask;
});

await chain.Handle(2);
await chain.Handle(3);
Console.WriteLine();

//Flyweight Pattern
Console.WriteLine("Flyweight Pattern");
var fonts = new Flyweight<(string Name, int Size), Font>(key => new Font(key.Name, key.Size));

var a = fonts.Get(("Arial", 12));
var b = fonts.Get(("Arial", 12));
var c = fonts.Get(("Arial", 14));

Console.WriteLine(ReferenceEquals(a, b)); // True: one shared object
Console.WriteLine(fonts.Count);           // 2 fonts, however many characters use them

// The position differs for every character, so it is passed in, not stored
Console.WriteLine(a.Draw('H', 0));        // H at 0 in Arial 12
Console.WriteLine(c.Draw('i', 1));        // i at 1 in Arial 14
Console.WriteLine();

//Proxy Pattern
Console.WriteLine("Proxy Pattern");
// The caller asks for an IService and cannot tell it was handed a proxy
IService service = LoggingProxy<IService>.Create(new Service());
Console.WriteLine(service.DoWork("request 1"));
// Proxy: calling DoWork
// Proxy: DoWork returned
// Work done for request 1
Console.WriteLine();

//Prototype Pattern
Console.WriteLine("Prototype Pattern");
var prototype = new Product("Product1", 10, ["tag1"]);

var copy = prototype with { };                      // a clone
var variant = prototype with { Name = "Product2" }; // a clone with one change

Console.WriteLine(copy == prototype);                // True: same values
Console.WriteLine(ReferenceEquals(copy, prototype)); // False: a different object
Console.WriteLine(variant);

variant.Tags.Add("tag2");
Console.WriteLine(prototype.Tags.Count);             // 2: the copy is shallow, so the list is shared
Console.WriteLine();

//Mediator Pattern
Console.WriteLine("Mediator Pattern");
var mediator = new Mediator();

// Three colleagues. None of them holds a reference to another.
mediator.Register<string>(message => Console.WriteLine("Colleague1 received " + message));
mediator.Register<string>(message => Console.WriteLine("Colleague2 received " + message));
mediator.Register<int>(number => Console.WriteLine("Colleague3 received " + number));

mediator.Send("Hello"); // Colleague1 and Colleague2
mediator.Send(42);      // Colleague3 only
Console.WriteLine();

//Memento Pattern
Console.WriteLine("Memento Pattern");
var editor = new Editor();
editor.Type("Hello");
editor.Type(" World");
Console.WriteLine(editor); // Hello World
editor.Undo();
Console.WriteLine(editor); // Hello
Console.WriteLine();

//Visitor Pattern
Console.WriteLine("Visitor Pattern");
//visit using classes and double dispatch
Shape[] shapes = [new Circle(1), new Rectangle(2, 3)];
foreach (var shape in shapes) Console.WriteLine(shape.Accept(new AreaVisitor()));

//visit using pattern matching: each operation is a function with a switch
foreach (var shape in shapes) Console.WriteLine($"{Describe(shape)} has area {Area(shape):F2}");
// Circle of radius 1 has area 3.14
// 2 by 3 rectangle has area 6.00
Console.WriteLine();

//Interpreter Pattern
Console.WriteLine("Interpreter Pattern");
var expression = Parse("1 2 + 3 *");
Console.WriteLine($"{Show(expression)} = {Evaluate(expression)}"); // ((1 + 2) * 3) = 9
Console.WriteLine();

//Repository Pattern (not one of the Gang of Four's: from Patterns of Enterprise Application Architecture)
Console.WriteLine("Repository Pattern");
// The caller sees a collection of vehicles. Where they are kept is the repository's business.
IRepository<Vehicle> vehicles = new InMemoryRepository<Vehicle>(v => v.Id);

vehicles.Add(new Vehicle(1, "KA-01", "Car"));
vehicles.Add(new Vehicle(2, "KA-02", "Bike"));
vehicles.Add(new Vehicle(3, "KA-03", "Car"));

Console.WriteLine(vehicles.Get(2)?.Plate);                  // KA-02
foreach (var car in vehicles.Find(v => v.Type == "Car"))    // the query is a lambda
    Console.WriteLine(car.Plate);                           // KA-01, KA-03

vehicles.Remove(1);
Console.WriteLine(vehicles.Find(_ => true).Count());        // 2
Console.WriteLine();

//Local functions used by the Visitor and Interpreter sections

// Each new operation is one function. The shapes are never touched.
static double Area(Shape shape) => shape switch
{
    Circle c    => Math.PI * c.Radius * c.Radius,
    Rectangle r => r.Width * r.Height,
    _           => throw new ArgumentException($"Unknown shape {shape}"),
};

static string Describe(Shape shape) => shape switch
{
    Circle c    => $"Circle of radius {c.Radius}",
    Rectangle r => $"{r.Width} by {r.Height} rectangle",
    _           => throw new ArgumentException($"Unknown shape {shape}"),
};

// Postfix needs no brackets or precedence rules, so the parser is a stack
static Expr Parse(string postfix)
{
    var stack = new Stack<Expr>();
    foreach (var token in postfix.Split(' '))
    {
        if (int.TryParse(token, out var value)) { stack.Push(new Number(value)); continue; }

        var right = stack.Pop();
        var left = stack.Pop();
        stack.Push(token == "+" ? new Add(left, right) : new Multiply(left, right));
    }
    return stack.Pop();
}

// One interpreter gives the sentence its value
static int Evaluate(Expr expr) => expr switch
{
    Number n   => n.Value,
    Add a      => Evaluate(a.Left) + Evaluate(a.Right),
    Multiply m => Evaluate(m.Left) * Evaluate(m.Right),
    _          => throw new ArgumentException($"Unknown expression {expr}"),
};

// Another prints it. The grammar below did not change.
static string Show(Expr expr) => expr switch
{
    Number n   => n.Value.ToString(),
    Add a      => $"({Show(a.Left)} + {Show(a.Right)})",
    Multiply m => $"({Show(m.Left)} * {Show(m.Right)})",
    _          => throw new ArgumentException($"Unknown expression {expr}"),
};
