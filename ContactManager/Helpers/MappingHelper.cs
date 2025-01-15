using ContactManager.Models;

namespace ContactManager.Helpers
{
    public class MappingHelper
    {
        public static Contact MapToContact(ContactDto dto)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                IsMarried = dto.IsMarried,
                Phone = dto.Phone,
                Salary = dto.Salary
            };
            return contact;
        }
    }
}
