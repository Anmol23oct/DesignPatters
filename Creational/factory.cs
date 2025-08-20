//You are given a class called `Person` . The person has two fields: `Id` , and `Name` .

//Please implement a *non-static* `PersonFactory`  that has a `CreatePerson()`  method that takes a person's name.

//The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.


using System;

namespace Coding.Exercise
{
    // 1. Product Interface
    public interface IPerson
    {
        int Id { get; }
        string Name { get; }
        string GetPersonType();  // For demonstration
    }

    // 2. Concrete Product A
    public class RegularPerson : IPerson
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public RegularPerson(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string GetPersonType()
        {
            return "Regular Person";
        }
    }

    // 3. Concrete Product B
    public class SpecialPerson : IPerson
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public SpecialPerson(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string GetPersonType()
        {
            return "Special Person";
        }
    }

    // 4. Abstract Creator
    public abstract class PersonFactory
    {
        private int _currentId = 0;

        public IPerson CreatePerson(string name)
        {
            var person = Create(name, _currentId);
            _currentId++;
            return person;
        }

        // Factory Method
        protected abstract IPerson Create(string name, int id);
    }

    // 5. Concrete Creator A (for RegularPerson)
    public class RegularPersonFactory : PersonFactory
    {
        protected override IPerson Create(string name, int id)
        {
            return new RegularPerson(id, name);
        }
    }

    // 6. Concrete Creator B (for SpecialPerson)
    public class SpecialPersonFactory : PersonFactory
    {
        protected override IPerson Create(string name, int id)
        {
            return new SpecialPerson(id, name);
        }
    }

    // 7. Client Code
    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory factory1 = new RegularPersonFactory();
            IPerson person1 = factory1.CreatePerson("Alice");

            PersonFactory factory2 = new SpecialPersonFactory();
            IPerson person2 = factory2.CreatePerson("Bob");

            Console.WriteLine($"{person1.Name} (ID: {person1.Id}) - {person1.GetPersonType()}");
            Console.WriteLine($"{person2.Name} (ID: {person2.Id}) - {person2.GetPersonType()}");
        }
    }
}
