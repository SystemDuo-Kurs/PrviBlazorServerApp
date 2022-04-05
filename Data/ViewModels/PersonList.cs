using PrviBlazorServerApp.Data;

namespace PrviBlazorServerApp.Data.ViewModels
{
    public class PersonList
    {
        private Services.Person _personService;
        private ILogger _logger;

        public List<Models.Person> People { get; set; }
        public PersonList(Services.Person personService, ILogger<PersonList> logger)
        {
            _personService = personService;
            _logger = logger;
            People = _personService.GetAll();
        }

        public void GetAll()
        {
            People = _personService.GetAll();
        }
        public async Task Delete(Models.Person person) => await _personService.Delete(person);
    }
}
