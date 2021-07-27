using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ChooseYourOwnAdventure
{
    class Character
    {
        public String Name { get; set; }


        public Character()
        {

        }

        public Character(String name)
        {
            Name = name;
        }

    }
}
