﻿using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsMarried { get; set; }
        public string Phone { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}
