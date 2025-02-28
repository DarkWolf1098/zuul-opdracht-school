class Player
{
    //auto property
    public Room CurrentRoom { get; set  ;}

    //constructor
    public void player()
    {
   
    }
    
	public void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul!");
		Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(CurrentRoom.GetLongDescription());

	}
    
    	public void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to "+direction+"!");
			return;
		}

		CurrentRoom = nextRoom;
		Console.WriteLine(CurrentRoom.GetLongDescription());
	}
    	public void look()
	
		{
			Console.WriteLine(CurrentRoom.GetLongDescription());
		}
	
}