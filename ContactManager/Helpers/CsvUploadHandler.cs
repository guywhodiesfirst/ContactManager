using ContactManager.Models;
using ContactManager.Exceptions;
using CsvHelper;
using System.Globalization;

namespace ContactManager.Helpers
{
    public class CsvUploadHandler
    {
        public static List<ContactDto> ParseCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new CsvException("File cannot be empty");
            }
            string extension = Path.GetExtension(file.FileName);
            if (extension != ".csv")
            {
                throw new CsvException("File extension is not valid - should be .csv");
            }

            long size = file.Length;
            if (size > 1 * 1024 * 1024)
            {
                throw new CsvException("File size should not exceed 1mb");
            }

            try
            {
                using var stream = file.OpenReadStream();
                using (var streamReader = new StreamReader(stream))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        var records = csvReader.GetRecords<ContactDto>().ToList();
                        return records;
                    }
                }
            }
            catch (Exception)
            {
                throw new CsvException("Error occurred while processing your file. " +
                    "Please ensure the CSV file has the required columns and that their data types match");
            }
        }
    }
}
