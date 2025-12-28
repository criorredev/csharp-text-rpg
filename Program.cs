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

String matchRock = @"
 🪨 ROCK
 ";

String matchPaper = @"
 📄 PAPER
 ";

String matchScissors = @"
 ✂️ SCISSORS
 ";

String narrationBase = @"   The training dummy just... stands there. Menacingly.
   (It's literally just a sack of hay...)";

String narrationNoOption = @"   (Psst...! Pick one of the options to DO something!!!)";

String narrationMatchStancePlayer = @"   Choose your stance!";

String narrationMatchStancePlayerRock = @"   Alright! Stance: ROCK!";

String narrationMatchStancePlayerPaper = @"   Alright! Stance: PAPER!";

String narrationMatchStancePlayerScissors = @"   Alright! Stance: SCISSORS!";

String narrationMatchStanceDummy = @"   Dummy chose a stance as well!";

String narrationMatchRPS = @"   ROCK, PAPER, SCISSORS...";

String narrationMatchShoot = @"   SHOOT!";

String narrationInspectDummy = @"   The dummy has seen better days. Also worse days. It's a dummy.
   HP: (number) ATK: (number) DEF: (number)";

String lineBreak = @"   ";

String narrationMatchDummyRockPlayerRock = @"   You and Dummy's ROCKs bang against each other! Woah!
   You took 1 damage!
   Dummy took 1 damage!";
String narrationMatchDummyRockPlayerPaper = @"   Your PAPER wraps around Dummy's ROCK! You win!
   Dummy took 3 damage!";
String narrationMatchDummyRockPlayerScissors = @"   Dummy's ROCK crushes your SCISSORS. Oof... You lose!
   You took 3 damage!";
String narrationMatchDummyPaperPlayerPaper = @"   You and Dummy's PAPERs crumble each other up! Woah!
   You took 1 damage!
   Dummy took 1 damage!";
String narrationMatchDummyPaperPlayerScissors = @"   Your SCISSORS cuts Dummy's PAPER to shreds! You win!
   Dummy took 3 damage!";
String narrationMatchDummyPaperPlayerRock = @"   Dummy's PAPER wraps around your ROCK. Oof... You lose!
   You took 3 damage!";
String narrationMatchDummyScissorsPlayerScissors = @"   You and Dummy's SCISSORS scrape against each other! Woah!
   You took 1 damage!
   Dummy took 1 damage!";
String narrationMatchDummyScissorsPlayerRock = @"   Your ROCK crushes Dummy's SCISSORS. You win!
   Dummy took 3 damage!";
String narrationMatchDummyScissorsPlayerPaper = @"   Dummy's SCISSORS cuts your PAPER to shreds! Oof... You lose!
   You took 3 damage!";

// VARIABLES
String currentScreen = "BattleMainGag";
String previousScreen = "";

String? responseLayer1 = "";

String playerChoice = "";
String dummyChoice = "";
int dummyChoicePos = 0;

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
   else if (currentScreen == "PlayerChoiceRock")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchStancePlayerRock);
      Console.WriteLine(divider);
      Console.WriteLine(matchRock);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "PlayerChoicePaper")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchStancePlayerPaper);
      Console.WriteLine(divider);
      Console.WriteLine(matchPaper);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "PlayerChoiceScissors")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchStancePlayerScissors);
      Console.WriteLine(divider);
      Console.WriteLine(matchScissors);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchStanceDummy")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchStanceDummy);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchRPS")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchRPS);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchShoot")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchShoot);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyRockPlayerRock")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyRockPlayerRock);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyRockPlayerPaper")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyRockPlayerPaper);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyRockPlayerScissors")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyRockPlayerScissors);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyPaperPlayerPaper")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyPaperPlayerPaper);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyPaperPlayerScissors")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyPaperPlayerScissors);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyPaperPlayerRock")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyPaperPlayerRock);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyScissorsPlayerScissors")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyScissorsPlayerScissors);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyScissorsPlayerRock")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyScissorsPlayerRock);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   else if (currentScreen == "narrationMatchDummyScissorsPlayerPaper")
   {
      Console.WriteLine(battleHeader);
      Console.WriteLine(narrationMatchDummyScissorsPlayerPaper);
      Console.WriteLine(divider);
      Console.WriteLine(optionsMatch);
      Console.WriteLine(divider);
   }
   // GET INPUT
   if (currentScreen == "BattleMainGag" || currentScreen == "BattleMain" || currentScreen == "InspectDummy" || currentScreen == "BattleMatchStance")
   {
      responseLayer1 = Console.ReadLine();
   }
   // AUTOMATIC SCREEN
   if (currentScreen == "PlayerChoiceRock" || currentScreen == "PlayerChoicePaper" || currentScreen == "PlayerChoiceScissors")
   {
      Thread.Sleep(2000);
      currentScreen = "narrationMatchStanceDummy";
   }
   else if (currentScreen == "narrationMatchStanceDummy")
   {
      Thread.Sleep(2000);
      currentScreen = "narrationMatchRPS";
   }
   else if (currentScreen == "narrationMatchRPS")
   {
      Thread.Sleep(2000);
      currentScreen = "narrationMatchShoot";
   }
   else if (currentScreen == "narrationMatchShoot")
   {
      Thread.Sleep(4000);
      currentScreen = "BattleCalculate";
   }
   else if (
   currentScreen == "narrationMatchDummyRockPlayerRock" ||
   currentScreen == "narrationMatchDummyRockPlayerPaper" ||
   currentScreen == "narrationMatchDummyRockPlayerScissors" ||
   currentScreen == "narrationMatchDummyPaperPlayerPaper" ||
   currentScreen == "narrationMatchDummyPaperPlayerScissors" ||
   currentScreen == "narrationMatchDummyPaperPlayerRock" ||
   currentScreen == "narrationMatchDummyScissorsPlayerScissors" ||
   currentScreen == "narrationMatchDummyScissorsPlayerRock" ||
   currentScreen == "narrationMatchDummyScissorsPlayerPaper")
   {
      Thread.Sleep(4000);
      currentScreen = "BattleMain";
   }

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
         Console.WriteLine(narrationInspectDummy);
         Console.WriteLine(lineBreak);
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
         playerChoice = "rock";
         currentScreen = "PlayerChoiceRock";
      }
      else if (responseLayer1?.ToLower() == "paper")
      {
         playerChoice = "paper";
         currentScreen = "PlayerChoicePaper";
      }
      else if (responseLayer1?.ToLower() == "scissors")
      {
         playerChoice = "scissors";
         currentScreen = "PlayerChoiceScissors";
      }
      // Process RPS Dummy Choice
      if (playerChoice == "rock" || playerChoice == "paper" || playerChoice == "scissors")
      {
         // Dummy RPS
         if (dummyChoicePos == 0)
         {
            dummyChoice = "rock";
            dummyChoicePos += 1;
         }
         else if (dummyChoicePos == 1)
         {
            dummyChoice = "paper";
            dummyChoicePos += 1;
         }
         else if (dummyChoicePos == 2)
         {
            dummyChoice = "scissors";
            dummyChoicePos += 1;
         }
         // Dummy RPS Reset
         if (dummyChoicePos > 2)
         {
            dummyChoicePos = 0;
         }
      }
      // Dummy Confirmation
      if (dummyChoice == "rock" || dummyChoice == "paper" || dummyChoice == "scissors")
      {
         currentScreen = "narrationMatchStanceDummy";
      }
   }
   // RPS Battle Logic
   if (currentScreen == "BattleCalculate")
   {
      if (playerChoice != "rock" && playerChoice != "paper" && playerChoice != "scissors")
      {
         currentScreen = "BattleMatchStance";
         continue;
      }
      if (dummyChoice != "rock" && dummyChoice != "paper" && dummyChoice != "scissors")
      {
         currentScreen = "BattleMatchStance";
         continue;
      }

      if (playerChoice == "rock" && dummyChoice == "scissors")
      {
         DummyHP = DummyHP - 3;
         currentScreen = "narrationMatchDummyScissorsPlayerRock";
      }
      else if (playerChoice == "rock" && dummyChoice == "rock")
      {
         DummyHP = DummyHP - 1;
         PlayerHP = PlayerHP - 1;
         currentScreen = "narrationMatchDummyRockPlayerRock";
      }
      else if (playerChoice == "rock" && dummyChoice == "paper")
      {
         PlayerHP = PlayerHP - 3;
         currentScreen = "narrationMatchDummyPaperPlayerRock";
      }
      else if (playerChoice == "paper" && dummyChoice == "rock")
      {
         DummyHP = DummyHP - 3;
         currentScreen = "narrationMatchDummyRockPlayerPaper";
      }
      else if (playerChoice == "paper" && dummyChoice == "paper")
      {
         DummyHP = DummyHP - 1;
         PlayerHP = PlayerHP - 1;
         currentScreen = "narrationMatchDummyPaperPlayerPaper";
      }
      else if (playerChoice == "paper" && dummyChoice == "scissors")
      {
         PlayerHP = PlayerHP - 3;
         currentScreen = "narrationMatchDummyScissorsPlayerPaper";
      }
      else if (playerChoice == "scissors" && dummyChoice == "paper")
      {
         DummyHP = DummyHP - 3;
         currentScreen = "narrationMatchDummyPaperPlayerScissors";
      }
      else if (playerChoice == "scissors" && dummyChoice == "scissors")
      {
         DummyHP = DummyHP - 1;
         PlayerHP = PlayerHP - 1;
         currentScreen = "narrationMatchDummyScissorsPlayerScissors";
      }
      else if (playerChoice == "scissors" && dummyChoice == "rock")
      {
         PlayerHP = PlayerHP - 3;
         currentScreen = "narrationMatchDummyRockPlayerScissors";
      }
      else
      {
         currentScreen = "BattleMatchStance";
         continue;
      }
   }
}