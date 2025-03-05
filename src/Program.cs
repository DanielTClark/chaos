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
            
            Console.WriteLine(@"
█▀▀ █░█ ▄▀█ █▀█ █▀ █▀▄▀█ ▄▀█ █▀▀ █░█ █ █▄░█ █▀▀
█▄▄ █▀█ █▀█ █▄█ ▄█ █░▀░█ █▀█ █▄▄ █▀█ █ █░▀█ ██▄");
            Console.WriteLine("ENTER THE DUNGEON OF SPINNING DOOM!\n");
            
            // .NET 9 VERSION MESSAGE
            Console.WriteLine($"RUNNING ON .NET {Environment.Version} - CHAOS LEVEL: UNPRECEDENTED!");
            
            // COMPLETELY WASTEFUL DUNGEON GENERATION THAT WE BARELY USE
            var ThE_dUnGeOn = DungeonGenerator.GenerateProcedurallyRandomizedDungeonOfChaosAndDoom();
            
            // Get the boss room to make it SEEM like we're using the generator
            var bossRoom = FindBossRoom(ThE_dUnGeOn);
            string FINAL_BOSS_NAME = bossRoom != null ? "THE " + bossRoom.name.ToUpper() : "SOME UNKNOWN ENTITY";
            
            Console.WriteLine($"You sense a great evil lurking in {FINAL_BOSS_NAME}...");
            Console.WriteLine($"There are {ThE_dUnGeOn.Count} rooms in this dungeon of MADNESS!\n");
            
            var HERO = new Player { 
                HP = 42, 
                maxHP = 100, 
                Name = "DOOMGUY_420", 
                gold = 69,
                // INITIALIZE DUNGEON DATA TO PREVENT NULL ERROR
                currentDungeon = ThE_dUnGeOn,
                currentRoomId = 0
            };
            
            var deck = InitDeck();
            
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
                        EnterNewRoom(HERO, deck);
                        break;
                    case "2":
                    case "spin":
                        SpinTheSlots(HERO);
                        break;
                    case "3":
                    case "cards":
                    case "view":
                        ViewCards(deck);
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
                        // .NET 9 ERROR FEATURE
                        Console.WriteLine("\nYOU HAVE SUMMONED THE CHAOS DEMONS!");
                        Thread.Sleep(1000);
                        try 
                        {
                            // Force a NullReferenceException
                            string? nullStr = null;
                            int x = nullStr!.Length;
                        }
                        catch
                        {
                            // We catch but then throw a different error because CHAOS
                            throw new Exception("THE CHAOS GODS DEMAND SACRIFICE!");
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
                    
                    throw new Exception(errors[new Random().Next(errors.Length)]);
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
        
        // Find the boss room in a RIDICULOUSLY INEFFICIENT way
        private static DungeonGenerator.DungeonRoom FindBossRoom(Dictionary<int, DungeonGenerator.DungeonRoom> dungeon) 
        {
            foreach (var room in dungeon.Values) 
            {
                if (room.Type == DungeonGenerator.ROOM_type.BOSS_room) 
                {
                    return room;
                }
            }
            return null;
        }
        
        static List<Card> InitDeck()
        {
            // Rick roll the player with super-mixed naming conventions
            var rickRoll = new List<Card>() {
                new Card { Name = "FIREBALL", Damage = 10, healAmount = 0, Effect = CardEffect.BURN },
                new Card { Name = "healingPotion", Damage = 0, healAmount = 20, Effect = CardEffect.heal },
                new Card { Name = "rusty_dagger", Damage = 5, healAmount = 0, Effect = CardEffect.poison },
                new Card { Name = "SHIELD-OF-DESTINY", Damage = 0, healAmount = 0, Effect = CardEffect.BLOCK },
                new Card { Name = "never_gonna_give_you_up", Damage = 15, healAmount = 15, Effect = CardEffect.DOUBLE }
            };
            
            return rickRoll;
        }
        
        static void DisplayHeroStatus(Player hero)
        {
            // WHY USE A PROGRESS BAR WHEN YOU CAN MAKE ASCII ART??
            Console.WriteLine("\n====================");
            Console.WriteLine($"HERO: {hero.Name}");
            Console.WriteLine($"HP: {hero.HP}/{hero.maxHP}");
            Console.WriteLine($"GOLD: {hero.gold} coins");
            
            // PRETEND to use dungeon data
            if (hero.currentDungeon != null && hero.currentDungeon.ContainsKey(hero.currentRoomId)) {
                var room = hero.currentDungeon[hero.currentRoomId];
                Console.WriteLine($"LOCATION: {room.name}");
            } else {
                Console.WriteLine("LOCATION: ???");
            }
            
            Console.WriteLine("====================\n");
        }
        
        static void EnterNewRoom(Player HERO, List<Card> CardDeck)
        {
            string[] DOOM_ROOMS = {
                "Chamber of Whispering Shadows",
                "THE PAIN PALACE",
                "fluffy bunny room",
                "Corridor of Eternal Screams",
                "Dave's Coffee Shop"
            };
            
            // YEET a random room at the player
            int roomIdx = new Random().Next(DOOM_ROOMS.Length);
            string room = DOOM_ROOMS[roomIdx];
            
            Console.WriteLine($"\nYou enter: {room}");
            
            // 50% chance of combat, 30% chance of treasure, 20% chance of trap
            int eventChance = new Random().Next(100);
            
            if (eventChance < 50)
            {
                CombatEncounter(HERO, CardDeck);
            }
            else if (eventChance < 80)
            {
                TreasureRoom(HERO);
            }
            else
            {
                Console.WriteLine("IT'S A TRAP! You take 5 damage from hidden spikes!");
                HERO.HP = Math.Max(0, HERO.HP - 5);
            }
            
            // PRETEND to move through the dungeon
            if (HERO.currentDungeon != null && HERO.currentDungeon.ContainsKey(HERO.currentRoomId)) {
                var currentRoom = HERO.currentDungeon[HERO.currentRoomId];
                if (currentRoom.ConnectedRooms.Count > 0) {
                    // Pick a random connected room
                    int nextRoomIndex = new Random().Next(currentRoom.ConnectedRooms.Count);
                    HERO.currentRoomId = currentRoom.ConnectedRooms[nextRoomIndex];
                }
            }
        }
        
        static void CombatEncounter(Player HERO, List<Card> deck)
        {
            string[] ENEMIES = { "SKELETOR", "slime_boi", "DRAGON-LORD", "annoying telemarketer", "JEFF" };
            string enemy = ENEMIES[new Random().Next(ENEMIES.Length)];
            int enemyHP = new Random().Next(10, 30);
            int enemyDMG = new Random().Next(3, 8);
            
            Console.WriteLine($"\nA WILD {enemy} APPEARS! HP: {enemyHP}");
            
            while (enemyHP > 0 && HERO.HP > 0)
            {
                // Player goes first
                Console.WriteLine("\nYour turn! Choose a card:");
                for (int i = 0; i < Math.Min(3, deck.Count); i++)
                {
                    Console.WriteLine($"{i+1}) {deck[i].Name} - DMG: {deck[i].Damage}, HEAL: {deck[i].healAmount}");
                }
                
                int cardChoice = -1;
                while (cardChoice < 0 || cardChoice >= Math.Min(3, deck.Count))
                {
                    Console.Write("Choose card (number): ");
                    if (!int.TryParse(Console.ReadLine(), out cardChoice)) cardChoice = -1;
                    cardChoice -= 1; // Convert to 0-based
                }
                
                Card chosenCard = deck[cardChoice];
                deck.RemoveAt(cardChoice); // USE ONCE AND DISCARD LIKE MY HOPES AND DREAMS
                deck.Add(chosenCard); // ACTUALLY PUT AT END OF DECK
                
                // APPLY CARD EFFECTS with MAXIMUM DRAMA
                enemyHP -= chosenCard.Damage;
                HERO.HP += chosenCard.healAmount;
                if (HERO.HP > HERO.maxHP) HERO.HP = HERO.maxHP;
                
                Console.WriteLine($"You used {chosenCard.Name}!");
                Console.WriteLine($"Enemy takes {chosenCard.Damage} damage! Enemy HP: {Math.Max(0, enemyHP)}");
                if (chosenCard.healAmount > 0)
                    Console.WriteLine($"You heal for {chosenCard.healAmount}! Your HP: {HERO.HP}");
                
                // Enemy turn if still alive
                if (enemyHP > 0)
                {
                    Console.WriteLine($"\n{enemy} ATTACKS YOU FOR {enemyDMG} DAMAGE!");
                    HERO.HP -= enemyDMG;
                    Console.WriteLine($"Your HP: {Math.Max(0, HERO.HP)}");
                }
            }
            
            if (enemyHP <= 0)
            {
                int goldReward = new Random().Next(5, 15);
                Console.WriteLine($"\nVICTORY! {enemy} is defeated!");
                Console.WriteLine($"You gain {goldReward} gold!");
                HERO.gold += goldReward;
                
                // 25% chance to find a new card
                if (new Random().Next(100) < 25)
                {
                    Card newCard = GenerateRandomCard();
                    deck.Add(newCard);
                    Console.WriteLine($"\nYOU FOUND A NEW CARD: {newCard.Name}!");
                }
            }
        }
        
        static Card GenerateRandomCard()
        {
            string[] cardNames = {
                "BOOM-STICK",
                "healz_potion",
                "BLADE-OF-CHAOS",
                "magic_missle.exe",
                "SPARTA_KICK"
            };
            
            var card = new Card {
                Name = cardNames[new Random().Next(cardNames.Length)],
                Damage = new Random().Next(5, 20),
                healAmount = new Random().Next(0, 10),
                Effect = (CardEffect)new Random().Next(5)
            };
            
            return card;
        }
        
        static void TreasureRoom(Player HERO)
        {
            Console.WriteLine("\nYOU FOUND A TREASURE CHEST!");
            int goldFound = new Random().Next(10, 30);
            HERO.gold += goldFound;
            Console.WriteLine($"You gained {goldFound} gold!");
            
            // 10% chance for a health boost
            if (new Random().Next(100) < 10)
            {
                HERO.maxHP += 5;
                HERO.HP += 5;
                Console.WriteLine("THE GODS FAVOR YOU! Max HP increased by 5!");
            }
        }
        
        static void SpinTheSlots(Player HERO)
        {
            if (HERO.gold < 5)
            {
                Console.WriteLine("TOO POOR! You need 5 gold to spin the slots!");
                return;
            }
            
            HERO.gold -= 5;
            Console.WriteLine("\nThe ancient slot machine rumbles to life! IT COSTS 5 GOLD.");
            Console.WriteLine("Spinning...");
            
            // SUSPENSE BUILDING
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
            
            // ABSOLUTELY CHAOTIC SLOT RESULTS
            string[] symbols = { "💀", "💰", "❤️", "🗡️", "🛡️" };
            
            string[] results = new string[3];
            for (int i = 0; i < 3; i++)
            {
                results[i] = symbols[new Random().Next(symbols.Length)];
                Console.Write(results[i] + " ");
            }
            Console.WriteLine();
            
            // CHECK FOR MATCHING SYMBOLS
            if (results[0] == results[1] && results[1] == results[2])
            {
                // JACKPOT BABYYYYY
                if (results[0] == "💰")
                {
                    Console.WriteLine("JACKPOT! You got 50 gold!");
                    HERO.gold += 50;
                }
                else if (results[0] == "❤️")
                {
                    Console.WriteLine("JACKPOT! Full health restore!");
                    HERO.HP = HERO.maxHP;
                }
                else if (results[0] == "💀")
                {
                    Console.WriteLine("OH NO! DEATH COMES FOR YOU! -20 HP!");
                    HERO.HP = Math.Max(0, HERO.HP - 20);
                }
                else if (results[0] == "🗡️")
                {
                    Console.WriteLine("JACKPOT! Enemies in the next room take 20 damage!");
                    // This doesn't actually do anything but the player doesn't know that MUHAHAHA
                }
                else if (results[0] == "🛡️")
                {
                    Console.WriteLine("JACKPOT! Max HP increased by 10!");
                    HERO.maxHP += 10;
                    HERO.HP += 10;
                }
            }
            else if (results[0] == results[1] || results[1] == results[2] || results[0] == results[2])
            {
                // Two matching symbols
                Console.WriteLine("Two matches! You got 10 gold!");
                HERO.gold += 10;
            }
            else
            {
                // No matches
                Console.WriteLine("No matches! YOU GET NOTHING! GOOD DAY SIR!");
            }
        }
        
        static void ViewCards(List<Card> deck)
        {
            Console.WriteLine("\n*** YOUR CARDS OF CHAOS ***");
            for (int i = 0; i < deck.Count; i++)
            {
                var card = deck[i];
                Console.WriteLine($"{i+1}. {card.Name} - DMG: {card.Damage}, HEAL: {card.healAmount}, EFFECT: {card.Effect}");
            }
        }
    }
    
    // MIXED STYLE CLASSES BECAUSE WHY NOT
    class Player {
        public string Name { get; set; } = "";
        public int HP;
        public int maxHP;
        public int gold;
        public bool wonGame = false;
        
        // DUNGEON DATA THAT WE BARELY USE
        public Dictionary<int, DungeonGenerator.DungeonRoom> currentDungeon;
        public int currentRoomId;
    }
    
    struct Card {
        public string Name;
        public int Damage;
        public int healAmount;
        public CardEffect Effect;
    }
    
    enum CardEffect {
        BURN,
        poison,
        heal,
        BLOCK,
        DOUBLE
    }
} 