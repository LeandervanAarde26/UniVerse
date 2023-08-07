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
                    Page = new StaffScreen(),
                    Title = "Staff",
                    FlyoutIcon = "staff_icon.png"
                },
                new Routes
                {
                    Page = new StudentScreen(),
                    Title = "Students",
                    FlyoutIcon = "students_icon.png"
                },
                 new Routes
                 {
                     Page = new FundsScreenAndComponents(),
                     Title = "Funds",
                     FlyoutIcon = "funds_icon.png"
                 },

                 new Routes
                 {
                     Page = new SubjectsScreen(),
                     Title = "Subjects",
                     FlyoutIcon = "subjects_icon.png"
                 }
};
            foreach (var page in pages)
            {
                ShellContent Content = new()
                {
                    ContentTemplate = new(() => page.Page)
                };

                FlyoutItem Item = new()
                {
                    Title = page.Title,
                    FlyoutIcon = page.FlyoutIcon
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
