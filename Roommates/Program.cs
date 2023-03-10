using Roommates.Models;
using Roommates.Repositories;

namespace Roommates;

class Program
{
    //  This is the address of the database.
    //  We define it here as a constant since it will never change.
    private const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=Roommates;Trusted_Connection=True;TrustServerCertificate=true;";

    static void Main(string[] args)
    {
        RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
        ChoreRepository choreRepo = new ChoreRepository(CONNECTION_STRING); //new BaseRepository()

        bool runProgram = true;
        while (runProgram)
        {
            string selection = GetMenuSelection();

            switch (selection)
            {
                case ("Show all chores"):
                    List<Chore> chores = choreRepo.GetAll();
                    foreach (var chore in chores)
                    {
                        Console.WriteLine($"{chore.Name} has an Id of {chore.Id}");
                    }
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                case ("Show all rooms"):
                    List<Room> rooms = roomRepo.GetAll();
                    foreach (Room r in rooms)
                    {
                        Console.WriteLine($"{r.Name} has an Id of {r.Id} and a max occupancy of {r.MaxOccupancy}");
                    }
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                case ("Search for room"):
                    Console.Write("Room Id: ");
                    int id = int.Parse(Console.ReadLine());

                    Room room = roomRepo.GetById(id);

                    Console.WriteLine($"{room.Id} - {room.Name} Max Occupancy({room.MaxOccupancy})");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                case ("Add a room"):
                    Console.Write("Room name: ");
                    string name = Console.ReadLine();

                    Console.Write("Max occupancy: ");
                    int max = int.Parse(Console.ReadLine());

                    Room roomToAdd = new Room()
                    {
                        Name = name,
                        MaxOccupancy = max
                    };

                    roomRepo.Insert(roomToAdd);//reference types can be affected by changes in other places if passed into methods as arguments

                    Console.WriteLine($"{roomToAdd.Name} has been added and assigned an Id of {roomToAdd.Id}");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                case ("Exit"):
                    runProgram = false;
                    break;
            }
        }

    }

    static string GetMenuSelection()
    {
        Console.Clear();

        List<string> options = new List<string>()
        {
            "Show all rooms",
            "Search for room",
            "Add a room",
            "Show all chores",
            "Search for chore",
            "Add a chore",
            "Exit"
        };

        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Select an option > ");

                string input = Console.ReadLine();
                int index = int.Parse(input) - 1;
                return options[index];
            }
            catch (Exception)
            {

                continue;
            }
        }
    }
}