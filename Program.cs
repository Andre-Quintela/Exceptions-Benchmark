using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

BenchmarkRunner.Run<ParseBenchmark>();

[MemoryDiagnoser]
[Config(typeof(Config))]
public class ParseBenchmark
{
    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithTimeUnit(TimeUnit.Millisecond);
        }
    }

    private string[] _valores;

    [Params(100, 1000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        _valores = new string[N];
        var random = new Random(42);
        for (int i = 0; i < N; i++)
        {
            // Create a mix of valid numbers (80%) and invalid strings (20%)
            if (random.NextDouble() < 0.8)
                _valores[i] = random.Next(1, 100).ToString();
            else
                _valores[i] = "invalid_string";
        }
    }

    [Benchmark(Baseline = true)]
    public int ParseWithCatch()
    {
        int soma = 0;
        foreach (var valor in _valores)
        {
            try
            {
                soma += int.Parse(valor);
            }
            catch
            {
            }
        }
        return soma;
    }

    [Benchmark]
    public int TryParse()
    {
        int soma = 0;
        foreach (var valor in _valores)
        {
            if (int.TryParse(valor, out var numero))
            {
                soma += numero;
            }
        }
        return soma;
    }
}
