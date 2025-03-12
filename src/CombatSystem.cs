using System;
using System.Collections.Generic;
using System.Threading;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // ENEMY DATA CLASS - SOME PROPERTIES, SOME FIELDS, MAXIMUM CONFUSION
    public class Enemy
    {
        public string NAME;  // ALL CAPS FOR NO REASON
        public int hp { get; private set; } // lowercase property because CHAOS
        private readonly int BASE_DMG; // PRIVATE CONSTANTS IN ALL CAPS
        public readonly string TAUNT; // PUBLIC BUT STILL ALL CAPS
        
        // LIST OF ENEMY TAUNTS FOR MAXIMUM CRINGE
        private static readonly string[] ENEMY_TAUNTS = {
            "I'LL CRUSH YOU LIKE A BUG!",
            "ur mom",
            "PREPARE TO DIE, MORTAL!",
            "*awkwardly stands there menacingly*",
            "can we just be friends?",
            "I HAVE COME TO BARGAIN",
            "YEET OR BE YEETED",
            "uwu *notices your health bar*",
            "GIT GUD SCRUB"
        };
        
        // CONSTRUCTOR WITH RANDOM TAUNTS
        public Enemy(string name, int health, int damage)
        {
            NAME = name;
            hp = health;
            BASE_DMG = damage;
            
            // RANDOM TAUNT
            TAUNT = ENEMY_TAUNTS[new Random().Next(ENEMY_TAUNTS.Length)];
        }
        
        // CAUSE DAMAGE WITH RANDOM VARIATION
        public int Attack()
        {
            // DAMAGE VARIES BY +/- 2
            int dmgVariation = new Random().Next(-2, 3);
            return Math.Max(1, BASE_DMG + dmgVariation); // never less than 1
        }
        
        // TAKE DAMAGE AND RETURN IF ENEMY DIED
        public bool TakeDamage(int amount)
        {
            hp -= amount;
            return hp <= 0;
        }
    }
    
    // SEPARATE STATIC CLASS FOR ENEMIES BECAUSE WE DON'T BELIEVE IN ORGANIZATION
    public static class EnemyGenerator
    {
        // WILDLY INCONSISTENT NAMING FOR THE WIN
        private static readonly string[] ENEMY_NAMES = {
            "SKELETOR",          // ALL CAPS
            "slime_boi",         // snake_case
            "DRAGON-LORD",       // CAPS WITH HYPHEN
            "annoying telemarketer", // lowercase with spaces
            "JEFF",              // PROPER NOUN ALL CAPS
            "k@r3n-FROM-HR",     // MIXED SYMBOLS WHY NOT
            "UwU-Face",          // Mixed case with symbols
            "xX_DarkLord420_Xx", // GAMER TAG
            "steve",             // just lowercase
            "MR. WHISKERS"       // CAPS WITH PUNCTUATION
        };
        
        // GENERATE A RANDOM ENEMY WITH WILDLY VARYING STATS
        public static Enemy GenerateRandomEnemy()
        {
            var rand = new Random();
            string enemyName = ENEMY_NAMES[rand.Next(ENEMY_NAMES.Length)];
            
            // HP BETWEEN 10-30
            int hp = rand.Next(10, 31);
            
            // DAMAGE BETWEEN 3-8
            int damage = rand.Next(3, 9);
            
            // 10% CHANCE OF SUPER ENEMY
            if (rand.Next(10) == 0)
            {
                hp *= 2;
                damage += 3;
                enemyName = "ELITE " + enemyName;
            }
            
            return new Enemy(enemyName, hp, damage);
        }
    }
    
    // COMBAT SYSTEM WITH THE MOST CHAOTIC BATTLE LOGIC EVER
    public static class CombatSystem
    {
        // RUN A COMBAT ENCOUNTER WHEN ENTERING A ROOM
        public static void CombatEncounter(Player HERO, List<Card> deck)
        {
            // GENERATE RANDOM ENEMY
            var enemy = EnemyGenerator.GenerateRandomEnemy();
            
            Console.WriteLine($"\nA WILD {enemy.NAME} APPEARS! HP: {enemy.hp}");
            Console.WriteLine($"Enemy: \"{enemy.TAUNT}\"");
            
            // BATTLE LOOP
            while (enemy.hp > 0 && HERO.HP > 0)
            {
                // PLAYER'S TURN - CHOOSE CARDS
                Console.WriteLine("\nYour turn! Choose a card:");
                
                // CREATE A TEMPORARY HAND OF 3 RANDOM CARDS FROM DECK
                List<Card> hand = new List<Card>();
                List<int> usedIndices = new List<int>();
                
                // GET 3 RANDOM CARDS FROM DECK (OR FEWER IF DECK IS SMALLER)
                for (int i = 0; i < Math.Min(3, deck.Count); i++)
                {
                    int cardIndex;
                    do
                    {
                        cardIndex = new Random().Next(deck.Count);
                    } while (usedIndices.Contains(cardIndex));
                    
                    usedIndices.Add(cardIndex);
                    hand.Add(deck[cardIndex]);
                }
                
                // DISPLAY CARD OPTIONS
                for (int i = 0; i < hand.Count; i++)
                {
                    Console.WriteLine($"{i+1}) {hand[i].Name} - DMG: {hand[i].Damage}, HEAL: {hand[i].healAmount}");
                }
                
                // GET PLAYER CHOICE
                int cardChoice = -1;
                while (cardChoice < 0 || cardChoice >= hand.Count)
                {
                    Console.Write("Choose card (number): ");
                    if (!int.TryParse(Console.ReadLine(), out cardChoice)) cardChoice = -1;
                    cardChoice -= 1; // Convert to 0-based
                }
                
                // GET THE CHOSEN CARD AND USE IT
                Card chosenCard = hand[cardChoice];
                
                // FIND THE CARD IN THE DECK AND REMOVE IT
                int deckIndex = deck.FindIndex(c => c.Name == chosenCard.Name);
                if (deckIndex >= 0)
                {
                    deck.RemoveAt(deckIndex);
                    // SHUFFLE THE CARD BACK INTO THE DECK AT A RANDOM POSITION
                    int newPosition = new Random().Next(deck.Count + 1);
                    deck.Insert(newPosition, chosenCard);
                }
                
                // USE THE CARD ON THE ENEMY
                int enemyHP = enemy.hp; // Get enemy HP
                CardManager.UseCard(chosenCard, ref enemyHP, ref HERO);
                
                // UPDATE ENEMY HP
                if (enemyHP <= 0)
                {
                    // ENEMY DEFEATED
                    break;
                }
                else
                {
                    enemy.TakeDamage(enemy.hp - enemyHP); // Apply damage to enemy
                }
                
                // ENEMY TURN - ATTACK PLAYER
                if (enemy.hp > 0)
                {
                    int enemyDamage = enemy.Attack();
                    Console.WriteLine($"\n{enemy.NAME} ATTACKS YOU FOR {enemyDamage} DAMAGE!");
                    
                    // USE THE PLAYER'S TAKE DAMAGE METHOD
                    HERO.TakeDamage(enemyDamage);
                }
            }
            
            // BATTLE RESULTS
            if (enemy.hp <= 0)
            {
                HERO.MoNsTeRsSlAiN++; // INCREMENT KILL COUNTER
                
                // CALCULATE REWARDS
                int goldReward = new Random().Next(5, 15);
                Console.WriteLine($"\nVICTORY! {enemy.NAME} is defeated!");
                Console.WriteLine($"You gain {goldReward} gold!");
                HERO.gold += goldReward;
                
                // CHECK IF A GOD KILLER CARD WAS USED - IF SO, DISCARD IT
                if (!string.IsNullOrEmpty(HERO.lastUsedGodKillerCard))
                {
                    // FIND AND REMOVE THE CARD
                    for (int i = deck.Count - 1; i >= 0; i--)
                    {
                        if (deck[i].Name == HERO.lastUsedGodKillerCard)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"\n🔥 YOUR {deck[i].Name} CARD CRUMBLES TO ASH... 🔥");
                            Console.WriteLine("THE GODS ONLY GRANT THEIR POWER ONCE!");
                            Console.ResetColor();
                            Thread.Sleep(1200);
                            
                            // REMOVE THE CARD
                            deck.RemoveAt(i);
                            
                            // RESET THE TRACKER
                            HERO.lastUsedGodKillerCard = "";
                            
                            break;
                        }
                    }
                }
                
                // 25% CHANCE TO FIND A NEW CARD
                if (new Random().Next(100) < 25)
                {
                    Card newCard = CardManager.GenerateRandomCard();
                    deck.Add(newCard);
                    Console.WriteLine($"\nYOU FOUND A NEW CARD: {newCard.Name}!");
                }
            }
        }
        
        // TREASURE ROOM FUNCTION
        public static void TreasureRoom(Player HERO)
        {
            Console.WriteLine("\nYOU FOUND A TREASURE CHEST!");
            
            // CREATE SUSPENSE
            Console.Write("Opening");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
            
            // DETERMINE THE TYPE OF TREASURE
            int treasureType = new Random().Next(100);
            
            if (treasureType < 60) // 60% CHANCE OF GOLD
            {
                int goldFound = new Random().Next(10, 30);
                HERO.gold += goldFound;
                Console.WriteLine($"You gained {goldFound} gold!");
            }
            else if (treasureType < 80) // 20% CHANCE OF HEALING
            {
                int healAmount = HERO.maxHP / 4;
                HERO.HP = Math.Min(HERO.maxHP, HERO.HP + healAmount);
                Console.WriteLine($"You found a health potion! Healed for {healAmount} HP!");
            }
            else if (treasureType < 95) // 15% CHANCE OF MAX HP INCREASE
            {
                HERO.maxHP += 5;
                HERO.HP += 5;
                Console.WriteLine("THE GODS FAVOR YOU! Max HP increased by 5!");
            }
            else // 5% CHANCE OF TRAP
            {
                int trapDamage = new Random().Next(5, 15);
                Console.WriteLine($"IT'S A TRAP! The chest EXPLODES for {trapDamage} damage!");
                HERO.TakeDamage(trapDamage);
            }
        }

        // 🧪 SPECIAL DEBUG VERSION FOR TESTING CARD ANIMATIONS 🧪
        public static void StartDebugCombat(Player HERO, List<Card> deck)
        {
            // CREATE A SUPER WEAK DEBUG ENEMY
            Enemy debugEnemy = new Enemy("DEBUG_DUMMY", 1000, 1);
            
            Console.WriteLine($"\nA WEAK {debugEnemy.NAME} APPEARS! HP: {debugEnemy.hp}");
            Console.WriteLine($"Enemy: \"{debugEnemy.TAUNT}\"");
            
            // MAKE SURE THE TEST CARD IS IN THE FIRST 3 CARDS
            // BY TEMPORARILY MAKING A COPY OF IT AT THE START OF THE DECK
            bool foundTestCard = false;
            Card testCard = new Card(); // Default card
            foreach (var card in deck)
            {
                if (card.Name.ToLower().Contains("test") || 
                    card.Name.ToLower().Contains("uwu") || 
                    card.Name.ToLower().Contains("god") || 
                    card.Name.ToLower().Contains("g0d") ||
                    card.Damage > 50)
                {
                    testCard = card;
                    foundTestCard = true;
                    break;
                }
            }
            
            List<Card> debugHand = new List<Card>();
            // ADD THE TEST CARD FIRST IF FOUND
            if (foundTestCard)
            {
                debugHand.Add(testCard);
                // ADD TWO RANDOM OTHER CARDS
                List<int> usedIndices = new List<int>();
                for (int i = 0; i < 2; i++)
                {
                    int cardIndex;
                    do
                    {
                        cardIndex = new Random().Next(deck.Count);
                    } while (usedIndices.Contains(cardIndex) || deck[cardIndex].Name == testCard.Name);
                    
                    usedIndices.Add(cardIndex);
                    debugHand.Add(deck[cardIndex]);
                }
            }
            else
            {
                // NO TEST CARD FOUND, JUST PICK 3 RANDOM CARDS
                List<int> usedIndices = new List<int>();
                for (int i = 0; i < 3; i++)
                {
                    int cardIndex;
                    do
                    {
                        cardIndex = new Random().Next(deck.Count);
                    } while (usedIndices.Contains(cardIndex));
                    
                    usedIndices.Add(cardIndex);
                    debugHand.Add(deck[cardIndex]);
                }
            }
            
            // DISPLAY CARD OPTIONS WITH THE TEST CARD FIRST
            Console.WriteLine("\nYour turn! Choose a card:");
            for (int i = 0; i < debugHand.Count; i++)
            {
                if (i == 0 && foundTestCard)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{i+1}) {debugHand[i].Name} - DMG: {debugHand[i].Damage}, HEAL: {debugHand[i].healAmount} [TEST CARD]");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i+1}) {debugHand[i].Name} - DMG: {debugHand[i].Damage}, HEAL: {debugHand[i].healAmount}");
                }
            }
            
            // GET PLAYER CHOICE
            int cardChoice = -1;
            while (cardChoice < 0 || cardChoice >= debugHand.Count)
            {
                Console.Write("Choose card (number): ");
                if (!int.TryParse(Console.ReadLine(), out cardChoice)) cardChoice = -1;
                cardChoice -= 1; // Convert to 0-based
            }
            
            // GET THE CHOSEN CARD AND USE IT
            Card chosenCard = debugHand[cardChoice];
            
            // USE THE CARD ON THE ENEMY
            int enemyHP = debugEnemy.hp; // Get enemy HP
            CardManager.UseCard(chosenCard, ref enemyHP, ref HERO);
            
            // CHECK IF A GOD KILLER CARD WAS USED - IF SO, DISCARD IT
            if (!string.IsNullOrEmpty(HERO.lastUsedGodKillerCard))
            {
                // FIND AND REMOVE THE CARD
                for (int i = deck.Count - 1; i >= 0; i--)
                {
                    if (deck[i].Name == HERO.lastUsedGodKillerCard)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\n🔥 YOUR {deck[i].Name} CARD CRUMBLES TO ASH... 🔥");
                        Console.WriteLine("THE GODS ONLY GRANT THEIR POWER ONCE!");
                        Console.ResetColor();
                        Thread.Sleep(1200);
                        
                        // REMOVE THE CARD
                        deck.RemoveAt(i);
                        
                        // RESET THE TRACKER
                        HERO.lastUsedGodKillerCard = "";
                        
                        break;
                    }
                }
            }
            
            // SIMPLE ENDING
            Console.WriteLine("\n== DEBUG COMBAT TEST COMPLETE ==");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
} 