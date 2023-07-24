using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FinalCLIProject.BL;
using FinalCLIProject.DL;
using FinalCLIProject.UI;
namespace FinalCLIProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralUI.printWelcome();
            ElectedPartyDL.loadDatafromElectedPartiesfile();
            PollingStationDL.loadDatafromPsfile();
            VoterDL.readDataFromVotersFile();
            string login = PersonDL.readDatafromlogin("LoginFile.txt");
            if (login == null)
            {
                GeneralUI.displayMsg("\n\n\n\n\t\t Data from login file is loaded...");
            }
            else
            {
                GeneralUI.displayMsg(login);
            }
            Console.ReadKey();
            string option = "0";
            do
            {
                Console.Clear();
                GeneralUI.header();
                option = GeneralUI.loginMenu();
                bool check = PersonDL.isValidInputOption(option);
                if(!check)
                {
                    GeneralUI.displayMsg("Invalid Input ): ");
                }
                else
                {
                    if(option == "1")
                    {
                        Console.Clear();
                        GeneralUI.header();
                                                 //Sign Up 
                        Person p = PersonUI.takeInput();
                        if(PersonDL.isValidPerson(p.getCnic()))
                        {
                            PersonDL.signUp(p); // Calls Sign up function
                            Console.ForegroundColor = ConsoleColor.Blue;
                            GeneralUI.displayMsg("\n <<< Remember that login name and password in order to sign in with that account >>>");
                            GeneralUI.displayMsg("\n SIGNED UP SUCCESSFULLY !!!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            GeneralUI.displayMsg("\n Cnic already founded. Don't behave like a malacious user (: ");
                        }
                    }
                    else if(option == "2")
                    {
                        Console.Clear();
                        GeneralUI.header();
                        //Sign In
                        if (PersonDL.returnUsers() != null)
                        {
                            string name = PersonUI.inputName();
                            string password = PersonUI.inputPassword();
                            Person p = PersonDL.signIn(name, password); // Calls Sign in function
                            if (p == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                GeneralUI.displayMsg("No User Found!!!! Sign up First...");
                            }
                            else if (p.getRole() == "Admin")
                            {
                                string choice = "0";
                                // Admin Menu
                                while (choice != "17")
                                {
                                    Console.Clear();
                                    choice = PersonUI.AdminMenu();
                                    if (choice == "1")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        //Adds elected party
                                        GeneralUI.displayMsg("########### ADD ELECTIVE Parties ##########");
                                        ElectedParty e = ElectedPartyUI.takeInputForElectedParty();
                                        if (e == null)
                                        {
                                            GeneralUI.displayMsg("Party already exists.....");
                                        }
                                        else
                                        {
                                            ElectedPartyDL.addIntoPartiesList(e);
                                            ElectedPartyDL.storeToElectedPartiesFile(e);
                                            GeneralUI.displayMsg("\n\n<<<Party added Successfully>>>");
                                        }
                                        Console.ReadKey();
                                    }
                                    else if (choice == "2")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        //deletes elected Party
                                        GeneralUI.displayMsg("########### Delete ELECTIVE Party ##########");
                                        string n = ElectedPartyUI.inputPartyName();
                                        bool flag = ElectedPartyDL.delParty(n);
                                        if (flag == true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            GeneralUI.displayMsg("\n\n" + " is deleted successfully...");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            GeneralUI.displayMsg("\n\nParty of this name is not Found..");
                                        }
                                        Console.ReadKey();
                                    }
                                    else if (choice == "3")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Search for a party
                                        ElectedParty p2 = ElectedPartyDL.searchParty(ElectedPartyUI.inputForSearchParty());
                                        if (p2 == null)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            GeneralUI.displayMsg("\n\tParty not exists....");
                                        }
                                        else
                                        {
                                            ElectedPartyUI.displaySearchedParty(p2);
                                        }

                                    }
                                    else if (choice == "4")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // View all parties
                                        ElectedPartyUI.viewParties(ElectedPartyDL.returnList());

                                    }
                                    else if (choice == "5")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // update Elected Party
                                        ElectedParty a = ElectedPartyUI.takeInputForElectedParty();
                                        if (a == null)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            GeneralUI.displayMsg("\nNo, existing party....");
                                        }
                                        else
                                        {
                                            if (ElectedPartyDL.isPartyExists(a.getPartyName()))
                                            {
                                                int index = ElectedPartyDL.getIndexOfSpecificParty(a.getPartyName());
                                                ElectedPartyDL.updateParty(a, index);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                GeneralUI.displayMsg("Updated Successfully!!!");
                                            }
                                        }

                                    }
                                    else if (choice == "6")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Add a polling station functions
                                        GeneralUI.displayMsg("\n************* ADD POLLING STATIONS ************\n");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        PollingStation p1 = new PollingStation("", "", "");
                                        p1 = PollingStationUI.takeInputInPs();
                                        bool flag = PollingStationDL.validPS(p1.getName(), p1.getCode());
                                        if (flag == true)
                                        {
                                            PollingStationDL.AddPs(p1);
                                            PollingStationDL.storeToPsFile(p1);
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            GeneralUI.displayMsg("Polling station added Successfully !!! ");
                                        }
                                        else
                                        {
                                            GeneralUI.displayMsg("\nPolling Station ALREADY EXISTS!!! ");
                                        }
                                        Console.ReadKey();
                                    }
                                    else if (choice == "7")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // delete polling station
                                        string delPs;
                                        GeneralUI.displayMsg("<><><><>< Deleting Polling station ><><><><>");
                                        delPs = PollingStationUI.inputName();
                                        int index = PollingStationDL.indexOfPs(delPs);
                                        if (index>=0)
                                        {
                                            PollingStationDL.deletePs(index);
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            GeneralUI.displayMsg("Polling station " + delPs + " is deleted successfully. \n");
                                            PollingStationDL.updatePsFile();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            GeneralUI.displayMsg("Polling station not found.\n");
                                        }
                                        Console.ReadKey();
                                    }

                                    else if (choice == "8")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // update polling Station
                                        string Ps;
                                        GeneralUI.displayMsg("<><><><>< Updating Polling station ><><><><>");
                                        Ps = PollingStationUI.inputName();
                                        int flag = PollingStationDL.indexOfPs(Ps);
                                        if (flag != -1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            PollingStation update = PollingStationUI.takeInputInPs();
                                            PollingStationDL.updatePs(update, flag);
                                            GeneralUI.displayMsg("Updated Successfully !!!\n");
                                        }
                                        else
                                        {
                                            GeneralUI.displayMsg("Polling station not found ): \n");
                                        }
                                        Console.ReadKey();

                                    }
                                    else if (choice == "9")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Search a pollingStation
                                        PollingStation ps = PollingStationDL.searchPs(PollingStationUI.inputName());
                                        PollingStationUI.viewSearchParty(ps);

                                    }
                                    else if (choice == "10")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // View all polling Stations
                                        PollingStationUI.viewPs(PollingStationDL.getPollingStations());

                                    }
                                    else if (choice == "11")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // View Voters Details
                                        VoterUI.viewVotersDetails();

                                    }
                                    else if (choice == "12")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Search for response of specific voter
                                        string n = PersonUI.inputName();
                                        Voter v = VoterDL.voterExists(n);
                                        VoterUI.viewVoter(v);

                                    }
                                    else if (choice == "13")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Result Declaration
                                        ElectedPartyDL.sortElectedParties();
                                        ElectedPartyUI.viewWinnerParty(ElectedPartyDL.returnList());
                                    }
                                    else if (choice == "14")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // View feedbacks
                                        VoterUI.viewFeddbacks();

                                    }
                                    else if (choice == "15")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // View all Accounts Details
                                        PersonUI.viewAllUsers();

                                    }
                                    
                                    else if (choice == "16")
                                    {
                                        Console.Clear();
                                        PersonUI.adminInterface();
                                        GeneralUI.showChoice(choice);
                                        // Add admin
                                        Person p1 = PersonUI.takeInputWithRole();
                                        if (PersonDL.isValidPerson(p1.getCnic()))
                                        {
                                            PersonDL.signUp(p1);
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            GeneralUI.displayMsg("\n <<< Remember that login name and password in order to sign in with that account >>>");
                                            GeneralUI.displayMsg("\n Admin Added SUCCESSFULLY !!!");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            GeneralUI.displayMsg("\n ID already found. Kindly sign up with unique ID (: ");
                                        }

                                    }
                                    GeneralUI.displayMsg("Press any key to continue...");
                                    Console.ReadKey();
                                }

                            }
                            else
                            {
                                string choice = "0";
                                while (choice != "10")
                                {
                                    Console.Clear();
                                    choice = VoterUI.userMenu();
                                    bool flag = PersonDL.isValidInputOption(choice);
                                    if (flag == false)
                                    {
                                        Console.WriteLine("Invalid Option");
                                    }
                                    else
                                    {
                                        if (choice == "1")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > View Polling stations");
                                            // View all polling stations
                                            PollingStationUI.viewPs(PollingStationDL.getPollingStations());
                                        }
                                        else if (choice == "2")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Search Polling stations");
                                            // Search a pollingStation
                                            PollingStation ps = PollingStationDL.searchPs(PollingStationUI.inputName());
                                            PollingStationUI.viewSearchParty(ps);
                                        }
                                        else if (choice == "3")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > View Elected Parties");
                                            // View all parties
                                            ElectedPartyUI.viewParties(ElectedPartyDL.returnList());
                                        }
                                        else if (choice == "4")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Search Elected Parties");
                                            ElectedParty p2 = ElectedPartyDL.searchParty(ElectedPartyUI.inputForSearchParty());
                                            if (p2 == null)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                GeneralUI.displayMsg("\n\tParty not exists....");
                                            }
                                            else
                                            {
                                                ElectedPartyUI.displaySearchedParty(p2);
                                            }
                                        }
                                        else if (choice == "5")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Cast Vote\n\n");
                                            //ElectedPartyUI.viewParties(ElectedPartyDL.returnList());
                                            // Vote Casting
                                            Voter v = VoterUI.takeInputForVoteCasting();
                                            if (v != null)
                                            {
                                                ElectedParty e = ElectedPartyDL.searchParty(v.getVotedParty());
                                                e.incrementVotesCount();
                                                VoterDL.castVote(v);
                                                GeneralUI.displayMsg("Voted successfully.");
                                                Console.ReadLine();
                                            }
                                        }
                                        else if (choice == "6")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > View your response");
                                            //see your response
                                            string voter = PersonUI.inputName();
                                            Voter v = VoterDL.voterExists(voter);
                                            VoterUI.viewVoter(v);
                                        }
                                        else if (choice == "7")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Update your response");
                                            // update response
                                            string voter = PersonUI.inputName();
                                            Voter v = VoterDL.voterExists(voter);
                                            if (v != null)
                                            {
                                                GeneralUI.displayMsg("<<<<<<<<<<<<<< Enter your updated Info Here >>>>>>>>>>>>>>>>>>");
                                                string person = PersonUI.inputName();
                                                string pass = PersonUI.inputPassword();
                                                string gender = PersonUI.inputGender();
                                                v.setName(person);
                                                v.setPassword(pass);
                                                v.setGender(gender);
                                                VoterDL.updateVoterFile();
                                                GeneralUI.displayMsg("Your Profile updated Successfully.");
                                            }
                                            else
                                            {
                                                GeneralUI.displayMsg("Not valid voter");
                                            }
                                        }
                                        else if (choice == "8")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Give your feedback");
                                            // Give feedback
                                            string n = PersonUI.inputCnic();
                                            Voter v = VoterDL.voterExists(n);
                                            if (v != null)
                                            {
                                                String feedback = VoterUI.takeFeedback();
                                                v.setFeedback(feedback);
                                            }
                                            else
                                            {
                                                GeneralUI.displayMsg("Voter not found.");
                                            }
                                            Console.ReadLine();
                                        }
                                        else if (choice == "9")
                                        {
                                            Console.Clear();
                                            VoterUI.userInterface();
                                            GeneralUI.subMenu(" SignIn menu > User menu > Check your vote status");
                                            // Vote Status
                                            bool flag1 = VoterDL.isVoterExists(PersonUI.inputCnic());
                                            if (flag1 == true)
                                            {
                                                GeneralUI.displayMsg("You have voted successfully..");
                                            }
                                            else
                                            {
                                                GeneralUI.displayMsg("You have not voted yet....");
                                            }
                                            Console.ReadKey();
                                        }
                                        GeneralUI.displayMsg("Press sny key to continue...");
                                        Console.ReadLine();

                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            GeneralUI.displayMsg("No, member registered. You need to sign up first");
                            Console.ResetColor();
                        }
                    }
                    else if (option != "1" && option != "2" && option != "3")
                    {
                        GeneralUI.displayMsg(" Invalid input ): ");
                    }   
                }
                GeneralUI.displayMsg("Press any key to continue...");
                Thread.Sleep(100);
                Console.ReadLine();
            } while (option != "3");
        }
    }
}
