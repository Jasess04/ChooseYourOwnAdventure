using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure
{
    class Item
    {
        public String ItemName { get; set; }
        public int ItemID { get; set; }

        public Item()
        {

        }

        public Item(String iName, int iID)
        {
            ItemName = iName;
            ItemID = iID;
        }
    }
}
