/*-------------------------------------------------------------------------------------------------
 // C# program for Hash Table-Open Addressing

 * The program will register players' username and ages, then be able to print
 * First the register agent will be asked to enter the number of players that need to be registered
 * Then each player will be ask to enter their username and year of birth only
 * The program will automatically calculate each player current age 
 * Then the program will print each player's number of stored position in the program following by
   username, current age and year of birth.
 * Then the agent will be able to Edit or delete any registered player's info
 * And finally print the Edit and delete list of players.
------------------------------------------------------------------------------------------------*/


using System;
using System.Collections;

namespace HashtableProgram
{
    class MainClass
    {
        static Hashtable userInfoHash;

   
        /*------------ Add Method ------------*/
        static void UserEntry(int slot)
        {
            for (int i = 0; i < slot; i++) //Looping through the number of Slot
            {
                Console.WriteLine("Enter username and year of birth");

                string username = Console.ReadLine(); //Get the user input(Username)
                int birthYear = Convert.ToInt32(Console.ReadLine()); //Get user input(Birth Year)

                DateTime thisDay = DateTime.Today; //Get the current date 
                int Year = thisDay.Year; // Get the Current Year
                int age = Year - birthYear; // Calculate the current Age of the user

                userInfoHash.Add(i, "Username: " + username + ", Age: " +
                                age + ", Birth Year: " + birthYear + "."); // Add it to the Slot[]
            }
            Console.WriteLine("\n");
            Console.WriteLine("The Original List is: ");
            PrintData();
        }

        /*------------ Remove Method ------------*/
        static void DeleteEntry()
         {
            Console.WriteLine("\n");
            Console.WriteLine("Enter the Key number you want to delete");

            int i = Convert.ToInt32(Console.ReadLine()); //Get the slot record to delete 
            if (userInfoHash.ContainsKey(i)) //Check if the Slot is there 
            {
                Console.WriteLine("The Updated List after Deleting the key: " + i + " is: ");
                userInfoHash.Remove(i); // removing the slot[]
                PrintData(); //print the current table
            }
            else
            {
                Console.WriteLine("the Key: " + i + " doesn't exist to delete");
            }
         }

        /*------------ Edit Method ------------*/
        static void EditEntry()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter the key number, then username or the year to edit ");
            int i = Convert.ToInt32(Console.ReadLine());
            string username = Console.ReadLine(); //Get the user input(Username)
            int year = Convert.ToInt32(Console.ReadLine()); //Get user input(Birth Year)

            DateTime thisDay = DateTime.Today;
            int Year = thisDay.Year;
            int age = Year - year;
            if (userInfoHash.ContainsKey(i))
            {
                Console.WriteLine("The Updated List after editing the key: " + i + " is: ");
                userInfoHash[i] = ("Username: " + username + ", Age: " +
                                age + ", Birth Year: " + year + ".");
                PrintData();
            }
            else
            {
                Console.WriteLine("the Key: " + i + " doesn't exist to edit");
            }

        }
        /*------------ Print Method ------------*/
        static void PrintData()
        {
            //Looping to print the users data
            foreach (DictionaryEntry entry in userInfoHash)
            {
                Console.WriteLine("Key: " + entry.Key + " / Value: " + entry.Value);
            }
        }

    static void Main(string[] args)
        {
            userInfoHash = new Hashtable();

            Console.WriteLine("Enter the number of Users you want to enter");
            int slotNumber = Convert.ToInt32(Console.ReadLine()); //Getting the length of the table

            UserEntry(slotNumber); //Calling the Add method 
            EditEntry(); //Calling the Edit method 
            DeleteEntry(); //Calling the Delete method 
        }
    }
}