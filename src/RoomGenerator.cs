using System;
using System.Collections.Generic;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // ROOM TYPES ENUM WITH COMPLETELY INCONSISTENT NAMING AND CAPITALIZATION
    public enum RoomType
    {
        MONSTER_LAIR,      // ALL_CAPS_WITH_UNDERSCORE
        TreasureVault,     // PascalCase 
        trap_room,         // snake_case
        BOSS,              // SHOUTING
        starting_area,     // snake_case_again
        randomEncounter,   // camelCase
        SlOt_MaChInE_rOoM, // cHaOs_CaSe
        SECRET,            // MORE SHOUTING
        EMPTY              // THE VOID SHOUTS BACK
    }
    
    // ROOM CLASS WITH MINIMAL FUNCTIONALITY BUT MAXIMUM CHAOS
    public class Room
    {
        // FIELDS AND PROPERTIES MIXED TOGETHER FOR NO REASON
        public readonly int ID; // CAPS
        public string name; // lowercase
        public RoomType Type { get; private set; } // Property
        public List<int> ConnectedRooms; // List of room IDs
        public bool vIsItEd; // cHaOs CaSe
        public readonly string DESCRIPTION; // ALL CAPS
        
        private static readonly string[] ROOM_ADJECTIVES = {
            "SPOOKY",
            "haunted",
            "ANCIENT",
            "fluffy",
            "DOOM-FILLED",
            "sparkly",
            "CHAOTIC",
            "smelly",
            "ABANDONED",
            "pretentious"
        };
        
        private static readonly string[] ROOM_NOUNS = {
            "CAVERN",
            "hallway",
            "CHAMBER",
            "altar",
            "CATACOMBS",
            "bathroom",
            "THRONE ROOM",
            "office",
            "DUNGEON",
            "kitchen"
        };
        
        // SUPER UNHELPFUL CONSTRUCTORS
        public Room(int id, RoomType type)
        {
            ID = id;
            Type = type;
            ConnectedRooms = new List<int>();
            vIsItEd = false;
            
            // GENERATE A RANDOM NAME
            var rand = new Random();
            
            // 20% CHANCE OF A SUPER WEIRD NAME
            if (rand.Next(5) == 0)
            {
                string[] weirdNames = {
                    "Dave's Coffee Shop",
                    "IKEA furniture showroom",
                    "DMV waiting line",
                    "Applebee's after hours",
                    "YOUR MOM'S HOUSE",
                    "Windows Vista Fan Club",
                    "Cursed Meme Gallery",
                    "Retrograde Mercury Lounge",
                    "THAT ONE WEIRD ROOM",
                    "Locker room of DOOM"
                };
                
                name = weirdNames[rand.Next(weirdNames.Length)];
            }
            else
            {
                // NORMAL-ISH NAME
                string adjective = ROOM_ADJECTIVES[rand.Next(ROOM_ADJECTIVES.Length)];
                string noun = ROOM_NOUNS[rand.Next(ROOM_NOUNS.Length)];
                
                // RANDOMLY FORMAT THE NAME
                int format = rand.Next(4);
                
                switch (format)
                {
                    case 0:
                        name = $"{adjective} {noun}"; // Normal format
                        break;
                    case 1:
                        name = $"{noun} of {adjective}"; // Fantasy format
                        break;
                    case 2:
                        name = $"THE {adjective} {noun}"; // DRAMATIC format
                        break;
                    default:
                        name = $"{noun} of ETERNAL {adjective}"; // OVER-THE-TOP format
                        break;
                }
            }
            
            // GENERATE RANDOM DESCRIPTIONS
            string[] descriptions = {
                "You see strange symbols on the walls. They're probably important but you can't read them.",
                "The floor is sticky. You decide not to think about why.",
                "A faint whispering can be heard. It's giving stock market advice.",
                "Someone left a half-eaten sandwich here. It's moving slightly.",
                "There's graffiti on the wall that says 'CHAOS WAS HERE'.",
                "The room is upside down. No, wait, YOU'RE upside down.",
                "Everything smells like burnt toast. This is fine.",
                "The walls are breathing. Normal dungeon stuff.",
                "There's a suggestion box in the corner. It's full of screams.",
                "You find a mirror that doesn't show your reflection, just a thumbs up.",
                "The ceiling is unusually high. Or maybe you're unusually short now?"
            };
            
            DESCRIPTION = descriptions[rand.Next(descriptions.Length)];
        }
        
        // CONNECT THIS ROOM TO ANOTHER
        public void ConnectTo(Room otherRoom)
        {
            // DON'T CONNECT TO SELF OR IF ALREADY CONNECTED
            if (otherRoom.ID == ID || ConnectedRooms.Contains(otherRoom.ID))
                return;
                
            // ADD BIDIRECTIONAL CONNECTION
            ConnectedRooms.Add(otherRoom.ID);
            otherRoom.ConnectedRooms.Add(ID);
        }
    }
    
    // DUNGEON MANAGER CLASS THAT DOESN'T REALLY MANAGE ANYTHING
    public static class RoomGenerator
    {
        // GENERATE A COMPLETELY RANDOM DUNGEON LAYOUT
        public static Dictionary<int, Room> GenerateRandomDungeon(int roomCount = 20)
        {
            Dictionary<int, Room> dungeon = new Dictionary<int, Room>();
            var rand = new Random();
            
            // CREATE ROOMS
            for (int i = 0; i < roomCount; i++)
            {
                // DETERMINE ROOM TYPE WITH BIASED DISTRIBUTION
                RoomType type;
                int typeRoll = rand.Next(100);
                
                if (i == 0)
                {
                    type = RoomType.starting_area;
                }
                else if (i == roomCount - 1)
                {
                    type = RoomType.BOSS;
                }
                else if (typeRoll < 40) // 40%
                {
                    type = RoomType.MONSTER_LAIR;
                }
                else if (typeRoll < 60) // 20%
                {
                    type = RoomType.TreasureVault;
                }
                else if (typeRoll < 70) // 10%
                {
                    type = RoomType.trap_room;
                }
                else if (typeRoll < 85) // 15%
                {
                    type = RoomType.randomEncounter;
                }
                else if (typeRoll < 95) // 10%
                {
                    type = RoomType.SlOt_MaChInE_rOoM;
                }
                else // 5%
                {
                    type = RoomType.SECRET;
                }
                
                dungeon[i] = new Room(i, type);
            }
            
            // CONNECT ROOMS IN CHAOTIC PATTERN
            for (int i = 0; i < roomCount; i++)
            {
                // ENSURE EACH ROOM HAS AT LEAST ONE CONNECTION
                if (dungeon[i].ConnectedRooms.Count == 0 && i > 0)
                {
                    int connectToId = i - 1;
                    dungeon[i].ConnectTo(dungeon[connectToId]);
                }
                
                // ADD MORE RANDOM CONNECTIONS
                int extraConnections = rand.Next(1, 4); // 1-3 extra connections
                for (int j = 0; j < extraConnections; j++)
                {
                    int connectToId = rand.Next(roomCount);
                    // DON'T CONNECT TO SELF
                    if (connectToId != i)
                    {
                        dungeon[i].ConnectTo(dungeon[connectToId]);
                    }
                }
            }
            
            // MAKE SURE ALL ROOMS ARE ACCESSIBLE FROM START (ROOM 0)
            EnsureAccessibility(dungeon, roomCount);
            
            return dungeon;
        }
        
        // MAKE SURE ALL ROOMS ARE ACCESSIBLE
        private static void EnsureAccessibility(Dictionary<int, Room> dungeon, int roomCount)
        {
            // TRACK VISITED ROOMS
            bool[] visited = new bool[roomCount];
            
            // DFS FROM STARTING ROOM
            Stack<int> stack = new Stack<int>();
            stack.Push(0); // START WITH ROOM 0
            visited[0] = true;
            
            while (stack.Count > 0)
            {
                int current = stack.Pop();
                
                foreach (int neighbor in dungeon[current].ConnectedRooms)
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }
            }
            
            // CONNECT ANY UNVISITED ROOMS TO A RANDOM VISITED ROOM
            for (int i = 1; i < roomCount; i++)
            {
                if (!visited[i])
                {
                    // FIND A RANDOM VISITED ROOM
                    List<int> visitedRooms = new List<int>();
                    for (int j = 0; j < roomCount; j++)
                    {
                        if (visited[j]) visitedRooms.Add(j);
                    }
                    
                    // CONNECT TO A RANDOM VISITED ROOM
                    int connectTo = visitedRooms[new Random().Next(visitedRooms.Count)];
                    dungeon[i].ConnectTo(dungeon[connectTo]);
                    
                    // MARK AS VISITED
                    visited[i] = true;
                }
            }
        }
        
        // PROCESS ENTERING A NEW ROOM
        public static void EnterRoom(Player HERO, List<Card> deck, int roomId)
        {
            if (HERO.currentDungeon == null || !HERO.currentDungeon.ContainsKey(roomId))
            {
                Console.WriteLine("ERROR: Room doesn't exist! FALLING INTO THE VOID!");
                return;
            }
            
            Room room = HERO.currentDungeon[roomId];
            HERO.currentRoomId = roomId;
            
            // UPDATE PLAYER'S LAST VISITED ROOM
            HERO.lastRoomVisited = room.name;
            
            Console.WriteLine($"\nYou enter: {room.name}");
            Console.WriteLine(room.DESCRIPTION);
            
            // PROCESS ROOM BASED ON TYPE
            switch (room.Type)
            {
                case RoomType.MONSTER_LAIR:
                    CombatSystem.CombatEncounter(HERO, deck);
                    break;
                    
                case RoomType.TreasureVault:
                    CombatSystem.TreasureRoom(HERO);
                    break;
                    
                case RoomType.trap_room:
                    int trapDamage = new Random().Next(5, 16);
                    Console.WriteLine($"IT'S A TRAP! You take {trapDamage} damage from hidden spikes!");
                    HERO.TakeDamage(trapDamage);
                    break;
                    
                case RoomType.BOSS:
                    Console.WriteLine("THE BOSS ROOM! But the boss is on coffee break. Try again later.");
                    // TODO: IMPLEMENT BOSS FIGHT SOMEDAY LOL
                    break;
                    
                case RoomType.SlOt_MaChInE_rOoM:
                    Console.WriteLine("You find an ancient slot machine in the corner!");
                    SlotMachine.SpinTheSlots(HERO);
                    break;
                    
                case RoomType.SECRET:
                    Console.WriteLine("You found a SECRET ROOM!");
                    
                    // RANDOM SECRET ROOM EFFECT
                    int secretRoll = new Random().Next(5);
                    switch (secretRoll)
                    {
                        case 0:
                            HERO.maxHP += 10;
                            HERO.HP += 10;
                            Console.WriteLine("You find a magical fountain! MAX HP +10!");
                            break;
                        case 1:
                            int secretGold = new Random().Next(30, 100);
                            HERO.gold += secretGold;
                            Console.WriteLine($"You find a hidden treasure! +{secretGold} GOLD!");
                            break;
                        case 2:
                            Card secretCard = CardManager.GenerateRandomCard();
                            deck.Add(secretCard);
                            Console.WriteLine($"You find a mysterious card: {secretCard.Name}!");
                            break;
                        case 3:
                            Console.WriteLine("The room contains nothing but a single rubber duck.");
                            Console.WriteLine("It squeaks ominously when you step near it.");
                            HERO.gold += 1;
                            Console.WriteLine("You find 1 gold coin under the duck. Worth it!");
                            break;
                        case 4:
                            Console.WriteLine("The secret room is ANOTHER SECRET ROOM!");
                            Console.WriteLine("Roomception! But it's empty. How anticlimactic.");
                            break;
                    }
                    break;
                    
                default:
                    // RANDOM ENCOUNTER OR EMPTY
                    int eventChance = new Random().Next(100);
                    
                    if (eventChance < 40) // 40% COMBAT
                    {
                        CombatSystem.CombatEncounter(HERO, deck);
                    }
                    else if (eventChance < 60) // 20% TREASURE
                    {
                        CombatSystem.TreasureRoom(HERO);
                    }
                    else // 40% NOTHING
                    {
                        Console.WriteLine("This room is eerily quiet. Nothing happens... for now.");
                    }
                    break;
            }
            
            // MARK ROOM AS VISITED
            room.vIsItEd = true;
        }
        
        // SHOW AVAILABLE ROOM CONNECTIONS
        public static List<int> GetConnectedRooms(Player HERO)
        {
            if (HERO.currentDungeon == null || !HERO.currentDungeon.ContainsKey(HERO.currentRoomId))
            {
                return new List<int>();
            }
            
            Room currentRoom = HERO.currentDungeon[HERO.currentRoomId];
            return currentRoom.ConnectedRooms;
        }
    }
} 