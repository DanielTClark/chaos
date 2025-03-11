using System;
using System.Collections.Generic;
using System.Threading;

namespace CHaoTIC_sLoT_DuNgEoN
{
    // ☢️☢️☢️ GAMBLING ADDICTION ENGINE ☢️☢️☢️
    public static class SlotMachine
    {
        // SLOT SYMBOLS ARRAY - EXTERRNAL FOR MAXIMUM UNPREDICTABILITY!
        private static readonly string[] SYMBOLS_OF_DOOM = { "💀", "💰", "❤️", "🗡️", "🛡️", "👽", "🌋", "🧨", "🔮", "🦄" };
        
        // COMPLETELY DIFFERENT RNG FOR EACH SPIN FOR MAXIMUM CHAOS
        private static Random GetFreshRandomizer() => new Random(Guid.NewGuid().GetHashCode() ^ DateTime.Now.Millisecond);
        
        // THE MAIN SLOT MACHINE FUNCTION THAT CAUSES SO MUCH SUFFERING
        public static void SpinTheSlots(Player HERO)
        {
            if (HERO.gold < 5)
            {
                Console.WriteLine("TOO POOR! You need 5 gold to spin the slots!");
                
                // PITY SYSTEM FOR THE TRULY DESPERATE
                if (HERO.slotLossStreak >= 10 && GetFreshRandomizer().Next(3) == 0)
                {
                    Console.WriteLine("...BUT THE MACHINE FEELS BAD FOR YOU AND GIVES YOU A FREE SPIN!");
                    Console.WriteLine("(The machine whispers: 'First one's free, kid')");
                }
                else
                {
                    return;
                }
            }
            else
            {
                HERO.gold -= 5;
            }
            
            // INCREMENT THE ADDICTION COUNTER - I MEAN "GAME MECHANICS"
            HERO.totalSpins++;
            
            // CHAOS FEVER MODE - HAPPENS RANDOMLY AFTER 20+ SPINS
            if (!HERO.hasCHAOS_FEVER && HERO.totalSpins >= 20 && GetFreshRandomizer().Next(10) == 0)
            {
                HERO.hasCHAOS_FEVER = true;
                Console.WriteLine("\n🔥🔥🔥 CHAOS FEVER MODE ACTIVATED! 🔥🔥🔥");
                Console.WriteLine("THE SLOT MACHINE BEGINS TO SHAKE VIOLENTLY AND GLOWS WITH OTHERWORLDLY POWER!");
                Thread.Sleep(1000);
            }
            
            Console.WriteLine("\nThe ancient slot machine rumbles to life! IT COSTS 5 GOLD.");
            
            // DISPLAY DIFFERENT MESSAGES BASED ON LOSS STREAK FOR THE PSYCHOLOGY OF ADDICTION
            if (HERO.slotLossStreak >= 15)
            {
                Console.WriteLine("The machine seems to be PITYING you with its cold mechanical eyes...");
            }
            else if (HERO.slotLossStreak >= 10)
            {
                Console.WriteLine("The machine makes a sad whimpering noise. It FEELS BAD for taking so much of your money!");
            }
            else if (HERO.slotLossStreak >= 5)
            {
                Console.WriteLine("The machine seems unusually EAGER to take your money!");
            }
            
            Console.WriteLine("Spinning...");
            
            // SUSPENSE BUILDING
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
            
            // GET THE SPIN RESULTS BASED ON PITY SYSTEM AND OTHER FACTORS
            string[] results = DetermineSlotResults(HERO);
            
            // DISPLAY THE RESULTS
            for (int i = 0; i < 3; i++)
            {
                Console.Write(results[i] + " ");
            }
            Console.WriteLine();
            
            // APPLY THE RESULTS TO THE PLAYER
            bool won = ApplySlotResults(HERO, results);
            
            // HANDLE POST-SPIN MECHANICS
            HandlePostSpinEffects(HERO, won);
        }
        
        // DETERMINE WHAT SYMBOLS WILL SHOW UP BASED ON PITY SYSTEM
        private static string[] DetermineSlotResults(Player HERO)
        {
            string[] results = new string[3];
            
            // PITY SYSTEM - THE MORE YOU LOSE, THE MORE THE MACHINE RIGS THINGS IN YOUR FAVOR
            // 100% JACKPOT if loss streak is 20+ (but only 20% chance to trigger)
            if (HERO.slotLossStreak >= 20 && GetFreshRandomizer().Next(5) == 0)
            {
                int jackpotType = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length); // Pick random jackpot type
                results[0] = results[1] = results[2] = SYMBOLS_OF_DOOM[jackpotType];
            }
            // 50% chance of two matches if loss streak is 10+
            else if (HERO.slotLossStreak >= 10 && GetFreshRandomizer().Next(2) == 0)
            {
                int matchSymbolIndex = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length);
                int nonMatchPosition = GetFreshRandomizer().Next(3);
                
                for (int i = 0; i < 3; i++)
                {
                    if (i == nonMatchPosition)
                    {
                        // Make sure this symbol is different
                        int differentSymbol;
                        do {
                            differentSymbol = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length);
                        } while (differentSymbol == matchSymbolIndex);
                        
                        results[i] = SYMBOLS_OF_DOOM[differentSymbol];
                    }
                    else
                    {
                        results[i] = SYMBOLS_OF_DOOM[matchSymbolIndex];
                    }
                }
            }
            // CHAOS FEVER gives higher chances overall
            else if (HERO.hasCHAOS_FEVER)
            {
                // In CHAOS FEVER mode, 40% chance of jackpot, 40% chance of two matches
                int feverRoll = GetFreshRandomizer().Next(10);
                
                if (feverRoll < 4) // 40% jackpot
                {
                    int jackpotType = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length);
                    results[0] = results[1] = results[2] = SYMBOLS_OF_DOOM[jackpotType];
                }
                else if (feverRoll < 8) // 40% two matches
                {
                    int matchSymbolIndex = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length);
                    int nonMatchPosition = GetFreshRandomizer().Next(3);
                    
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == nonMatchPosition)
                        {
                            int differentSymbol;
                            do {
                                differentSymbol = GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length);
                            } while (differentSymbol == matchSymbolIndex);
                            
                            results[i] = SYMBOLS_OF_DOOM[differentSymbol];
                        }
                        else
                        {
                            results[i] = SYMBOLS_OF_DOOM[matchSymbolIndex];
                        }
                    }
                }
                else // 20% truly random
                {
                    for (int i = 0; i < 3; i++)
                    {
                        results[i] = SYMBOLS_OF_DOOM[GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length)];
                    }
                }
            }
            else // NORMAL SPIN - COMPLETELY RANDOM
            {
                for (int i = 0; i < 3; i++)
                {
                    results[i] = SYMBOLS_OF_DOOM[GetFreshRandomizer().Next(SYMBOLS_OF_DOOM.Length)];
                }
            }
            
            return results;
        }
        
        // APPLY THE SLOT RESULTS TO THE PLAYER
        private static bool ApplySlotResults(Player HERO, string[] results)
        {
            bool won = false;
            
            if (results[0] == results[1] && results[1] == results[2])
            {
                // JACKPOT BABYYYYY
                won = true;
                
                // EXTRA CRAZY JACKPOT IN CHAOS FEVER MODE
                int chaosMultiplier = HERO.hasCHAOS_FEVER ? 3 : 1;
                
                if (results[0] == "💰")
                {
                    int jackpotGold = GetFreshRandomizer().Next(69, 420) * chaosMultiplier;
                    Console.WriteLine($"MEGA-ULTRA-JACKPOT! You got {jackpotGold} gold and the machine WEEPS TEARS OF CURRENCY!");
                    HERO.gold += jackpotGold;
                }
                else if (results[0] == "❤️")
                {
                    int hpBoostPercent = 25 * chaosMultiplier;
                    Console.WriteLine($"LOVE JACKPOT! Full health restore PLUS {hpBoostPercent}% MAX HP INCREASE!");
                    HERO.maxHP += (HERO.maxHP * hpBoostPercent / 100);
                    HERO.HP = HERO.maxHP;
                    Console.WriteLine($"YOUR MAX HP IS NOW {HERO.maxHP}! FEEL THE POWER!");
                }
                else if (results[0] == "💀")
                {
                    if (HERO.hasCHAOS_FEVER && GetFreshRandomizer().Next(2) == 0)
                    {
                        // In CHAOS FEVER, sometimes death is actually good!
                        Console.WriteLine("TRIPLE DEATH... BUT CHAOS FEVER REVERSES ITS EFFECT!");
                        Console.WriteLine("YOUR BRUSH WITH DEATH MAKES YOU STRONGER! +30 MAX HP AND FULL HEAL!");
                        HERO.maxHP += 30;
                        HERO.HP = HERO.maxHP;
                    }
                    else
                    {
                        int deathDamage = Math.Max(1, HERO.HP - 1); // Leave 1 HP remaining because we're "merciful"
                        Console.WriteLine($"TRIPLE DEATH! YOUR SOUL IS FORFEIT! LOSE {deathDamage} HP!");
                        HERO.HP = 1;
                        Console.WriteLine("THE VOID SPARES YOU WITH 1 HP REMAINING... THIS TIME.");
                    }
                }
                else if (results[0] == "🗡️")
                {
                    Console.WriteLine("WEAPON JACKPOT! You find the SWORD OF A THOUSAND TRUTHS!");
                    Thread.Sleep(1000);
                    
                    if (HERO.hasCHAOS_FEVER)
                    {
                        Console.WriteLine("In CHAOS FEVER mode, this weapon is ACTUALLY REAL!");
                        Console.WriteLine("You feel EMPOWERED! +50 Gold and +20 MAX HP!");
                        HERO.gold += 50 * chaosMultiplier;
                        HERO.maxHP += 20;
                        HERO.HP += 20;
                    }
                    else
                    {
                        Console.WriteLine("It deals 9999 damage! (but only to your HOPES and DREAMS because IT'S NOT REAL)");
                        Console.WriteLine("On the bright side, have 30 gold as consolation!");
                        HERO.gold += 30;
                    }
                }
                else if (results[0] == "🛡️")
                {
                    int hpBoost = GetFreshRandomizer().Next(20, 50);
                    Console.WriteLine($"TANK MODE ACTIVATED! Max HP increased by {hpBoost}!");
                    HERO.maxHP += hpBoost;
                    HERO.HP += hpBoost;
                }
                else if (results[0] == "👽")
                {
                    Console.WriteLine("ALIEN ABDUCTION! You're probed by extraterrestrials!");
                    Thread.Sleep(1000);
                    Console.WriteLine("They implant a WEIRD CHIP in your brain that randomly changes your stats!");
                    
                    // Randomize ALL THE STATS!!!
                    int hpChange = GetFreshRandomizer().Next(-10, 30);
                    int goldChange = GetFreshRandomizer().Next(-20, 100);
                    
                    HERO.HP = Math.Max(1, HERO.HP + hpChange);
                    HERO.gold = Math.Max(0, HERO.gold + goldChange);
                    
                    Console.WriteLine($"HP {(hpChange >= 0 ? "+" : "")}{hpChange}, GOLD {(goldChange >= 0 ? "+" : "")}{goldChange}");
                    Console.WriteLine("THE ALIENS DISAPPEAR, GIGGLING MANIACALLY!");
                }
                else if (results[0] == "🌋")
                {
                    Console.WriteLine("VOLCANO JACKPOT! THE FLOOR IS LITERALLY LAVA!");
                    Thread.Sleep(1000);
                    
                    // 50% chance of amazing reward, 50% chance of terrible punishment
                    if (GetFreshRandomizer().Next(2) == 0)
                    {
                        Console.WriteLine("You SURF the lava like a RADICAL DUDE and find 100 gold!");
                        HERO.gold += 100;
                    }
                    else
                    {
                        int lavaDamage = HERO.HP / 2;
                        Console.WriteLine($"THE LAVA BURNS! You lose {lavaDamage} HP but gain STREET CRED!");
                        HERO.HP -= lavaDamage;
                    }
                }
                else if (results[0] == "🧨")
                {
                    Console.WriteLine("BOOM! BOOM! BOOM! TRIPLE DYNAMITE JACKPOT!");
                    Thread.Sleep(1000);
                    
                    // Completely random outcome
                    int randomEffect = GetFreshRandomizer().Next(5);
                    switch (randomEffect)
                    {
                        case 0:
                            Console.WriteLine("You're blown to BITS but your gold MULTIPLIES x2!");
                            HERO.gold *= 2;
                            HERO.HP = Math.Max(1, HERO.HP / 2);
                            break;
                        case 1:
                            Console.WriteLine("The explosion reveals a SECRET PASSAGE!");
                            Console.WriteLine("You find 50 gold and a health potion (+25 HP)!");
                            HERO.gold += 50;
                            HERO.HP += 25;
                            break;
                        case 2:
                            Console.WriteLine("EVERYTHING EXPLODES! INCLUDING YOUR STATS!");
                            HERO.HP = GetFreshRandomizer().Next(1, HERO.maxHP);
                            HERO.gold = GetFreshRandomizer().Next(0, HERO.gold * 3);
                            break;
                        default:
                            Console.WriteLine("The explosion was just SPECIAL EFFECTS! You get 40 gold for enduring the LOUD NOISES!");
                            HERO.gold += 40;
                            break;
                    }
                }
                else if (results[0] == "🔮")
                {
                    Console.WriteLine("MYSTIC CRYSTAL BALL JACKPOT! You glimpse your CHAOTIC FUTURE!");
                    Thread.Sleep(1000);
                    
                    // Permanent stat boost
                    HERO.maxHP += 15;
                    HERO.HP += 15;
                    HERO.gold += 25;
                    
                    Console.WriteLine("The vision grants you +15 MAX HP and +25 gold, but at what COSMIC COST?");
                    Console.WriteLine("(Spoiler: No actual cost, we just like being DRAMATIC)");
                }
                else if (results[0] == "🦄")
                {
                    Console.WriteLine("UNICORN JACKPOT! A MYTHICAL CREATURE APPEARS!");
                    Thread.Sleep(1000);
                    Console.WriteLine("It BARFS RAINBOWS all over you! GROSS BUT MAGICAL!");
                    
                    // Heal to full and get RAINBOW POWER
                    HERO.HP = HERO.maxHP;
                    HERO.gold += 42;
                    
                    Console.WriteLine("You are fully healed and gain 42 gold because UNICORNS LOVE THAT NUMBER!");
                }
            }
            else if (results[0] == results[1] || results[1] == results[2] || results[0] == results[2])
            {
                // Two matching symbols - more interesting outcomes
                won = true;
                
                // Figure out which symbol matched
                string matchSymbol = "";
                
                // Figure out which symbol matched
                if (results[0] == results[1]) matchSymbol = results[0];
                else if (results[1] == results[2]) matchSymbol = results[1];
                else matchSymbol = results[0]; // must be results[0] == results[2]
                
                Console.WriteLine($"Two {matchSymbol} symbols! PARTIALLY BLESSED BY CHAOS!");
                
                switch (matchSymbol)
                {
                    case "💰":
                        int goldReward = GetFreshRandomizer().Next(20, 50);
                        Console.WriteLine($"GOLD RUSH! You get {goldReward} gold pieces!");
                        HERO.gold += goldReward;
                        break;
                    case "❤️":
                        int healAmount = HERO.maxHP / 3;
                        Console.WriteLine($"PARTIAL HEART HEALING! Recover {healAmount} HP!");
                        HERO.HP = Math.Min(HERO.maxHP, HERO.HP + healAmount);
                        break;
                    case "💀":
                        int deathTax = Math.Min(HERO.HP - 1, GetFreshRandomizer().Next(5, 15));
                        Console.WriteLine($"DEATH TAX! Lose {deathTax} HP to the REAPER!");
                        HERO.HP -= deathTax;
                        break;
                    case "🗡️":
                        Console.WriteLine("SHARP OBJECTS APPEAR! You juggle them and earn 15 gold from impressed ghosts!");
                        HERO.gold += 15;
                        break;
                    case "🛡️":
                        int smallHpBoost = GetFreshRandomizer().Next(5, 15);
                        Console.WriteLine($"PARTIAL PROTECTION! Max HP increased by {smallHpBoost}!");
                        HERO.maxHP += smallHpBoost;
                        HERO.HP += smallHpBoost;
                        break;
                    case "👽":
                        Console.WriteLine("ALIEN SIGNAL DETECTED! They wire you 20 SPACE GOLD!");
                        HERO.gold += 20;
                        break;
                    case "🌋":
                        Console.WriteLine("MINOR ERUPTION! Hot but not deadly! Gain 10 gold from selling LAVA ROCKS to tourists!");
                        HERO.gold += 10;
                        break;
                    case "🧨":
                        Console.WriteLine("SMALL EXPLOSION! Your hair is singed but you find 25 gold in the debris!");
                        HERO.gold += 25;
                        break;
                    case "🔮":
                        Console.WriteLine("FOGGY CRYSTAL BALL! You see a vision of yourself with 20 more gold!");
                        HERO.gold += 20;
                        break;
                    case "🦄":
                        Console.WriteLine("UNICORN SIGHTING! It gallops away but drops a MAGICAL HAIR worth 30 gold!");
                        HERO.gold += 30;
                        break;
                }
            }
            else
            {
                // No matches - but sometimes lucky anyway
                HERO.slotLossStreak++; // Increment loss streak
                
                if (HERO.hasCHAOS_FEVER && GetFreshRandomizer().Next(3) == 0) // 33% chance in CHAOS FEVER
                {
                    Console.WriteLine("NO MATCHES... BUT CHAOS FEVER TRANSFORMS YOUR LOSS INTO A WIN!");
                    int chaosReward = GetFreshRandomizer().Next(25, 75);
                    HERO.gold += chaosReward;
                    Console.WriteLine($"You get {chaosReward} gold as the universe BENDS THE RULES FOR YOU!");
                    won = true;
                }
                else if (GetFreshRandomizer().Next(10) == 0) // 10% chance of SURPRISE REWARD
                {
                    Console.WriteLine("NO MATCHES... BUT WAIT! THE MACHINE MALFUNCTIONS IN YOUR FAVOR!");
                    int surpriseGold = GetFreshRandomizer().Next(10, 30);
                    HERO.gold += surpriseGold;
                    Console.WriteLine($"You get {surpriseGold} gold from the GLITCHED CIRCUITS!");
                    won = true;
                }
                else
                {
                    // Regular loss
                    Console.WriteLine("No matches! YOU GET NOTHING! GOOD DAY SIR!");
                    
                    // PITY MECHANICS FOR DISPLAY
                    if (HERO.slotLossStreak >= 5)
                    {
                        Console.WriteLine($"LOSS STREAK: {HERO.slotLossStreak} - The odds are getting better!");
                    }
                    
                    if (HERO.slotLossStreak >= 10)
                    {
                        Console.WriteLine("The machine is starting to feel GUILTY about taking all your money...");
                    }
                    
                    if (HERO.slotLossStreak >= 15)
                    {
                        Console.WriteLine("Any spin now could be THE BIG ONE! You can FEEL IT!");
                    }
                    
                    // 5% chance of consolation prize because CHAOS IS RANDOM
                    if (GetFreshRandomizer().Next(20) == 0)
                    {
                        Console.WriteLine("...ACTUALLY, here's 1 gold as a PITY PRIZE.");
                        HERO.gold += 1;
                    }
                }
            }
            
            return won;
        }
        
        // HANDLE POST-SPIN EFFECTS LIKE RAGE MODE AND FEVER RESET
        private static void HandlePostSpinEffects(Player HERO, bool won)
        {
            // RESET LOSS STREAK IF WON
            if (won)
            {
                HERO.slotLossStreak = 0;
                
                // 5% chance to end CHAOS FEVER after a win
                if (HERO.hasCHAOS_FEVER && GetFreshRandomizer().Next(20) == 0)
                {
                    Console.WriteLine("\n🧊🧊🧊 CHAOS FEVER SUBSIDES! 🧊🧊🧊");
                    Console.WriteLine("The slot machine returns to its normal state... for now.");
                    HERO.hasCHAOS_FEVER = false;
                }
            }
            
            // 2% chance of RAGE MODE if on a big losing streak
            if (!won && HERO.slotLossStreak >= 8 && GetFreshRandomizer().Next(50) == 0)
            {
                Console.WriteLine("\n😡😡😡 R A G E   M O D E   A C T I V A T E D 😡😡😡");
                Console.WriteLine("YOU'VE HAD ENOUGH OF THIS STUPID MACHINE!");
                Thread.Sleep(1000);
                Console.WriteLine("You SMASH it with your fist and...");
                Thread.Sleep(1500);
                
                int rageGold = HERO.gold + GetFreshRandomizer().Next(50, 150);
                Console.WriteLine($"JACKPOT!!! {rageGold} GOLD COINS EXPLODE EVERYWHERE!");
                HERO.gold += rageGold;
                
                // But there's a price...
                int rageDamage = GetFreshRandomizer().Next(5, 15);
                Console.WriteLine($"But you hurt your hand in the process! Take {rageDamage} damage from SHARP METAL EDGES!");
                HERO.HP = Math.Max(1, HERO.HP - rageDamage);
                
                // Reset loss streak
                HERO.slotLossStreak = 0;
            }
        }
    }
} 