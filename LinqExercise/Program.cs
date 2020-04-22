using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num => num);
            var desc = numbers.OrderByDescending(num => num);
            foreach(var num in desc)
            {
                Console.WriteLine(num);
            }
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }


            //Print to the console only the numbers greater than 6

            var g6 = numbers.Where(num => num > 6);
            foreach (var num in g6)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var only4 = numbers.OrderByDescending(num => num);
            foreach(var num in only4.Where(num => num < 4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 27;
            var ageOf = numbers.OrderByDescending(x => x);
            foreach(var num in ageOf)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.

            var cS = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S'));
            foreach (var emp in cS)
            {
                Console.WriteLine(emp.FullName);
            }

            //Order this in acesnding order by FirstName.

            cS.OrderBy(x => x.FirstName);
            foreach(var emp in cS)
            {
                Console.WriteLine(emp.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.

            var over = employees.Where(x => x.Age > 26);
            foreach (var emp in over)
            {
                Console.WriteLine($"{emp.FullName} {emp.Age}");
            }

            //Order this by Age first and then by FirstName in the same result.

            var oldest = over.OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var emp in oldest)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience

            var yoe = employees.Sum(x => x.YearsOfExperience);
            Console.WriteLine(yoe);

            var avgYOE = employees.Average(x => x.YearsOfExperience);
            Console.WriteLine(avgYOE);

            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var exp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            foreach (var emp in exp)
            {
                Console.WriteLine(emp.FirstName);
            }

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("PK", "Jones", 27, 1)).ToList();
            foreach(var emp in employees)
            {
                Console.WriteLine(emp.FirstName);
            }
            


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
