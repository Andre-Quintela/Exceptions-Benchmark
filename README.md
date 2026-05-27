# Exceptions Benchmark

This is a simple C# benchmarking project using BenchmarkDotNet. It compares the performance and memory allocation of parsing strings to integers using two different approaches:

1. ParseWithCatch: Using `int.Parse` inside a `try-catch` block to handle invalid conversions.
2. TryParse: Using the `int.TryParse` method, which is the recommended and optimized approach.

The benchmark demonstrates the severe performance penalties and unnecessary memory allocations caused by throwing and catching exceptions in regular application flow.

## Requirements

- .NET 10.0 SDK

## How to run

To run the benchmarks, execute the following command in your terminal from the project root directory. Benchmarks must be run in Release mode to yield accurate results:

```bash
dotnet run -c Release
```
