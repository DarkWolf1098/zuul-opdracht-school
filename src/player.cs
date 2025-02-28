class Player
{
    public int HP;
	    public void Damage(int amount)
    {
        HP -= amount;
        if (HP < 0)
        {
            HP = 0;
        }
    }

    public void Heal(int amount)
    {
        HP += amount;
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

    public Room CurrentRoom { get; set; }

    // Correct constructor
    public Player() 
    {
        HP = 100;
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
        if (!command.HasSecondWord())
        {
            Console.WriteLine("Go where?");
            return;
        }

        string direction = command.SecondWord;
        Room nextRoom = CurrentRoom.GetExit(direction);

        if (nextRoom == null)
        {
            Console.WriteLine("There is no door to " + direction + "!");
            return;
        }

        CurrentRoom = nextRoom;
        Console.WriteLine(CurrentRoom.GetLongDescription());
    }

    public void Look()
    {
        Console.WriteLine(CurrentRoom.GetLongDescription());
    }

}
