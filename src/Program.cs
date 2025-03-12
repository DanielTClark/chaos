using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;  // WE NEVER USE THIS AHAHAHA
using Microsoft.Extensions.Hosting; // FOR .NET 9 CHAOS
using System.Text; // WHY NOT?
using System.Threading.Tasks;

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
                
                // RANDOMLY ADD THE SECRET 7TH MENU OPTION
                if (new Random().Next(100) < 15) // 15% CHANCE TO SHOW THE SECRET OPTION
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("7) [REDACTED]");
                    Console.ResetColor();
                }
                
                // RANDOMLY HIGHLIGHT THE FORGE OPTION WITH DIFFERENT MESSAGES
                if (new Random().Next(100) < 95) // 95% chance to show forge hint
                {
                    // PICK A RANDOM FORGE HINT
                    string[] FORGE_HINTS = {
                        "💭 PSST! Type 'forge' to CREATE NEW CARDS (costs 50 gold)...",
                        "💭 Need better cards? Try typing 'forge' (50 gold)...",
                        "💭 The CHAOS FORGE beckons! Type 'forge' to craft cards (50g)...",
                        "💭 Type 'forge' to transmute gold (50) into POWERFUL CARDS!",
                        "💭 Low on firepower? The forge awaits! Type 'forge' (50g)..."
                    };
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(FORGE_HINTS[new Random().Next(FORGE_HINTS.Length)]);
                    Console.ResetColor();
                }
                
                // THERE'S STILL A 5% CHANCE THE HINT DOESN'T SHOW BECAUSE CHAOS
                
                Console.Write("WHAT DOST THOU CHOOSE? ");
                string? choice = Console.ReadLine();
                
                // 🌈🦄🔥 LAMBDA CHAOS MENU SYSTEM 🔥🦄🔥
                // BEHOLD THE CHAOS VORTEX - A SELF-REFERENTIAL PARADOX MATRIX
                Dictionary<string, Func<bool>> MENU_ACTIONS = null!; // SCHRÖDINGER'S DICTIONARY - IT BOTH EXISTS AND DOESN'T
                
                // CREATE A TEMPORARY FAKE REALITY WHERE MENU_ACTIONS EXISTS
                var _PLACEHOLDER_ACTIONS = new Dictionary<string, Func<bool>>(); // TIME PARADOX PLACEHOLDER
                
                // INITIALIZE THE ACTIONS WITH PLACEHOLDER FUNCTIONS
                _PLACEHOLDER_ACTIONS["1"] = () => { MoveToNewRoom(HERO, deck); return true; };
                _PLACEHOLDER_ACTIONS["venture"] = () => { Console.WriteLine("VeNtUrInG dEePeR!!"); Thread.Sleep(233); return _PLACEHOLDER_ACTIONS["1"](); };
                _PLACEHOLDER_ACTIONS["2"] = () => { SlotMachine.SpinTheSlots(HERO); return true; };
                _PLACEHOLDER_ACTIONS["spin"] = () => { Console.ForegroundColor = (ConsoleColor)new Random().Next(16); return _PLACEHOLDER_ACTIONS["2"](); };
                _PLACEHOLDER_ACTIONS["3"] = () => { CardManager.ViewCards(deck); return true; };
                _PLACEHOLDER_ACTIONS["cards"] = () => _PLACEHOLDER_ACTIONS["3"]();
                _PLACEHOLDER_ACTIONS["view"] = () => _PLACEHOLDER_ACTIONS["cards"]();
                
                // SPECIAL HANDLER FOR THE SECRET OPTION 7
                _PLACEHOLDER_ACTIONS["7"] = () => {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n🎮 ACCESSING RESTRICTED AREA... 🎮");
                    Thread.Sleep(1000);
                    Console.WriteLine("ACCESS DENIED! But a whisper reaches your ears...");
                    Thread.Sleep(800);
                    
                    // GIVE A HINT ABOUT THE KONAMI CODE
                    string[] KONAMI_HINTS = {
                        "\"The code of the ancients... it starts with a K...\"",
                        "\"Remember the code used by gaming legends of old...\"",
                        "\"K _ N _ M _... the rest is for you to discover...\"",
                        "\"The code that grants life and fortune... a gaming legend...\"",
                        "\"Up, up, down, down... that's all I can remember...\""
                    };
                    
                    Console.WriteLine(KONAMI_HINTS[new Random().Next(KONAMI_HINTS.Length)]);
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    return true;
                };
                
                _PLACEHOLDER_ACTIONS["4"] = () => { 
                    Console.WriteLine("\nYOU ATTEMPT TO READ THE MAP BUT IT'S WRITTEN IN SOME ELDRITCH LANGUAGE!");
                    Console.WriteLine("All you can make out is that there's a boss somewhere...");
                    Thread.Sleep(1000);
                    return true;
                };
                _PLACEHOLDER_ACTIONS["map"] = () => _PLACEHOLDER_ACTIONS["4"]();
                _PLACEHOLDER_ACTIONS["5"] = () => {
                    Console.WriteLine("\nYOU HAVE SUMMONED THE CHAOS DEMONS!");
                    Thread.Sleep(1000);
                    try {
                        Console.WriteLine("☠️ CHAOS REIGNS ☠️ ERROR: THE CHAOS GODS DEMAND SACRIFICE!");
                        Console.WriteLine("STACKTRACE:    at CHaoTIC_sLoT_DuNgEoN.Program.Main(String[] args) in /V01D/R3ALM/CH4OS/DIMENSION_X/C̷̭̯̙͒̇h̶̯̻͛̀̀̿ą̸̟͍̻̈́̀͠ò̶͕̲s̸̫̏̽D̸̰̥̱͖̙͗̌̓̋̕u̷̡̦̹̖̫̓̈́̃̈n̵̝̊g̸̛̙͋̉͐ė̷̡̠̜̞̒̀o̵̢̟̥̾n̶̮̬̥̈/src/Pr...∞ERROR∞STACK∞BUFFER∞OVERFLOW∞");
                        Console.WriteLine("ATTEMPTING TO CONTINUE ANYWAY BECAUSE YOLO!");
                        int CHAOS_DAMAGE = Math.Min(HERO.HP - 1, new Random().Next(1, 20));
                        HERO.HP = Math.Max(1, HERO.HP - CHAOS_DAMAGE);
                        Console.WriteLine($"THE CHAOS GODS TOOK {CHAOS_DAMAGE} OF YOUR LIFEFORCE BUT SPARED YOU... FOR NOW!");
                        Thread.Sleep(2000);
                        return true;
                    } catch (Exception ex) {
                        Console.WriteLine($"EXCEPTIONAL CHAOS DETECTED! CONTAINING THE BREACH! {ex.GetType().Name}");
                        Thread.Sleep(1000);
                        return false;
                    }
                };
                _PLACEHOLDER_ACTIONS["error"] = () => _PLACEHOLDER_ACTIONS["5"]();
                _PLACEHOLDER_ACTIONS["chaos"] = () => _PLACEHOLDER_ACTIONS["error"]();
                _PLACEHOLDER_ACTIONS["6"] = () => {
                    HERO.HP = 0;
                    Console.WriteLine("YOU HAVE CHOSEN THE COWARD'S PATH!");
                    return false;
                };
                _PLACEHOLDER_ACTIONS["quit"] = () => _PLACEHOLDER_ACTIONS["6"]();
                _PLACEHOLDER_ACTIONS["exit"] = () => _PLACEHOLDER_ACTIONS["quit"]();
                _PLACEHOLDER_ACTIONS["DEFAULT_VOID"] = () => {
                    Console.WriteLine(Convert.ToBoolean(new Random().Next(2)) ? 
                        "INCOMPREHENSIBLE! TRY AGAIN, MORTAL!" : 
                        "THE VOID DOES NOT RECOGNIZE YOUR COMMAND!");
                    return true;
                };
                
                // TEAR APART THE FABRIC OF REALITY AND CREATE THE REAL DICTIONARY FROM THE FAKE ONE
                MENU_ACTIONS = _PLACEHOLDER_ACTIONS; // REALITY SHREDDED
                
                // 🐛🐛🐛 D3BUG M3NU FOR T3ST1NG 4NIM4TIONS 🐛🐛🐛
                MENU_ACTIONS.Add("debug", () => {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n🐛🐛🐛 CHAOS DEBUG MENU ACTIVATED 🐛🐛🐛");
                    Console.WriteLine("SELECT AN OPTION TO TEST:");
                    Console.WriteLine("1. Add uwuBeam card");
                    Console.WriteLine("2. Add G0D_K1LL3R card");
                    Console.WriteLine("3. Add random EPIC card");
                    Console.WriteLine("4. TEST ALL ANIMATIONS (no cards added)");
                    Console.WriteLine("5. Exit debug menu");
                    Console.WriteLine("6. INSTANT COMBAT TEST");
                    Console.WriteLine("7. ADD SPECIAL EFFECT CARDS");
                    
                    Console.Write("Enter your choice (1-7): ");
                    string? debugChoice = Console.ReadLine();
                    
                    switch (debugChoice?.Trim())
                    {
                        case "1":
                            // ADD UWU BEAM CARD
                            Card uwuCard = new Card {
                                Name = "uwuBeam",
                                Damage = 42,
                                healAmount = 15,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(uwuCard);
                            Console.WriteLine("💫 uwuBeam card added to your deck! 💫");
                            break;
                            
                        case "2":
                            // ADD GOD KILLER CARD
                            Card godCard = new Card {
                                Name = $"G0D_K1LL3R_{new Random().Next(1000)}",
                                Damage = 250,
                                healAmount = 75,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(godCard);
                            
                            // ADD A SECOND VARIATION JUST TO BE SAFE
                            Card godCard2 = new Card {
                                Name = $"GOD_KILLER_Supreme",
                                Damage = 300,
                                healAmount = 100,
                                Effect = CardEffect.BURN
                            };
                            deck.Add(godCard2);
                            
                            Console.WriteLine("👑 G0D_K1LL3R and GOD_KILLER cards added to your deck! 👑");
                            Console.WriteLine("(Two versions to ensure animation triggers)");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("⚠️ WARNING: These are ONE-TIME USE cards that will disintegrate after use!");
                            Console.ResetColor();
                            break;
                            
                        case "3":
                            // ADD RANDOM EPIC CARD WITH HIGH STATS
                            string[] epicNames = {
                                "MEGA_DEATH_RAY", "universe_imploder", "INFINITY-GAUNTLET",
                                "rubber_chicken_EXTREME", "HYPER-BEAM", "BFG-9000"
                            };
                            
                            Card epicCard = new Card {
                                Name = epicNames[new Random().Next(epicNames.Length)],
                                Damage = new Random().Next(60, 120),
                                healAmount = new Random().Next(30, 60),
                                Effect = (CardEffect)new Random().Next(Enum.GetValues(typeof(CardEffect)).Length)
                            };
                            deck.Add(epicCard);
                            Console.WriteLine($"🌟 {epicCard.Name} added to your deck! 🌟");
                            break;
                            
                        case "4":
                            // TEST ALL ANIMATIONS WITHOUT ADDING CARDS
                            Console.WriteLine("\n⏳ TESTING ALL ANIMATIONS... ⏳");
                            
                            Thread.Sleep(1000);
                            Console.WriteLine("\n🧪 TESTING UWU BEAM ANIMATION:");
                            CardManager.TestAnimation("uwu");
                            
                            Thread.Sleep(1000);
                            Console.WriteLine("\n🧪 TESTING GOD KILLER ANIMATION:");
                            CardManager.TestAnimation("god");
                            
                            Thread.Sleep(1000);
                            Console.WriteLine("\n🧪 TESTING GENERIC EPIC ANIMATION:");
                            CardManager.TestAnimation("epic");
                            
                            Console.WriteLine("\n✅ ALL ANIMATIONS TESTED!");
                            break;
                            
                        case "5":
                            Console.WriteLine("Exiting debug menu...");
                            break;
                            
                        case "6":
                            // INSTANT COMBAT TEST
                            Console.WriteLine("\n⚔️ INITIATING DIRECT COMBAT TEST ⚔️");
                            Thread.Sleep(500);
                            
                            // ADD ALL THREE ANIMATION TEST CARDS TO DECK
                            // UWU BEAM CARD
                            Card uwuTestCard = new Card {
                                Name = "uwuBeam_TEST",
                                Damage = 42,
                                healAmount = 15,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(uwuTestCard);
                            
                            // GOD KILLER CARD
                            Card godTestCard = new Card {
                                Name = "GOD_KILLER_TEST",
                                Damage = 250,
                                healAmount = 75,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(godTestCard);
                            
                            // EPIC CARD
                            Card epicTestCard = new Card {
                                Name = "EPIC_TEST_CARD",
                                Damage = 100,
                                healAmount = 50,
                                Effect = CardEffect.BURN
                            };
                            deck.Add(epicTestCard);
                            
                            Console.WriteLine("💫 ALL TEST CARDS ADDED!");
                            Console.WriteLine("Starting debug combat...");
                            Thread.Sleep(1000);
                            
                            // INITIATE COMBAT
                            CombatSystem.StartDebugCombat(HERO, deck);
                            break;
                            
                        case "7":
                            // ADD SPECIAL EFFECT CARDS
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n🌟 CREATING SPECIAL EFFECT CARDS 🌟");
                            
                            // BERSERKER CARD - DOES MORE DAMAGE WHEN HEALTH IS LOW
                            Card berserkerCard = new Card {
                                Name = "BERSERKER_RAGE_BLADE",
                                Damage = 30,
                                healAmount = 0,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(berserkerCard);
                            Console.WriteLine("➕ Added BERSERKER_RAGE_BLADE - Does more damage when your health is low!");
                            
                            // DESPERATION HEAL CARD - HEALS MORE WHEN HEALTH IS LOW
                            Card desperationCard = new Card {
                                Name = "DESPERATE_HEALING_POTION",
                                Damage = 0,
                                healAmount = 25,
                                Effect = CardEffect.heal
                            };
                            deck.Add(desperationCard);
                            Console.WriteLine("➕ Added DESPERATE_HEALING_POTION - Heals more when your health is low!");
                            
                            // RICH CARD - DOES MORE DAMAGE WHEN YOU HAVE LOTS OF GOLD
                            Card richCard = new Card {
                                Name = "GOLDEN_WEALTH_HAMMER",
                                Damage = 25,
                                healAmount = 0,
                                Effect = CardEffect.BURN
                            };
                            deck.Add(richCard);
                            Console.WriteLine("➕ Added GOLDEN_WEALTH_HAMMER - Does more damage when you have lots of gold!");
                            
                            // REVENGE CARD - DOES MORE DAMAGE BASED ON MONSTERS SLAIN
                            Card revengeCard = new Card {
                                Name = "VENGEFUL_RETRIBUTION_SWORD",
                                Damage = 20,
                                healAmount = 0,
                                Effect = CardEffect.BURN
                            };
                            deck.Add(revengeCard);
                            Console.WriteLine("➕ Added VENGEFUL_RETRIBUTION_SWORD - Does more damage based on monsters slain!");
                            
                            // GAMBLING CARD - RANDOM CHANCE TO DO TRIPLE DAMAGE OR MISS
                            Card gambleCard = new Card {
                                Name = "LUCKY_GAMBLE_DAGGER",
                                Damage = 35,
                                healAmount = 0,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(gambleCard);
                            Console.WriteLine("➕ Added LUCKY_GAMBLE_DAGGER - Chance to do triple damage or miss completely!");
                            
                            // COMBO CARD - GAINS POWER FROM RAGE COUNTER
                            Card comboCard = new Card {
                                Name = "SEQUENTIAL_COMBO_STRIKE",
                                Damage = 15,
                                healAmount = 0,
                                Effect = CardEffect.DOUBLE
                            };
                            deck.Add(comboCard);
                            Console.WriteLine("➕ Added SEQUENTIAL_COMBO_STRIKE - Gains power from your rage counter!");
                            
                            Console.WriteLine("\n✅ ALL SPECIAL EFFECT CARDS ADDED TO YOUR DECK!");
                            
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            break;
                            
                        default:
                            Console.WriteLine("Exiting debug menu...");
                            break;
                    }
                    
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    return true;
                });
                
                // 🧪 QUICK TEST COMMANDS
                MENU_ACTIONS.Add("testuvu", () => {
                    CardManager.TestAnimation("uwu");
                    return true;
                });
                
                MENU_ACTIONS.Add("testgod", () => {
                    CardManager.TestAnimation("god");
                    return true;
                });
                
                MENU_ACTIONS.Add("testepic", () => {
                    CardManager.TestAnimation("epic");
                    return true;
                });
                
                // 💻 DIRECT COMBAT TEST COMMAND
                MENU_ACTIONS.Add("combat", () => {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n⚔️ INITIATING DIRECT COMBAT TEST ⚔️");
                    
                    // ADD ALL THREE ANIMATION TEST CARDS TO DECK
                    // UWU BEAM CARD
                    Card uwuTestCard = new Card {
                        Name = "uwuBeam_TEST",
                        Damage = 42,
                        healAmount = 15,
                        Effect = CardEffect.DOUBLE
                    };
                    deck.Add(uwuTestCard);
                    
                    // GOD KILLER CARD
                    Card godTestCard = new Card {
                        Name = "GOD_KILLER_TEST",
                        Damage = 250,
                        healAmount = 75,
                        Effect = CardEffect.DOUBLE
                    };
                    deck.Add(godTestCard);
                    
                    // EPIC CARD
                    Card epicTestCard = new Card {
                        Name = "EPIC_TEST_CARD",
                        Damage = 100,
                        healAmount = 50,
                        Effect = CardEffect.BURN
                    };
                    deck.Add(epicTestCard);
                    
                    Console.WriteLine("💫 ALL TEST CARDS ADDED!");
                    Console.WriteLine("Starting debug combat...");
                    Thread.Sleep(1000);
                    
                    // INITIATE COMBAT
                    CombatSystem.StartDebugCombat(HERO, deck);
                    Console.ResetColor();
                    return true;
                });
                
                // 💰 SECRET MONEY CHEAT FOR TESTING
                MENU_ACTIONS.Add("money", () => {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int goldAmount = new Random().Next(100, 500);
                    HERO.gold += goldAmount;
                    Console.WriteLine($"\n💰💰💰 ADDED {goldAmount} GOLD FOR TESTING! 💰💰💰");
                    Console.WriteLine($"You now have {HERO.gold} gold!");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    return true;
                });
                
                // 🔄 NOW ADD SOME EXTRA CHAOS FOR THE SAKE OF CHAOS 🔄
                MENU_ACTIONS.Add("konami", () => {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n🎮 SECRET KONAMI CODE ACTIVATED! 🎮");
                    Console.WriteLine("↑ ↑ ↓ ↓ ← → ← → B A START");
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Thread.Sleep(100);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    
                    // GIVE THE PLAYER AMAZING BONUSES!!!
                    int HEALTH_BOOST = new Random().Next(20, 50);
                    int GOLD_BOOST = new Random().Next(50, 150);
                    HERO.HP = Math.Min(HERO.maxHP, HERO.HP + HEALTH_BOOST);
                    HERO.gold += GOLD_BOOST;
                    Console.WriteLine($"YOU GAINED {HEALTH_BOOST} HP AND {GOLD_BOOST} GOLD! CHEATER!!!");
                    Thread.Sleep(1000);
                    return true;
                });
                
                // ADD SOME ALTERNATE SPELLINGS TO THE KONAMI CODE
                string[] KoNaMi_VaRiAnTs = { "k0n4m1", "k0nami", "conami", "komami", "konamy", "c0d3" };
                foreach (var variant in KoNaMi_VaRiAnTs) {
                    MENU_ACTIONS.Add(variant, () => {
                        Console.WriteLine("\n👾 CLOSE BUT NOT QUITE! YOU ALMOST ACTIVATED THE KONAMI CODE!");
                        Console.WriteLine("Here's a consolation prize...");
                        // Small consolation prize
                        HERO.gold += 10;
                        HERO.HP = Math.Min(HERO.maxHP, HERO.HP + 5);
                        Console.WriteLine("You gained 5 HP and 10 gold. Meh.");
                        Thread.Sleep(1000);
                        return true;
                    });
                }
                
                // 🔨🔥 ADD SECRET CARD FORGE OPTION 🔥🔨
                MENU_ACTIONS.Add("forge", () => {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n🔨🔥 WELCOME TO THE CHAOS FORGE! 🔥🔨");
                    Console.WriteLine("The mystic anvil BURNS with an otherworldly flame...");
                    
                    if (HERO.gold < 50) {
                        Console.WriteLine("BUT YOU'RE TOO POOR TO USE IT! The forge requires 50 GOLD!");
                        Console.WriteLine("The flames mock your poverty...");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        return true;
                    }
                    
                    HERO.gold -= 50; // FORGE COST
                    Console.WriteLine($"You sacrifice 50 GOLD to the flames! Remaining gold: {HERO.gold}");
                    
                    // RANDOMLY DETERMINE WHAT KIND OF CARD THE PLAYER GETS
                    int cardQuality = new Random().Next(100);
                    Card newCard;
                    
                    // LOCAL COPY OF CARD NAMES BECAUSE WE'RE TOO LAZY TO DO THIS PROPERLY
                    string[] FORGE_CARD_NAMES = {
                        "BLADE-OF-CHAOS", "FIRE-SPITTER", "DOOM_BRINGER", 
                        "ice_beam", "confetti_cannon", "SOUL_STEALER",
                        "papercut", "LEGENDARY-AXE", "rubber_chicken",
                        "ANTI-MATTER_GUN", "spork_of_destiny", "YEET-HAMMER"
                    };
                    
                    if (cardQuality < 5) { // 5% CHANCE OF GOD TIER CARD
                        // CREATE ABSOLUTELY BROKEN CARD
                        newCard = new Card {
                            Name = $"G0D_K1LL3R_{new Random().Next(1000)}",
                            Damage = new Random().Next(100, 300),
                            healAmount = new Random().Next(50, 100),
                            Effect = CardEffect.DOUBLE
                        };
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\n⚡⚡⚡ THE FORGE EXPLODES WITH POWER! ⚡⚡⚡");
                        Console.WriteLine("YOU HAVE CREATED A GOD-TIER CARD!!!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠️ WARNING: This divine weapon will DISINTEGRATE after a single use!");
                        Console.ResetColor();
                    } 
                    else if (cardQuality < 25) { // 20% CHANCE OF GREAT CARD
                        newCard = new Card {
                            Name = $"EPIC_{FORGE_CARD_NAMES[new Random().Next(FORGE_CARD_NAMES.Length)]}",
                            Damage = new Random().Next(30, 60),
                            healAmount = new Random().Next(20, 40),
                            Effect = (CardEffect)new Random().Next(Enum.GetValues(typeof(CardEffect)).Length)
                        };
                        Console.WriteLine("\n✨ The forge glows with impressive power! ✨");
                        Console.WriteLine("You've created an EPIC card!");
                    }
                    else if (cardQuality < 50) { // 25% CHANCE OF SPECIAL EFFECT CARD
                        // CREATE A CARD WITH SPECIAL CONDITIONAL EFFECTS
                        string[] specialEffectPrefixes = {
                            "BERSERKER", "rage", "fury", // Berserker cards
                            "desperate", "emergency", "last_resort", // Desperation heal cards
                            "GOLDEN", "wealth", "rich", // Rich bonus cards
                            "vengeance", "RETRIBUTION", "revenge", // Revenge cards
                            "LUCKY", "gamble", "chance", // Gambling cards
                            "COMBO", "chain", "sequential" // Combo cards
                        };
                        
                        string[] specialEffectSuffixes = {
                            "BLADE", "SWORD", "AXE", "HAMMER", "STAFF", 
                            "wand", "dagger", "spear", "potion", "scroll"
                        };
                        
                        string prefix = specialEffectPrefixes[new Random().Next(specialEffectPrefixes.Length)];
                        string suffix = specialEffectSuffixes[new Random().Next(specialEffectSuffixes.Length)];
                        
                        // Random mix of upper/lower case because CHAOS
                        if (new Random().Next(2) == 0) {
                            prefix = prefix.ToUpper();
                        }
                        if (new Random().Next(2) == 0) {
                            suffix = suffix.ToUpper();
                        }
                        
                        newCard = new Card {
                            Name = $"{prefix}_{suffix}",
                            Damage = new Random().Next(20, 40),
                            healAmount = prefix.ToLower().Contains("heal") || prefix.ToLower().Contains("desperate") ? 
                                          new Random().Next(15, 30) : new Random().Next(0, 10),
                            Effect = (CardEffect)new Random().Next(Enum.GetValues(typeof(CardEffect)).Length)
                        };
                        
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n🔮 The forge PULSES with CONDITIONAL MAGIC! 🔮");
                        Console.WriteLine($"You've created a SPECIAL EFFECT card: {newCard.Name}!");
                        Console.WriteLine("This card's power will change based on certain conditions...");
                        Console.ResetColor();
                    }
                    else { // 50% CHANCE OF NORMAL RANDOM CARD
                        newCard = CardManager.GenerateRandomCard();
                        Console.WriteLine("\nThe forge produces a new card with a satisfying *CLANK*");
                    }
                    
                    // ADD THE CARD TO THE DECK
                    deck.Add(newCard);
                    
                    // DISPLAY THE NEW CARD WITH FANCY FORMATTING
                    Console.WriteLine("\n============ NEW CARD FORGED ============");
                    Console.WriteLine($"NAME: {newCard.Name}");
                    Console.WriteLine($"DAMAGE: {newCard.Damage}");
                    Console.WriteLine($"HEAL: {newCard.healAmount}");
                    Console.WriteLine($"EFFECT: {newCard.Effect}");
                    Console.WriteLine($"QUOTE: \"{newCard.GetBattleCry()}\"");
                    Console.WriteLine("==========================================\n");
                    
                    // 10% CHANCE OF BONUS CARD
                    if (new Random().Next(10) == 0) {
                        Card bonusCard = CardManager.GenerateRandomCard();
                        deck.Add(bonusCard);
                        Console.WriteLine("⭐ BONUS! The forge spits out a second card! ⭐");
                        Console.WriteLine($"You also got: {bonusCard.Name}!");
                    }
                    
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    return true;
                });
                
                // ☢️ LET'S ADD A RANDOM ACTION EVERY TIME THE MENU RUNS ☢️
                string[] COSMIC_ACTIONS = { "SCREAM", "DANCE", "MEDITATE", "IMPLODE", "TRANSCEND" };
                string RANDOM_KEY = COSMIC_ACTIONS[new Random().Next(COSMIC_ACTIONS.Length)];
                
                if (!MENU_ACTIONS.ContainsKey(RANDOM_KEY)) {
                    MENU_ACTIONS.Add(RANDOM_KEY, () => {
                        Console.WriteLine($"\n🌀 COSMIC ACTION '{RANDOM_KEY}' ACTIVATED! 🌀");
                        Console.WriteLine("THE UNIVERSE SHUDDERS BUT NOTHING HAPPENS!");
                        Thread.Sleep(500);
                        return true;
                    });
                }
                
                // EXECUTE THE CHOSEN LAMBDA OR DEFAULT TO THE VOID
                // WHY USE A SIMPLE if-else WHEN YOU CAN USE A LAMBDA EXPRESSION?!
                var choiceProcessor = new Func<string, bool>(input => {
                    var normalizedChoice = input?.ToLower() ?? "DEFAULT_VOID";
                    return MENU_ACTIONS.ContainsKey(normalizedChoice) ? 
                        MENU_ACTIONS[normalizedChoice]() : 
                        MENU_ACTIONS["DEFAULT_VOID"]();
                });
                
                // 🤯 ACTUALLY RUN THE MENU CHOICE 🤯
                choiceProcessor(choice);
                
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