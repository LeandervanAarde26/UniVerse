using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniVerse.Models;
using UniVerse.Screens;

namespace UniVerse.ViewModels
{
    public class Navigation
    {

        public List<FlyoutItem> Items { get; set; }

        public Navigation()
        {
            Items = new List<FlyoutItem>();
         
        }
        public void AddNavItems()
        {
            var pages = new Routes[]
            {

               new Routes
                {
                    FlyoutIcon = "dashboard_icon.png",
                    Page = new Dashboard(),
                    Title = "  Home",

                },

                new Routes
                {
                    FlyoutIcon = "staff_icon.png",
                    Page = new StaffScreen(),
                    Title = "  Staff",
                   
                },
                new Routes
                {
                    FlyoutIcon = "students_icon.png",
                    Page = new StudentScreen(),
                    Title = "  Students",
                    
                },
                 new Routes
                 {
                      FlyoutIcon = "funds_icon.png",
                     Page = new FundsScreenAndComponents(),
                     Title = "  Funds",
                    
                 },

                 new Routes
                 {
                     FlyoutIcon = "subjects_icon.png",
                     Page = new SubjectsScreen(),
                     Title = "  Subjects",
                    
                 },

      

            };
            foreach (var page in pages)
            {
                ShellContent Content = new()
                {
                    ContentTemplate = new(() => page.Page)

                };

                //NavigationPage.SetHasNavigationBar(Content, false);
                //NavigationPage.SetHasBackButton(Content, false);
                Shell.SetTabBarIsVisible(Content, false);
                Shell.SetBackButtonBehavior(Content, new BackButtonBehavior
                {
                    IsVisible = false
                });

                FlyoutItem Item = new()
                {
                    Title = page.Title,
                    FlyoutIcon = page.FlyoutIcon,
                    
                    
                };
                Item.Items.Add(new Tab
                {
                    Items = { Content },
                });
                Items.Add(Item);
               
            }
        }
    }
}
