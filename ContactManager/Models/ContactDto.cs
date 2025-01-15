namespace ContactManager.Models
{
    public class ContactDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsMarried { get; set; }
        public string Phone { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
