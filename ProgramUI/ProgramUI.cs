using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace ConsoleUI
{
    class ProgramUI
    {
        ClaimRepo Repo { get; set; }
        public ProgramUI(ClaimRepo claimRepo)
        {
            Repo = claimRepo;
        }
        public void Commands()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Komodo Insurance Claims Manager!");
                Console.WriteLine("Type 'Help' for a list of commands");
                string commands = Console.ReadLine();
                if (commands == "Help" || commands == "help")
                {
                    Console.WriteLine("Type 'Add' to add a claim, Type 'Claim' to address the next claim, Type 'List' to see a list of all registered claims, Type 'Done' to exit the program.");
                }
                else if (commands == "Add" || commands == "add")
                {
                    Console.WriteLine("Please put an ID");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Put 1 for car, press 2 for home, press 3 for theft");
                    int qase = int.Parse(Console.ReadLine());
                    string type;
                    switch (qase)
                    {
                        case 1:
                            type = "Car";
                            break;
                        case 2:
                            type = "Home";
                            break;
                        case 3:
                            type = "Theft";
                            break;
                        default:
                            type = "";
                            break;
                    }
                    Console.WriteLine("Please provide a description of the claim");
                    string description = Console.ReadLine();
                    Console.WriteLine("Please provide the amount for the claim");
                    double cost = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please write the date of the incident 'XX/XX/20XX X:XX:XX XM'");
                    DateTime dateIncident = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please write the date of the claim 'XX/XX/20XX X:XX:XX XM'");
                    DateTime dateClaim = DateTime.Parse(Console.ReadLine());
                    ClaimPoco claim = new ClaimPoco(id, type, description, cost, dateIncident, dateClaim);
                    Repo.AddClaim(claim);
                }
                else if (commands == "Claim" || commands == "claim")
                {
                    ClaimPoco temp = Repo.GetNextPoco();
                    Console.WriteLine("ClaimID: " + temp.ClaimID);
                    Console.WriteLine("Type: " + temp.ClaimType);
                    Console.WriteLine("Description: " + temp.Description);
                    Console.WriteLine("Amount: " + temp.ClaimAmount);
                    Console.WriteLine("DateOfAccident: " + temp.DateOfIncident);
                    Console.WriteLine("DateOfClaim: " + temp.DateOfClaim);
                    Console.WriteLine("IsValid: " + temp.IsValid);
                    Console.WriteLine();
                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    char respond = Console.ReadKey().KeyChar;
                    if (respond == 'y' || respond == 'Y')
                    {
                        Repo.RemoveClaim();
                    }
                }
                else if (commands == "List" || commands == "list")
                {

                    List<ClaimPoco> _claims = Repo.GetList();
                    for (int i = 0; i < _claims.Count; i++)
                    {
                        string list = "";
                        list += _claims[i].ClaimID;
                        list += " " + _claims[i].ClaimType + " " + _claims[i].Description + " $" + _claims[i].ClaimAmount + " " + _claims[i].DateOfIncident + " " + _claims[i].DateOfClaim + " " + _claims[i].IsValid;
                        Console.WriteLine(list);
                    }

                }
                else if (commands == "Done" || commands == "done")
                {
                    done = true;
                }
            }
        }
    }
}
