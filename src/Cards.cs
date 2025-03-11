using System;
using System.Collections.Generic;
using System.Linq;

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
            "cardboard_tube"
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
            
            // ROLL FOR CRITICAL HIT BECAUSE RNG IS MORE FUN THAN SKILL
            bool criticalHit = new Random().Next(10) == 0; // 10% chance
            
            // MULTIPLY DAMAGE IF CRITICAL
            int actualDamage = criticalHit ? card.Damage * 2 : card.Damage;
            
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
    }
} 