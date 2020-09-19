# Code Styles
This document is created to guide your style of code. 

First rule is:
> You MUST follow **.editorconfig** file!

You can get .editorconfig file from [here](../Files/.editorconfig)

Other rules is listed below:

# this Preferences

## Fields
Do not prefer `this`

```csharp
// Prefer:
capacity = 0;

// Over:
this.capacity = 0;
```

## Property
Prefer `this`

```csharp
// Prefer:
this.Id = 0;

// Over:
Id = 0;
```

## Method
Do not prefer `this`

```csharp
// Prefer:
Display();

// Over:
this.Display();
```

## Event Access
Prefer `this`.
```csharp
// Prefer:
this.Elapsed += Handler;

// Over:
Elapsed += Handler;
```

***

# Predefined type preferences

## For locals, parameters and members 
⚠ Prefer predefined type instead of framework type. 
> For example use `int` instead of `Int32`

```csharp
private int _member;
static void M(int argument)
{
	int local;
}
```

## For member access expressions 
```csharp
static void M(int argument)
{
	int local = int.MaxValue;
}
```

***

# 'var' preferences

## For built-in types
Prefer explicit type

```csharp
// Prefer:
int x = 5; // built-in types

// Over:
var x = 5; // built-in types
```

## When variable type is apparent
Prefer `var`

```csharp
var cojb = new C(); //type is apparent from assignment expression
```

## Elsewhere
Prefer `var`

```csharp
var f = this.Init(); //everywhere else
```

***

# Code block preferences

## Prefer braces
When on multiple lines

```csharp
// Allow:
if (test) Console.WriteLine("Text");

// Allow:
if (test)
    Console.WriteLine("Text");

// Prefer:
if (test)
{
    Console.WriteLine("Text");
}

// Over:
if (test)
    Console.WriteLine(
		"Text");
```

## Prefer Auto Properties
⚠ Yes

```csharp
// Prefer:
public int Age { get; }

// Over:
private int age;
public int Age
{
  get
  {
     return age;
  }
}
```

## Prefer Simple using Statement
Yes

```csharp
// Prefer:
void Method()
{
  using var resource = GetResource();
  ProcessResource(resource);
}

// Prefer:
void Method()
{
	using (var resource = GetResource())
		ProcessResource(resource);
}

// Over:
void Method()
{
  using (var resource = GetResource())
  {
     ProcessResource(resource);
  }
}
```

***

# Parantheses preferences

## In aritmethic operators
`*`  `/`  `%`  `+`  `-`  `<<`  `>>`  `&`  `^`  `|`  

Never if unnecessary

```csharp
// Prefer:
var v = a + b * c;

// Over:
var v = a + (b * c);
```

## In other binary operators
`&&` `||` `??`

Always for clarity

```csharp
// Prefer:
var v = a || (b && c);

// Over:
var v = a || b && c;
```

## In relational operators

 `<` `>` `<=` `>=` `is` `as` `!=`

Always for clarity

```csharp
// Prefer:
var v = (a < b) == (c > b);

// Over:
var v = a < b == c > b;
```

## In other operators
Never if unnecessary

```csharp
// Prefer:
var v = a.b.Length;

// Over:
var v = (a.b).Length;
```

***

# Expression preferences

## Prefer object initializer
⚠ Yes

```csharp
// Prefer:
var c = new Customer 
{
    Age = 21
};

// Over:
var c = new Customer();
c.Age = 21;

```

## Prefer collection initializer
⚠ Yes

```csharp
// Prefer:
var list = new List<int>
{
    1,
    2,
    3,
};

// Over:
var list = new List<int>();
list.Add(1);
list.Add(2);
list.Add(3);
```

## Prefer pattern matching over is with cast check
⚠ Yes

```csharp
// Prefer:
if (o is int i)
{
}

// Over:
if (o is int)
{
    var i = (int)o;
}
```

## Prefer pattern matching over as with null check
⚠ Yes

```csharp
// Prefer:
if (o is string s)
{
}

// Over:
var s = o as string;
if(s != null)
{
}
```

## Prefer conditional expression over if with assignments
ℹ Prefer Yes up to **one single** condition!

```csharp
// Prefer:
string s = expr ? "hello" : "world";

// Over:
string s;
if(expr)
{
    s = "hello";
}
else 
{
    s = "world";
}
```

## Prefer conditional expression over if with returns
ℹ Prefer Yes

```csharp
// Prefer:
return expr ? "hello" : "world";

// Over:
if(expr)
{
    return "hello";
}
else 
{
    return "world";
}
```

## Prefer explicit tuple name
ℹ Prefer Yes, *because it's new feature since C# 7*

```csharp
// Prefer:
public (string name, int age) GetCustomer()
{

}

// Over:
public Tuple<string,int> GetCustomer()
{

}

// Prefer:
(string name, int age) customer = GetCustomer();
var name = customer.name;
var age = customer.age;

// Over:
(string name, int age) customer = GetCustomer();
var name = customer.Item1;
var age = customer.Item2;
```

## Prefer simple default expression
ℹ Prefer Yes

```csharp
// Prefer:
void DoWork(CancellationToken cancellationToken = default) { }

// Over:
void DoWork(CancellationToken cancellationToken = default(CancellationToken)) { }
```

## Prefer inferred tuple element names
ℹ Prefer Yes

```csharp
// Prefer:
var tuple = (age, name);

// Over:
var tuple = (age: age, name: name);
```

## Prefer inferred anonymous type member names
ℹ Prefer Yes

```csharp
// Prefer:
var anon = new { age, name };

// Over:
var anon = new { age = age, name = name };
```

## Prefer local function over anonymous function
⚠ Yes

```csharp
// Prefer:
int fibonacci(int n)
{
    return n <= 1 ? n : fibonacci(n - 1) + fibonacci(n - 2);
}

// Over:
Func<int, int> fibonacci = null;
fibonacci = (int n) =>
{
    return n <= 1 ? n : fibonacci(n - 1) + fibonacci(n - 2);
}
```

## Prefer compound assignments
ℹ Prefer Yes

```csharp
// Prefer:
value += 10;

// Over:
value = value + 10;
```

## Prefer index operator
⚠ Yes

```csharp
// Prefer:
var ch = value[^1];

// Over:
var ch = value[value.Length - 1];
```

## Prefer range operator
⚠ Yes

```csharp
// Prefer:
var sub = value[1..^1];

// Over:
var sub = value.Substring(1, value.Length - 2);
```

## Use expression body for methods
ℹ Prefer when on single line

```csharp
class Customer
{
    private int age;
    public int GetAge() => age;
}
```

## Use expression body for constructors
❌ Never

```csharp
class Customer
{
    private int age;
    public Customer(int age)
    {
        this.age = age;
    }
}
```

## Use expression body for operators
ℹ When on single line

```csharp
public static ComlexNumber operator +(ComlexNumber c1, ComlexNumber c2)
    => new ComlexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
```

## Use expression body for properties
ℹ When possible

```csharp
class Customer
{
    private int _age;
    public int Age => _age;
}
```

## Use expression body for indexers
ℹ When possible

```csharp
class List<T>
{
    private T[] _values;
    public T this[int i] => _values[i];
}
```

## Use expression body for accessors
⚠ When possible

```csharp
class Customer
{
    private int _age;
    public int Age 
    {
        get => _age;
        set => _age = value;
    }
}
```

## Use expression body for lambdas
When possible

```csharp
Func<int, string> f = a => a.ToString();
```

## Expression body for local functions
ℹ When possible

```csharp
class Customer
{
    private int age;
    public int GetAge()
    {
        return GetAgeLocal();

        int GetAgeLocal() => age;
    }
}
```

## Avoid unused value assignments
ℹ Discard

```csharp
// Prefer:
_ = Computation(); // Unused value is explicitly assigned to discard
int x = 1;

// Over:
var unused = Computation(); // Unused value is explicitly assigned to an unused local
int x = 1;

// Over:
var x = Computation(); // Value assigned here is never used
int x = 1;
```

## Avoid expression statements that implicitly ignore value
Discard

```csharp
// Prefer:
_ = Computation();

// Over:
var unused = Computation();

// Over:
Computation();
```

***

# Variable preferences

## Prefer inlined variable declaration
ℹ Yes

```csharp
// Prefer:
if (int.TryParse(value, out int i))
{
}

// Over:
int i;
if (int.TryParse(value, out i))
{
}
```

## Prefer deconstructed variable declaration
ℹ Yes

```csharp
// Prefer:
var (name, age) = GetPersonTuple();
Console.WriteLine($"{name} {age}");

(int x, int y) = GetPointTuple();
Console.WriteLine($"{x} {y}");

// Over:
var person = GetPersonTuple();
Console.WriteLine($"{person.name} {person.age}");

var point = GetPointTuple();
Console.WriteLine($"{point.x} {point.y}");
```

***

# 'null' checking

## Prefer throw-expression
⚠ Yes

```csharp
// Prefer:
this.s = s ?? throw new ArgumentNullException(nameof(s));

// Over:
if (s == null)
    throw new ArgumentNullException(nameof(s));

this.s = s;
```

## Prefer conditional delegate call
⚠ Yes

```csharp
// Prefer:
func?.Invoke(args);

// Over:
if (func != null)
{
    func(args);
}
```

## Prefer coalesce expression
❌ YES!

```csharp
// Prefer:
var v = x ?? y;

// Over:
var v = x != null ? x : y; // or
var v = x == null ? y : x;
```

## Prefer null propagition
❌ YES!

```csharp
// Prefer:
var v = o?.ToString();

// Over:
var v = o == null ? null : o.ToString(); // or
var v = o != null ? o.ToString() : null;
```

## Prefer is null for reference equality checks
⚠ Yes

```csharp
// Prefer:
if (value1 is null)
    return;

if (value2 is null)
    return;

// Over:
if (object.ReferenceEquals(value1, null))
    return;

if ((object)value2 == null)
    return;
```

****

# 'using' preferences

## Prefered using directive placement
Outside namespace

```csharp
// Prefer:
using System;
using System.Linq;

namespace Namespace
{
    class Customer
    {
    }
}

// Over:
namespace Namespace
{
    using System;
    using System.Linq;

    class Customer
    {
    }
}
```

***

# Modifier preferences

## Prefer readonly fields
⚠ Yes

```csharp
// Prefer:
// '_value' can only be assigned in constructor
private readonly int _value = 0;

// Over:
// '_value' can be assigned anywhere
private int _value = 0;
```

## Prefer static local functions
❌ YES!

If a local function doesn't use any member from method body, just declare it as static!

```csharp
void Method()
{
    // Prefer:
    static int fibonacci(int n)
    {
        return n <= 1 ? n : fibonacci(n - 1) : fibonacci(n - 2);
    }
}

void Method()
{
    // Over:
    int fibonacci(int n)
    {
        return n <= 1 ? n : fibonacci(n - 1) : fibonacci(n - 2);
    }
}
```

# Parameter preferences

## Avoid unused parameters
ℹ All methods

```csharp
// Prefer:
public void M()
{
}

// Over:
public void M(int param)
{
}
```
