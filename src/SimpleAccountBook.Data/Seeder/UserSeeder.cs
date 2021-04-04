using System.Collections.Generic;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Seeder
{
    public class UserSeeder
    {
        public static IEnumerable<User> GetUser()
        {
            return new List<User>
            {
                new User
                {
                    Email = "sample@sample.com",
                    Password = "",
                    DisplayName = "Sample User",
                    Businesses = new List<Business>
                    {
                        new Business
                        {
                            Name = "Sample",
                            Address = new Address
                            {
                                Zipcode="06232",
                                State = "서울특별시",
                                City = "강남구",
                                StreetAddress1 = "강남대로 382",
                                StreetAddress2 = null,
                                PhoneNumber= "010-1234-1234",
                            },
                            BusinessItem = "인적용역",
                            BusinessItemCode ="940909",
                            TypeOfIncomeCode = "40",
                            RegistrationNumber = "800101-1000000"
                        },
                    }
                }
            };
        }
    }
}
