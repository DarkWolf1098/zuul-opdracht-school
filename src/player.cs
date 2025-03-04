using System;

class Player
{
    private int hp;

    public int HP
    {
        get { return hp; }
        private set { hp = Math.Max(0, value); } // Ensures HP never goes below 0
    }

    public Player()
    {
        HP = 100;
    }

    public void Damage(int amount)
    {
        HP -= amount;
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

    public void PrintWelcome()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to Zuul!");
        Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
        Console.WriteLine("Type 'help' if you need help.");
        Console.WriteLine();
        Console.WriteLine(CurrentRoom.GetLongDescription());
    }

    public void Look()
    {
        Console.WriteLine(CurrentRoom.GetLongDescription());
    }
}
