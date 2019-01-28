using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class MenuItem
    {
        public string DisplayName;
        public int ID;

        public enum Behavior
        {
            GoToMenu,
            TextPrompt,
            ChangeUserNameBadge,
            ChangeUserRank,
            ChangeUserPassword,
            WriteToDataFile,
            
            
        }
        public Behavior[] Behaviors;
        public MenuItem(int ID,string DisplayName, Behavior[] Behaviors)
        {
            this.DisplayName = DisplayName;
            this.Behaviors = Behaviors;
            this.ID = ID;
        }
        public void PerformBehavior(object Object)
        {
            try
            {

            }
            catch (Exception e)
            {

            }

        }
    }
}
