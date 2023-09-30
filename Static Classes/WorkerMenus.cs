using Boss.AzFinalProject.Static_Classes_about_Worker_Menu_Choices;
using BossAzFinalProject.Entity_Classes;
using BossAzFinalProject.Helper_Static_Classes;
using BossAzFinalProject.Static_Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BossAzFinalProject.Static_Classes
{
    public static class WorkerMenus
    {
        public static void WorkerCVSideUpdateChoiceMenu(Worker worker, List<Employer> employers)
        {
            while (true)
            {
                Console.Clear();
                worker.ShowLessInfoAboutCVs();

                string[] updateForms = Configuration.GetCVSideUpdateChoiceMenu();
                string id = null;

                Console.Write("\nWhich ID do you want to update: ");
                id = Console.ReadLine();

                while (!Verify.IsNumberPositiveInteger(id))
                {
                    Console.WriteLine("\nEnter one of this ID's: ");
                    id = Console.ReadLine();
                }
                Console.Clear();

                CV cv = worker.CV.Find(c => c.ID == int.Parse(id));

                if (cv == null)
                {
                    Console.WriteLine($"There is no ID {id} CV exist in your portfolio");
                    return;
                }

                while (true)
                {
                    string cvHelper = cv.ToString();//prev cv info

                    Console.Clear();
                    cv.ShowMore();
                    Configuration.PrintMenu(updateForms);
                    Console.Write("Enter update choice: ");
                    string choice = Console.ReadLine();

                    while (!Verify.IsChoiceCorrect(choice, updateForms.Length))
                    {
                        Console.WriteLine("\nEnter one of this choices: ");
                        choice = Console.ReadLine();
                    }
                    Console.Clear();

                    if (choice == WorkerCVSideUpdateChoiceMenuChoices.Back)
                        break;

                    if (choice == WorkerCVSideUpdateChoiceMenuChoices.Exit)
                        return;


                    switch (choice)
                    {
                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateBySpeciality:
                            {
                                Console.Write("Enter speciality: ");
                                string speciality = Console.ReadLine();

                                Console.WriteLine("Do you want to add this speciality to your portfolio and don't delete other specialities ?");
                                string result = Console.ReadLine();
                                StringBuilder helper = new StringBuilder();
                                try
                                {
                                    helper.Append(", ")
                                          .Append(speciality);

                                    if (result.ToUpper() == "YES")
                                        cv.Speciality += helper.ToString();
                                    else
                                        cv.Speciality = speciality;

                                    Console.Clear();
                                    Console.WriteLine("Speciality updated successfully");
                                    Thread.Sleep(1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;

                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateByCity:
                            {
                                Console.Write("Enter city: ");
                                string city = Console.ReadLine();

                                Console.WriteLine("Do you want to add this city to your portfolio and don't delete other cities ?");
                                string result = Console.ReadLine();
                                StringBuilder helper = new StringBuilder();
                                try
                                {
                                    helper.Append(", ")
                                          .Append(city);

                                    if (result.ToUpper() == "YES")
                                        cv.City += helper.ToString();
                                    else
                                        cv.City = city;

                                    Console.Clear();
                                    Console.WriteLine("City updated successfully");
                                    Thread.Sleep (1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;

                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateByForeignLanguage:
                            {
                                Console.Write("Enter language: ");
                                string language = Console.ReadLine();

                                Console.WriteLine("Do you want to add this foreign language to your portfolio and don't delete other languages ?");
                                string result = Console.ReadLine();
                                StringBuilder helper = new StringBuilder();

                                try
                                {
                                    helper.Append(", ")
                                          .Append(language);

                                    if (result.ToUpper() == "YES")
                                        cv.ForeignLanguage += helper.ToString();
                                    else
                                        cv.ForeignLanguage = language;

                                    Console.Clear();
                                    Console.WriteLine("Foreign Language updated successfully");
                                    Thread.Sleep(1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;

                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateByWorkedCompanies:
                            {
                                Console.Write("Enter worked company: ");
                                string workerCompany = Console.ReadLine();

                                Console.WriteLine("Do you want to add this worked company to your portfolio and don't delete other worked companies ?");
                                string result = Console.ReadLine() ;
                                StringBuilder helper = new StringBuilder();

                                try
                                {
                                    helper.Append(", ")
                                          .Append(workerCompany);

                                    if (result.ToUpper() == "YES")
                                        cv.WorkedCompanies += helper.ToString();
                                    else
                                        cv.WorkedCompanies = workerCompany;

                                    Console.Clear();
                                    Console.WriteLine("Worked Companies updated successfully");
                                    Thread.Sleep (1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;

                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateBySkills:
                            {
                                Console.Write("Enter skill: ");
                                string skill = Console.ReadLine();
                                Console.WriteLine("Do you want to add this skill to your portfolio and don't delete other skills ?");
                                string result = Console.ReadLine();
                                StringBuilder helper = new StringBuilder();

                                try
                                {
                                    helper.Append(", ")
                                          .Append(skill);

                                    if (result.ToUpper() == "YES")
                                        cv.Skills += helper.ToString();
                                    else
                                        cv.Skills = skill;

                                    Console.Clear();
                                    Console.WriteLine("Skills updated successfully");
                                    Thread.Sleep(1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;

                        case WorkerCVSideUpdateChoiceMenuChoices.UpdateByAll:
                            {
                                try
                                {
                                    CV newCV = CVHelper.CreateNewCV();
                                    cv.Speciality = newCV.Speciality;
                                    cv.School = newCV.School;
                                    cv.Linkedin = newCV.Linkedin;
                                    cv.GitLink = newCV.GitLink;
                                    cv.ForeignLanguage = newCV.ForeignLanguage;
                                    cv.WorkedCompanies = newCV.WorkedCompanies;
                                    cv.Skills = newCV.Skills;
                                    cv.AcceptScore = newCV.AcceptScore;
                                    cv.City = newCV.City;
                                    cv.StartWorkTime = newCV.StartWorkTime;
                                    cv.EndWorkTime = newCV.EndWorkTime;

                                    Console.Clear();
                                    Console.WriteLine("CV updated successfully");
                                    Thread.Sleep(1000);
                                }
                                catch (Exception caption)
                                {
                                    Console.Clear();
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                                Console.Clear();
                            }
                            break;
                    }


                    foreach (var employer in employers)
                    {
                        List<Announcement> all = employer.Announcements.FindAll(ann => ann.appliedWorkersCV.Contains(cvHelper));

                        for (int i = 0; i < all.Count; i++)
                        {
                            for (int j = 0; j < all[i].appliedWorkersCV.Count; j++)
                            {
                                if (all[i].appliedWorkersCV[j].Contains(cvHelper))
                                    all[i].appliedWorkersCV[j] = cv.ToString();
                            }
                        }
                    }
                }
            }

        }
        public static void WorkerCVSideMenu(Worker worker, List<Employer> employers)
        {
            string[] cvSideMenu = Configuration.GetCVSideMenu();
            string id = null;

            while (true)
            {
                Console.Clear();
                worker.ShowLessInfoAboutCVs();
                Console.WriteLine();
                Configuration.PrintMenu(cvSideMenu);
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(choice, cvSideMenu.Length))
                {
                    Console.WriteLine("\nEnter one of this choices: ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

                if (choice == WorkerCVSideMenuChoices.Back)
                {
                    Console.WriteLine("See you soon");
                    Thread.Sleep(1000);
                    break;
                }

                worker.ShowLessInfoAboutCVs();
                Console.WriteLine();
                switch (choice)
                {
                    case WorkerCVSideMenuChoices.ShowMoreWithID:
                        {
                            if (worker.CV.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no CV in your portfolio");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.Write("\nWhich ID do you want to show: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                CV cv = worker.CV.Find(c => c.ID == int.Parse(id));

                                if (cv != null)
                                {
                                    cv.ShowMore();
                                    Console.ReadLine();
                                }
                                else { 
                                    Console.WriteLine($"There is no ID {id} CV exist in your portfolio");
                                    Thread.Sleep(1000);
                                    }
                            }
                        }
                        break;

                    case WorkerCVSideMenuChoices.AddCV:
                        {
                            try
                            {
                                Console.Clear();
                                CV cv = CVHelper.CreateNewCV();
                                worker.CV.Add(cv);
                                Console.WriteLine("CV added successfully to your portfolio");
                                Thread.Sleep(1000);
                            }
                            catch (Exception caption)
                            {
                                Console.WriteLine(caption.Message);
                                StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                            }

                        }
                        break;

                    case WorkerCVSideMenuChoices.DeleteCVWithID:
                        {
                            if (worker.CV.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no CV in your portfolio");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.Write("\nWhich ID do you want to delete: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                try
                                {
                                    worker.IsDeleteCVCorrect(int.Parse(id));
                                    Console.WriteLine($"Do you want to delete CV ID {id} in your portfolio ?");
                                    string result = Console.ReadLine() ;

                                    if (result.ToUpper() == "YES")
                                    {
                                        CV cv = worker.CV.Find(c => c.ID == int.Parse(id));
                                        worker.CV.Remove(cv);

                                        foreach (var employer in employers)
                                        {
                                            List<Announcement> all = employer.Announcements.FindAll(ann => ann.appliedWorkersCV.Contains(cv.ToString()));
                                            for (int i = 0; i < all.Count; i++)
                                            {
                                                all[i].appliedWorkersCV.Remove(cv.ToString());
                                            }

                                            List<Notification> jobOffers = worker.JobOffers.FindAll(jo => jo.Message.EndsWith($"To Your CV ID: {id}"));

                                            foreach (var jobOffer in jobOffers)
                                            {
                                                //job offer olunan annoncementin ID-si ni dasiyan employere notification gonder CV-nin silinmesi barede;
                                                Announcement announcement = employer.Announcements.Find(ann => $"ID: {ann.ID}" == jobOffer.Message.Substring(0, jobOffer.Message.IndexOf('\n') - 1));
                                                if (announcement != null)
                                                {
                                                    employer.notesFromJobOffers.Add(new Notification($"You offered Job ID {announcement.ID}, Speciality: {announcement.Speciality} to Worker ID: {worker.ID}, {worker.Name} {worker.Surname}, but {worker.Name} {worker.Surname} deleted CV ID {id}"));
                                                }
                                            }

                                        }

                                        worker.JobOffers.RemoveAll(jo => jo.Message.EndsWith($"To Your CV ID: {id}"));

                                        Console.WriteLine($"CV ID {long.Parse(id)} deleted successfully");
                                        Thread.Sleep(1000);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"CV ID {id} didn't delete");
                                    }

                                }
                                catch (InvalidOperationException caption)
                                {
                                    Console.WriteLine(caption.Message);
                                    StreamFileWriteHelper.WriteLogErrorFile($"{caption.Message} => Worker: {worker.Name} {worker.Surname}");
                                }
                            }
                        }
                        break;

                    case WorkerCVSideMenuChoices.UpdateCVWithID:
                        {
                            if (worker.CV.Count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no CV in your portfolio");
                                Thread.Sleep(1000);
                            }
                            else
                                WorkerCVSideUpdateChoiceMenu(worker, employers);
                        }
                        break;
                }


            }

        }
        public static void WorkerAnnouncementSideFilterChoiceMenu(Worker worker, List<Employer> employers)
        {
            string[] userAnnouncementSideFilterChoiceMenu = Configuration.GetUserAnnouncementSideFilterChoiceMenu();
            string[] filterMenu = Configuration.GetFilterByMenu();
            string id = null;

            Console.WriteLine();
            Configuration.PrintMenu(filterMenu);
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            while (!Verify.IsChoiceCorrect(choice, filterMenu.Length))
            {
                Console.WriteLine("\nEnter one of this choices: ");
                choice = Console.ReadLine();
            }
            Console.Clear();

            if (choice != FilterBy.PayCheck)
                Console.Write("Enter filter key: ");
            else
                Console.Write("Enter minimum pay check: ");

            string filterKey = Console.ReadLine();
            string maxPayCheck = null;

            if (choice == FilterBy.PayCheck)
            {
                while (!Verify.IsNumberPositiveInteger(filterKey))
                {
                    Console.WriteLine("\nEnter positive number: ");
                    filterKey = Console.ReadLine();
                }

                Console.Write("Enter maximum pay check: ");
                maxPayCheck = Console.ReadLine();
                while ((!Verify.IsNumberPositiveInteger(maxPayCheck)) || int.Parse(maxPayCheck) < int.Parse(filterKey))
                {
                    Console.WriteLine("\nEnter positive number and must be more than minimum pay check: ");
                    maxPayCheck = Console.ReadLine();
                }
            }
            Console.Clear();

            List<Announcement> filteredAnnouncements = new List<Announcement>();

            foreach (var employer in employers)
            {
                List<Announcement> temp = new List<Announcement>();

                if (choice == FilterBy.Speciality)
                {
                    temp = employer.Announcements.FindAll(ann => ann.Speciality == filterKey);
                }
                else if (choice == FilterBy.City)
                {
                    temp = employer.Announcements.FindAll(ann => ann.City == filterKey);
                }
                else
                {
                    temp = employer.Announcements.FindAll(ann => int.Parse(ann.PayCheck) >= int.Parse(filterKey) && int.Parse(ann.PayCheck) <
                    int.Parse(maxPayCheck));
                }
                filteredAnnouncements.AddRange(temp);
            }

            if (filteredAnnouncements.Count == 0)
            {
                Console.WriteLine($"No announcements exist for this => {filterKey}");
                return;
            }

            while (true)
            {
                Console.Clear();
                filteredAnnouncements.ForEach(ann => ann.ShowLess());
                Configuration.PrintMenu(userAnnouncementSideFilterChoiceMenu);
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(choice, userAnnouncementSideFilterChoiceMenu.Length))
                {
                    Console.WriteLine("\nEnter one of this choices: ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

                if (choice == WorkerAnnouncementSideFilterChoiceMenuChoices.Back)
                    break;

                filteredAnnouncements.ForEach(ann => ann.ShowLess());
                switch (choice)
                {
                    case WorkerAnnouncementSideFilterChoiceMenuChoices.ShowMoreAboutAnnouncementWithID:
                        {
                            Console.Write("\nWhich ID do you want to show: ");
                            id = Console.ReadLine();

                            while (!Verify.IsNumberPositiveInteger(id))
                            {
                                Console.WriteLine("\nEnter one of this ID's: ");
                                id = Console.ReadLine();
                            }
                            Console.Clear();

                            Announcement c = filteredAnnouncements.Find(ann => ann.ID == int.Parse(id));

                            if (c != null)
                            {
                                c.ShowMore();
                                c.IncreaseView(worker.UserName);
                                Thread.Sleep(1000);
                                Console.ReadLine();
                            }
                            else { 
                            Console.WriteLine($"There is no ID {id} announcement exist");
                            Thread.Sleep(1000);
                                }

                        }
                        break;
                    case WorkerAnnouncementSideFilterChoiceMenuChoices.ApplyAnnouncementWithID:
                        {
                            if (!worker.IsCVExist())
                            {
                                Console.WriteLine("There is no CV in your portfolio");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.Write("Which ID announcement do you want to apply: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                Announcement announcement = filteredAnnouncements.Find(ann => ann.ID == int.Parse(id));
                                bool flag = true;

                                if (announcement != null)
                                {
                                    foreach (var cv in worker.CV)
                                    {
                                        string thisCV = cv.ToString();
                                        if (announcement.appliedWorkersCV.Contains(thisCV))
                                        {
                                            cv.ShowMore();
                                            Console.WriteLine("Do you want to remove this CV ? You applied this announcement before.");
                                            string result = Console.ReadLine();


                                            if (result.ToUpper() == "YES")
                                            {
                                                Console.Clear();
                                                announcement.appliedWorkersCV.Remove(thisCV);
                                                Console.WriteLine("CV remove successfully");
                                                Thread.Sleep(1000);
                                            }
                                            else
                                                flag = false;

                                            break;
                                        }
                                    }

                                    Console.Clear();
                                }

                                if (announcement != null && flag)
                                {
                                    worker.ShowMoreInfoAboutCVs();

                                    Console.Write("Which ID CV do you want to send to this announcement: ");
                                    id = Console.ReadLine();

                                    while (!Verify.IsNumberPositiveInteger(id))
                                    {
                                        Console.WriteLine("\nEnter one of this ID's: ");
                                        id = Console.ReadLine();
                                    }
                                    Console.Clear();

                                    CV cv = worker.CV.Find(oneCV => oneCV.ID == int.Parse(id));
                                    if (cv != null)
                                    {
                                        announcement.appliedWorkersCV.Add(cv.ToString());
                                        Console.WriteLine($"CV ID {id} sent successfully");
                                    }
                                    else
                                        Console.WriteLine($"There is no ID {id} cv exist in your portfolio");

                                }
                                else
                                    Console.WriteLine($"There is no ID {id} announcement exist or you applied this announcement before");
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                }

            }



        }
        public static void WorkerAnnouncementSideMenu(Worker worker, List<Employer> employers)
        {
            string[] userAnnouncementSideMenu = Configuration.GetUserAnnouncementSideMenu();
            string id = null;

            while (true)
            {
                Console.Clear();
                employers.ForEach(a => a.ShowLessAnnouncements());
                Configuration.PrintMenu(userAnnouncementSideMenu);
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(choice, userAnnouncementSideMenu.Length))
                {
                    Console.WriteLine("\nEnter one of this choices: ");
                    choice = Console.ReadLine();
                }
                Console.Clear();

                if (choice == WorkerAnnouncementSideMenuChoices.Back)
                {
                    Console.WriteLine("See you soon");
                    Thread.Sleep(1000);
                    break;
                }

                employers.ForEach(a => a.ShowLessAnnouncements());
                switch (choice)
                {
                    case WorkerAnnouncementSideMenuChoices.ShowMoreAboutAnnouncementWithID:
                        {
                            bool isAnnouncementExist = false;

                            foreach (var employer in employers)
                            {
                                if (employer.Announcements.Count > 0)
                                {
                                    isAnnouncementExist = true;
                                    break;
                                }
                            }

                            if (!isAnnouncementExist)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no announcement in the system right now");
                            }
                            else
                            {
                                Console.Write("\nWhich ID do you want to show: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                Announcement c = null;
                                foreach (var employer in employers)
                                {
                                    c = employer.Announcements.Find(ann => ann.ID == int.Parse(id));
                                    if (c != null)
                                        break;

                                }

                                if (c != null)
                                {
                                    c.ShowMore();
                                    c.IncreaseView(worker.UserName);                                   
                                }
                                else
                                    Console.WriteLine($"There is no ID {id} announcement exist");
                            }
                            Thread.Sleep(1000);


                        }
                        break;

                    case WorkerAnnouncementSideMenuChoices.ApplyAnnouncementWithID:
                        {
                            bool isAnnouncementExist = false;

                            foreach (var employer in employers)
                            {
                                if (employer.Announcements.Count > 0)
                                {
                                    isAnnouncementExist = true;
                                    break;
                                }
                            }

                            if (!isAnnouncementExist)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no announcement exist in the system right now");
                                Thread.Sleep(1000);
                            }
                            else if (!worker.IsCVExist())
                            {
                                Console.Clear();
                                Console.WriteLine("There is no CV in your portfolio");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.Write("Which ID announcement do you want to apply: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                bool isEmployerSendThisIDJobToThisWorker = false;
                                foreach (var employer in employers)
                                {
                                    if (worker.JobOffers.Find(jo => jo.Message.Substring(0, jo.Message.IndexOf('\n') - 1) == $"ID: {long.Parse(id)}") != null)
                                    {
                                        isEmployerSendThisIDJobToThisWorker = true;
                                        break;
                                    }
                                }

                                if (worker.acceptedAnnouncementID.Find(key => key == long.Parse(id)) != 0)
                                {
                                    Console.WriteLine("Employer Accepted you to this work or you Accepted this work and you can not send CV");
                                    Thread.Sleep(1000);
                                }
                                else if (isEmployerSendThisIDJobToThisWorker)
                                {
                                    Console.WriteLine($"Employer Send ID {id} job to your job offers box");
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    Announcement announcement = null;
                                    foreach (var employer in employers)
                                    {
                                        announcement = employer.Announcements.Find(ann => ann.ID == int.Parse(id));
                                        if (announcement != null)
                                            break;
                                    }
                                    bool flag = true;

                                    if (announcement != null)
                                    {
                                        foreach (var cv in worker.CV)
                                        {
                                            string thisCV = cv.ToString();
                                            if (announcement.appliedWorkersCV.Contains(thisCV))
                                            {
                                                cv.ShowMore();
                                                Console.WriteLine("Do you want to remove this CV ? You applied this announcement before.");
                                                string result = Console.ReadLine();

                                                if (result.ToUpper() == "YES")
                                                {
                                                    Console.Clear();
                                                    announcement.appliedWorkersCV.Remove(thisCV);
                                                    Console.WriteLine("CV remove successfully");
                                                    Thread.Sleep(1000);
                                                }
                                                else
                                                    flag = false;

                                                break;
                                            }
                                        }

                                        Console.Clear();
                                    }


                                    if (announcement != null && flag)
                                    {
                                        worker.ShowMoreInfoAboutCVs();

                                        Console.Write("Which ID CV do you want to send to this announcement: ");
                                        id = Console.ReadLine();

                                        while (!Verify.IsNumberPositiveInteger(id))
                                        {
                                            Console.WriteLine("\nEnter one of this ID's: ");
                                            id = Console.ReadLine();
                                        }
                                        Console.Clear();

                                        CV cv = worker.CV.Find(oneCV => oneCV.ID == long.Parse(id));
                                        if (cv != null)
                                        {
                                            announcement.appliedWorkersCV.Add(cv.ToString());
                                            Console.WriteLine($"CV ID {id} sent successfully");
                                        }
                                        else
                                            Console.WriteLine($"There is no ID {id} cv exist in your portfolio");
                                        Thread.Sleep(1000);

                                    }
                                    else
                                        Console.WriteLine($"There is no ID {id} announcement exist or you applied this announcement before");
                                    Thread.Sleep(1000);
                                }


                            }
                        }
                        break;

                    case WorkerAnnouncementSideMenuChoices.Filter:
                        {
                            bool isAnnouncementExist = false;

                            foreach (var employer in employers)
                            {
                                if (employer.Announcements.Count > 0)
                                {
                                    isAnnouncementExist = true;
                                    break;
                                }
                            }

                            if (!isAnnouncementExist)
                            {
                                Console.Clear();
                                Console.WriteLine("There is no announcement exist in the system right now");
                                Thread.Sleep(1000);
                            }
                            else
                                WorkerAnnouncementSideFilterChoiceMenu(worker, employers);
                        }
                        break;

                    case WorkerAnnouncementSideMenuChoices.ShowNotifications:
                        {
                            Console.Clear();
                            if (worker.IsNotificationExist()) 
                            { 
                            worker.ShowNotifications();
                            Console.WriteLine("All done");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.WriteLine("There are not any notifications in the portfolio");
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    case WorkerAnnouncementSideMenuChoices.ShowJobOffersWithID:
                        {
                            Console.Clear();
                            if (worker.JobOffers.Count != 0)
                            {
                                worker.ShowJobOffers();

                                Console.Write("\nWhich ID do you want to choose, when you choose you jump to accept or reject page: ");
                                id = Console.ReadLine();

                                while (!Verify.IsNumberPositiveInteger(id))
                                {
                                    Console.WriteLine("\nEnter one of this ID's: ");
                                    id = Console.ReadLine();
                                }
                                Console.Clear();

                                if (worker.JobOffers.Find(jo => jo.Message.Substring(0, jo.Message.IndexOf('\n') - 1) == $"ID: {long.Parse(id)}") != null)
                                {
                                    foreach (var employer in employers)
                                    {
                                        Announcement respond = employer.Announcements.Find(ann => ann.ToString().StartsWith($"ID: {long.Parse(id)}"));
                                        if (respond != null)
                                        {
                                            Console.WriteLine($"Do you want to Accept {respond.Speciality} Job ?");
                                            string result = Console.ReadLine(); 

                                            if (result.ToUpper() != "NO")
                                            {
                                                Notification jobOffer = worker.JobOffers
                                                .Find(jo => jo.Message.Substring(0, jo.Message.IndexOf('\n') - 1) == $"ID: {long.Parse(id)}");

                                                worker.JobOffers.Remove(jobOffer);
                                            }

                                            if (result.ToUpper() == "YES")
                                            {
                                                employer.notesFromJobOffers.Add(new Notification($"ID: {worker.ID}, {worker.Name} {worker.Surname} Accepts Job\n\n{respond}"));
                                                worker.acceptedAnnouncementID.Add(long.Parse(id));
                                            }
                                            else if (result.ToUpper() == "NO")
                                            {
                                                employer.notesFromJobOffers.Add(new Notification($"ID: {worker.ID}, {worker.Name} {worker.Surname} Rejects Job\n\n{respond}"));
                                            }

                                            Console.WriteLine($"Operation {result} done succesfully");
                                            Thread.Sleep(1000);

                                            break;
                                        }
                                    }
                                }
                                else
                                    Console.WriteLine("Wrong Id selected");
                                Thread.Sleep(1000);
                            }
                            else
                                Console.WriteLine("There is no job offer in your portfolio");
                            Thread.Sleep(1000);

                        }
                        break;
                }

            }

        }
    }
}