namespace PersonApi
{
    public class People
    {

        public string FiscalCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public People (string fiscalCode, string firstName, string lastName, int age)
        {
            FiscalCode = fiscalCode;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public People ()
        {

        }
    }
}