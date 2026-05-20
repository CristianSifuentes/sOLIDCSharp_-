# sOLIDCSharp_

A practical learning repository for SOLID principles in C#.

## Table of Contents

- [Summary](#summary)
- [What are SOLID principles?](#what-are-solid-principles)
- [What does each letter in SOLID mean?](#what-does-each-letter-in-solid-mean)
  - [Single Responsibility Principle (SRP)](#single-responsibility-principle-srp)
    - [SRP definition in C#](#srp-definition-in-c)
    - [Why SRP matters](#why-srp-matters)
    - [Applying SRP in C#](#applying-srp-in-c)
    - [System components under SRP](#system-components-under-srp)
    - [Practical example: user confirmation workflow](#practical-example-user-confirmation-workflow)
    - [StudentRepository case study](#studentrepository-case-study)
  - [Open/Closed Principle (OCP)](#openclosed-principle-ocp)
    - [OCP definition in C#](#ocp-definition-in-c)
    - [Why OCP matters](#why-ocp-matters)
    - [A violation of OCP](#a-violation-of-ocp)
    - [Applying OCP with abstraction and polymorphism](#applying-ocp-with-abstraction-and-polymorphism)
    - [OCP in this repository](#ocp-in-this-repository)
    - [Techniques to implement OCP in C#](#techniques-to-implement-ocp-in-c)
    - [Scientific design heuristic](#scientific-design-heuristic)
  - [Liskov Substitution Principle (LSP)](#liskov-substitution-principle-lsp)
    - [LSP definition in C#](#lsp-definition-in-c)
    - [Why LSP matters](#why-lsp-matters)
    - [The type and subtype contract](#the-type-and-subtype-contract)
    - [A classic LSP violation](#a-classic-lsp-violation)
    - [Fixing the design with capabilities](#fixing-the-design-with-capabilities)
    - [Employee example: when inheritance lies](#employee-example-when-inheritance-lies)
    - [LSP in this repository](#lsp-in-this-repository)
    - [How to detect LSP violations](#how-to-detect-lsp-violations)
    - [LSP best practices in C#](#lsp-best-practices-in-c)
  - [Interface Segregation Principle (ISP)](#interface-segregation-principle-isp)
    - [ISP definition in C#](#isp-definition-in-c)
    - [Why ISP matters](#why-isp-matters)
    - [The problem with fat interfaces](#the-problem-with-fat-interfaces)
    - [Applying ISP with focused contracts](#applying-isp-with-focused-contracts)
    - [ISP and dependency injection](#isp-and-dependency-injection)
    - [ISP and the Open/Closed Principle](#isp-and-the-openclosed-principle)
    - [How to detect ISP violations](#how-to-detect-isp-violations)
    - [ISP best practices in C#](#isp-best-practices-in-c)
  - [Dependency Inversion Principle (DIP)](#dependency-inversion-principle-dip)
    - [DIP definition in C#](#dip-definition-in-c)
    - [High-level and low-level components](#high-level-and-low-level-components)
    - [Why DIP matters](#why-dip-matters)
    - [A direct dependency problem](#a-direct-dependency-problem)
    - [Applying DIP with abstractions](#applying-dip-with-abstractions)
    - [Types of dependency injection](#types-of-dependency-injection)
    - [DIP and TDD](#dip-and-tdd)
    - [DIP in a student API](#dip-in-a-student-api)
    - [DIP best practices in C#](#dip-best-practices-in-c)
- [Why apply SOLID from the start?](#why-apply-solid-from-the-start)
- [How SOLID helps in TDD](#how-solid-helps-in-tdd)
- [SOLID and object-oriented programming](#solid-and-object-oriented-programming)
- [Recommended C# practices](#recommended-c-practices)
- [Risks of violating SOLID in C#](#risks-of-violating-solid-in-c)
- [Community and learning](#community-and-learning)

> The table of contents is designed to grow with the repository, staying concise and easy to navigate as more sections are added.

## Summary

SOLID is a set of software design principles that improve object-oriented code by making it easier to understand, maintain, and extend. Popularized by Robert C. Martin in *Clean Code*, these principles help developers build systems with better structure and fewer hidden dependencies.

## What are SOLID principles?

SOLID is a mnemonic for five principles that guide good design in object-oriented systems. Each principle addresses a common source of technical debt and architectural fragility.

## What does each letter in SOLID mean?

### Single Responsibility Principle (SRP)

The Single Responsibility Principle states that every class, module, or service should have only one reason to change. In a well-designed C# system, SRP is a cornerstone of cohesion and modularity.

#### SRP definition in C#

- A class should represent a single domain concept or model.
- A method should perform one clear operation and be named to express that action.
- A module should have one focus, and a library should provide one family of related capabilities.

#### Why SRP matters

- Improves modularity: smaller, self-contained components are easier to reason about.
- Makes maintenance safer: a targeted change affects a narrow area of the codebase.
- Reduces coupling: components depend on fewer concerns and clearer abstractions.
- Enhances testability: single-purpose units are simpler to verify with focused tests.

#### Applying SRP in C#

- Identify distinct responsibilities and assign them to separate types.
- Group related behavior in classes or services that share the same role.
- Use interfaces to express abstractions and keep implementation details hidden.
- Avoid cyclic or mutual dependencies between classes that represent different concerns.

#### System components under SRP

SRP applies beyond classes and methods:

- Modules should implement a single function or responsibility.
- Libraries should expose a cohesive set of features, not a mixed bag of unrelated concerns.
- In microservice architectures, each service should own one domain process or capability.

#### Practical example: user confirmation workflow

Consider a user story where after a purchase is confirmed, the system must:

- show a confirmation message and save the event,
- provide a receipt download,
- send a confirmation email.

A monolithic class that handles all three responsibilities violates SRP. Instead, separate these into distinct components:

- a confirmation handler,
- an invoice/download service,
- an email notification service.

Each component remains focused, easier to extend, and less prone to regression.

#### StudentRepository case study

A `StudentRepository` example is a strong candidate for SRP analysis. If it combines data access, validation, and notification, it should be refactored so each responsibility lives in a dedicated class. This is an ideal exercise for identifying SRP violations and evolving a design toward cleaner, single-purpose services.

In short, SRP is not a rule of thumb; it is a scientific approach to software structure. Applying it consistently helps produce C# designs that are maintainable, extensible, and resilient to future change.

### Open/Closed Principle (OCP)

Software should be open for extension but closed for modification. New behavior should be added by extending existing code, not by modifying the code that already works.

#### OCP definition in C#

The Open/Closed Principle, attributed to Bertrand Meyer and later popularized through the SOLID principles by Robert C. Martin, states that software entities such as classes, modules, and functions should be:

- open for extension: new behavior can be added when requirements evolve,
- closed for modification: existing, tested behavior should remain stable and untouched.

In practical C# terms, OCP means designing around abstractions such as interfaces, abstract classes, polymorphism, and composition. The goal is not to freeze the system forever, but to protect proven code from unnecessary edits when new variants, rules, or behaviors appear.

#### Why OCP matters

Real software evolves continuously. New report formats, payment methods, notification channels, discount rules, export types, and validation strategies appear over time. If every new requirement forces developers to reopen and modify stable classes, the risk of regression increases.

OCP helps reduce that risk by encouraging a design where new features are introduced through new code that plugs into existing contracts.

This leads to:

- better modularity: each behavior can live in its own implementation,
- safer maintenance: stable code is not repeatedly edited for every new case,
- stronger testability: each extension can be tested independently,
- improved scalability: the system can grow by adding components instead of expanding conditional logic,
- clearer architecture: abstractions reveal the variation points of the system.

#### A violation of OCP

Consider a report generator that decides what to do by checking a string value:

```csharp
public class ReportGenerator
{
    public string GenerateReport(string reportType)
    {
        if (reportType == "PDF")
        {
            return "PDF Report Generated";
        }

        if (reportType == "Excel")
        {
            return "Excel Report Generated";
        }

        return "Invalid Report Type";
    }
}
```

The problem is not the `if` statement by itself. The deeper design issue is that every new report type requires changing `ReportGenerator`. If the application later needs Word, CSV, HTML, or JSON reports, the same class must keep growing.

That means `ReportGenerator` is open for modification, which is the opposite of what OCP asks us to protect.

#### Applying OCP with abstraction and polymorphism

A better design defines a contract for report generation and lets each report type implement that contract.

```csharp
public interface IReport
{
    string Generate();
}
```

Each report becomes an independent extension:

```csharp
public sealed class PdfReport : IReport
{
    public string Generate()
    {
        return "PDF Report Generated";
    }
}

public sealed class ExcelReport : IReport
{
    public string Generate()
    {
        return "Excel Report Generated";
    }
}
```

The generator now depends on the abstraction, not on concrete report types:

```csharp
public sealed class ReportGenerator
{
    public string GenerateReport(IReport report)
    {
        return report.Generate();
    }
}
```

Usage:

```csharp
ReportGenerator generator = new();

Console.WriteLine(generator.GenerateReport(new PdfReport()));
Console.WriteLine(generator.GenerateReport(new ExcelReport()));
```

If a new `WordReport` is required, the system grows by adding a new class:

```csharp
public sealed class WordReport : IReport
{
    public string Generate()
    {
        return "Word Report Generated";
    }
}
```

No change is required in `ReportGenerator`. That is the essence of OCP: the behavior expands, while the stable orchestration remains closed to modification.

#### OCP in this repository

The SRP refactor in `1-SingleResponsability` prepares the ground for OCP. For example, `StudentExporter` does not know whether students are formatted as CSV, JSON, XML, or plain text. It depends on the `IStudentReportFormatter` abstraction:

```csharp
public interface IStudentReportFormatter
{
    string Format(IEnumerable<Student> students);
}
```

Today the project includes `StudentCsvFormatter`. Tomorrow, a new formatter could be added:

```csharp
public sealed class StudentJsonFormatter : IStudentReportFormatter
{
    public string Format(IEnumerable<Student> students)
    {
        return JsonSerializer.Serialize(students);
    }
}
```

The important architectural result is that `StudentExporter` would not need to be rewritten. The system is open to a new export format, but the existing export workflow stays closed to modification.

#### Techniques to implement OCP in C#

- Interfaces and abstract classes: define contracts that new implementations can satisfy.
- Strategy pattern: encapsulate interchangeable algorithms or behaviors.
- Decorator pattern: add behavior to an object without modifying its class.
- Dependency injection: provide dependencies from the outside so high-level code depends on abstractions.
- Composition over inheritance: build behavior by combining focused components.

#### Scientific design heuristic

Use OCP when variation is expected. If a behavior is likely to have multiple versions, model it behind an abstraction. If a behavior is stable and unlikely to change, avoid premature abstraction.

The professional skill is not adding interfaces everywhere. The skill is identifying the axis of change: the part of the system that is most likely to evolve. OCP is strongest when it protects stable code while giving unstable requirements a clean extension point.

### Liskov Substitution Principle (LSP)

Derived types must be substitutable for their base types without breaking program behavior. This ensures that subclasses behave consistently when used through a common abstraction.

#### LSP definition in C#

The Liskov Substitution Principle was introduced by Barbara Liskov and later incorporated into SOLID by Robert C. Martin. Its central idea is precise:

> Objects of a base type should be replaceable by objects of a subtype without changing the correctness of the program.

In simpler C# terms: if code works with an `Employee`, `Shape`, `Stream`, or any other base abstraction, it should continue to work correctly when it receives any valid subtype of that abstraction.

LSP is not only about inheritance compiling successfully. It is about behavioral compatibility. A subtype must honor the promises made by its base type.

#### Why LSP matters

Inheritance creates a scientific contract between a type and its subtypes. When that contract is honest, polymorphism becomes powerful. When that contract is false, the system becomes fragile.

Violating LSP can lead to:

- unexpected behavior in polymorphic code,
- runtime errors hidden behind base-class references,
- conditionals that check concrete types with `is` or `as`,
- tests that pass for the base class but fail for derived classes,
- hierarchies that become harder to extend safely.

Respecting LSP makes code more predictable, reusable, testable, and easier to evolve.

#### The type and subtype contract

For a subtype to be substitutable, the following must remain true:

- The subtype includes the meaningful properties and behaviors of the base type.
- The inherited members make sense for the subtype.
- The subtype does not weaken the expectations established by the base type.
- Client code can use the subtype through the base abstraction without special checks.

The key question is not only "is this subtype related by name?" The stronger question is "can this subtype behave correctly everywhere the base type is expected?"

#### A classic LSP violation

The rectangle and square example is one of the clearest ways to understand the problem.

```csharp
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}
```

At first glance, making `Square` inherit from `Rectangle` seems natural:

```csharp
public class Square : Rectangle
{
    public override int Width
    {
        set
        {
            base.Width = value;
            base.Height = value;
        }
    }

    public override int Height
    {
        set
        {
            base.Height = value;
            base.Width = value;
        }
    }
}
```

But the subtype changes the behavior expected from the base type:

```csharp
void PrintArea(Rectangle rectangle)
{
    rectangle.Width = 5;
    rectangle.Height = 10;

    Console.WriteLine(rectangle.GetArea()); // Expected: 50
}

PrintArea(new Square()); // The behavior is no longer correct for the caller.
```

The issue is not that a square and a rectangle are unrelated in mathematics. The issue is that this software model gives `Rectangle` two independently mutable dimensions, while `Square` cannot honestly support that contract.

#### Fixing the design with capabilities

When behavior differs, composition and interfaces often model the domain more accurately than inheritance.

```csharp
public interface IShape
{
    int GetArea();
}

public sealed class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

public sealed class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}
```

Now the shared abstraction is not "has width and height." The shared abstraction is "can calculate area."

```csharp
void PrintArea(IShape shape)
{
    Console.WriteLine(shape.GetArea());
}
```

This design is LSP-compliant because every `IShape` can be substituted safely wherever area calculation is required.

#### Employee example: when inheritance lies

Consider an employee hierarchy with full-time employees and contractors. A full-time employee may have overtime compensation, while a contractor may not.

An LSP violation appears if the base `Employee` class contains a method such as `CalculateOvertime()` and every subtype is forced to inherit it. A `ContractorEmployee` would then inherit behavior that does not belong to it.

That design usually produces one of these symptoms:

```csharp
public override decimal CalculateOvertime()
{
    throw new NotImplementedException();
}
```

or:

```csharp
if (employee is ContractorEmployee)
{
    // Avoid overtime logic.
}
```

Both are warning signs. The base type promised a capability that not every subtype can honor.

A better design keeps shared employee data in the base type and moves special capabilities into more precise abstractions:

```csharp
public abstract class Employee
{
    public string FullName { get; init; } = string.Empty;
    public int HoursWorked { get; init; }

    public abstract decimal CalculateSalary();
}

public interface IOvertimeEligible
{
    decimal CalculateOvertime();
}
```

Then only the employees that truly support overtime implement the overtime capability:

```csharp
public sealed class FullTimeEmployee : Employee, IOvertimeEligible
{
    public override decimal CalculateSalary()
    {
        return HoursWorked * 50;
    }

    public decimal CalculateOvertime()
    {
        return Math.Max(0, HoursWorked - 160) * 75;
    }
}

public sealed class ContractorEmployee : Employee
{
    public override decimal CalculateSalary()
    {
        return HoursWorked * 40;
    }
}
```

The architecture becomes more honest: all employees can calculate salary, but only overtime-eligible employees calculate overtime.

#### LSP in this repository

The `3-LiskovSubstitution` project demonstrates LSP through an employee payroll model. The original design had two important problems:

- `Employee` contained `ExtraHours`, even though contractors do not use overtime.
- Salary calculation depended on a boolean flag that told the base class whether the employee was full-time.

That design made substitution fragile. A caller could not simply trust the `Employee` abstraction. It had to know which subtype it was dealing with, which is exactly the kind of hidden type dependency LSP warns us about.

The corrected design keeps the base class small and truthful:

```csharp
public abstract class Employee
{
    protected Employee(string fullname, int hoursWorked)
    {
        Fullname = fullname;
        HoursWorked = hoursWorked;
    }

    public string Fullname { get; }
    public int HoursWorked { get; }
    public abstract string ContractType { get; }

    public abstract decimal CalculateSalary();
}
```

The base type now promises only what every employee can honestly provide. Full-time employees and contractors each implement their own salary behavior:

```csharp
public sealed class EmployeeFullTime : Employee, IOvertimeEligible
{
    public override decimal CalculateSalary()
    {
        return (50M * HoursWorked) + CalculateOvertimePay();
    }
}

public sealed class EmployeeContractor : Employee
{
    public override decimal CalculateSalary()
    {
        return 40M * HoursWorked;
    }
}
```

Overtime is modeled as a capability instead of a forced base-class member:

```csharp
public interface IOvertimeEligible
{
    int ExtraHours { get; }
    decimal CalculateOvertimePay();
}
```

This distinction matters. Every employee can calculate salary, but only some employees can calculate overtime. The design therefore models behavior precisely instead of forcing every subtype into the same shape.

The payroll workflow becomes the practical substitution test:

```csharp
foreach (Employee employee in employees)
{
    decimal salary = employee.CalculateSalary();
    Console.WriteLine($"{employee.Fullname}: {salary}");
}
```

The loop does not need `is EmployeeFullTime` to calculate salary. It does not pass `true` or `false` into the base class. It trusts the abstraction, and each subtype behaves correctly through that abstraction.

To verify the implementation:

```powershell
dotnet build '3-LiskovSubstitution/LiskovSubstitution.csproj'
dotnet run --project '3-LiskovSubstitution/LiskovSubstitution.csproj'
```

Expected behavior:

- full-time employees include overtime pay,
- contractors calculate salary without fake overtime state,
- the payroll report works with `Employee` references without breaking.

This is LSP in practice: subtypes remain interchangeable through the base contract because the base contract is honest, minimal, and behaviorally stable.

#### How to detect LSP violations

Look for these signals in C# code:

- A subtype overrides a method just to throw `NotImplementedException`.
- A subtype returns fake values because the inherited member does not apply.
- Client code uses `is`, `as`, or `switch` to treat subtypes as exceptions.
- A base class exposes behavior that only some derived classes can support.
- Tests written for the base type fail when a derived type is substituted.
- Derived classes weaken validation rules, skip required behavior, or change expected side effects.

These signals usually mean the hierarchy is modeling taxonomy instead of behavior.

#### LSP best practices in C#

- Prefer behavioral abstractions over broad inheritance trees.
- Use interfaces to model capabilities such as `IShape`, `IOvertimeEligible`, or `IDiscountPolicy`.
- Keep base classes small and semantically honest.
- Avoid forcing subtypes to inherit members they cannot support.
- Favor composition when two concepts share data but not behavior.
- Design derived classes so they strengthen the model without surprising the caller.

In short, LSP protects the reliability of polymorphism. It asks every subtype to be a truthful participant in the contract established by its base type. When applied well, it transforms inheritance from a risky shortcut into a disciplined design tool.

### Interface Segregation Principle (ISP)

Interfaces should be specific and focused. Prefer smaller, purpose-built interfaces over large, general ones so implementers are not forced to support operations they do not need.

#### ISP definition in C#

The Interface Segregation Principle, proposed by Robert C. Martin, states:

> Clients should not be forced to depend upon interfaces that they do not use.

In C#, this means an interface should describe a coherent capability required by a specific client. Instead of designing one large contract that tries to represent every possible operation, ISP encourages many small, role-specific interfaces.

The scientific idea is dependency precision: a class should depend only on the behaviors it actually consumes. Every extra method in an interface is an unnecessary dependency, and unnecessary dependencies become friction when the system evolves.

#### Why ISP matters

Large interfaces look convenient at first, but they create structural coupling. When a class implements a method it does not support, the design is already lying.

ISP helps produce:

- lower coupling: classes depend on smaller contracts,
- safer maintenance: changing one capability does not ripple through unrelated implementers,
- better testability: small interfaces are easier to mock and verify,
- clearer intent: each interface communicates one role,
- stronger extensibility: new capabilities can be added as new contracts instead of bloating old ones.

ISP also supports long-term architecture because it makes boundaries explicit. A printing component should not be required to know about scanning. A PayPal vendor should not be forced to implement Bitcoin processing. A login service should not inherit annual-report behavior.

#### The problem with fat interfaces

A fat interface groups unrelated responsibilities into one contract:

```csharp
public interface IMachine
{
    void Print(Document document);
    void Scan(Document document);
    void Fax(Document document);
}
```

This forces simple devices to implement operations they cannot perform:

```csharp
public sealed class OldPrinter : IMachine
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing...");
    }

    public void Scan(Document document)
    {
        throw new NotImplementedException("OldPrinter cannot scan.");
    }

    public void Fax(Document document)
    {
        throw new NotImplementedException("OldPrinter cannot fax.");
    }
}
```

The problem is not only the exception. The deeper issue is that `IMachine` makes a false promise: it claims every machine can print, scan, and fax. `OldPrinter` is then forced to violate that promise at runtime.

#### Applying ISP with focused contracts

The correction is to split behavior by capability:

```csharp
public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

public interface IFax
{
    void Fax(Document document);
}
```

Now classes implement only the operations they truly support:

```csharp
public sealed class SimplePrinter : IPrinter
{
    public void Print(Document document)
    {
        Console.WriteLine("Simple print job executed.");
    }
}

public sealed class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing...");
    }

    public void Scan(Document document)
    {
        Console.WriteLine("Scanning...");
    }

    public void Fax(Document document)
    {
        Console.WriteLine("Faxing...");
    }
}
```

This design is more honest. A simple printer is not pretending to scan, and a multifunction printer can compose several capabilities without forcing those capabilities onto everyone else.

The same idea applies to business roles:

```csharp
public interface ILogin
{
    void IniciarSesion();
    void CerrarSesion();
}

public interface IReporte
{
    void GenerarReporteAnual();
}
```

A class that only handles authentication depends on `ILogin`. A class that only generates annual reports depends on `IReporte`. The client receives exactly the contract it needs.

#### ISP and dependency injection

ISP becomes especially powerful with dependency injection. A service should request the narrowest abstraction that lets it do its work:

```csharp
public sealed class DocumentProcessor
{
    private readonly IScanner scanner;

    public DocumentProcessor(IScanner scanner)
    {
        this.scanner = scanner;
    }

    public void Process(Document document)
    {
        scanner.Scan(document);
    }
}
```

`DocumentProcessor` does not know whether the concrete object can print or fax. It only knows that it can scan. This creates loose coupling and makes tests smaller, because a test double only needs to implement `IScanner`.

#### ISP and the Open/Closed Principle

ISP naturally supports the Open/Closed Principle. When capabilities are separated, new functionality can be introduced by adding a new interface or implementation instead of modifying one large shared contract.

For example, a payment system should avoid this:

```csharp
public interface IPaymentProcessor
{
    void ProcessCreditCard(string cardNumber);
    void ProcessPayPal(string email);
    void ProcessBitcoin(string walletAddress);
}
```

A vendor that supports only PayPal would be forced to depend on credit card and Bitcoin behavior. A better design segregates the contracts:

```csharp
public interface ICreditCardProcessor
{
    void ProcessCreditCard(string cardNumber);
}

public interface IPayPalProcessor
{
    void ProcessPayPal(string email);
}

public interface IBitcoinProcessor
{
    void ProcessBitcoin(string walletAddress);
}
```

Now each provider implements only the payment methods it supports:

```csharp
public sealed class PayPalVendor : IPayPalProcessor
{
    public void ProcessPayPal(string email)
    {
        Console.WriteLine($"Processing PayPal payment for {email}");
    }
}
```

The system becomes open to new payment capabilities while keeping existing providers closed to unrelated modifications.

#### How to detect ISP violations

Look for these signals:

- classes implement interface methods by throwing `NotImplementedException`,
- methods have empty bodies because the capability does not apply,
- one interface mixes unrelated roles such as login, reporting, persistence, and notification,
- tests need to mock many methods that the tested class never calls,
- adding one method to an interface forces many unrelated classes to change,
- client code receives a dependency with more power than it actually needs.

These are signs that the interface is modeling a category too broadly instead of modeling a precise capability.

#### ISP best practices in C#

- Name interfaces by role or capability, such as `IPrinter`, `IScanner`, `ILogin`, or `IReportGenerator`.
- Prefer several small interfaces over one general-purpose interface.
- Let classes implement multiple interfaces when they genuinely support multiple capabilities.
- Avoid adding methods to an existing interface just because one implementation needs them.
- Use dependency injection with the smallest useful abstraction.
- Keep interfaces stable, cohesive, and meaningful to their clients.

In short, ISP protects clients from unnecessary knowledge. It asks every interface to be a precise contract rather than a bucket of possible operations. When applied well, it produces systems that are easier to test, easier to extend, and calmer to maintain.

### Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions. This often leads to dependency injection and more loosely coupled, flexible architecture.

#### DIP definition in C#

The Dependency Inversion Principle states:

> High-level components should not depend on low-level components. Both should depend on abstractions.

In C#, this usually means that business logic should depend on interfaces or abstract classes instead of concrete infrastructure classes. A service that coordinates a use case should not be tightly coupled to a specific database repository, file logger, email sender, HTTP client, or storage provider.

DIP is called "inversion" because it reverses the usual dependency direction. Instead of high-level policy code depending directly on low-level implementation details, both sides depend on a stable abstraction.

#### High-level and low-level components

A high-level component contains business rules or orchestration logic. It decides what the application should do.

Examples:

- a student API endpoint,
- a payroll service,
- an order checkout service,
- a report generation workflow.

A low-level component contains technical details used to execute that behavior.

Examples:

- a SQL repository,
- a file-based logger,
- an email provider,
- an external payment gateway,
- a concrete storage implementation.

The high-level component should not know the concrete class names of these low-level details. It should know only the contract it needs.

#### Why DIP matters

DIP reduces the cost of change. Low-level details change frequently: a logger might move from console to file, a repository might move from memory to SQL, or an API client might be replaced by another provider.

When high-level logic depends directly on those details, every infrastructure change risks damaging business behavior.

DIP helps achieve:

- loose coupling: components know less about each other,
- better maintainability: implementation changes affect fewer files,
- stronger testability: dependencies can be replaced with test doubles,
- flexible architecture: new implementations can be added behind existing contracts,
- cleaner boundaries: business logic is separated from infrastructure details.

#### A direct dependency problem

Consider a service that calculates the area of a circle by depending directly on one concrete circle implementation:

```csharp
public sealed class ConcreteCircle
{
    private readonly double radius;

    public ConcreteCircle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.Round(Math.PI * Math.Pow(radius, 2));
    }
}

public sealed class CircleService
{
    private readonly ConcreteCircle circle;

    public CircleService(ConcreteCircle circle)
    {
        this.circle = circle;
    }

    public double CalculateArea()
    {
        return circle.CalculateArea();
    }
}
```

The problem is that `CircleService` depends directly on `ConcreteCircle`. If the application later needs a different shape, a different circle implementation, or a test double, the service is harder to reuse.

The dependency direction is too rigid: high-level orchestration knows low-level detail.

#### Applying DIP with abstractions

The correction is to introduce an abstraction that describes the behavior the high-level component needs:

```csharp
public interface IAreaCalculable
{
    double CalculateArea();
}
```

The low-level implementation depends on that abstraction:

```csharp
public sealed class ConcreteCircle : IAreaCalculable
{
    private readonly double radius;

    public ConcreteCircle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.Round(Math.PI * Math.Pow(radius, 2));
    }
}
```

The high-level service also depends on the abstraction:

```csharp
public sealed class AreaService
{
    private readonly IAreaCalculable shape;

    public AreaService(IAreaCalculable shape)
    {
        this.shape = shape;
    }

    public double CalculateArea()
    {
        return shape.CalculateArea();
    }
}
```

Usage:

```csharp
IAreaCalculable circle = new ConcreteCircle(5);
AreaService service = new(circle);

Console.WriteLine(service.CalculateArea());
```

Now `AreaService` is protected from concrete implementation details. A new shape can be introduced as long as it satisfies the `IAreaCalculable` contract.

#### Types of dependency injection

Dependency Injection is one common technique for applying DIP. It supplies dependencies from the outside instead of letting a class create them internally.

Common forms:

- constructor injection: dependencies are required at object creation time,
- property injection: dependencies are assigned through public properties,
- method parameter injection: dependencies are supplied only to the method that needs them.

Constructor injection is usually the preferred default in C# because it makes required dependencies explicit and prevents partially constructed objects.

Example:

```csharp
public sealed class StudentApi
{
    private readonly IStudentRepository studentRepository;
    private readonly ILogger logger;

    public StudentApi(IStudentRepository studentRepository, ILogger logger)
    {
        this.studentRepository = studentRepository;
        this.logger = logger;
    }
}
```

This constructor tells the truth: the API needs a repository and a logger to do its work.

#### DIP and TDD

DIP is essential for effective Test-Driven Development. Without abstractions, unit tests often become trapped behind real databases, real files, real network calls, or real logging infrastructure.

When a class depends on interfaces, tests can provide controlled substitutes:

```csharp
public sealed class InMemoryStudentRepository : IStudentRepository
{
    public IEnumerable<Student> GetAll()
    {
        return new[]
        {
            new Student(1, "Test Student")
        };
    }
}
```

The test can verify business behavior without requiring the production repository. That is the practical power of DIP: it makes important logic independently testable.

#### DIP in a student API

Imagine a student API that returns a list of students and records each API call in a log. A tightly coupled version might create concrete dependencies inside the API:

```csharp
public sealed class StudentApi
{
    private readonly StudentRepository repository = new();
    private readonly FileLogger logger = new();

    public IEnumerable<Student> GetStudents()
    {
        logger.Log("Students requested.");
        return repository.GetAll();
    }
}
```

This design works at first, but it is rigid. Changing the repository or logger requires editing the API itself.

A DIP-compliant design depends on abstractions:

```csharp
public interface IStudentRepository
{
    IEnumerable<Student> GetAll();
}

public interface IApplicationLogger
{
    void Log(string message);
}
```

The API receives those abstractions:

```csharp
public sealed class StudentApi
{
    private readonly IStudentRepository repository;
    private readonly IApplicationLogger logger;

    public StudentApi(IStudentRepository repository, IApplicationLogger logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public IEnumerable<Student> GetStudents()
    {
        logger.Log("Students requested.");
        return repository.GetAll();
    }
}
```

Now the API is stable. The repository can become SQL, in-memory, file-based, or external-service based. The logger can write to console, file, database, telemetry, or a test spy. The high-level API logic remains unchanged.

#### DIP best practices in C#

- Depend on interfaces for infrastructure and volatile details.
- Prefer constructor injection for required dependencies.
- Keep abstractions small and meaningful to the client.
- Avoid creating concrete dependencies inside high-level services.
- Use dependency injection containers only after the design boundaries are clear.
- Do not abstract everything prematurely; abstract the parts that are likely to vary or are expensive to test directly.
- Combine DIP with SRP, OCP, and ISP for cleaner service boundaries.

In short, DIP protects high-level policy from low-level volatility. It makes systems easier to test, easier to extend, and safer to change because business logic depends on stable contracts rather than fragile implementation details.

## Why apply SOLID from the start?

Using SOLID from the beginning establishes a strong foundation. It helps create scalable, reusable code, reduces technical debt, and encourages clear conventions that improve team collaboration.

## How SOLID helps in TDD

SOLID and Test-Driven Development (TDD) complement each other. TDD writes tests before implementing code, and SOLID encourages modular, testable design. Together they promote code that is easier to verify and evolve.

## SOLID and object-oriented programming

SOLID is especially well suited for object-oriented languages like C#, Java, and C++. While functional languages may not use SOLID in the same way, the principles still offer valuable guidance for good design.

## Recommended C# practices

- Keep responsibilities separate: avoid mixing domain models, UI rendering, and data access in the same class.
- Favor abstractions and interfaces for services and dependencies.
- Avoid platform-specific dependencies in core logic.
- Use factories, DI containers, and IoC frameworks rather than manual creation and cleanup calls.
- Design interfaces with a clear purpose and minimize unnecessary operations.

## Risks of violating SOLID in C# 

Violating SOLID can lead to:

- tightly coupled classes
- fragile code that breaks easily when extended
- hard-to-test implementations
- excessive complexity and maintenance cost
- duplicated or platform-specific code in core layers

Well-structured SOLID design prevents these issues and makes code easier to evolve.

## Community and learning

This repository is a place to learn and share experiences with SOLID in C#. If you have worked with SOLID principles or encountered them in interviews, your contributions and ideas are welcome.

---

### Future sections

The repository will expand gradually with examples, common violations, refactor patterns, and practical code demonstrations. The table of contents is intentionally compact so it can remain useful as the project grows.
