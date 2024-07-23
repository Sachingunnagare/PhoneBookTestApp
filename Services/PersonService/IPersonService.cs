
namespace PhoneBookTestApp.Services.PersonService
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPerson();
        Task<Person?> findPerson(int id);
        Task<List<Person>> AddPerson(Person person);
        Task<List<Person>?> UpdatePerson(int id, Person requestPerson);
        Task<List<Person>?> DeletePerson(int id);
    }
}
