using Application.Interfaces;
using Domain.Models;

namespace Services
{
    public class PersonService
    {
        private readonly IUnitOfWork _uof;
        public PersonService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public List<Person> getAllPersons()
        {
            try
            {
                var Persons = _uof.Persons.GetAll().ToList();
                if (Persons != null)
                {
                    return Persons;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Person getPersonById(int id)
        {
            try
            {
                var Person = _uof.Persons.GetByid(id);
                if (Person == null)
                {
                    return null;
                }
                return Person;
            }
            catch
            {
                return null;
            }
        }

        public Person addPerson(Person Person)
        {
            try
            {
                var r = _uof.Persons.Add(Person);
                _uof.Complete();
                return Person;
            }
            catch
            {
                return null;
            }
        }
        public bool removePerson(int id)
        {
            try
            {
                var Persons = _uof.Persons.GetByid(id);
                _uof.Persons.Delete(Persons);
                _uof.Complete();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Person updatePerson(Person Person)
        {
            try
            {
                var result = _uof.Persons.Update(Person);
                _uof.Complete();
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
