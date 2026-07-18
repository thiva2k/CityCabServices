using System;

namespace CityCabServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cab management system
            CabManagementSystem cabSystem = new CabManagementSystem();

            // Create the menu handler
            MenuHandler menuHandler = new MenuHandler(cabSystem);

            // Main application loop
            bool running = true;
            while (running)
            {
                menuHandler.DisplayMenu();
                string choice = Console.ReadLine();
                running = menuHandler.ProcessMenuChoice(choice);
            }
        }
    }
}
