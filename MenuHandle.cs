using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class MenuHandle
    {
        public List<Menu> ParentMenus = new List<Menu>();

        public MenuHandle()
        {

        }

        public void AddMenu(Menu Menu)
        {
            ParentMenus.Add(Menu);

        }
        public Menu MenuByID(int ID)
        {

            foreach (Menu x in ParentMenus)
            {
                if (x.ID == ID)
                {
                    return x;

                }

            }
            return null;





        }
    }
}
