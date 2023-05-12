using System.Text;
using BenchmarkDotNet.Attributes;

namespace Snowflake.Client.Benchmarks
{
    [MemoryDiagnoser]
    public class SnowflakeTypesConverterBenchmarks
    {
        static readonly string __hexCharsLong = GenerateRandomHex(2_000_000);

        [Benchmark]
        public void HexToBase64_Short()
        {
            byte[] bytes = SnowflakeTypesConverter.HexToBytes("0a0b0c");
            string base64String = Convert.ToBase64String(bytes);
        }

        [Benchmark]
        public void HexToBase64_Long()
        {
            byte[] bytes = SnowflakeTypesConverter.HexToBytes(__hexCharsLong);
            string base64String = Convert.ToBase64String(bytes);
        }

        private static string GenerateRandomHex(int length)
        {
            Random rng = new(123);

            StringBuilder sb = new(length);
            for(int i = 0; i < length; i++)
            {
                sb.Append(rng.Next(0, 16).ToString("X"));
            }

            return sb.ToString();
        }
    }
}
