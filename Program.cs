using Boss.AzFinalProject.Abstract_Classes;
using Boss.AzFinalProject.Static_Classes_about_Common_Menu_Choices;
using Boss.AzFinalProject.Static_Classes_about_Employer_Menu_Choices;
using Boss.AzFinalProject.Static_Classes_about_Worker_Menu_Choices;
using BossAzFinalProject.Entity_Classes;
using BossAzFinalProject.Helper_Static_Classes;
using BossAzFinalProject.Static_Classes;


namespace BossAzFinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Boss.az";
            Console.CursorVisible = false;

            Database database = null;
            if (File.Exists(JsonFileHelper.fileName))
            {
                JsonFileHelper.WriteToJson(database);
                UniqueID.id = database.DatabaseCurrentID;
            }
            else { 
            database = new Database(Configuration.GetWorkersAndSetCVs(), Configuration.GetEmployersAndSetAnnouncements());
                JsonFileHelper.WriteToJson(database);
            }

            string[] bossFirstMenu = Configuration.GetBossFirstMenu();
            string[] userHeadMenu = Configuration.GetUserHeadMenu();

            string[] employerSecondMenu = Configuration.GetEmployerSecondMenu();
            string[] userSecondMenu = Configuration.GetUserSecondMenu();

            string userName = null, password = null, choice = null;

            while (true)
            {
                Console.Clear();
                Configuration.PrintEntryWord();
                Configuration.PrintMenu(bossFirstMenu);
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(choice, bossFirstMenu.Length))
                {
                    Console.WriteLine("\nEnter one of this choices: ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

                if (choice == BossFirstMenuChoices.Exit)
                {
                    Console.WriteLine("Thank you for visiting...");
                    JsonFileHelper.WriteToJson(database);
                    break;
                }

                if (choice == BossFirstMenuChoices.Employer)
                {
                    while (true)
                    {
                        bool isConfirmedEmployer = false;
                        Employer employer = null;

                        Console.Clear();
                        Configuration.PrintMenu(userHeadMenu);
                        Console.Write("Enter choice: ");
                        choice = Console.ReadLine();

                        while (!Verify.IsChoiceCorrect(choice, userHeadMenu.Length))
                        {
                            Console.WriteLine("\nEnter one of this choices: ");
                            choice = Console.ReadLine();
                        }
                        Console.Clear();

                        if (choice == UserHeadMenuChoices.Exit)
                            break;

                        Console.Write("Enter username: ");
                        userName = Console.ReadLine().Trim();

                        if (database.IsUserNameExist(userName) && choice == UserHeadMenuChoices.Register)
                        {
                            Console.WriteLine("\nUsername exists in database or username is empty or white space, Enter again: ");
                            userName = Console.ReadLine();
                        }

                        Console.Write("Enter password: ");
                        password = Console.ReadLine().Trim();

                        while ((!Verify.IsPasswordStrong(password)) && choice == UserHeadMenuChoices.Register)
                        {
                            Console.WriteLine("\nPassword must contain at least 8 characters");
                            password = Console.ReadLine().Trim();
                        }
                        password = password.GetHashCode().ToString();
                        Console.Clear();

                        if (choice == UserHeadMenuChoices.Register)
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter surname: ");
                            string surname = Console.ReadLine();
                            Console.Write("Enter age: ");
                            string age = Console.ReadLine();

                            while (!Verify.IsPersonAgeMoreThanSeventeen(age))
                            {
                                Console.WriteLine("Age must be more than 17, enter: ");
                                age = Console.ReadLine();
                            }

                            Console.Write("Enter city: ");
                            string city = Console.ReadLine();

                            Console.Write("Enter phone number: ");
                            string phone = Console.ReadLine();

                            while (!Verify.IsPhoneNumberCorrectFormat(phone))
                            {
                                Console.WriteLine("\nPhone number is not correct format: ");
                                phone = Console.ReadLine();
                            }

                            try
                            {
                                employer = new Employer(userName, password, name, surname, age, city, phone);
                                database.Employers.Add(employer);
                                isConfirmedEmployer = true;
                            }
                            catch (Exception caption)
                            {
                                Console.Clear();
                                Console.WriteLine(caption.Message);
                                StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Employer Side");
                            }
                        }
                        else if (choice == UserHeadMenuChoices.Login)
                        {
                            employer = database.Employers.Find(e => e.UserName == userName && e.Password == password);
                            if (employer != null)
                                isConfirmedEmployer = true;
                        }
                        else
                        {
                            Console.WriteLine("See you next time goodbye.");
                            break;
                        }

                        Console.Clear();

                        if (!isConfirmedEmployer)
                            Console.WriteLine("Wrong Credentials");
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome {employer.Name} {employer.Surname} to Boss.az");

                            while (true)
                            {
                                Configuration.PrintMenu(employerSecondMenu);
                                Console.Write("Enter choice: ");
                                choice = Console.ReadLine();

                                while (!Verify.IsChoiceCorrect(choice, employerSecondMenu.Length))
                                {
                                    Console.WriteLine("\nEnter one of this choices: ");
                                    choice = Console.ReadLine();
                                }
                                Console.Clear();

                                if (choice == EmployerSecondMenuChocies.AnnouncementSide)
                                {
                                    EmployerMenus.EmployerAboutAnnouncementSideMenu(database.Workers, employer);
                                }
                                else if (choice == EmployerSecondMenuChocies.WorkerSide)
                                {
                                    EmployerMenus.EmployerAboutWorkerSideMenu(database.Workers, employer);
                                }
                                else
                                {
                                    Console.WriteLine($"Good Luck {employer.Name} {employer.Surname}");
                                    isConfirmedEmployer = false;
                                    break;
                                }
                                Console.Clear();
                            }
                            if (choice == EmployerSecondMenuChocies.Exit)
                                break;
                        }

                    }
                }
                else if (choice == BossFirstMenuChoices.Worker)
                {
                    while (true)
                    {
                        bool isConfirmedUser = false;
                        Worker worker = null;

                        Console.Clear();
                        Configuration.PrintMenu(userHeadMenu);
                        Console.Write("Enter choice: ");
                        choice = Console.ReadLine();

                        while (!Verify.IsChoiceCorrect(choice, userHeadMenu.Length))
                        {
                            Console.WriteLine("\nEnter one of this choices: ");
                            choice = Console.ReadLine();
                        }
                        Console.Clear();

                        if (choice == UserHeadMenuChoices.Exit)
                            break;

                        Console.Write("Enter username: ");
                        userName = Console.ReadLine().Trim();

                        if (database.IsUserNameExist(userName) && choice == UserHeadMenuChoices.Register)
                        {
                            Console.WriteLine("\nUsername exists in database or username is empty or white space, Enter again: ");
                            userName = Console.ReadLine();
                        }

                        Console.Write("Enter password: ");
                        password = Console.ReadLine().Trim();

                        while ((!Verify.IsPasswordStrong(password)) && choice == UserHeadMenuChoices.Register)
                        {
                            Console.WriteLine("\nPassword must contain at least 8 characters");
                            password = Console.ReadLine().Trim();
                        }
                        password = password.GetHashCode().ToString();
                        Console.Clear();

                        if (choice == UserHeadMenuChoices.Register)
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter surname: ");
                            string surname = Console.ReadLine();
                            Console.Write("Enter age: ");
                            string age = Console.ReadLine();

                            while (!Verify.IsPersonAgeMoreThanSeventeen(age))
                            {
                                Console.WriteLine("Age must be more than 17, enter: ");
                                age = Console.ReadLine();
                            }

                            Console.Write("Enter city: ");
                            string city = Console.ReadLine();

                            Console.Write("Enter phone number: ");
                            string phone = Console.ReadLine();

                            while (!Verify.IsPhoneNumberCorrectFormat(phone))
                            {
                                Console.WriteLine("\nPhone number is not correct format: ");
                                phone = Console.ReadLine();
                            }

                            try
                            {
                                worker = new Worker(userName, password, name, surname, age, city, phone);
                                database.Workers.Add(worker);
                                isConfirmedUser = true;
                            }
                            catch (Exception caption)
                            {
                                Console.Clear();
                                Console.WriteLine(caption.Message);
                                StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker Side");
                            }
                        }
                        else if (choice == UserHeadMenuChoices.Login)
                        {
                            worker = database.Workers.Find(w => w.UserName == userName && w.Password == password);
                            if (worker != null)
                                isConfirmedUser = true;
                        }
                        else
                        {
                            Console.WriteLine("See you next time goodbye.");
                            break;
                        }

                        Console.Clear();

                        if (!isConfirmedUser)
                            Console.WriteLine("Wrong Credentials");
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Welcome {worker.Name} {worker.Surname} to Boss.az");
                            while (true)
                            {
                                Configuration.PrintMenu(userSecondMenu);
                                Console.Write("Enter choice: ");
                                choice = Console.ReadLine();

                                while (!Verify.IsChoiceCorrect(choice, userSecondMenu.Length))
                                {
                                    Console.WriteLine("\nEnter one of this choices: ");
                                    choice = Console.ReadLine();
                                }
                                Console.Clear();

                                if (choice == WorkerSecondMenuChoices.Announcements)
                                {
                                    WorkerMenus.WorkerAnnouncementSideMenu(worker, database.Employers);
                                }
                                else if (choice == WorkerSecondMenuChoices.CV)
                                {
                                    WorkerMenus.WorkerCVSideMenu(worker, database.Employers);
                                }
                                else
                                {
                                    Console.WriteLine($"Good Luck {worker.Name} {worker.Surname}");
                                    isConfirmedUser = false;
                                    break;
                                }
                                Console.Clear();
                            }

                            if (choice == WorkerSecondMenuChoices.Exit)
                                break;
                        }


                    }
                }
                else
                {
                    Configuration.PrintMission();
                }

            }

        }

    }
}

