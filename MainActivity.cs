using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class MainActivity
    {
        public string ClientVersion = "1.0.0";
        public UserHandle UserHandle = new UserHandle();
        public WebsocketHandle WebsocketHandle;
        public static MenuHandle MenuHandle = new MenuHandle();
        public static LocalDataHandle LocalDataHandle = new LocalDataHandle(System.IO.Directory.GetCurrentDirectory() + "/data/data.bin");
        static void Main(string[] args)
        {
            Console.WriteLine("Checking dependencies...");
            HandleDependencies();
            Console.WriteLine("Initiating variables...");
            InitMenus();
            MenuHandle.MenuByID(0).Display();
        }
        static void HandleDependencies()
        {
            TryReadWrite:
            try
            {
                if (LocalDataHandle.ReadDataByHeader("log") == null)
                {
                    LocalDataHandle.WriteDataByHeader("log",LogDataBuffer);
                }
            }
            catch (Exception e)
            {
                LocalDataHandle.CreateDataFile();
                goto TryReadWrite;
            }
        }
        //Initiates every menu and submenu
        static void InitMenus()
        {
            Menu[] Menus = new Menu[]
            {
                new Menu(0,new MenuItem[]
                {
                    new MenuItem(0,"Login",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(1,"Register",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(2,"Exit",new MenuItem.Behavior[] {MenuItem.Behavior.GoToMenu}),
                },"Login"),
                      new Menu(1,new MenuItem[]
                {
                    new MenuItem(0,"Name Badges",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(1,"Login",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(2,"Login",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                },"Shop"), 
                    new Menu(2,new MenuItem[]
                {
                    new MenuItem(0,"Customization",new MenuItem.Behavior[] {MenuItem.Behavior.GoToMenu}),
                    new MenuItem(1,"Settings",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(2,"Login",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                },"User Control"), 
                    new Menu(3,new MenuItem[]
                {
                    new MenuItem(0,"Shop",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(1,"User Control",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(2,"Back",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(3,"Logout",new MenuItem.Behavior[] {MenuItem.Behavior.GoToMenu}),
                },"Main"), 
                new Menu(3,new MenuItem[]
                {
                    new MenuItem(0,"Shop",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(1,"User Control",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(2,"Back",new MenuItem.Behavior[] {MenuItem.Behavior.TextPrompt}),
                    new MenuItem(3,"Logout",new MenuItem.Behavior[] {MenuItem.Behavior.GoToMenu}),
                },"Name Badge Shop"),
                new Menu(3,new MenuItem[]
                {
                    new MenuItem(0,"✪ Senator - 2,300F",new MenuItem.Behavior[] {MenuItem.Behavior.ChangeUserNameBadge}),
                    new MenuItem(1,"★ Eques - 1,200F",new MenuItem.Behavior[] {MenuItem.Behavior.ChangeUserNameBadge}),
                    new MenuItem(2,"✦ Triarius - 570F",new MenuItem.Behavior[] {MenuItem.Behavior.ChangeUserNameBadge}),
                    new MenuItem(3,"✧ Princeps - 170F",new MenuItem.Behavior[] {MenuItem.Behavior.ChangeUserNameBadge}),
                },"Customization"),

            };
                foreach (Menu Menu in Menus)
                {
                MenuHandle.AddMenu(Menu);
                }
        }
        
    }
}
//(c) Hunter Wheat 2018-2019