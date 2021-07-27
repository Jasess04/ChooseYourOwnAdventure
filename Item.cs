using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure
{
    class Item
    {
        public String ItemName { get; set; }
        public int ItemID { get; set; }

        //constructor methods for items
        public Item()
        {

        }
        //Overloaded constructor
        public Item(String iName, int iID)
        {
            ItemName = iName;
            ItemID = iID;
        }
    }
}
