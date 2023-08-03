using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        //Step 2: Implement Dynamic Property Mapping
        public static void MapProperties(Source source, Destination destination)
        {
            var sourceProperties = typeof(Source).GetProperties();
            var destinationProperties = typeof(Destination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                        break;
                    }
                }
            }
        }
        //Step 3: Test the Dynamic Property Mapp
        public static void Main(string[] args)
        {
            var source = new Source
            {
                Name = "Mary Tom",
                ID = 24,
                ISEmployee = true
            };

            var destination = new Destination();

            MapProperties(source, destination);

            Console.WriteLine("***Destination Propertiess***\n");
            Console.WriteLine("Name        : " + destination.Name);
            Console.WriteLine("ID          : " + destination.ID);
            Console.WriteLine("IsEmployee  : " + destination.IsEmployee);
            Console.WriteLine("Salary      :  " + destination.Salary);
            Console.WriteLine("\n Mapping Was Successful");
           
            Console.ReadKey();
        }
    }
    
}
