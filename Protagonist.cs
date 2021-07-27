using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure
{
    class Protagonist : Character  //Child of the character class
    {
        public DateTime BirthDate { get; set; }
        public List<Item> Inventory { get; set; }

        public Protagonist()
        {

        }

        public Protagonist(String name, DateTime bDay, List<Item> items)
        {
            Name = name;
            BirthDate = bDay;
            Inventory = items;
        }

        public int CalculateAge()
        {
            TimeSpan AgeRange = new TimeSpan();

            AgeRange = DateTime.Now - BirthDate;

            int Age = AgeRange.Days / 365;

            return Age;
        }


        // This satisfies the Calculate and display data based on an external factor
        // (ex: get the current date, and display how many days remaining until some event) requirement //

        // calculated the amount the number of days until the players next birthday. 
        public int DaysUntil()
        {
            DateTime Today = DateTime.Now;
            DateTime NextBirthday = BirthDate;
            NextBirthday = NextBirthday.AddYears(CalculateAge());

            while (NextBirthday < Today)
            {
                NextBirthday = NextBirthday.AddYears(1);
            }

            TimeSpan daysUntil = NextBirthday - Today;

            return daysUntil.Days;
        }
    }
}

//Create an additional class which inherits one or more properties from its parent