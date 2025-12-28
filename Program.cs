// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
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

// ASCII ART

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

String back = @"
 ↩️ BACK
 ";

String narrationBase = @"   The training dummy just... stands there. Menacingly.
   (It's literally just a sack of hay...)";

String narrationNoOption = @"   (Psst...! Pick one of the options to DO something!!!)";

String narrationMatchStancePlayer = @"   Choose your stance!";

String narrationMatchStanceDummy = @"   Dummy chose a stance as well!";

String narrationMatchRPS = @"   ROCK, PAPER, SCISSORS...";

String narrationMatchShoot = @"   SHOOT!";

String narrationInspectDummy = @"   The dummy has seen better days. Also worse days. It's a dummy.
   HP: (number) ATK: (number) DEF: (number)";

String currentScreen = "BattleMainGag";
String previousScreen = "";

int PlayerHP = 10;
int DummyHP = PlayerHP;

while (PlayerHP > 0 && DummyHP > 0)
{
   // SCREEN DISPLAY
   if (currentScreen == "BattleMainGag")
   {
      Console.WriteLine(battleHeaderGag);
      Console.WriteLine(narrationBase);
      Console.WriteLine(divider);
      Console.WriteLine(options);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "BattleMain")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationBase);
      Console.WriteLine(divider);
      Console.WriteLine(options);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "InspectDummy")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationInspectDummy);
      Console.WriteLine(divider);
      Console.WriteLine(back);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "BattleMatchStance")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchStancePlayer);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }

   // GET INPUT
   String? responseLayer1 = Console.ReadLine();

   // HANDLE INPUT FOR BATTLEMAIN SCREENS
   if (currentScreen == "BattleMainGag" || currentScreen == "BattleMain")
   {
      // Input validation
      while (responseLayer1?.ToLower() != "match" 
          && responseLayer1?.ToLower() != "bag" 
          && responseLayer1?.ToLower() != "inspect")
      {
         Console.WriteLine(battleHeader);
         Console.WriteLine(narrationNoOption);
         Console.WriteLine(divider);
         Console.WriteLine(options);
         Console.WriteLine(divider);
         responseLayer1 = Console.ReadLine();
      }

      // Process valid input
      if (responseLayer1?.ToLower() == "match")
      {
         previousScreen = currentScreen;
         currentScreen = "BattleMatchStance";
      }
      else if (responseLayer1?.ToLower() == "bag")
      {
         // TODO: bag screen
      }
      else if (responseLayer1?.ToLower() == "inspect")
      {
         previousScreen = currentScreen;
         currentScreen = "InspectDummy";
      }
   }
   // HANDLE INPUT FOR INSPECT SCREEN
   else if (currentScreen == "InspectDummy")
   {
      // Input validation
      while (responseLayer1?.ToLower() != "back")
      {
         Console.WriteLine(battleHeader);
         Console.WriteLine(narrationNoOption);
         Console.WriteLine(divider);
         Console.WriteLine(back);
         Console.WriteLine(divider);
         responseLayer1 = Console.ReadLine();
      }

      // Process back
      if (responseLayer1?.ToLower() == "back")
      {
         currentScreen = "BattleMain";
      }
   }
   // HANDLE INPUT FOR MATCH STANCE SCREEN
   else if (currentScreen == "BattleMatchStance")
   {
      // Input validation
      while (responseLayer1?.ToLower() != "rock" 
          && responseLayer1?.ToLower() != "paper" 
          && responseLayer1?.ToLower() != "scissors")
      {
         Console.WriteLine(battleHeader);
         Console.WriteLine(narrationNoOption);
         Console.WriteLine(divider);
         Console.WriteLine(optionsMatch);
         Console.WriteLine(divider);
         responseLayer1 = Console.ReadLine();
      }

      // Process RPS choice
      if (responseLayer1?.ToLower() == "rock")
      {
         // TODO: rock logic
      }
      else if (responseLayer1?.ToLower() == "paper")
      {
         // TODO: paper logic
      }
      else if (responseLayer1?.ToLower() == "scissors")
      {
         // TODO: scissors logic
      }
   }
}