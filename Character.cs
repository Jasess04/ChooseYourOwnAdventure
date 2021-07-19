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

        // calculated the amount the number of days until the players next birthday
        public int DaysUntil()
        {
            DateTime Today = DateTime.Now;             
            DateTime NextBirthday = BirthDate;
            NextBirthday = NextBirthday.AddYears(CalculateAge());

            while(NextBirthday < Today)
            {
                NextBirthday = NextBirthday.AddYears(1);
            }

            TimeSpan daysUntil = NextBirthday - Today;

            return daysUntil.Days;
        }

    }
}
