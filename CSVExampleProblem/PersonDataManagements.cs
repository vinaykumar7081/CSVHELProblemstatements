using CsvHelper;
using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSVExampleProblem
{
    public class PersonDataManagements
    {
        string IMPORT_FILEPATH = @"D:\CommaSeparatedValue\CSVHELProblemstatements\CSVExampleProblem\Address.csv";
        string EXPORT_FILEPATH = @"D:\CommaSeparatedValue\CSVHELProblemstatements\CSVExampleProblem\Export.csv";
        const string EXPORT_JSON_FILENAME = @"D:\CommaSeparatedValue\CSVHELProblemstatements\CSVExampleProblem\Export.json";
        public void ImplementationCsv()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var Csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                { 
                var records=Csv.GetRecords<Address>().ToList();
                    foreach (var record in records)
                    { 
                    Console.WriteLine(record.FirstName+" "+record.LastName+" "+record.AddressDetails+" "+record.City+" "+record.Email+" "+record.PhoneNumber);
                    }
                    using (var writer = new StreamWriter(EXPORT_FILEPATH))
                    {
                        using (var CsvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        { 
                        CsvExport.WriteRecords(records);
                        
                        }
                    }
                }
            }
        }
        public void ImplementationJson()
        {
            using (var reader = new StreamReader(IMPORT_FILEPATH))
            {
                using (var Csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = Csv.GetRecords<Address>().ToList();
                    foreach (var record in records)
                    {
                        Console.WriteLine(record.FirstName + " " + record.LastName + " " + record.AddressDetails + " " + record.City + " " + record.Email + " " + record.PhoneNumber);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writer = new StreamWriter(EXPORT_JSON_FILENAME))
                    {
                        using (var jsonWriter = new JsonTextWriter(writer))
                        {
                            serializer.Serialize(writer, records);

                        }
                    }
                }
            }
        }
    }
}
