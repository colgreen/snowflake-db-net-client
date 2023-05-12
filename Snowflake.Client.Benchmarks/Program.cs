using BenchmarkDotNet.Running;
using Snowflake.Client.Benchmarks;

var switcher = new BenchmarkSwitcher(new[] {
            typeof(SnowflakeDataMapperBenchmarks),
            typeof(SnowflakeTypesConverterBenchmarks)
        });

switcher.Run(args);