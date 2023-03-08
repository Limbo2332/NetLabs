namespace LAB1_Linq_To_Objects.Classes
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; } 
        public string? PhoneNumber { get; set; }
        

        public override string ToString()
        {
            return $"{Name} живе за адресою: \"{Address}\" i має номер телефону: {PhoneNumber}";
        }

    }
}
