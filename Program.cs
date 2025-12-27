// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
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

String battleHeaderGag = @"╔═══════════════════════════════════════════════════════╗
║           BATTLE START (...against a Dummy)           ║
╚═══════════════════════════════════════════════════════╝"; //@ = multiline

String battleHeader = @"╔══════════════════════════════════════════════════════╗
║                        BATTLE                        ║
╚══════════════════════════════════════════════════════╝";

String divider = "─────────────────────────────────────────────────────────";

String options = @" ⚔️ MATCH    -- Engage in a battle of RPS.
 🎒 BAG      -- Check your bag for ITEMs.
 🔍 INSPECT  -- Look at your opponent.";

 String optionsMatch = @" 🪨 ROCK
 📄 PAPER
 ✂️ SCISSORS";

 String optionInspectSelected = @" [ 🔍 INSPECT  -- Look at your opponent. ]";

String narrationBase = @"   The training dummy just... stands there. Menacingly.
   (It's literally just a sack of hay...)";

String narrationNoOption = @"   (Psst...! Pick one of the options to DO something!!!)";

String narrationMatchStancePlayer = @"   Choose your stance!";

String narrationMatchStanceDummy = @"   Dummy chose a stance as well!";

String narrationMatchRPS = @"   ROCK, PAPER, SCISSORS...";

String narrationMatchShoot = @"   SHOOT!";

String narrationInspectDummy = @"   The dummy has seen better days. Also worse days. It's a dummy.
   HP: (number) ATK: (number) DEF: (number)";

Console.WriteLine(battleHeaderGag);
Console.WriteLine(narrationBase);
Console.WriteLine(divider);
Console.WriteLine(options);
Console.WriteLine(divider);

String? responseLayer1 = Console.ReadLine();

if (responseLayer1?.ToLower() == "match")
{
   Console.WriteLine(battleHeader);
   Console.WriteLine(narrationMatchStancePlayer);
   Console.WriteLine(divider);
   Console.WriteLine(optionsMatch);
   Console.WriteLine(divider);
}
else if (responseLayer1?.ToLower() == "bag")
{
    
}
else if (responseLayer1?.ToLower() == "inspect")
{
   Console.WriteLine(battleHeader);
   Console.WriteLine(narrationInspectDummy);
   Console.WriteLine(divider);
   Console.WriteLine(optionInspectSelected);
   Console.WriteLine(divider);
}
else
{
   Console.WriteLine(battleHeader);
   Console.WriteLine(narrationNoOption);
   Console.WriteLine(divider);
   Console.WriteLine(options);
   Console.WriteLine(divider);
}