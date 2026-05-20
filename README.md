# sOLIDCSharp_

A practical learning repository for SOLID principles in C#.

## Table of Contents

- [Summary](#summary)
- [What are SOLID principles?](#what-are-solid-principles)
- [What does each letter in SOLID mean?](#what-does-each-letter-in-solid-mean)
  - [Single Responsibility Principle (SRP)](#single-responsibility-principle-srp)
  - [Open/Closed Principle (OCP)](#openclosed-principle-ocp)
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

Each class or module should have a single reason to change. Assigning one clear responsibility per component reduces complexity and improves maintainability.

### Open/Closed Principle (OCP)

Software should be open for extension but closed for modification. New behavior should be added by extending existing code, not by modifying the code that already works.

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
