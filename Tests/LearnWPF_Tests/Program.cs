using System.Collections;
using System.Globalization;

namespace LearnWPF_Tests
{
    internal class Program
    {
        static string url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/refs/heads/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync(url).Result;
            //var data = response.Content.ReadAsStringAsync().Result;

            //foreach (string line in GetDataLines())
            //{
            //    Console.WriteLine(line);
            //}

            //foreach (var data in GetDateTimes())
            //{
            //    Console.WriteLine(data);
            //}

            var russian_data = GetData()
                .First(c => c.country.Equals("russia", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(String.Join("\r\n", GetDateTimes().Zip(russian_data.counts, (date, count) => $"{date} - {count}")));

            Console.ReadKey();
        }

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var stream = GetDataStream().Result;
            using var dataReader = new StreamReader(stream);

            while (!dataReader.EndOfStream)
            {
                var line = dataReader.ReadLine();
                if (String.IsNullOrWhiteSpace(line)) continue;

                line = line.Replace("Bonaire,", "Bonaire -");
                line = line.Replace("Korea,", "Korea -");

                yield return line;
            }
        }

        private static IEnumerable<(string country, string province, int[] counts)> GetData()
        {
            // Пропускаем первую строку с заголовками
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            int currentRow = 1;
            foreach (var row in lines)
            {
                string province = row[0].Trim() ?? string.Empty;
                string country = row[1].Trim(' ', '"') ?? string.Empty;

                var test = row.Skip(4);

                var counts = row.Skip(4)
                    .Select(int.Parse).ToArray();

                currentRow++;

                yield return (country, province, counts);
            }
        }

        private static DateTime[] GetDateTimes() => 
            GetDataLines()
                .First()
                .Split(',')
                .Skip(4)
                .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
                .ToArray();

    }
}
