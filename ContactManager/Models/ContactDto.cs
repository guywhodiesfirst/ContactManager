using CsvHelper.Configuration.Attributes;

namespace ContactManager.Models
{
    public class ContactDto
    {
        [Name("name")]
        public string Name { get; set; } = string.Empty;
        [Name("birthDate")]
        public DateTime BirthDate { get; set; }
        [Name("isMarried")]
        public bool IsMarried { get; set; }
        [Name("phone")]
        public string Phone { get; set; } = string.Empty;
        [Name("salary")]
        public decimal Salary { get; set; }
    }
}
