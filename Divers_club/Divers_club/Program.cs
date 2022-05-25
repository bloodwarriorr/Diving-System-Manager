using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //init vars and add a bunch of object to start

            List<DivingClub> divingClub_list = new List<DivingClub>();
            int userChoice;
            int partner_cohice;
            bool isLoggedIn = false;
            string dive_club;
            DivingSite diving_site = null;
            List<Diver> diving_users_list = new List<Diver>();
            List<Diver> diving_partner_list = new List<Diver>();
            List<DivingSite> sites = new List<DivingSite>();
            DivingClub diveClub= null;
            Diver user = null;
            List<Country> country_list = new List<Country>();
            List<Instractor> instractors = new List<Instractor>();
            string[] equipmentArr = { "Go pro", "Knife", "Oxygen bottle" };

            //init vars
            InitVarsAndStartingData(diving_users_list, country_list, sites, instractors,divingClub_list);
            //program
            while (true)
            {
                Console.Clear();
                HeadLine(user, diveClub, diving_partner_list.Count);
                FirstMenu();
                userChoice = ValidateReadLine();
               if (userChoice == -1)
                {
                    Console.ReadKey();
                    continue;
                }

               switch (userChoice)
                {
                    case 1:
                        user= diving_users_list != null?Login(diving_users_list) :null;
                        isLoggedIn=user!=null;
                        if (!isLoggedIn)
                        {
                            Console.WriteLine("User not exist in the system");
                            Console.ReadKey();
                        }
                        break;
                        case 2:
                        Register(diving_users_list);
                        break;
                       case 3:
                        return;
                }
                Console.Clear();
                while (isLoggedIn)
                {
                    Console.Clear();

                    HeadLine(user, diveClub, diving_partner_list.Count);
                    SecondMenu();
                    userChoice = ValidateReadLine();

                    if (userChoice == -1)
                        continue;

                    switch (userChoice)
                    {
                        case 1:
                            if (diveClub != null && diving_partner_list.Count > 0)
                            {
                                diving_site = AddDiveSite(sites, diveClub);
                            }
                            if (diving_site != null)
                                AddDiveToDiver(diving_site, user, diving_partner_list, diveClub, instractors, equipmentArr);
                            break;
                        case 2:
                            Console.WriteLine("Enter Dive club name or enter country name(type 'list' to show all dive clubs)");
                            dive_club = Console.ReadLine();
                            DivingClub temp = null;
                            if (dive_club == "list")
                            {
                                temp = DivingClubList(divingClub_list);
                                diveClub = temp == null ? diveClub : temp;
                            }
                            foreach (DivingClub club in divingClub_list)
                            {
                                if (club.GetClubName() == dive_club)
                                    diveClub = club;
                            }

                            foreach (Country country in country_list)
                            {
                                if (dive_club == country.GetName())
                                {
                                    temp = ClubChooseAccordingToCountry(divingClub_list, country);
                                    diveClub = temp == null ? diveClub : temp;
                                }

                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter your partner id, or add new partner by typing 2");
                            partner_cohice = ValidateReadLine();
                            if (partner_cohice == -1)
                                break;
                            PartnerCheck(partner_cohice, diving_users_list, diving_partner_list, user);
                            break;
                        case 4:
                            Console.WriteLine("Enter country name");
                            string country_name = Console.ReadLine();

                            foreach (Country country in country_list)
                            {
                                if (country.GetName() == country_name)
                                {
                                    Console.WriteLine(country.GetDivingRegulations());
                                    Console.ReadKey();
                                }
                            }

                            break;
                        case 5:
                            user = null;
                            isLoggedIn = false;
                            diveClub = null;
                            diving_partner_list = new List<Diver>();
                            break;
                        case 6:
                            if (user.GetDiveList() != null)
                                ShowDivingList(user.GetDiveList());
                            break;
                        case 7:
                            Console.WriteLine("Diver rank:");
                            Console.WriteLine(user.GetDiverRank());
                            Console.ReadKey();
                            break;


                    }
                }
            }    





        }
        //validate partner details help method
        private static void PartnerCheck(int partner_cohice, List<Diver> users_list, List<Diver> partner_list,Diver user)
        {
           
            if (partner_cohice == 2)
            {
                Register(users_list);
                partner_list.Add(users_list[users_list.Count - 1]);
            }
            else if (partner_cohice == user.GetId())
            {
                Console.WriteLine("You can't add yourself!!");
                Console.ReadKey();
                return;
            }


            else
            {
                bool check = false;
                foreach (Diver diver in users_list)
                {
                    if (diver.GetId() == partner_cohice)
                    {
                        partner_list.Add(diver);
                        Console.WriteLine($"{diver.GetFirstName()} was added Successfuly");
                        check = true;
                        Console.ReadKey();
                        break;
                    }
                }
                if (!check)
                    Console.WriteLine("Not Found!");
            }
            Console.ReadKey();
        }

        //init vars function
        public static void InitVarsAndStartingData(List<Diver> users_list, List<Country> country_list, List<DivingSite> sites, List<Instractor> instractors, List<DivingClub> divingClub_list)
        {

            users_list.Add(new Diver(147852369, "David", "Beckham", new DateTime(1987, 11, 12), "123456789", "David@gmail.com"));
            users_list.Add(new Diver(369852147, "Chris", "Day", new DateTime(1999, 10, 10), "123698745", "Chris@gmail.com"));
            country_list.Add(new Country("Israel", $"In order to dive as a certified diver you must:\n1.be 12 years old and above\n" +
                     $"2.Own Personal diving certification\n3.have a Diving insurance\n4.dived in the last six months"));
            country_list.Add(new Country("Thailand", $"In order to dive as a certified diver you must:\n1.be 12 years old and above\n" +
                   $"2.Own Personal diving certification\n3.have a Diving insurance\n4.dived in the last six months"));



           
            divingClub_list.Add(new DivingClub(555474, "Reef Eilat", "John", "Almogim 14 Eilat", country_list[0], 0502456987, "DiveReefEilat.co.il"));
            divingClub_list.Add(new DivingClub(258746, "Ko Phi Phi", "Andrew", "Ko Phi Phi Don Thailand", country_list[1], 555487435, "KoPhiPhi.com"));

            sites.Add(new DivingSite("Eilat-Reef", country_list[0], "Israel Eilat Reef", "Wonderfull place very clean", "salty_water", 30, 40, divingClub_list[0]));
            sites.Add(new DivingSite("Ko Phi Phi Don", country_list[1], "Ko Phi Phi Don Thailand", "The most beautifull place on planet to dive in", "sweet_water", 50, 100, divingClub_list[1]));


            instractors.Add(new Instractor(264587435, "Moshon", "Avnet", new DateTime(1970, 11, 11), "444555666", "Moshon@g.com",
            new DateTime(2016, 01, 03), new DateTime(2022, 01, 01), divingClub_list[0]));

            instractors.Add(new Instractor(369874521, "Mawai", "desdunf", new DateTime(1964, 05, 05), "888999777", "Mawai@gmail.com",
            new DateTime(2018, 06, 03), new DateTime(2021, 01, 01), divingClub_list[1]));

        }
        //function to validate int type inputs
        public static int ValidateReadLine()
        {
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return -1;
            }
            return choice;

        }
        //validate instractor before addition
        public static bool InstractorValidate(List<Instractor> instractors_list, Dive dive, DivingClub club)
        {
            foreach (Instractor instractor in instractors_list)
            {
                if (instractor.GetClub().CompareTo(club) == 0)
                {

                    if (dive.GetDiveDate() >= instractor.GetStartDate() && dive.GetDiveDate() <= instractor.GetEndDate())
                    {

                       
                        dive.SetGuide(instractor);
                        return true;
                       
                    }
                }
              

            }
            return false;
        }
        //diving equipment add
        public static void AddEquipmentToDive(string[] equipment, Dive dive)
        {
            Console.WriteLine("Add Equipment");
            int index = 0, amount = 0;
            string description = "";

            foreach (string item in equipment)
            {
                index++;
                Console.WriteLine($"{index}) {item}");
            }

            while (true)
            {
                Console.WriteLine("choose index to add gear 0 to exit");
                index = ValidateReadLine();
                if (index == -1)
                    continue;
                if (index == 0)
                    break;
                Console.WriteLine("choose amount");
                amount = ValidateReadLine();
                if (amount == -1)
                    continue;
                Console.WriteLine("add description");
                description = Console.ReadLine();
                Equipment equip = new Equipment(equipment[index - 1], amount, description);
                dive.AddGear(equip);
            }
        }
        //set diving time
        public static void SetStartAndEndDivingTime(int startingMinute,int startingHour,Dive dive,DateTime dive_date)
        {
            Console.WriteLine("Enter start time:");
            Console.WriteLine("Hours:");
            startingHour = ValidateReadLine();
            if (startingHour == -1)
                return;
            Console.WriteLine("Minutes");
            startingMinute = ValidateReadLine();
            if (startingMinute == -1)
                return;
            DateTime full_start_diving_date = new DateTime(dive_date.Year, dive_date.Month, dive_date.Day, startingHour, startingMinute, 0);
            dive.SetDiveStartTime(full_start_diving_date);

            Console.WriteLine(dive.GetDiveStartTime());

            Console.WriteLine("Enter End time:");
            Console.WriteLine("Hours:");
            startingHour = ValidateReadLine();
            if (startingHour == -1)
                return;
            Console.WriteLine("Minutes");
            startingMinute = ValidateReadLine();
            if (startingMinute == -1)
                return;
            DateTime end = new DateTime(dive_date.Year, dive_date.Month, dive_date.Day, startingHour, startingMinute, 0);
            dive.SetDiveEndTime(end);
            Console.WriteLine(dive.GetDiveEndTime());
            Console.WriteLine($"The dive was approved by {dive.GetGuide().GetFirstName()}");
        }
        //program headline to show who is logged in
        public static void HeadLine(Diver user, DivingClub club, int partners)
        {
            string displayname;
            if (user == null)
            {
                displayname = "null";
            }
            else
            {
                displayname = user.GetFirstName();
            }
            string club_name;
            if (club == null)
            {
                club_name = "null";
            }
            else
            {
                club_name = club.GetClubName();
            }
            Console.WriteLine($"User: {displayname} \t\t\t\t  Dive Club: {club_name} \t\t\t\t Dive-Partners: {partners}");
            if (user == null)
                Console.WriteLine("Welcome To ProDiver 1.0");
            else
                Console.WriteLine("Welcome,");
            Console.WriteLine("############");
        }
        //first menu -login,register,exit
        public static void FirstMenu()
        {
            Console.WriteLine("Welcome! take action:\n1.Login\n2.Register\n3.Exit");
        }
        //second menu-after signed up
        public static void SecondMenu()
        {
            Console.WriteLine("Welcome! please take a pick:\n1.Add Dive\n2.Enter DiveClub\n3.Add Diving Partner/s\n4.Display Diving regualtions By Country" +
                "\n5.Login menu\n6.Dive list\n7.Show diver rank");
        }
        //login function
        public static Diver Login(List<Diver> users)
        {
            Diver user = null;
            int userId;
            string userPassword;


            Console.WriteLine("Insert your id:");
            userId = ValidateReadLine();
            if (userId == -1)
                return null;


            Console.WriteLine("Insert your password");
            userPassword = Console.ReadLine();



            foreach (Diver diver in users)
            {
                if (diver.GetId().Equals(userId) && diver.GetPassword().Equals(userPassword))
                {
                    user = diver;
                    break;
                }

            }

            return user;

        }
        //register method
        public static void Register(List<Diver> users)
        {
            Regex emailPattern = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Regex passwordPattern = new Regex("^[a-z0-9]{8,}$");
            int userId;
            string firstName, lastName, password, email;
            DateTime date;
            Console.WriteLine("Insert Id");
            userId = ValidateReadLine();
            if (userId == -1)
            {
                Console.WriteLine("invalid id pattern");
                return;
            }
            if (userId.ToString().Length < 7)
            {
                Console.WriteLine("Bad id pattern");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter your first name");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter password-at least 8 digits contain ");
            password = Console.ReadLine();
            if (!passwordPattern.IsMatch(password))
            {
                Console.WriteLine("Invalid password");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Insert your date of birth");
            date = DateInput(true);


            if (date == DateTime.MinValue)
            {
                return;
            }


            Console.WriteLine("enter your email");
            email = Console.ReadLine();


            if (!emailPattern.IsMatch(email))
            {
                Console.WriteLine("email input is wrong!");
                Console.ReadKey();
                return;
            }
            Diver diver = new Diver(userId, firstName, lastName, date, password, email);
            users.Add(diver);


        }
        //date validation
        public static DateTime DateInput(bool dob = false)
        {
            int year, month, day;
            bool date_birth_check = true;
            Console.WriteLine("enter year: yyyy ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("enter month: mm");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("enter day: dd");
            day = int.Parse(Console.ReadLine());
            DateTime myDateTime = DateTime.Now;
            string today_year = myDateTime.Year.ToString();
            if (dob && year > (int.Parse(today_year) - 18))
            {
                date_birth_check = false;
            }


            if (year < 1902 || !date_birth_check || month < 1 || month > 12 || day < 1 || day > 31)
            {
                Console.WriteLine("Bad/invalid date pattern");
                Console.ReadKey();
                return new DateTime();
            }
            return new DateTime(year, month, day);
        }
        //return club by country according to specific choice of the diver
        public static DivingClub ClubChooseAccordingToCountry(List<DivingClub> divingClub_list, Country country)
        {
            int choice, index = 0;


            foreach (DivingClub club in divingClub_list)
            {
                index++;
                if (club.GetCountry().GetName() == country.GetName())
                    Console.WriteLine($"{index}){club.GetClubName()} Country: {club.GetCountry().GetName()}");
            }
            choice = ValidateReadLine();
            if (choice == -1)
                return null;
            index = 0;

            foreach (DivingClub club in divingClub_list)
            {
                index++;
                if (index == choice && club.GetCountry() == country)
                    return club;
            }

            return null;
        }
        // show all clubs and chose according to their index
        public static DivingClub DivingClubList(List<DivingClub> divingClub_list)
        {
            int index = 0, clubChoice;
            Console.WriteLine("Choose club to dive in according to index:");
            foreach (DivingClub club in divingClub_list)
            {
                index++;
                Console.WriteLine($"{index}){club.GetClubName()}\t\t {club.GetCountry().GetName()}");
            }
            clubChoice = ValidateReadLine();
            if (clubChoice == -1)
                return null;
            if (clubChoice >= 1 && clubChoice <= index)
                return divingClub_list[clubChoice - 1];
            else
                return null;



        }
        //show all dives of a specifig diver-if he has any
        public static void ShowDivingList(List<Dive> diveList)
        {
            foreach (Dive dive in diveList)
            {
                Console.WriteLine($"Club Name: {dive.GetClub().GetClubName()}");
                Console.WriteLine($"Site Name: {dive.GetSite().GetSitesName()}");
                Console.WriteLine($"Instractor Name: {dive.GetGuide().GetFirstName()}");
                Console.WriteLine($"Diving Date: {dive.GetDiveDate().ToString("d")}");
                Console.WriteLine($"Equipment");
                if (dive.GetGearList().Count > 0)
                    foreach (Equipment item in dive.GetGearList())
                    {
                        Console.WriteLine($"Equip: {item.GetEquipmentType()}");
                        Console.WriteLine($"Amount of item: {item.GetAmount()}");
                        Console.WriteLine($"Ps: {item.GetPs()}");
                        Console.WriteLine("###############################");
                    }
                Console.WriteLine("###############################");
            }
            Console.ReadKey();
        }
        //add a diving site
        public static DivingSite AddDiveSite(List<DivingSite> sites, DivingClub club)
        {
            int index = 0, choice;
            string index_list = "";
            Console.WriteLine("Enter dive site index:");

            foreach (DivingSite site in sites)
            {
                index++;
                if (site.GetSiteClub().CompareTo(club) == 0)
                {
                    Console.WriteLine($"{index}){site.GetSitesName()}");
                    index_list += index + ",";
                }
            }
            choice = ValidateReadLine();
            if (choice == -1)
                return null;
            if (index_list.IndexOf($"{choice}") != -1)
                return sites[choice - 1];
            else
                return null;

        }
        //add dive to a diver-according to all rules
        public static void AddDiveToDiver(DivingSite site, Diver diver, List<Diver> ptlist, DivingClub club, List<Instractor> instractors_list, string[] equipment)
        {
            //add new dive object,date,water temp
            Dive dive = new Dive();
            bool instractor_validate = false;
            int tideType,startingHour=0,startingMinute=0;
            DateTime diving_date;
            double water_temperature;
            //add the site and the club the diving takes place
            dive.SetSites(site);
            dive.SetClub(club);
           //tide check
            Console.WriteLine("chose Tide type: 0=low, 1=high");
            tideType = ValidateReadLine();
            if (tideType == -1)
            {
                Console.WriteLine("invalid choice");
                return;
            }
            if (tideType != 0 && tideType != 1)
            {
                Console.WriteLine("invalid choice");
                return;
            }
            //water temp check
            Console.WriteLine("choose water temperature");
            try
            {
                water_temperature = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            dive.SetWaterTemp(water_temperature);
            //diving date check
            Console.WriteLine("Enter diving date");
            diving_date = DateInput();
            if (diving_date == DateTime.MinValue)
            {
                return;
            }

            dive.SetDiveDate(diving_date);
            //instractor validation 
            instractor_validate = InstractorValidate(instractors_list,dive, club);
            if (!instractor_validate)
            {
                Console.WriteLine("Unconfirmed dive-there was no instarcor worked at the given date");
                return;
            }
            Console.WriteLine($"Date added successfuly {dive.GetDiveDate()}");
            //set start and end time
            SetStartAndEndDivingTime(startingMinute, startingHour, dive, diving_date);
            //clone dive
            foreach (Diver partner in ptlist)
            {
                partner.AddDive((Dive)dive.Clone());
            }
            //add diving equipment
            AddEquipmentToDive(equipment, dive);
            diver.AddDive(dive);
            Console.ReadKey();
        }
        




    }
}
