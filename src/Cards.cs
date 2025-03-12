using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // INCONSISTENT NAMING CONVENTIONS BECAUSE WE'RE REBELS
    public struct Card 
    {
        public string Name;  // pascal case
        public int Damage;   // pascal case
        public int healAmount; // camel case
        public CardEffect Effect; // pascal case again
        
        // CARDS NEED RANDOM QUOTES BECAUSE WHY NOT
        private static readonly string[] CARD_QUOTES = {
            "TASTE MY FURY!",
            "i'm just a card, don't expect much",
            "BOOM SHAKALAKA!",
            "pew pew pew",
            "*existential screaming*",
            "This card would like to speak to your manager",
            "UwU what's this?"
        };
        
        // GET A RANDOM BATTLE QUOTE
        public string GetBattleCry() 
        {
            return CARD_QUOTES[new Random().Next(CARD_QUOTES.Length)];
        }
        
        // OVERRIDE TO STRING SO THE CARD CAN INSULT YOU
        public override string ToString()
        {
            return $"{Name} [{Effect}] - DMG: {Damage}, HEAL: {healAmount} - '{GetBattleCry()}'";
        }
    }
    
    // WILDLY INCONSISTENT ENUM CAPITALIZATION
    public enum CardEffect 
    {
        BURN,   // SHOUTING
        poison, // whispering
        heal,   // whispering
        BLOCK,  // SHOUTING 
        DOUBLE  // SHOUTING
    }
    
    // A MANAGER CLASS THAT DOESN'T ACTUALLY MANAGE ANYTHING PROPERLY
    public static class CardManager
    {
        // CARDS SO NICE WE DEFINE THEM TWICE
        private static readonly string[] CARD_NAMES = {
            "FIREBALL",
            "healingPotion",
            "rusty_dagger",
            "SHIELD-OF-DESTINY",
            "never_gonna_give_you_up",
            "BOOM-STICK",
            "healz_potion",
            "BLADE-OF-CHAOS",
            "magic_missle.exe",
            "SPARTA_KICK",
            "uwuBeam",
            "Y33T-CANNON",
            "poTAYto",
            "MR_WORLDWIDE",
            "cardboard_tube",
            // NEW SPECIAL EFFECT CARDS WITH KEYWORDS
            "BERSERKER_rage_SWORD",
            "desperate_HEALING_flask",
            "RICH_gold_MACE",
            "vengeful_RETRIBUTION",
            "LUCKY_gamble_DICE",
            "COMBO_chain_ATTACK"
        };
        
        // INITIALIZE A DECK OF CARDS WITH WILDLY DIFFERENT POWER LEVELS
        public static List<Card> InitDeck()
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
        
        // GENERATE A RANDOM CARD - COMPLETELY UNBALANCED
        public static Card GenerateRandomCard()
        {
            var rand = new Random();
            
            // SOMETIMES WE MAKE INCREDIBLY OVERPOWERED CARDS
            bool makeOverpoweredCard = rand.Next(10) == 0; // 10% chance
            
            var card = new Card {
                Name = CARD_NAMES[rand.Next(CARD_NAMES.Length)],
                // DAMAGE COULD BE 500 LOL GET REKT
                Damage = makeOverpoweredCard ? rand.Next(100, 500) : rand.Next(5, 20),
                // HEALING IS RANDOM TOO
                healAmount = makeOverpoweredCard ? rand.Next(50, 200) : rand.Next(0, 15),
                // RANDOM EFFECT BECAUSE WHO CARES
                Effect = (CardEffect)rand.Next(Enum.GetValues(typeof(CardEffect)).Length)
            };
            
            return card;
        }
        
        // DISPLAY THE PLAYER'S CARDS BUT IN A RIDICULOUS WAY
        public static void ViewCards(List<Card> deck)
        {
            Console.WriteLine("\n*** YOUR CARDS OF CHAOS ***");
            
            // RANDOMLY SORT THE DECK HALF THE TIME BECAUSE CHAOS
            if (new Random().Next(2) == 0)
            {
                deck = deck.OrderBy(x => Guid.NewGuid()).ToList(); // SHUFFLE FOR NO REASON
                Console.WriteLine("(Your cards decided to SHUFFLE THEMSELVES)");
            }
            
            for (int i = 0; i < deck.Count; i++)
            {
                var card = deck[i];
                
                // 5% CHANCE OF PRETENDING A CARD IS "CURSED" BUT IT'S NOT ACTUALLY DIFFERENT
                if (new Random().Next(20) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i+1}. {card.Name} - DMG: {card.Damage}, HEAL: {card.healAmount}, EFFECT: {card.Effect} [CURSED!!!]");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i+1}. {card.Name} - DMG: {card.Damage}, HEAL: {card.healAmount}, EFFECT: {card.Effect}");
                }
            }
        }
        
        // USE A CARD IN BATTLE BUT SOMETIMES IT DOES UNEXPECTED THINGS
        public static void UseCard(Card card, ref int enemyHP, ref Player player)
        {
            Console.WriteLine($"You used {card.Name}!");
            
            // CHECK IF THIS IS A GOD KILLER CARD (SINGLE USE!!!)
            bool isGodKillerCard = card.Name.ToLower().Contains("god") || 
                                  card.Name.ToLower().Contains("killer") || 
                                  card.Name.ToLower().Contains("g0d") || 
                                  card.Name.ToLower().Contains("k1ll3r");
            
            if (isGodKillerCard)
            {
                // DRAMATIC WARNING ABOUT SINGLE USE
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠️ ⚠️ ⚠️ ONE-TIME USE DIVINE WEAPON! ⚠️ ⚠️ ⚠️");
                Console.WriteLine("THIS CARD WILL DISINTEGRATE AFTER USE!");
                Console.ResetColor();
                Thread.Sleep(1000);
            }
            
            // CHECK FOR SPECIAL CARDS THAT DESERVE L33T GRAPHICS!! 🔥🔥🔥
            if (card.Name.ToLower().Contains("uwu") || card.Name.ToLower().Contains("beam"))
            {
                // UwU BEAM EPIC ANIMATION!!! 
                PlayUwuBeamAnimation();
            }
            else if (isGodKillerCard)
            {
                // GOD KILLER EPIC ANIMATION!!!
                PlayGodKillerAnimation();
            }
            else if (card.Damage > 50 || card.healAmount > 40)
            {
                // ANY HIGH-POWER CARD GETS EPIC ANIMATION!
                PlayEpicCardAnimation(card.Name);
            }
            
            // ROLL FOR CRITICAL HIT BECAUSE RNG IS MORE FUN THAN SKILL
            bool criticalHit = new Random().Next(10) == 0; // 10% chance
            
            // MULTIPLY DAMAGE IF CRITICAL
            int actualDamage = criticalHit ? card.Damage * 2 : card.Damage;
            
            // CHECK FOR SPECIAL CONDITIONAL EFFECTS THAT MAKE CARDS UNPREDICTABLE
            // 1. BERSERKER CARDS DO MORE DAMAGE WHEN PLAYER IS ALMOST DEAD
            if (card.Name.ToLower().Contains("berserker") || card.Name.ToLower().Contains("rage") || 
                card.Name.ToLower().Contains("anger") || card.Name.ToLower().Contains("fury"))
            {
                // Calculate percentage of missing health (0-100)
                int missingHealthPercent = 100 - (int)((float)player.HP / player.maxHP * 100);
                
                // Bonus damage based on missing health (up to +200% damage at 1 HP)
                int berserkerBonus = (int)(actualDamage * (missingHealthPercent / 50.0f));
                
                // Apply bonus if significant
                if (berserkerBonus > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"⚡ BERSERKER RAGE! Your low health fuels your attack with {berserkerBonus} bonus damage!");
                    Console.ResetColor();
                    actualDamage += berserkerBonus;
                }
            }
            
            // 2. DESPERATION HEAL CARDS HEAL MORE WHEN PLAYER IS ALMOST DEAD
            if (card.healAmount > 0 && (card.Name.ToLower().Contains("desperate") || 
                card.Name.ToLower().Contains("emergency") || card.Name.ToLower().Contains("last")))
            {
                // Calculate percentage of missing health (0-100)
                int missingHealthPercent = 100 - (int)((float)player.HP / player.maxHP * 100);
                
                // Bonus healing when health is low (up to +100% at 1 HP)
                int desperationBonus = (int)(card.healAmount * (missingHealthPercent / 100.0f));
                
                // Apply bonus if significant
                if (desperationBonus > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"💉 DESPERATION HEAL! Your critical condition enhances healing by {desperationBonus}!");
                    Console.ResetColor();
                    card.healAmount += desperationBonus;
                }
            }
            
            // 3. RICH CARDS DO MORE DAMAGE IF PLAYER HAS LOTS OF GOLD
            if (card.Name.ToLower().Contains("gold") || card.Name.ToLower().Contains("rich") || 
                card.Name.ToLower().Contains("wealth") || card.Name.ToLower().Contains("money"))
            {
                // Calculate gold bonus (5% of gold as bonus damage)
                int richBonus = player.gold / 20;
                
                // Apply bonus if significant
                if (richBonus > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"💰 WEALTH POWER! Your {player.gold} gold empowers your attack with {richBonus} bonus damage!");
                    Console.ResetColor();
                    actualDamage += richBonus;
                }
            }
            
            // 4. REVENGE CARDS DO MORE DAMAGE BASED ON MONSTERS SLAIN
            if (card.Name.ToLower().Contains("revenge") || card.Name.ToLower().Contains("vengeance") || 
                card.Name.ToLower().Contains("retribution"))
            {
                // Bonus damage based on monsters slain (2 damage per monster)
                int revengeBonus = player.MoNsTeRsSlAiN * 2;
                
                // Cap the bonus at 100 extra damage to prevent one-shots
                revengeBonus = Math.Min(revengeBonus, 100);
                
                // Apply bonus if significant
                if (revengeBonus > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"👻 SOULS OF THE SLAIN! The {player.MoNsTeRsSlAiN} monsters you've defeated add {revengeBonus} vengeance damage!");
                    Console.ResetColor();
                    actualDamage += revengeBonus;
                }
            }
            
            // 5. GAMBLING CARDS HAVE A CHANCE TO BE AMAZING OR TERRIBLE
            if (card.Name.ToLower().Contains("gamble") || card.Name.ToLower().Contains("luck") || 
                card.Name.ToLower().Contains("random") || card.Name.ToLower().Contains("chance"))
            {
                // Roll the dice (1-100)
                int gambleDice = new Random().Next(1, 101);
                
                if (gambleDice <= 10) // 10% chance to miss completely
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("🎲 TERRIBLE LUCK! Your gamble fails completely - NO DAMAGE!");
                    Console.ResetColor();
                    actualDamage = 0;
                }
                else if (gambleDice >= 90) // 10% chance to hit SUPER CRITICAL
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("🎲 JACKPOT! Your gamble pays off with a SUPER CRITICAL HIT - TRIPLE DAMAGE!");
                    Console.ResetColor();
                    actualDamage *= 3;
                }
                else
                {
                    Console.WriteLine("🎲 You take a gamble... average luck today.");
                }
            }
            
            // 6. COMBO CARDS GAIN POWER FROM THE PLAYER'S RAGE COUNTER
            if (card.Name.ToLower().Contains("combo") || card.Name.ToLower().Contains("chain") || 
                card.Name.ToLower().Contains("sequential"))
            {
                int comboBonus = player.rageCounter * 3;
                
                // Apply bonus if significant  
                if (comboBonus > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"⚡ COMBO x{player.rageCounter}! Your combo streak adds {comboBonus} bonus damage!");
                    Console.ResetColor();
                    actualDamage += comboBonus;
                    
                    // Reset combo counter on use
                    player.rageCounter = 0;
                }
            }
            
            // DAMAGE THE ENEMY
            enemyHP -= actualDamage;
            Console.WriteLine($"Enemy takes {actualDamage} damage! {(criticalHit ? "CRITICAL HIT!" : "")} Enemy HP: {Math.Max(0, enemyHP)}");
            
            // APPLY HEAL EFFECT
            if (card.healAmount > 0)
            {
                player.HP += card.healAmount;
                if (player.HP > player.maxHP) player.HP = player.maxHP;
                Console.WriteLine($"You heal for {card.healAmount}! Your HP: {player.HP}");
            }
            
            // RECORD IF THIS CARD SHOULD BE DISCARDED
            if (isGodKillerCard)
            {
                player.lastUsedGodKillerCard = card.Name;
            }
            
            // APPLY SPECIAL EFFECTS SOMETIMES
            if (new Random().Next(4) == 0) // 25% chance
            {
                switch (card.Effect)
                {
                    case CardEffect.BURN:
                        int burnDamage = new Random().Next(1, 5);
                        enemyHP -= burnDamage;
                        Console.WriteLine($"BURN EFFECT: Enemy takes {burnDamage} extra damage from FLAMES!");
                        break;
                    case CardEffect.poison:
                        int poisonDamage = new Random().Next(1, 3);
                        enemyHP -= poisonDamage;
                        Console.WriteLine($"poison effect: enemy takes {poisonDamage} POISON damage... it's not very effective...");
                        break;
                    case CardEffect.heal:
                        int extraHeal = new Random().Next(1, 10);
                        player.HP += extraHeal;
                        if (player.HP > player.maxHP) player.HP = player.maxHP;
                        Console.WriteLine($"BONUS HEAL: You recover {extraHeal} more HP!");
                        break;
                    case CardEffect.BLOCK:
                        Console.WriteLine("BLOCK EFFECT: You will take less damage next enemy attack!");
                        // BUT WE DON'T ACTUALLY IMPLEMENT THIS LOL
                        break;
                    case CardEffect.DOUBLE:
                        // BROKEN EFFECT THAT RANDOMLY DOES DIFFERENT THINGS
                        if (new Random().Next(2) == 0)
                        {
                            enemyHP -= card.Damage; // DOUBLE DAMAGE
                            Console.WriteLine($"DOUBLE EFFECT: Enemy takes {card.Damage} EXTRA DAMAGE!");
                        }
                        else
                        {
                            player.gold += new Random().Next(1, 10);
                            Console.WriteLine($"DOUBLE EFFECT: Wait what? You found some gold somehow!");
                        }
                        break;
                }
            }
            
            // 1% CHANCE FOR SOMETHING COMPLETELY WILD TO HAPPEN
            if (new Random().Next(100) == 0)
            {
                Console.WriteLine("\n🌈🌈🌈 CHAOS CARD EVENT! 🌈🌈🌈");
                int chaosEffect = new Random().Next(5);
                
                switch (chaosEffect)
                {
                    case 0:
                        enemyHP = 1;
                        Console.WriteLine("The enemy is suddenly on the brink of death! HP SET TO 1!");
                        break;
                    case 1:
                        player.HP = player.maxHP;
                        Console.WriteLine("You are fully healed by CHAOS ENERGY!");
                        break;
                    case 2:
                        player.gold += 50;
                        Console.WriteLine("GOLD COINS RAIN FROM THE SKY! +50 GOLD!");
                        break;
                    case 3:
                        player.maxHP += 10;
                        player.HP += 10;
                        Console.WriteLine("YOUR MAXIMUM HP INCREASES BY 10!");
                        break;
                    case 4:
                        Console.WriteLine("THE UNIVERSE GLITCHES AND NOTHING HAPPENS!");
                        break;
                }
            }
        }
        
        // 🌈🌈🌈 SUPER CHAOTIC UwU BEAM ANIMATION 🌈🌈🌈
        private static void PlayUwuBeamAnimation()
        {
            Console.Clear(); // START WITH A BLANK SLATE FOR MAXIMUM CHAOS
            
            // SAVE ORIGINAL COLORS
            ConsoleColor originalFG = Console.ForegroundColor;
            ConsoleColor originalBG = Console.BackgroundColor;
            
            // DRAMATIC COUNTDOWN
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\n\n\n\n\n\n\n\n                    CHARGING UwU BEAM IN {i}...");
                Thread.Sleep(333);
            }
            
            // BUILDUP ANIMATION
            string[] uwuFaces = { "UwU", "OwO", "^w^", ">w<", "°w°" };
            
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)(i % 15 + 1); // CYCLE THROUGH COLORS
                Console.BackgroundColor = (ConsoleColor)((i + 8) % 15 + 1); // MORE COLOR CYCLING
                
                // DRAW A RANDOM UWU FACE THAT GETS BIGGER
                string face = uwuFaces[new Random().Next(uwuFaces.Length)];
                Console.WriteLine("\n\n");
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine($"{new string(' ', 20 - i)}{new string(face[0], i*2)}{face.Substring(1)}{new string(face[face.Length-1], i*2)}");
                }
                
                Thread.Sleep(100);
            }
            
            // EXPLOSIVE FINALE
            Console.Clear();
            
            // DRAW THE BIG UWU BEAM TEXT
            string[] uwuBeamArt = {
                @"  __  ___      ___  __  __     ____  _____  _____  __  __  __ ",
                @" / / / \ \    / / |/ / / /    / __ )/ ___/ / ___/ / / / / / / ",
                @"/ / /   \ \  / /|   / / /    / __  / __/  / __/  / / / / / /  ",
                @"\ \ \    \ \/ //   | / /___ / /_/ / /___ / /___ / /_/ /_/ /   ",
                @" \_\_\    \__//_/|_|/_____//_____/_____//_____//_(_)_(_)_/    "
            };
            
            for (int i = 0; i < 15; i++) // RAPID FLASHING COLORS
            {
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)(new Random().Next(15) + 1);
                Console.BackgroundColor = (ConsoleColor)(new Random().Next(15) + 1);
                
                Console.WriteLine("\n\n\n");
                foreach (string line in uwuBeamArt)
                {
                    Console.WriteLine(line);
                }
                
                // ADD RANDOM BEAM EFFECTS
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine($"{new string(' ', new Random().Next(20))}{'~'}{new string('=', new Random().Next(30, 60))}{'~'}{new string('>', new Random().Next(5, 15))}");
                }
                
                Thread.Sleep(100);
            }
            
            // EXPLOSION FINALE
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine(@"      ____    ____    ____    ____    _  _   _  _      _  _   _ ");
            Console.WriteLine(@"     | __ )  / __ \  / __ \  |  _ \  | || | | || |    | || | | |");
            Console.WriteLine(@"     |  _ \ / / _` |/ / _` | | |_) | | || |_| || |_   | || |_| |");
            Console.WriteLine(@"     | |_) | | (_| | | (_| | |  _ <  |__   _|__   _|  |__   _|_|");
            Console.WriteLine(@"     |____/ \ \__,_|\ \__,_| |_| \_\    |_|    |_|       |_| (_)");
            Console.WriteLine(@"             \____/  \____/                                     ");
            Thread.Sleep(1000);
            
            // RESTORE CONSOLE
            Console.Clear();
            Console.ForegroundColor = originalFG;
            Console.BackgroundColor = originalBG;
            
            // DISPLAY BATTLE INFORMATION AGAIN
            Console.WriteLine("\n== UwU BEAM AFTERMATH ==");
        }
        
        // 💥💥💥 EPIC GOD KILLER ANIMATION 💥💥💥
        private static void PlayGodKillerAnimation()
        {
            // SAVE ORIGINAL COLORS
            ConsoleColor originalFG = Console.ForegroundColor;
            ConsoleColor originalBG = Console.BackgroundColor;
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            
            // DRAMATIC TEXT
            string[] deathMessages = {
                "THE GODS TREMBLE...",
                "HEAVEN ITSELF SHAKES...",
                "REALITY TEARS APART...",
                "A GOD CRIES OUT IN PAIN...",
                "TIME FREEZES FOR AN INSTANT..."
            };
            
            foreach (string msg in deathMessages)
            {
                Console.Clear();
                Console.WriteLine($"\n\n\n\n\n\n\n\n{new string(' ', 25)}{msg}");
                Thread.Sleep(700);
            }
            
            // GOD KILLER ANIMATION
            Console.Clear();
            
            // DISPLAY THE FINAL BLOW
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"      ╔═════════════════════════════════════════════════╗");
            Console.WriteLine(@"      ║                                                 ║");
            Console.WriteLine(@"      ║       G0D K1LL3R PR0T0C0L 4CT1V4T3D            ║");
            Console.WriteLine(@"      ║                                                 ║");
            Console.WriteLine(@"      ╚═════════════════════════════════════════════════╝");
            Thread.Sleep(1000);
            
            // SIMULATE A SYSTEM CRASH
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                
                if (i % 2 == 0)
                {
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine(@"      ███████╗ █████╗ ████████╗ █████╗ ██╗         ");
                    Console.WriteLine(@"      ██╔════╝██╔══██╗╚══██╔══╝██╔══██╗██║         ");
                    Console.WriteLine(@"      █████╗  ███████║   ██║   ███████║██║         ");
                    Console.WriteLine(@"      ██╔══╝  ██╔══██║   ██║   ██╔══██║██║         ");
                    Console.WriteLine(@"      ██║     ██║  ██║   ██║   ██║  ██║███████╗    ");
                    Console.WriteLine(@"      ╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝    ");
                    Console.WriteLine(@"      ███████╗████████╗██████╗ ██╗██╗  ██╗███████╗ ");
                    Console.WriteLine(@"      ██╔════╝╚══██╔══╝██╔══██╗██║██║ ██╔╝██╔════╝ ");
                    Console.WriteLine(@"      ███████╗   ██║   ██████╔╝██║█████╔╝ █████╗   ");
                    Console.WriteLine(@"      ╚════██║   ██║   ██╔══██╗██║██╔═██╗ ██╔══╝   ");
                    Console.WriteLine(@"      ███████║   ██║   ██║  ██║██║██║  ██╗███████╗ ");
                    Console.WriteLine(@"      ╚══════╝   ╚═╝   ╚═╝╚═╝╚═╝  ╚═╝╚══════╝ ");
                }
                
                Thread.Sleep(200);
            }
            
            // RESTORE CONSOLE
            Console.Clear();
            Console.ForegroundColor = originalFG;
            Console.BackgroundColor = originalBG;
            
            // DISPLAY BATTLE INFORMATION AGAIN
            Console.WriteLine("\n== DIVINE EXECUTION COMPLETE ==");
        }
        
        // 🌟🌟🌟 GENERIC EPIC CARD ANIMATION 🌟🌟🌟
        private static void PlayEpicCardAnimation(string cardName)
        {
            // SAVE ORIGINAL COLORS
            ConsoleColor originalFG = Console.ForegroundColor;
            ConsoleColor originalBG = Console.BackgroundColor;
            
            // CREATE EMPHASIZED VERSION OF CARD NAME WITH RANDOM CHARACTERS
            string emphasizedName = "";
            foreach (char c in cardName)
            {
                // 50% CHANCE TO REPLACE WITH L33T SPEAK
                if (new Random().Next(2) == 0)
                {
                    switch (char.ToLower(c))
                    {
                        case 'a': emphasizedName += "4"; break;
                        case 'e': emphasizedName += "3"; break;
                        case 'i': emphasizedName += "1"; break;
                        case 'o': emphasizedName += "0"; break;
                        case 's': emphasizedName += "$"; break;
                        case 't': emphasizedName += "7"; break;
                        default: emphasizedName += char.ToUpper(c); break;
                    }
                }
                else
                {
                    emphasizedName += (char.IsLetter(c) && new Random().Next(2) == 0) ? char.ToUpper(c) : c;
                }
            }
            
            // DISPLAY WITH RANDOM BORDERS
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)(new Random().Next(14) + 1);
                
                char borderChar = "!@#$%^&*=+".ToCharArray()[new Random().Next(10)];
                string border = new string(borderChar, emphasizedName.Length + 8);
                
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"{new string(' ', 20)}{border}");
                Console.WriteLine($"{new string(' ', 20)}{borderChar}   {emphasizedName}   {borderChar}");
                Console.WriteLine($"{new string(' ', 20)}{border}");
                
                Thread.Sleep(200);
            }
            
            // RESTORE CONSOLE
            Console.ForegroundColor = originalFG;
            Console.BackgroundColor = originalBG;
        }
        
        // 🧪🧪🧪 TEST ANIMATIONS DIRECTLY FOR DEBUG PURPOSES 🧪🧪🧪
        public static void TestAnimation(string animationType)
        {
            switch (animationType.ToLower())
            {
                case "uwu":
                case "beam":
                case "uwubeam":
                    PlayUwuBeamAnimation();
                    break;
                
                case "god":
                case "killer":
                case "godkiller":
                    PlayGodKillerAnimation();
                    break;
                
                case "epic":
                case "powerful":
                    PlayEpicCardAnimation("TEST-EPIC-CARD");
                    break;
                
                default:
                    Console.WriteLine("Unknown animation type!");
                    break;
            }
        }
    }
} 