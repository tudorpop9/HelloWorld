using HelloWorldWeb.Models;
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            string serializationFile = "./teamMember.json";

            TeamMember teamMember = new TeamMember("Member1");
            string jsonString = JsonSerializer.Serialize(teamMember);
            File.WriteAllText(serializationFile, jsonString);

            var teamMemberPromise = File.ReadAllTextAsync(serializationFile);
            teamMemberPromise.Wait();
            var expectedOutput = teamMemberPromise.Result;

            TeamMember teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);
            Console.WriteLine(teamMemberDeserialized);

            Coffee coffee = MakeCoffee("grains", "milk", "water", "sugar", Espresso);
            Console.WriteLine($"Here's your coffee: {coffee.CoffeeType}");

        }

        static Coffee MakeCoffee(string coffeeGrains, string milk, string water, string sugar, 
            Func<string, string, string, string, Coffee> recipe)
        {
            Coffee coffee = null;
            try
            {
                Console.WriteLine("Start preparing coffee.");
                coffee = recipe(coffeeGrains, milk, water, sugar);
                
            }
            catch
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
            return coffee;
        }

        static Coffee Espresso(string grains, string milk, string water, string sugar)
        {
            return new Coffee("Espresso");
        }
    }
}


