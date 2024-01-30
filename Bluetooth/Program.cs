using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluetooth
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.startMenu();
            Console.ReadLine();
        }

        private void startMenu()
        {
            Console.WriteLine("BluetoothConnector 0.1");

            BluetoothConnector bc = new BluetoothConnector();
            int choice;
            bool condition = true;
            do
            {
                Console.Write("----------------------------------------------------\n");
                Console.WriteLine("What do you want to do? :\n");
                Console.Write(" 1 - Find a bluetooth adapter\n");
                Console.Write(" 2 - Find bluetooth devices\n");
                Console.Write(" 3 - Send file \n");
                Console.Write(" 4 - Receive file \n");
                Console.Write(" 0 - Finish\n");
                Console.Write("----------------------------------------------------\n");
                Console.Write(" Your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nFinding adapters...");

                        bc.showAllRadios();
                        break;
                    case 2:
                        Console.WriteLine("\nSearching for devices...");
                        bc.scanRemoteDevices();
                        bc.showDiscoveredDevices();
                        break;
                    case 3:
                        Console.WriteLine("Sending a file");
                        Console.WriteLine("What to send?");
                        FileManager fileManager = new FileManager();
                        fileManager.listFiles();
                        int fileIndex = Convert.ToInt32(Console.ReadLine());
                        string filePath = fileManager.getFilePath(fileIndex);

                        Console.WriteLine("To whom?");
                        bc.scanRemoteDevices();
                        bc.showDiscoveredDevices();
                        int deviceIndex = Convert.ToInt32(Console.ReadLine());
                        bc.sendFile(filePath, deviceIndex);
                        break;
                    case 4:
                        Console.WriteLine("Receiving a file");
                        bc.receiveFile();
                        break;

                    case 0:
                        Console.Write("Ending the program");
                        condition = false;
                        break;
                    default:
                        Console.Write("Invalid selection\n");
                        break;
                }
            } while (condition != false);
        }


    }
}
