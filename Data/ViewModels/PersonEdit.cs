namespace PrviBlazorServerApp.Data.ViewModels
{
    public class PersonEdit
    {
        private Services.Person _personService;
        private ILogger _logger;

        public Models.Person Person { get; set; } = new();
        public PersonEdit(Services.Person personService, ILogger<PersonEdit> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        public async Task SaveAsync()
        {
            await _personService.SaveAsync(Person);
            Person = new();
        }
    }
}
