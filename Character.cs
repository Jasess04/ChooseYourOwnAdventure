using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ChooseYourOwnAdventure
{
    class Character
    {
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Item> Inventory { get; set; }

        public Character()
        {

        }

        public Character(String name, string bDay, List<Item> items)
        {
            Name = name;
            BirthDate = DateTime.Parse(bDay);
            Inventory = items;
        }

        public int CalculateAge()
        {
            TimeSpan AgeRange = new TimeSpan();

            AgeRange = DateTime.Now - BirthDate;

            int Age = AgeRange.Days / 365;

            return Age;
        }
    }
}
