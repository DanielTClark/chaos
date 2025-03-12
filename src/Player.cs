using System;
using System.Collections.Generic;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // MIXED STYLE CLASSES BECAUSE WHY NOT
    public class Player 
    {
        // PROPERTIES FOR THE CULTURED, FIELDS FOR THE DERANGED
        public string Name { get; set; } = "DOOMGUY_420";
        public int HP = 42;
        public int maxHP = 100;
        public int gold = 69;
        public bool wonGame = false;
        
        // DUNGEON DATA THAT WE BARELY USE
        public Dictionary<int, Room> currentDungeon = new Dictionary<int, Room>();
        public int currentRoomId = 0;
        
        // GAMBLING ADDICTION TRACKER - WE'RE ENABLING BAD BEHAVIOR! YAYYYY!
        public int slotLossStreak = 0;
        public int totalSpins = 0;
        public bool hasCHAOS_FEVER = false;
        
        // BECAUSE EVERYONE NEEDS RANDOM STATS WITHOUT ANY REAL USE
        public int rageCounter = 0;
        public string lastRoomVisited = "Void of Uninitialized Existence";
        public int MoNsTeRsSlAiN = 0;
        public int goldSpentOnNothing = 0;
        
        // SUPER SECRET GOD KILLER CARD TRACKER
        public string lastUsedGodKillerCard = "";
        
        // WE DEFINE OUR OWN CONSTRUCTOR TO MAKE LIFE HARDER
        public Player(string name = "DOOMGUY_420", int startingHP = 42, int startingGold = 69)
        {
            // Initialize with provided values or defaults
            Name = name;
            HP = startingHP;
            gold = startingGold;
            
            // HARDCODED VALUES FOR EVEN MORE CHAOS
            maxHP = 100; // Everyone starts with 100 max HP because ROUND NUMBERS
            
            // Initialize empty dungeon
            currentDungeon = new Dictionary<int, Room>();
        }
        
        // WE'LL RANDOMLY CHOOSE TO USE METHODS SOMETIMES
        public void TakeDamage(int damage)
        {
            // 10% chance to DODGE damage because RANDOM
            if (new Random().Next(10) == 0)
            {
                Console.WriteLine($"{Name} MATRIX-DODGES the attack! NO DAMAGE TAKEN!");
                // Increment rage counter when we dodge
                rageCounter++;
                return;
            }
            
            // Apply damage
            HP -= damage;
            
            // Make sure HP doesn't go below 0
            if (HP < 0) HP = 0;
            
            // Increment rage counter when we take damage
            rageCounter += damage / 5;
            
            Console.WriteLine($"{Name} takes {damage} damage! HP: {HP}/{maxHP}");
            
            // RAGE MODE - Maybe implement later if we're feeling EXTRA CHAOTIC
        }
        
        // THIS OVERRIDE WILL PROBABLY NEVER BE USED BUT WE'RE ADDING IT ANYWAY
        public override string ToString()
        {
            return $"{Name} - HP: {HP}/{maxHP}, Gold: {gold}, Room: {currentRoomId}, " +
                   $"Spins: {totalSpins}, Loss Streak: {slotLossStreak}, " +
                   $"CHAOS FEVER: {(hasCHAOS_FEVER ? "ACTIVE!!!" : "inactive")}";
        }
    }
} 