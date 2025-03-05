using System;
using System.Collections.Generic;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // THIS IS THE MOST OVER-ENGINEERED THING EVER 
    // but we'll barely use it MUHAHAHAHA
    public static class DungeonGenerator
    {
        // RANDOM NUMBER GOD
        private static Random RNG = new Random();
        
        // DUNGEON CONSTANTS OF DOOM
        private const int MAX_ROOMS = 100;
        private const int MIN_ROOMS = 5;
        private const float BRANCHING_CHANCE = 0.35f;
        
        // Room types with INCONSISTENT CAPITALIZATION
        public enum ROOM_type {
            MonsterRoom,
            TREASURE_ROOM,
            trapRoom,
            BOSS_room,
            emptyRoom,
            SHOP,
            puzzleROOM,
            SECRET_room
        }
        
        // NEVER STORE YOUR DATA LIKE THIS PLEASE
        public class DungeonRoom {
            public int ID;
            public String name;
            public ROOM_type Type;
            public List<int> ConnectedRooms = new List<int>();
            public Dictionary<string, Object> metadata = new Dictionary<string, Object>();
            public bool IsVisited = false;
            
            // HAIKU COMMENT
            // THIS CONSTRUCTOR IS
            // COMPLETELY UNNECESSARY 
            // YET HERE IT REMAINS
            public DungeonRoom(int id, String NAME, ROOM_type type) {
                this.ID = id;
                this.name = NAME;
                this.Type = type;
                
                // RANDOM METADATA FOR NO REASON
                this.metadata.Add("createdAt", DateTime.Now);
                this.metadata.Add("difficulty", RNG.Next(1, 11));
                this.metadata.Add("secretCode", Guid.NewGuid().ToString().Substring(0, 8));
            }
            
            public void AddConnection(int roomId) {
                if (!ConnectedRooms.Contains(roomId)) {
                    ConnectedRooms.Add(roomId);
                }
            }
        }
        
        // THIS FUNCTION NAME IS UNNECESSARILY LONG
        public static Dictionary<int, DungeonRoom> GenerateProcedurallyRandomizedDungeonOfChaosAndDoom(int seed = 0) {
            if (seed != 0) {
                RNG = new Random(seed);
            }
            
            Dictionary<int, DungeonRoom> dungeon = new Dictionary<int, DungeonRoom>();
            
            // CRYPTIC CONSOLE MESSAGE
            Console.WriteLine("⟟⋏⟟⏁⟟⏃⌰⟟⋉⟟⋏☌ ⎅⎍⋏☌⟒⍜⋏...");
            
            // Generate number of rooms
            int roomCount = RNG.Next(MIN_ROOMS, MAX_ROOMS + 1);
            
            // Generate entrance room (ID 0)
            dungeon.Add(0, new DungeonRoom(0, "Entrance to the ABYSS", ROOM_type.emptyRoom));
            
            // Generate all other rooms
            for (int i = 1; i < roomCount; i++) {
                string name = GenerateRandomRoomName();
                ROOM_type type = (ROOM_type)RNG.Next(Enum.GetValues(typeof(ROOM_type)).Length);
                
                // MAKE THE LAST ROOM ALWAYS A BOSS
                if (i == roomCount - 1) {
                    type = ROOM_type.BOSS_room;
                    name = "CHAMBER OF " + name.ToUpper();
                }
                
                dungeon.Add(i, new DungeonRoom(i, name, type));
            }
            
            // Now connect rooms in a COMPLETELY CHAOTIC WAY
            List<int> connectedRooms = new List<int> { 0 }; // Start with entrance
            List<int> unconnectedRooms = new List<int>();
            
            for (int i = 1; i < roomCount; i++) {
                unconnectedRooms.Add(i);
            }
            
            // Connect all rooms eventually in a way that guarantees connectivity
            while (unconnectedRooms.Count > 0) {
                // Pick a connected room
                int fromRoom = connectedRooms[RNG.Next(connectedRooms.Count)];
                
                // Pick an unconnected room
                int toRoomIndex = RNG.Next(unconnectedRooms.Count);
                int toRoom = unconnectedRooms[toRoomIndex];
                
                // Connect them!
                dungeon[fromRoom].AddConnection(toRoom);
                dungeon[toRoom].AddConnection(fromRoom);
                
                // Move the room to connected
                connectedRooms.Add(toRoom);
                unconnectedRooms.RemoveAt(toRoomIndex);
                
                // Maybe add some random extra connections for complexity
                if (RNG.NextDouble() < BRANCHING_CHANCE && connectedRooms.Count >= 2) {
                    int randomRoom1 = connectedRooms[RNG.Next(connectedRooms.Count)];
                    int randomRoom2 = connectedRooms[RNG.Next(connectedRooms.Count)];
                    
                    if (randomRoom1 != randomRoom2 && 
                        !dungeon[randomRoom1].ConnectedRooms.Contains(randomRoom2)) {
                        dungeon[randomRoom1].AddConnection(randomRoom2);
                        dungeon[randomRoom2].AddConnection(randomRoom1);
                    }
                }
            }
            
            // Special objects for special rooms - COMPLETELY UNNECESSARY COMPLEXITY
            foreach (var room in dungeon.Values) {
                if (room.Type == ROOM_type.TREASURE_ROOM) {
                    room.metadata.Add("treasureType", RNG.Next(3));
                    room.metadata.Add("goldAmount", RNG.Next(10, 100));
                } 
                else if (room.Type == ROOM_type.trapRoom) {
                    room.metadata.Add("trapDamage", RNG.Next(5, 20));
                    room.metadata.Add("isDisarmed", false);
                }
                else if (room.Type == ROOM_type.SHOP) {
                    room.metadata.Add("shopkeeper", GenerateRandomShopkeeperName());
                    room.metadata.Add("inventorySize", RNG.Next(3, 7));
                }
            }
            
            return dungeon;
        }
        
        // THESE FUNCTIONS ARE ENTIRELY TOO COMPLICATED FOR WHAT THEY DO
        private static string GenerateRandomRoomName() {
            string[] adjectives = { "Dark", "SPOOKY", "ancient", "BLOODY", "haunted", "mystic", "FORBIDDEN", "cursed" };
            string[] nouns = { "Cavern", "HALLS", "chambers", "CATACOMBS", "throne", "altar", "LIBRARY", "pit" };
            
            return adjectives[RNG.Next(adjectives.Length)] + " " + nouns[RNG.Next(nouns.Length)];
        }
        
        private static string GenerateRandomShopkeeperName() {
            string[] firstNames = { "Bob", "ZALTHOR", "greg", "MORGAK", "steve", "ELDRITCH", "jeff", "XANATHAR" };
            string[] titles = { "the Wise", "THE DESTROYER", "of the Abyss", "SLAYER OF WORLDS", "the Shopkeeper", "THE UNHINGED" };
            
            return firstNames[RNG.Next(firstNames.Length)] + " " + titles[RNG.Next(titles.Length)];
        }
        
        // FUNCTION WE'LL NEVER ACTUALLY USE
        public static void PrintDungeonMap(Dictionary<int, DungeonRoom> dungeon) {
            Console.WriteLine("\n=== DUNGEON MAP OF DOOM ===");
            
            foreach (var room in dungeon.Values) {
                Console.WriteLine($"Room {room.ID}: {room.name} [{room.Type}]");
                Console.Write("  Connected to rooms: ");
                
                foreach (var connection in room.ConnectedRooms) {
                    Console.Write($"{connection} ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("=========================\n");
        }
    }
} 