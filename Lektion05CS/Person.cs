using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion05CS
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Score { get; set; }
        public bool Accepted { get; set; } = false;

        public Person(string data)
        {
            var D = data.Split(';');
            Name = D[0];
            Age = int.Parse(D[1]);
            Weight = int.Parse(D[2]);
            Score = int.Parse(D[3]);
        }
        public override string ToString()
        {
            return Name + " " + Age + " years, weight: " + Weight + ", score: " + Score + ". accepted: " + Accepted;
        }

        public static List<Person> ReadCSVFile(string fn)
        {
            List<Person> people = new List<Person>();

            using (var file = new StreamReader(fn))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    var p = new Person(line);
                    people.Add(p);
                }
            }

            return people;
        }
        
        public static void Ex1()
        {
            try
            {              
                var data = Person.ReadCSVFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data1.csv"));
                var underTwos = data.FindAll(new Predicate<Person>(p => p.Score < 2));
                var evens = data.FindAll(new Predicate<Person>(p => p.Score % 2 == 0));
                var evensAndWeightAbove = data.FindAll(new Predicate<Person>(p => p.Score % 2 == 0 && p.Weight > 60));
                var divisibleByThree = data.FindAll(new Predicate<Person>(p => p.Weight % 3 == 0));
                var firstThree = data.FindIndex(0, new Predicate<Person>(p => p.Age < 10));
                Console.WriteLine("under twos: ");
                PrintPeople(underTwos);
                Console.WriteLine("evens: ");
                PrintPeople(evens);
                Console.WriteLine("evens, weight above 60: ");
                PrintPeople(evensAndWeightAbove);
                Console.WriteLine("weight divisible by 3: ");
                PrintPeople(divisibleByThree);
                Console.WriteLine("first under age 10: ");
                Console.WriteLine(firstThree);
                Console.WriteLine("first under age 10 with score of 3 ");
                Console.WriteLine(data.FindIndex(0,new Predicate<Person>(p => p.Age < 10 && p.Score == 3)));
                Console.WriteLine("amount of people under age 10 with score of 3 ");
                Console.WriteLine(data.FindAll(new Predicate<Person>(p => p.Age < 10 && p.Score == 3)).Count);
                Console.WriteLine("first under 8 score of 3");
                Console.WriteLine(data.FindIndex(0, new Predicate<Person>(p => p.Age < 8 && p.Score == 3)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            static void PrintPeople(List<Person> people)
            {
                people.ForEach(p => Console.WriteLine(p));
            }
        }
        
        
    }
}
