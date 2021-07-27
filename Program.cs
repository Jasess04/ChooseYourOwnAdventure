using System;
using System.Collections.Generic;

namespace ChooseYourOwnAdventure
{
    //Implement a “master loop” console application where the user can repeatedly enter
      //commands/perform actions, including choosing to exit the program//
    class Program 
    {
        static void Main(string[] args)
        {                 
            Program program = new Program();
            List<Item> ItemCatalog = new List<Item>();  
            List<Character> CharacterCatalog = new List<Character>();
            Character Player = new Character();

            ItemCatalog = program.GenerateItems();
            CharacterCatalog = program.GenerateCharacters(ItemCatalog);

                Player = program.GeneratePlayer();

                CharacterCatalog.Add(Player);

                //program.Credits(CharacterCatalog);
                program.GameEvents(ItemCatalog, CharacterCatalog);

            Console.WriteLine("Press space bar to exit the game");
            Console.Read(); //May not be needed?
        }
       // Create a dictionary or list, populate it with several values, retrieve at least one value, and
       //use it in your program

          //This is a list of of potential items. I got kinda in over my head so I just went with a sandwich.// 
          //Don't hold it against me. I wish i'd make a bigger game but ya know...It got too big.//
        public List<Item> GenerateItems()
        {
            List<Item> ItemList = new List<Item>();

            ItemList.Add(new Item() { ItemID = 0, ItemName = "Rope" });
            ItemList.Add(new Item() { ItemID = 1, ItemName = "Magnet" });
            ItemList.Add(new Item() { ItemID = 2, ItemName = "Knife" });
            ItemList.Add(new Item() { ItemID = 3, ItemName = "Rock" });
            ItemList.Add(new Item() { ItemID = 4, ItemName = "Sandwich" });

            return ItemList;
        }

          //the characters in the game. Their birthdates and ages as well as the items each character would carry. Again,
          // I settled on a sandwich.

        public List<Character> GenerateCharacters(List<Item> ItemCatalog)
        {
            List<Character> CharList = new List<Character>();

            CharList.Add(new Character() { Name = "Rodrigo", BirthDate = DateTime.Parse("Jan 2 1960"), Inventory = new List<Item>() { } });
            CharList.Add(new Character() { Name = "Jannette", BirthDate = DateTime.Parse("Oct 14 1987"), Inventory = new List<Item>() { } });
            CharList.Add(new Character() { Name = "Bear", BirthDate = DateTime.Parse("9 21 1992"), Inventory = new List<Item>() { } });
            CharList.Add(new Antagonist() { Name = "EVIL Bear", BirthDate = DateTime.Parse("9 21 1992"), Inventory = new List<Item>() { } });

            CharList[0].Inventory.Add(ItemCatalog[0]);
            CharList[1].Inventory.Add(ItemCatalog[2]);
            CharList[1].Inventory.Add(ItemCatalog[3]);
            CharList[2].Inventory.Add(ItemCatalog[3]);
            CharList[3].Inventory.Add(ItemCatalog[0]);
            CharList[3].Inventory.Add(ItemCatalog[1]);
            CharList[3].Inventory.Add(ItemCatalog[2]);
            CharList[3].Inventory.Add(ItemCatalog[3]);

            return CharList;
        }


        public void Credits(List<Character> CList)
        {
            foreach (Character c in CList)
            {
                Console.WriteLine("Character: " + c.Name + " is " + c.CalculateAge() + " years old, was born on " + c.BirthDate + " and has equpped:");
                foreach (Item i in c.Inventory)
                {
                    Console.WriteLine("     a " + i.ItemName);
                };
            }
        }
        //Calculate and display data based on an external factor(ex: get the current date, and
        //display how many days remaining until some event) The user inputs a date and the real time days until their next birthday is the output//
        public Character GeneratePlayer()
        {
            Character Player = new Protagonist();
            Boolean Parsed = false;

            Console.WriteLine("Welcome! Please enter your name: ");
            Player.Name = Console.ReadLine();
            
            while(Parsed == false)
            {
                String Response = "";
                Console.WriteLine("Please enter your birthdate DD/MM/YYYY (with the forward slashes): ");
                Response = Console.ReadLine();

                if (DateTime.TryParse(Response, out DateTime result) == true)
                {
                    Player.BirthDate = result;
                    Parsed = true;
                }
                else Console.WriteLine("Please try again...");
            }
            //Player.BirthDate 
            Console.WriteLine("[PRESS ENTER TO CONTINUE]");
            Console.ReadLine();
            return Player;
        }

        ////////////////////////////////////////////////
                // THE DUNGEON BEGINS HERE!!!! //
        ////////////////////////////////////////////////
        public void GameEvents(List<Item> ItemCatalog, List<Character> CharacterCatalog)
        {
            Character Player = getProtagonist(CharacterCatalog);
            int DaysUntilNextBirthday = Player.DaysUntil();

            Console.WriteLine("Every man and woman on their birthday must enter the cave of the hungry bear. " +
                "Unfortunately for you drew the short straw. Tough luck bud.");
            Console.WriteLine("You enter the cave with only " + DaysUntilNextBirthday + " days remaining until your next birthday.");

            String quitResponse = "";
            Boolean EventQuit = false;
            Boolean EventEnd = false;
            Boolean HasSandwich = false;
            Boolean HasKey = false;
            Boolean HasMetJannette = false;
            Boolean HasMetRodrigquez = false;

            while (EventEnd == false && EventQuit == false) //If the player chooses to quit it breaks the loop.//
                                                            //But if the player beats the game, it should end the loop as well.
                                                            //there is a separate boolean for each because beating the game has a congrats attached. 
                                                            //This Implements a “master loop” console application where the user can repeatedly enter
                                                            //commands / perform actions, including choosing to exit the program//
            {
                Console.WriteLine("You find yourself in a dark room. It has a door on each wall. " +
                "You hear voices coming from the East and South rooms. What would you like to do? Type w to go west or e to go east. or type \"Quit\" to exit)");
                /*[1 to go West, 2 to go North, 3 to go East, 4 to go South, 5 to check your surroundings, 6 to quit]*/
                String Response = Console.ReadLine().ToLower();
                
                /*Need to swap toLower*/
                
                switch (Response)
                {
                    case "w":
                    case "west":
                        Console.WriteLine("You go to the West room.");
                        if (HasKey)
                        {
                            if (HasSandwich)
                            {
                                Console.WriteLine("You find the unlocked box that contained the sandwich.");
                            }
                            else
                            {
                                Console.WriteLine("You open the locked box and find a sandwich!");
                                HasSandwich = true;
                            }
                        } else
                        {
                            Console.WriteLine("You find a locked box... but have no way of opening it.");
                        }
                        Console.WriteLine("You return to the center room.");
                        break;

                    case "n":
                    case "north":
                        Console.WriteLine("You go to the North room.");
                        if (HasSandwich)
                        {
                            Console.WriteLine(" In the Northern Room you confront the Evil Bear with the sandwich of hope.The Evil Bear lunges at you! " +
                                "Janette yells! GO FORTH AND FEEL NO DARKNESS! You shove the sandwich into its maw! The bear burps! Stumbles back and " +
                                "lands on its tuckus! The Evil Bear falls into a deep sleep. The Evil Bear will sleep another year until a new hope" +
                                "arises.");


                            EventEnd = true;
                        }
                        else
                        {
                            Console.WriteLine("I'll have this sandwich! You and your friends! Bahahaha");
                        }

                        Console.WriteLine("You return to the center room.");
                        break;

                    case "e":
                    case "east":
                        Console.WriteLine("You go to the East room.");
                        if (!HasMetJannette)
                        {
                            Console.WriteLine("Hiya I'm Janet! I'll be helping you with your doomed quest to put the bear back to sleep!");
                            //Jannette introduces herself
                        }
                        if (HasKey)
                        {
                            if (HasSandwich)
                            {
                                Console.WriteLine("We have the sandwich! Now its time for you to bite it! This will be exciting to watch. " +
                                                "I've only seen 7 succeed and 942 fail. Based on your muscle mass, i'm betting on the bear!");
                                //Let's feed the bear!
                            }
                            else
                            {
                                //Jannette gets the sandwich
                                Console.WriteLine("Ok, I have acquired the sandwich. Are you sure you don't want to eat it yourself? Lets be fair. " +
                                                  "You can either have a bomb last meal or be a meal and lose the magic sandwich");
                                HasSandwich = true;
                            }
                        }
                        else
                        {
                            //Jannette drops a hint?
                            Console.WriteLine(" Oh were you hoping for help? Maybe throw your hands up and it'll get freightened that works 0% of the time!" +
                                                "Maybe you'll be the first. ");
                        }

                        Console.WriteLine("You return to the center room.");
                        break;

                    case "s":
                    case "south":
                        Console.WriteLine("You go to the South room.");
                        if (!HasMetRodrigquez)
                        { 
                            //Desription of Rod
                             Console.WriteLine("My friend! I am Rodriguez de la cruz the 32nd and a half! " +
                                                "! Don't listen to miss wet blanket over there! You've got this eh!?");
                        }
                        if (HasKey)
                        {
                            //Rodriguez drops a hint?
                            Console.WriteLine("Jannette and I have been stuck in this cave for years waiting for someone to feed that mangey miscreant!" +
                                "I believe you are the one! And you shut it jannette! Don't mind her, she just likes watching the new challenger get torn" +
                                "limb from limb. You must get the sandwich into the bears mouth. I assume taking your arm out of it is your preference");
                        }
                        else
                        {
                            Console.WriteLine(" Here is the key my friend. Free our souls of this place and put that evil bear back to sleep forever!");
                            HasKey = true;
                        }

                        Console.WriteLine("You return to the center room.");
                        break;

                    case "q":
                    case "quit":
                        Console.WriteLine("Do you want to quit? 1 yes, 2 no.");
                        quitResponse = Console.ReadLine();

                        break;

                    default:
                        Console.WriteLine("Sorry, " + Response + " not recognized, please try again.");
                        break;
                }

                //Console.WriteLine("Do you want to quit? 1 yes, 2 no.");
                //String quit = Console.ReadLine();

                if(quitResponse == "1")
                {
                    EventQuit = true;
                }
              
            }

            if (EventEnd)
            {
               Console.WriteLine("Congrats! Jannette and Rodriguez are free! And you go home victorous and with a completed code louisville project!!!");
            }
        }

        public Character getProtagonist(List<Character> CharacterCatalog)
        {
            Character character = null;
            Type protagonistType = new Protagonist().GetType();

            foreach (Character catalogCharacter in CharacterCatalog)
            {
                if (catalogCharacter.GetType() == protagonistType)
                {
                    character = catalogCharacter;
                }
            }

            return character;
        }
    }
}

// room
// west
// north
// east
// south

/*
X - Antagonist - Need Sandwich
# - locked box with sandwich - Need Key to get Sandwich
1 - Rodrigo - Has Key
2 - Jannette - Gets Sandwich for Player if have Key

    [X]        
 [#][*][2]
    [1]

 */

//It gets the player character which is of the protagonist type.
//it demonstrates inheritance in object oriented programming

