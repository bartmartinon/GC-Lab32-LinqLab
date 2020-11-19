using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab32LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 32: Linq Exercises");

            int[] nums = { 10, 2330, 112233, 10, 949, 3764, 2942 };

            // nums
            // 1. Minimum Value
            Console.WriteLine("Minimum");
            Console.WriteLine(nums.Min());

            // 2. Maximum Value
            Console.WriteLine("----");
            Console.WriteLine("Maximum");
            Console.WriteLine(nums.Max());

            // 3. Maximum Value less than 10000
            Console.WriteLine("----");
            Console.WriteLine("Maximum less than 10000");
            var numsLessThan10000 = nums.Where(x => x < 10000);
            Console.WriteLine(numsLessThan10000.Max());

            // 4. Values between 10 and 100
            Console.WriteLine("----");
            Console.WriteLine("Between 10 and 100");
            var numsLessThan100 = nums.Where(x => x < 100);
            var numsBetween10and100 = numsLessThan100.Where(x => x > 10);
            foreach(int i in numsBetween10and100)
            {
                Console.WriteLine("  " + i);
            }

            // 5. Values between 100000 and 999999 inclusive
            Console.WriteLine("----");
            Console.WriteLine("Between 100000 and 999999 Inclusive");
            var numsLessThanEquals999999 = nums.Where(x => x <= 999999);
            var numsBetween100000and999999Inc = numsLessThanEquals999999.Where(x => x >= 100000);
            foreach (int i in numsBetween100000and999999Inc)
            {
                Console.WriteLine("  " + i);
            }

            // 6. Count all Even Numbers
            Console.WriteLine("----");
            Console.WriteLine("Even Numbers");
            var evenNums = nums.Where(x => x % 2 == 0);
            Console.WriteLine("Count: " + evenNums.Count());

            Console.WriteLine("-------------------------------------------------------");

            List<Student> students = new List<Student>();
            students.Add(new Student("Jimmy", 13));
            students.Add(new Student("Hannah Banana", 21));
            students.Add(new Student("Justin", 30));
            students.Add(new Student("Sarah", 53));
            students.Add(new Student("Hannibal", 15));
            students.Add(new Student("Phillip", 16));
            students.Add(new Student("Maria", 63));
            students.Add(new Student("Abe", 33));
            students.Add(new Student("Curtis", 10));

            // Students
            // 1. Find all students age of 21 and over (aka US drinking age)
            var DrinkingAgeStudents = students.Where(x => x.Age >= 21);
            Console.WriteLine("Students at Drinking Age");
            PrintStudentList(DrinkingAgeStudents.ToList());

            var DrinkingAgeStudents2 = from s in students
                                       where s.Age >= 21
                                       select s;
            Console.WriteLine("Students at Drinking Age (Query)");
            PrintStudentList(DrinkingAgeStudents2.ToList());

            // 2. Find the oldest student
            Console.WriteLine("----");
            Console.WriteLine("Oldest Student");
            var oldestAge = students.Max(x => x.Age);
            Console.WriteLine("Oldest Age found: " + oldestAge);
            var oldestStudent = students.Where(x => x.Age == oldestAge).First();
            Console.WriteLine("Oldest Student is: " + oldestStudent.Name);

            // 3. Find the youngest student
            Console.WriteLine("----");
            Console.WriteLine("Youngest Student");
            var youngestAge = students.Min(x => x.Age);
            Console.WriteLine("Youngest Age found: " + youngestAge);
            var youngestStudent = students.Where(x => x.Age == youngestAge).First();
            Console.WriteLine("Youngest Student is: " + youngestStudent.Name);

            // 4. Finding the oldest student under Age 25
            Console.WriteLine("----");
            Console.WriteLine("Oldest Student under Age 25");
            var studentsUnderAge25 = students.Where(x => x.Age < 25).ToList();
            var oldestAgeUnderAge25 = studentsUnderAge25.Max(x => x.Age);
            Console.WriteLine("Oldest Age under 25 found: " + oldestAgeUnderAge25);
            var oldestStudentUnderAge25 = students.Where(x => x.Age == oldestAgeUnderAge25).First();
            Console.WriteLine("Oldest Student under 25 is: " + oldestStudentUnderAge25.Name);

            // 5. Finding students over Age 21 and with even ages
            Console.WriteLine("----");
            Console.WriteLine("Students over Age 21 and with Even Ages");
            var studentsOverAge21 = students.Where(x => x.Age >= 21).ToList();
            var studentsOverAge21WithEvenAge = studentsOverAge21.Where(x => x.Age % 2 == 0).ToList();
            PrintStudentList(studentsOverAge21WithEvenAge.ToList());

            // 6. Find Teenage Students (13-19)
            Console.WriteLine("----");
            Console.WriteLine("Teenage Students (Age 13-19)");
            var studentsOverAge13 = students.Where(x => x.Age >= 13).ToList();
            var studentsOverAge13AndUnder19 = studentsOverAge13.Where(x => x.Age <= 19).ToList();
            PrintStudentList(studentsOverAge13AndUnder19);

            // 7. Find all Student whose Name starts with a Vowel
            Console.WriteLine("----");
            Console.WriteLine("Students with Name that start with a Vowel");
            List<char> vowels = new List<char>{ 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'y', 'Y' };
            var studentsWithNameStartingWithVowel = students.Where(x => vowels.Contains(x.Name[0])).ToList();
            PrintStudentList(studentsWithNameStartingWithVowel);
        }

        public static void PrintStudentList(List<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine($"Name: {s.Name}, Age: {s.Age}");
            }
        }
    }
}
