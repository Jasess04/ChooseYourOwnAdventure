using System;
using System.Collections.Generic;

namespace ChooseYourOwnAdventure
{
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

        public Character GeneratePlayer()
        {
            Character Player = new Protagonist();
            Boolean Parsed = false;

            Console.WriteLine("Welcome! Please enter your name: ");
            Player.Name = Console.ReadLine();
            
            while(Parsed == false)
            {
                String Response = "";
                Console.WriteLine("Please enter your birthdate DD/MM/YYYY: ");
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
        // JOSHUA START HERE - BUILD YO DREAM DUNJINN //
        ////////////////////////////////////////////////
        public void GameEvents(List<Item> ItemCatalog, List<Character> CharacterCatalog)
        {
            Character Player = getProtagonist(CharacterCatalog);
            int DaysUntilNextBirthday = Player.DaysUntil();

            Console.WriteLine("Every man and woman on their birthday must enter the gave of the hungry bear. " +
                "Unfortunately for you, you drew the short straw. Tough luck bud.");
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
            {
                Console.WriteLine("You find yourself in a dark room. It has a door on each wall. " +
                "You hear voices coming from the East and South rooms. What would you like to do? (\"Quit\" to exit)");
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
                            //Lay the bear low!
                            EventEnd = true;
                        }
                        else
                        {
                            //The bear taunts you?
                        }

                        Console.WriteLine("You return to the center room.");
                        break;

                    case "e":
                    case "east":
                        Console.WriteLine("You go to the East room.");
                        if (!HasMetJannette)
                        {
                            //Description of Jannette; she's bald!
                            //Jannette introduces herself?
                        }
                        if (HasKey)
                        {
                            if (HasSandwich)
                            {
                                //Let's feed the bear!
                            }
                            else
                            {
                                //Jannette gets the sandwich
                                HasSandwich = true;
                            }
                        }
                        else
                        {
                            //Jannette drops a hint?
                        }

                        Console.WriteLine("You return to the center room.");
                        break;

                    case "s":
                    case "south":
                        Console.WriteLine("You go to the South room.");
                        if (!HasMetRodrigquez)
                        { 
                            //Desription of Rod
                            //Rod introduces himself
                        }
                        if (HasKey)
                        {
                            //Rodriguez drops a hint?
                        }
                        else
                        {
                            //Rodriguz gives the Keo
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
               Console.WriteLine("Congrats!");
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

