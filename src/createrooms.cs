class RoomManager
{
    private Player player;

    public RoomManager(Player player)
    {
        this.player = player;
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
}
