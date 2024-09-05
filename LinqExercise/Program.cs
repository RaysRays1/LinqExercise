using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 43, 6, 7, 8, 9, 0 };

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

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            //Console.WriteLine();

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine("starting ascendingNumbers");

            //TODO: Order numbers in ascending order and print to the console
            var ascendingNumber = numbers.OrderBy(x => x );
            foreach (var number in ascendingNumber)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("starting descendingNumber");

            //TODO: Order numbers in descending order and print to the console;
            var descendingNumber = numbers.OrderByDescending(x => x);
            foreach (var number in descendingNumber)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var numbersOverSix = numbers.Where(number => number > 6);
            foreach (var number in numbersOverSix)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var numbersOverFive = numbers.Take(4);
            foreach (var number in numbersOverFive)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            Console.WriteLine("Index 4");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers.SetValue(43,4);
            var numbersUnderFortyThree = numbers.OrderByDescending(x => x);
            foreach (var number in numbersUnderFortyThree)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("List of employees");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();
            
            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered =employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(
                person => person.FirstName);
            foreach (var person in filtered)
            {
                Console.WriteLine(person.FirstName);
            }
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("List of Age first");
            var orderAgeName26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var person in orderAgeName26)
            {
                Console.WriteLine($"Age : {person.Age} | {person.FirstName}");
            }

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Sum and Average");
            var specialFilteredEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).ToList();
            
            Console.WriteLine($"Total years of exp:{specialFilteredEmployees.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg years of exp :{specialFilteredEmployees.Average(x => x.YearsOfExperience )}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Average of year exp:");
            Console.WriteLine($"Avg years of exp :{specialFilteredEmployees.Average(x => x.YearsOfExperience )}");

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Ray", "Brown", 43, 1)).ToList();

            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FullName} | {person.Age}");
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
