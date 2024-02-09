using boutaburger.Models;
namespace boutaburger.Models.Domain


{
    public class Employee
    {
        public Guid ID { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
