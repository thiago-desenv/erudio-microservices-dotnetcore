using RestWithAspNet.Controllers.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindbyId(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}
