using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//odata
namespace DemoApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonRepository
    {
        private static PersonRepository repo = new PersonRepository();
        public static PersonRepository Current { get => repo; }
        private List<Person> db = new List<Person>();
        public PersonRepository()
        {
            db.Add(new Person() { Id = 1, Age = 12, Name = "amir" });
            db.Add(new Person() { Id = 2, Age = 14, Name = "reza" });
            db.Add(new Person() { Id = 3, Age = 8, Name = "mina" });
            db.Add(new Person() { Id = 4, Age = 20, Name = "ali" });
        }

        public IEnumerable<Person> GetAll() => db;

        public Person Get(int id) => db.First(a => a.Id == id);

        public int Create(Person person)
        {
            person.Id = db.Count + 1;
            db.Add(person);
            return person.Id ;
        }

        public Person Update(Person person)
        {
            int index=db.FindIndex(a => a.Id == person.Id);
            db[index] = person;
            return person;
        }

        public void Delete(int id)
        {
            db.Remove(db.Single(a => a.Id == id));
        }

    }
}
