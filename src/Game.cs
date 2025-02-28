using System;

class Game
{
	// Private fields
	public Parser parser;
	public Player player;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room enterence = new Room("outside the main entrance of the university");
		Room theatre = new Room("in a lecture theatre");
		Room pub = new Room("in the campus pub");
		Room lab = new Room("in a computing lab");
		Room office = new Room("in the computing admin office");
		Room basement = new Room("in matthews basement full with small children");

		// Initialise room exits
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


		// Create your Items here
		// ...
		// And add them to the Rooms
		// ...

		// Start game outside
		player.CurrentRoom = enterence;
	}

	//  Main play routine. Loops until end of play
	public void Play()
	{
		player.PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
	}

	// Print out the opening message for the player.


	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if (command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit; // false
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
				look();
				break;
			case "stats":
				stats();
				break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################

	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wander around at the university.");
		Console.WriteLine();
		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	public void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}

		player.CurrentRoom = nextRoom;
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	public void look()

	{
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	public void stats()
	{
		Console.WriteLine("Player HP is " + "(" + player.HP + ")");

	}


}
