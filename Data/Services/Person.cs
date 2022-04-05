using Microsoft.AspNetCore.SignalR;

namespace PrviBlazorServerApp.Data.Services
{
    public class Person
    {
        private Db _baza;
        private IHubContext<CrudHub> _crudHub;

        public Person(Db baza, IHubContext<CrudHub> crudHub)
        {
            _baza = baza;
            _crudHub = crudHub;
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
            await _crudHub.Clients.All.SendAsync("bilaPromena");
        }

        public async Task Delete(Models.Person person)
        {
            _baza.Remove(person);
            await _baza.SaveChangesAsync();
            await _crudHub.Clients.All.SendAsync("bilaPromena");
        }
    }
}