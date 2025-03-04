using System;

class Game
{
    public Parser parser;
    public Player player;

    public Game()
    {
        parser = new Parser();
        player = new Player();
        CreateRooms();
    }

    private void CreateRooms()
    {
        Room enterence = new Room("outside the main entrance of the university");
        Room theatre = new Room("in a lecture theatre");
        Room pub = new Room("in the campus pub");
        Room lab = new Room("in a computing lab");
        Room office = new Room("in the computing admin office");
        Room basement = new Room("in Matthew's basement full with small children (and Justin)");

        enterence.AddExit("east", theatre);
        enterence.AddExit("south", lab);
        enterence.AddExit("west", pub);

        theatre.AddExit("west", enterence);
        pub.AddExit("east", enterence);
        lab.AddExit("north", enterence);
        lab.AddExit("east", office);
        office.AddExit("west", lab);
        office.AddExit("down", basement);
        basement.AddExit("up", office);

        player.CurrentRoom = enterence;
    }

    public void Play()
    {
        player.PrintWelcome();

        bool finished = false;
        while (!finished)
        {
            Command command = parser.GetCommand();
            finished = ProcessCommand(command);
        }
    }

    private bool ProcessCommand(Command command)
    {
        bool wantToQuit = false;

        if (command.IsUnknown())
        {
            Console.WriteLine("I don't know what you mean...");
            return wantToQuit;
        }

        switch (command.CommandWord)
        {
            case "help":
                PrintHelp();
                break;
            case "go":
                GoRoom(command);
                break;
            case "quit":
                wantToQuit = true;
                break;
            case "look":
                Look();
                break;
            case "stats":
                Stats();
                break;
        }

        return wantToQuit;
    }

    private void PrintHelp()
    {
        Console.WriteLine("You are lost. You are alone.");
        Console.WriteLine("You wander around at the university.");
        Console.WriteLine();
        parser.PrintValidCommands();
    }

    public void GoRoom(Command command)
    {
        if (!command.HasSecondWord())
        {
            Console.WriteLine("Go where?");
            return;
        }

        string direction = command.SecondWord;
        Room nextRoom = player.CurrentRoom.GetExit(direction);

        if (nextRoom == null)
        {
            Console.WriteLine("There is no door to " + direction + "!");
            return;
        }

        // Apply damage when changing rooms
        player.Damage(25);

        if (!player.IsAlive())
        {
            CheckGameOver();
            return;
        }

        player.CurrentRoom = nextRoom;
        Console.WriteLine(player.CurrentRoom.GetLongDescription());
    }

    public void Look()
    {
        Console.WriteLine(player.CurrentRoom.GetLongDescription());
    }

    public void Stats()
    {
        Console.WriteLine("Player HP is (" + player.HP + ")");
    }

    public void CheckGameOver()
    {
        Console.WriteLine("Your HP has reached 0. Game over.");
        Environment.Exit(0);
    }
}
