using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Turtle.Exceptions;

namespace Turtle
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        private static ConsoleRunner _consoleRunner = new ConsoleRunner();

        static void Main(string[] args)
        {
            //Checking for input file with command present or not
            if (args != null && args.Length > 0)
            {
                var filePath = args[0];
                if (File.Exists(filePath))
                {
                    var commandLines = File.ReadAllLines(filePath);

                    if (commandLines != null)
                    {
                        //valid file found in the arguments and processing the commands
                        foreach (var commnadLine in commandLines)
                        { 
                            ProcessCommand(commnadLine);
                        }
                    }
                }
            }

            Console.WriteLine("Please enter a command to proceed or enter \"exit\" to stop:");

            while (true)
            {
                //Getting the command input from the user
                var commandLine = Console.ReadLine();

                if(commandLine.Trim().ToLower() == "exit")
                {
                    break;
                }

                ProcessCommand(commandLine);
            }
        }

        private static void ProcessCommand(string command)
        {
            try
            {
                _consoleRunner.Execute(command, (textToOutput) => { Console.WriteLine(textToOutput); } );
            }
            catch (BadCommandException)
            {
                Console.WriteLine($"Command {command} is not valid. Please enter a valid command");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"System error occured while executing the command and the error is {ex}");
            }
        }
    }
}
