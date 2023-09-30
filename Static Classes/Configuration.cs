using BossAzFinalProject.Entity_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BossAzFinalProject.Static_Classes
{
    public static class Configuration
    {
        public static void PrintMenu(in string[] menu)
        {    
                for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{menu[i]}");
            }
        }

        public static string[] GetBossFirstMenu()
        {
            return new string[] { "Employer", "Worker", "About Our Mission", "Exit" };
        }

        public static string[] GetUserHeadMenu()
        {
            return new string[] { "Register", "Login", "Exit" };
        }

        public static string[] GetUserSecondMenu()
        {
            return new string[] { "Announcements", "CV", "Exit" };
        }

        ////////
        public static string[] GetUserAnnouncementSideMenu()
        {
            return new string[] { "Show more about Announcement with ID", "Apply Announcement with ID", "Filter", "Show Notifications", "Show Job Offers with ID", "Back" };
        }
        public static string[] GetUserAnnouncementSideFilterChoiceMenu()
        {
            return new string[] { "Show more about Announcement with ID", "Apply Announcement with ID", "Back" };
        }
        public static string[] GetFilterByMenu()
        {
            return new string[] { "By Speciality", "By City", "By Pay Check" };
        }
        ////////


        ////////

        public static string[] GetCVSideMenu()
        {
            return new string[] { "Show more about CV with ID", "Add CV", "Delete CV with ID", "Update CV with ID", "Back" };
        }

        public static string[] GetCVSideUpdateChoiceMenu()
        {
            return new string[] { "Speciality", "City", "Foreign Language", "Worked Companies", "Skills", "All", "Back", "Exit" };
        }
        ////////

        public static string[] GetEmployerAboutWorkerSideMenu()
        {
            return new string[] {"Show incoming requests from workers", "Send job offer to workers who are in the system",
                "Show notifications about job offers", "Back"};
        }

        public static string[] GetEmployerAboutAnnouncementSideMenu()
        {
            return new string[] { "Add Announcement", "Delete Announcement", "Update Announcement", "Back" };
        }

        public static string[] GetEmployerAboutAnnouncementSideUpdateChoiceMenu()
        {
            return new string[] { "Speciality", "City", "Pay check", "Experience Year", "Description", "Back", "Exit" };
        }


        public static string[] GetEmployerSecondMenu()
        {
            return new string[] { "Announcement Side", "Worker Side", "Exit" };
        }

        //////


        private static List<Announcement> GetFirstEmployerAnnouncements()
        {
            Announcement a1 = new Announcement("Programmer", "Baku", "9999", "5", "Hi , We need a Programmer");
            Announcement a2 = new Announcement("IT", "New-York", "10000", "7", "Qaqa men proqramistem deyen oglan lazimdi");
            Announcement a3 = new Announcement("Software Engineer", "London", "10000", "8", "Hello World yazan qaqas lazimdi");

            return new List<Announcement> { a1, a2, a3 };
        }


        private static List<Announcement> GetSecondEmployerAnnouncements()
        {
            Announcement a1 = new Announcement("Software Engineer", "London", "100000", "10", "We want ");
            Announcement a2 = new Announcement("Economist", "Baku", "5000", "6", "Do calculations right");
            Announcement a3 = new Announcement("Administrator", "New-York", "30000", "8", "Controlling restaurant");

            return new List<Announcement> { a1, a2, a3 };
        }

        private static List<Announcement> GetThirdEmployerAnnouncements()
        {
            Announcement a1 = new Announcement("BodyGuard", "Roma", "20000", "10", "You protect one of the famous actor");
            Announcement a2 = new Announcement("Life Coach", "Azerbaijan", "5000", "5", "Touch people's lives");
            Announcement a3 = new Announcement("Baby sitter", "Brazilia", "1000", "2", "All we need patience");

            return new List<Announcement> { a1, a2, a3 };
        }

        public static string[] GetWorkerSideSendJobOfferChoiceFilterMenuChoices()
        {
            return new string[] { "By Speciality", "By Foreign Language", "By Experience Year", "By Skill", "By City", "By Accept Score", "Back" };
        }

        public static List<Employer> GetEmployersAndSetAnnouncements()
        {
            List<Announcement> firstEmployerAnnouncements = GetFirstEmployerAnnouncements();
            Employer employer1 = new Employer("Amin", "amin1234".GetHashCode().ToString(), "Ibrahimov", "bekarciliq", "18", "Sumqayit", "9999999");

            List<Announcement> secondEmployerAnnouncements = GetSecondEmployerAnnouncements();
            Employer employer2 = new Employer("Maqa", "GeleceyinHekimi".GetHashCode().ToString(), "Liliput", "bosluqdu", "19", "Sabran", "8888888");

            List<Announcement> thirdEmployerAnnouncements = GetThirdEmployerAnnouncements();
            Employer employer3 = new Employer("PasterRaper", "Synaps123".GetHashCode().ToString(), "Paster", "MenNeBilim", "25", "Las Vegas", "7777777");

            List<Employer> employers = new List<Employer> { employer1, employer2, employer3 };

            employers[0].Announcements.Add(firstEmployerAnnouncements[0]);
            employers[0].Announcements.Add(firstEmployerAnnouncements[1]);
            employers[0].Announcements.Add(firstEmployerAnnouncements[2]);


            employers[1].Announcements.Add(secondEmployerAnnouncements[0]);
            employers[1].Announcements.Add(secondEmployerAnnouncements[1]);
            employers[1].Announcements.Add(secondEmployerAnnouncements[2]);

            employers[2].Announcements.Add(thirdEmployerAnnouncements[0]);
            employers[2].Announcements.Add(thirdEmployerAnnouncements[1]);
            employers[2].Announcements.Add(thirdEmployerAnnouncements[2]);


            return employers;
        }


        public static List<Worker> GetWorkersAndSetCVs()
        {

            CV cv1 = new CV("Designer", "Baku", "THL", "designYourLife", "mydesign.com", "English, Adobe", "Amazon", "You can't see my hands when i writing", "699", DateTime.Now, DateTime.Now.AddYears(4));
            Worker w1 = new Worker("t", "t".GetHashCode().ToString(), "Jessy", "Yessy", "23", "New York", "999333222");
            w1.CV.Add(cv1);

            CV cv2 = new CV("Boxer", "Everywhere", "no where", "mypunch", "whereAreYou.hit", "English", "World Champion of Boxing on HeavyWeight", "i love punching", "111", DateTime.Now, DateTime.Now.AddYears(10));
            Worker w2 = new Worker("Mike", "Tyson".GetHashCode().ToString(), "Mike", "Tyson", "27", "Las Vegas", "9875462");
            w2.CV.Add(cv2);

            CV cv3 = new CV("UFC", "Ireland", "Dallas", "notorious", "notorious.championn", "English, Russian", "UFC champion on two Weights", "essalam aleykum", "333", DateTime.Now, DateTime.Now.AddYears(8));
            Worker w3 = new Worker("Conor", "notorious".GetHashCode().ToString(), "Conor", "McGregor", "30", "Ireland", "1111111");
            w3.CV.Add(cv3);

            CV cv4 = new CV("Life Coach", "California", "California", "i love  helping people", "bosluq", "English, Italian, Spanish", "Has changed many lives", "change your body change your life", "700", DateTime.Now, DateTime.Now.AddYears(20));
            Worker w4 = new Worker("LifeChanger", "Helper".GetHashCode().ToString(), "Anthony", "Robbins", "60", "California", "8888888");
            w4.CV.Add(cv4);


            return new List<Worker> { w1, w2, w3, w4 };
        }

        public static void PrintMission()
        {
            Console.Write(new string('\n', Console.WindowHeight / 2));
            StringBuilder statement = new StringBuilder("Our mission is to help people get not only job opportunities,");
            Console.Write(new string(' ', (Console.WindowWidth - statement.Length) / 2));
            Console.WriteLine(statement);
            statement.Clear().Append("but also earning high salaries and get rich :) .");
            Console.Write(new string(' ', (Console.WindowWidth - statement.Length) / 2));
            Console.WriteLine($"{statement}\n");

            Console.CursorLeft = Console.WindowWidth - "By Amin Ibrahimov".Length * 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Amin Ibrahimov");
            Thread.Sleep(2000);
            Console.ResetColor();           
        }

        public static void PrintEntryWord()
        {
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n /$$$$$$$                                   /$$$$$$           \r\n| $$__  $$                                 /$$__  $$          \r\n| $$  \\ $$  /$$$$$$   /$$$$$$$ /$$$$$$$   | $$  \\ $$ /$$$$$$$$\r\n| $$$$$$$  /$$__  $$ /$$_____//$$_____/   | $$$$$$$$|____ /$$/\r\n| $$__  $$| $$  \\ $$|  $$$$$$|  $$$$$$    | $$__  $$   /$$$$/ \r\n| $$  \\ $$| $$  | $$ \\____  $$\\____  $$   | $$  | $$  /$$__/  \r\n| $$$$$$$/|  $$$$$$/ /$$$$$$$//$$$$$$$//$$| $$  | $$ /$$$$$$$$\r\n|_______/  \\______/ |_______/|_______/|__/|__/  |__/|________/\r\n                                                              \r\n                                                              \r\n                                                              \r\n");
            Console.ResetColor();
        }

    }
}