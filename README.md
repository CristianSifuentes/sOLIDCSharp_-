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
  - [Interface Segregation Principle (ISP)](#interface-segregation-principle-isp)
  - [Dependency Inversion Principle (DIP)](#dependency-inversion-principle-dip)
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

### Interface Segregation Principle (ISP)

Interfaces should be specific and focused. Prefer smaller, purpose-built interfaces over large, general ones so implementers are not forced to support operations they do not need.

### Dependency Inversion Principle (DIP)

High-level modules should not depend on low-level modules. Both should depend on abstractions. This often leads to dependency injection and more loosely coupled, flexible architecture.

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
