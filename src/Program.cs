using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;  // WE NEVER USE THIS AHAHAHA
using Microsoft.Extensions.Hosting; // FOR .NET 9 CHAOS
using System.Text; // WHY NOT?

namespace CHaoTIC_sLoT_DuNgEoN
{
    class Program
    {
        // STATIC CONSTRUCTOR FOR MAXIMUM CHAOS
        static Program() 
        {
            // .NET 9 HAS SO MANY FEATURES, LET'S BREAK THEM ALL
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => 
            {
                var EX = args.ExceptionObject as Exception;
                Console.ForegroundColor = (ConsoleColor)(new Random().Next(16));
                Console.BackgroundColor = (ConsoleColor)(new Random().Next(16));
                Console.WriteLine($"☠️ CHAOS REIGNS ☠️ ERROR: {EX?.Message ?? "WHO KNOWS?!"}");
                
                // FIX THE CRASH - DIFFERENTLY CHAOTIC NOW
                string stackTrace = EX?.StackTrace ?? "NO STACKTRACE FOR YOU!";
                int maxLength = Math.Min(100, stackTrace.Length);
                Console.WriteLine($"STACKTRACE: {stackTrace.Substring(0, maxLength)}...TOO BORING TO SHOW MORE");
                
                // Let's "fix" the error by just continuing anyway
                Console.WriteLine("ATTEMPTING TO CONTINUE ANYWAY BECAUSE YOLO!");
            };
        }
        
        // INCEPTION POINT OF MADNESS
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            DisplayTitleScreen();
            
            // .NET 9 VERSION MESSAGE
            Console.WriteLine($"RUNNING ON .NET {Environment.Version} - CHAOS LEVEL: UNPRECEDENTED!");
            
            // GENERATE RANDOMIZED DUNGEON WITH ROOMS
            var dungeon = RoomGenerator.GenerateRandomDungeon(new Random().Next(40, 100));
            
            // CREATE NEW PLAYER
            var HERO = new Player();
            HERO.currentDungeon = dungeon;
            
            // Initialize the room ID to the starting room (Room 0)
            HERO.currentRoomId = 0;
            HERO.lastRoomVisited = "Entrance to the ABYSS";
            
            // INITIALIZE DECK OF CARDS
            var deck = CardManager.InitDeck();
            
            Console.WriteLine("⟟⋏⟟⏁⟟⏃⌰⟟⋉⟟⋏☌ ⎅⎍⋏☌⟒⍜⋏...");
            
            // Find the boss room to make it SEEM like we're using the generator
            Room bossRoom = null;
            foreach (var room in dungeon.Values)
            {
                if (room.Type == RoomType.BOSS)
                {
                    bossRoom = room;
                    break;
                }
            }
            
            string FINAL_BOSS_NAME = bossRoom != null ? bossRoom.name.ToUpper() : "SOME UNKNOWN ENTITY";
            
            Console.WriteLine($"You sense a great evil lurking in {FINAL_BOSS_NAME}...");
            Console.WriteLine($"There are {dungeon.Count} rooms in this dungeon of MADNESS!\n");
            
            // 3AM vibes, don't ask
            while (HERO.HP > 0 && !HERO.wonGame)
            {
                DisplayHeroStatus(HERO);
                
                // CHOOSE YOUR DOOM
                Console.WriteLine("\n1) VENTURE DEEPER 🔥");
                Console.WriteLine("2) SPIN THE SLOTS OF DESTINY 🎰");
                Console.WriteLine("3) VIEW YOUR PATHETIC CARDS 🃏");
                Console.WriteLine("4) SHOW MAP (BUT NOT REALLY) 🗺️");
                Console.WriteLine("5) CAUSE INTENTIONAL ERROR 💥"); // NEW .NET 9 FEATURE - ERRORS ARE FUN!
                Console.WriteLine("6) RAGE QUIT 💀\n");
                
                Console.Write("WHAT DOST THOU CHOOSE? ");
                string? choice = Console.ReadLine();
                
                switch (choice?.ToLower())
                {
                    case "1":
                    case "venture":
                        // MOVE TO A RANDOM CONNECTED ROOM
                        MoveToNewRoom(HERO, deck);
                        break;
                    case "2":
                    case "spin":
                        SlotMachine.SpinTheSlots(HERO);
                        break;
                    case "3":
                    case "cards":
                    case "view":
                        CardManager.ViewCards(deck);
                        break;
                    case "4":
                    case "map":
                        // PRETEND to use the dungeon map but don't actually show it
                        Console.WriteLine("\nYOU ATTEMPT TO READ THE MAP BUT IT'S WRITTEN IN SOME ELDRITCH LANGUAGE!");
                        Console.WriteLine("All you can make out is that there's a boss somewhere...");
                        Thread.Sleep(1000);
                        break;
                    case "5":
                    case "error":
                    case "chaos":
                        // .NET 9 ERROR FEATURE - NOW WITH 100% MORE SURVIVAL
                        Console.WriteLine("\nYOU HAVE SUMMONED THE CHAOS DEMONS!");
                        Thread.Sleep(1000);
                        try 
                        {
                            // FAKE a NullReferenceException
                            Console.WriteLine("☠️ CHAOS REIGNS ☠️ ERROR: THE CHAOS GODS DEMAND SACRIFICE!");
                            Console.WriteLine("STACKTRACE:    at CHaoTIC_sLoT_DuNgEoN.Program.Main(String[] args) in /Users/danielclark/Projects/chaos/src/Prog...TOO BORING TO SHOW MORE");
                            Console.WriteLine("ATTEMPTING TO CONTINUE ANYWAY BECAUSE YOLO!");
                            
                            // Randomly decrease HP but NEVER to zero
                            int CHAOS_DAMAGE = Math.Min(HERO.HP - 1, new Random().Next(1, 20));
                            HERO.HP = Math.Max(1, HERO.HP - CHAOS_DAMAGE);
                            
                            Console.WriteLine($"THE CHAOS GODS TOOK {CHAOS_DAMAGE} OF YOUR LIFEFORCE BUT SPARED YOU... FOR NOW!");
                            Thread.Sleep(2000);
                        }
                        catch
                        {
                            // Just in case our chaos causes a REAL error, don't propagate it
                            Console.WriteLine("EXCEPTIONAL CHAOS DETECTED! CONTAINING THE BREACH!");
                            Thread.Sleep(1000);
                        }
                        break;
                    case "6":
                    case "quit":
                    case "exit":
                        HERO.HP = 0; // YOU DIE NOW
                        Console.WriteLine("YOU HAVE CHOSEN THE COWARD'S PATH!");
                        break;
                    default:
                        Console.WriteLine("INCOMPREHENSIBLE! TRY AGAIN, MORTAL!");
                        break;
                }
                
                Thread.Sleep(500); // DRAMATIC PAUSE FOR EFFECT
                
                // 5% chance to cause RANDOM ERROR because .NET 9 is CHAOTIC
                if (new Random().Next(100) < 5) 
                {
                    Console.WriteLine("\n⚡ CHAOS SPIKE DETECTED! ⚡");
                    Thread.Sleep(500);
                    
                    string[] errors = {
                        "RANDOM NullReferenceException: Object is too NULL to exist",
                        "CHAOS IndexOutOfRangeException: You went too far, mortal",
                        "MADNESS InvalidOperationException: That operation was too valid",
                        "DEMONIC ArgumentException: Your argument is illogical, Captain"
                    };
                    
                    // SIMULATE ERROR INSTEAD OF ACTUALLY CRASHING
                    string fakeError = errors[new Random().Next(errors.Length)];
                    Console.WriteLine($"\n☢️ SIMULATED CHAOS ERROR: {fakeError} ☢️");
                    Console.WriteLine("CHAOS CONTAINED... THIS TIME.");
                    
                    // Maybe do something UNPREDICTABLE to the player
                    switch (new Random().Next(5)) {
                        case 0:
                            // LOSE SOME GOLD
                            int goldLost = Math.Min(HERO.gold, new Random().Next(1, 15));
                            HERO.gold -= goldLost;
                            Console.WriteLine($"YOU DROPPED {goldLost} GOLD COINS INTO THE VOID!");
                            break;
                        case 1:
                            // GAIN SOME HP
                            int hpGained = new Random().Next(1, 10);
                            HERO.HP = Math.Min(HERO.maxHP, HERO.HP + hpGained);
                            Console.WriteLine($"CHAOS ENERGY HEALS YOU FOR {hpGained} HP. WEIRD!");
                            break;
                        case 2:
                            // TELEPORT TO RANDOM ROOM (not implemented but we'll fake it)
                            Console.WriteLine("YOU SUDDENLY TELEPORT TO A DIFFERENT ROOM! ...OR DO YOU?");
                            break;
                        default:
                            // NOTHING HAPPENS
                            Console.WriteLine("THE UNIVERSE GLITCHES BUT NOTHING CHANGES. SPOOKY!");
                            break;
                    }
                    
                    Thread.Sleep(2000);
                }
            }
            
            if (HERO.wonGame)
            {
                Console.WriteLine("IMPOSSIBRU! YOU HAVE CONQUERED THE CHAOTIC DUNGEON!");
            }
            else
            {
                Console.WriteLine("GAME OVER - YOUR SOUL BELONGS TO THE VOID NOW!");
            }
        }
        
        // DISPLAY THE TITLE SCREEN WITH FANCY ASCII ART
        private static void DisplayTitleScreen()
        {
            Console.WriteLine(@"
█▀▀ █░█ ▄▀█ █▀█ █▀ █▀▄▀█ ▄▀█ █▀▀ █░█ █ █▄░█ █▀▀
█▄▄ █▀█ █▀█ █▄█ ▄█ █░▀░█ █▀█ █▄▄ █▀█ █ █░▀█ ██▄");
            Console.WriteLine("ENTER THE DUNGEON OF SPINNING DOOM!\n");
        }
        
        // DISPLAY THE HERO'S STATUS IN A FANCY BOX
        private static void DisplayHeroStatus(Player hero)
        {
            // WHY USE A PROGRESS BAR WHEN YOU CAN MAKE ASCII ART??
            Console.WriteLine("\n====================");
            Console.WriteLine($"HERO: {hero.Name}");
            Console.WriteLine($"HP: {hero.HP}/{hero.maxHP}");
            Console.WriteLine($"GOLD: {hero.gold} coins");
            Console.WriteLine($"LOCATION: {hero.lastRoomVisited}");
            Console.WriteLine("====================\n");
        }
        
        // MOVE TO A NEW ROOM
        private static void MoveToNewRoom(Player HERO, List<Card> deck)
        {
            // GET CONNECTED ROOMS
            List<int> connectedRooms = RoomGenerator.GetConnectedRooms(HERO);
            
            if (connectedRooms.Count == 0)
            {
                Console.WriteLine("\nTHERE ARE NO EXITS FROM THIS ROOM! How did that happen?!");
                
                // EMERGENCY - TELEPORT TO RANDOM ROOM
                int randomRoomId = new Random().Next(HERO.currentDungeon.Count);
                RoomGenerator.EnterRoom(HERO, deck, randomRoomId);
                return;
            }
            
            // CHOOSE A RANDOM CONNECTED ROOM
            int nextRoomId = connectedRooms[new Random().Next(connectedRooms.Count)];
            
            // ENTER THE NEW ROOM
            RoomGenerator.EnterRoom(HERO, deck, nextRoomId);
        }
    }
} 