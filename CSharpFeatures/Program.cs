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
            

        }
    }
}
