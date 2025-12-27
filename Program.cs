// See https://aka.ms/new-console-template for more information

using Microsoft.Win32.SafeHandles;

/* 
Player has HP, attack, gold (variables)
Enemy has HP, attack (variables)
Make choices with if statements
Combat system with if statements checking HP
Different story paths based on choices
Simple inventory (just number variables like hasSword, hasPotion)
*/

/* 
Dummy: Will always choose Rock, Paper, and then Scissors and the repeat
Bandit: 
*/

/*
Options:
1. Rock -- A quick jab. Classic.
2. Paper -- An open-palm slap. Sophisticated.
3. Scissors -- A poke with two fingers. Intimidating.
*/

Console.WriteLine(@"╔══════════════════════════════════════════════════════╗
║          BATTLE START (...against a Dummy)           ║
╚══════════════════════════════════════════════════════╝

   The training dummy just... stands there. Menacingly.
   (It's literally just a sack of hay...)

─────────────────────────────────────────────────────────

 ⚔️ MATCH    -- Engage in a battle of RPS.
 🎒 BAG      -- Check your bag for ITEMs.
 🔍 INSPECT  -- Look at your opponent.
 
 ─────────────────────────────────────────────────────────"); //@ = multiline

String? responseLayer1 = Console.ReadLine();

if (responseLayer1 == MATCH)
{
    
}
else if (responseLayer1 == BAG)
{
    
}
else if (responseLayer1 == INSPECT)
        {
            
        }
else
{
   Console.WriteLine(@"╔══════════════════════════════════════════════════════╗
║          BATTLE START (...against a Dummy)           ║
╚══════════════════════════════════════════════════════╝

   (Psst...! Pick one of the options to DO something!!!)

─────────────────────────────────────────────────────────

 ⚔️ MATCH    -- Engage in a battle of RPS.
 🎒 BAG      -- Check your bag for ITEMs.
 🔍 INSPECT  -- Look at your opponent.
 
 ─────────────────────────────────────────────────────────");
}