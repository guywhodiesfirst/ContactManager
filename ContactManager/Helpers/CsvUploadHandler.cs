using ContactManager.Models;
using ContactManager.Exceptions;
using CsvHelper;
using System.Globalization;

namespace ContactManager.Helpers
{
    public class CsvUploadHandler
    {
        public List<ContactDto> ParseCsv(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            if (extension != ".csv")
            {
                throw new CsvException("Extension is not valid - should be .csv");
            }

            long size = file.Length;
            if (size > 1 * 1024 * 1024)
            {
                throw new CsvException("File size should not exceed 1 mb");
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
            catch (Exception ex)
            {
                throw new CsvException(ex.Message);
            }
        }
    }
}
