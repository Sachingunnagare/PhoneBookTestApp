namespace PhoneBookTestApp.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private static List<Person> personDetails = new List<Person>
            {
                new Person
                {
                    Id=1,
                    Name="Sachin",
                    PhoneNumber="+919986706094",
                    Address="Bangalore"
                },
                new Person
                {
                    Id=2,
                    Name="John Smith",
                    PhoneNumber="(248) 123-4567",
                    Address="1234 Sand Hill Dr, Royal Oak, MI"
                },
                new Person
                {
                    Id=3,
                    Name="Cynthia Smith",
                    PhoneNumber="(824) 128-8758",
                    Address="875 Main St, Ann Arbor, MI"
                }
            };
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }
        public  async Task<List<Person>> AddPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return await _context.Persons.ToListAsync();
        }

        public async Task<List<Person>?> DeletePerson(int id)
        {
            var phoneUser = await _context.Persons.FindAsync(id);
            if (phoneUser is null)
                return null;
           _context.Persons.Remove(phoneUser);
            await _context.SaveChangesAsync();
            return await _context.Persons.ToListAsync();
        }


        public async Task<List<Person>> GetAllPerson()
        {
            var persons = await _context.Persons.ToListAsync();
            return persons;
        }

        public async Task<Person?> findPerson(int id)
        {
            var PhoneUser = await _context.Persons.FindAsync(id);
            if (PhoneUser is null)
                return null;
            return PhoneUser;
        }

        public async Task<List<Person>?> UpdatePerson(int id, Person requestPerson)
        {
            var PhoneUser = await _context.Persons.FindAsync(id);
            if (PhoneUser is null)
                return null;
            PhoneUser.Name = requestPerson.Name;
            PhoneUser.PhoneNumber = requestPerson.PhoneNumber;
            PhoneUser.Address = requestPerson.Address;

            await _context.SaveChangesAsync();

            return await _context.Persons.ToListAsync();
        }

    }
}