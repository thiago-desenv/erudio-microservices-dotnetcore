using System.Collections.Generic;
using System.Threading;
using RestWithAspNet.Model;

namespace RestWithAspNet.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindbyId(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Goiaba",
                LastName = "Goiabada",
                Address = "São paulo - São paulo - Brasil",
                Gender = 'M'
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Abacaxi" + i,
                LastName = "Abacaxizeiro" + i,
                Address = "São paulo - Guarulho - Brasil" + i,
                Gender = 'F'
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
