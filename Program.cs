using System;
using System.Collections.Generic;

namespace ChooseYourOwnAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean EndGame = false;
            Program program = new Program();
            List<Item> ItemCatalog = new List<Item>();
            List<Character> CharacterCatalog = new List<Character>();
            Character Player = new Character();

            ItemCatalog = program.GenerateItems();
            CharacterCatalog = program.GenerateCharacters(ItemCatalog);

            while (EndGame == false) {
                Player = program.GeneratePlayer();

                CharacterCatalog.Add(Player);

                //program.Credits(CharacterCatalog);
                program.GameEvents();
            }

            Console.Read();
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
            Character Player = new Character();
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
            Console.Read();
            return Player;
        }

        ////////////////////////////////////////////////
        // JOSHUA START HERE - BUILD YO DREAM DUNJINN //
        ////////////////////////////////////////////////
        public void GameEvents()
        {
            Boolean EventEnd = false;
            while (EventEnd == false)
            {
                Console.WriteLine("You find yourself in a dark room. It has a door on each wall. " +
                "You hear voices coming from the East and South rooms. What would you like to do? ");
                /*[1 to go West, 2 to go North, 3 to go East, 4 to go South, 5 to check your surroundings, 6 to quit]*/
                String Response = Console.ReadLine().ToLower();
                
                /*Need to swap toLower*/
                
                switch (Response)
                {
                    case "w":
                    case "west":
                    
                        Console.WriteLine("You go West.");
                        break;
                    case "n":
                    case "north":
                 
                        Console.WriteLine("You go North.");
                        break;
                    case "e":
                    case "east":
                   
                        Console.WriteLine("You go East.");
                        break;
                    case "s":
                    case "south":
                        Console.WriteLine("You go South.");
                        break;
                    default:
                        Console.WriteLine("Sorry, " + Response + " not recognized, please try again.");
                        break;
                }

                Console.WriteLine("Do you want to quit? 1 yes, 2 no.");
                String quit = Console.ReadLine();

                if(quit == "1")
                {
                    EventEnd = true;
                }
              
            }
        }
        // room
        // west
        // north
        // east
        // south

        /*
        X - Antagonist
        # - locked box with sandwich
        1 - Rodrigo
        2 - Jannette
        
            [X]        
         [#][*][2]
            [1]
         
         */
    }
}
