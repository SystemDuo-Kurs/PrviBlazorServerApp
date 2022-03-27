namespace PrviBlazorServerApp.Data.Services
{
    public class Person
    {
        private Db _baza;

        public Person(Db baza)
        {
            _baza = baza;
        }

        public List<Models.Person> GetAll()
            => _baza.People.ToList();

        /*{
            return _baza.People.ToList();
        }*/


        public async Task SaveAsync(Models.Person person)
        {
            _baza.Update(person);
            await _baza.SaveChangesAsync();
        }

        public void Delete(Models.Person person)
        {
            _baza.Remove(person);
            _baza.SaveChanges();
        }
    }
}