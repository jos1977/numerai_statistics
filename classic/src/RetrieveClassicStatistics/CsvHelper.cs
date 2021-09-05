using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace RetrieveClassicStatistics
{
    class CsvHelper
    {
        public static void WriteCsv(System.Collections.IEnumerable records, string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";",
                HasHeaderRecord = true
            };

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (CsvWriter csvWriter = new CsvWriter(writer, config))
            {
                csvWriter.WriteRecords(records);

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());

                File.WriteAllText(fileName, result);
            }
        }
    }
}
