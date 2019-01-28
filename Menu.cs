using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class Menu
    {
      
        public int ID;
        string Title;
        MenuItem[] Items;
        List<Menu> SubMenus = new List<Menu>();
        public Menu(int ID, MenuItem[] Items, string Title)
        {
            

            this.ID = ID;
            this.Items = Items;
            this.Title = Title;
        }
        public MenuItem MenuItemByID(int ID)
        {
            //search Items for MenuItem with ID matching argument ID            
            foreach(MenuItem Item in Items)
            {
               if(Item.ID == ID)
               {
                    return Item;
               }
               else
               {
                   return null;
               }
            }
            return null;
        }
        public void Display()
        {
            //Menu titling routine
            Console.Clear();
            drawline(5, false);
            Console.Write(Title);
            drawline(5, true);

            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Items[i].DisplayName);
            }
            try
            {
                
               
                  Items[Console.ReadKey().KeyChar].PerformBehavior();

                
            }


        }
        public void drawline(int length, bool NewLineAfter)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            if (NewLineAfter)
            {
                Console.Write(Environment.NewLine);

            }

        }

    }
}
