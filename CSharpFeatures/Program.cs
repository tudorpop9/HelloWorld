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
            TeamMember teamMember = new TeamMember("Member1");
            string jsonString = JsonSerializer.Serialize(teamMember);
            File.WriteAllText("./teamMember.json", jsonString);

            TeamMember teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(jsonString);
            Console.WriteLine(teamMemberDeserialized);

        }
    }
}
