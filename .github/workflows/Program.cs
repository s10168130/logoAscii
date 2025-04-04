using System;
using System.Diagnostics;
using NAudio.Wave;  // Add NAudio namespace for audio playback
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace CybersecurityAwarenessBot
{
    class Program
    {
        // Method to play the voice greeting
        static void PlayVoiceGreeting()
        {
            // Path to the WAV file on your Desktop
            string path = @"C:\Users\RC_Student_lab\source\repos\CybersecurityAwarenessBot\Chatbot_voice_greeting.wav"; // Update with your actual file path

            try
            {
                // Check if the file exists
                if (System.IO.File.Exists(path))
                {
                    // Create an instance of AudioFileReader and WaveOutEvent
                    using (var audioFile = new AudioFileReader(path))
                    using (var outputDevice = new WaveOutEvent())
                    {
                        // Initialize playback with the audio file
                        outputDevice.Init(audioFile);
                        outputDevice.Play();

                        // Wait for playback to finish
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);  // Wait until the sound finishes playing
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: The file '{path}' was not found. Please ensure the file path is correct.");
                }
            }
            catch (Exception e)
            {
                // Catch any error that occurs during playback
                Console.WriteLine($"An error occurred while trying to play the audio: {e.Message}");
            }
        }

        // Method to display ASCII Art
        static void DisplayAsciiArt()
        {
            string asciiArt = @"
              ___           ___     
    ___        /\  \         /\  \    
   /\  \      /::\  \       /::\  \   
   \:\  \    /:/\:\  \     /:/\ \  \  
   /::\__\  /:/  \:\  \   _\:\~\ \  \ 
  __/:/\/__/ /:/__/ \:\__\ /\ \:\ \ \__\
 /\/:/  /    \:\  \  \/__/ \:\ \:\ \/__/
 \::/__/      \:\  \        \:\ \:\__\  
  \:\__\       \:\  \        \:\/:/  /  
   \/__/        \:\__\        \::/  /   
                 \/__/         \/__/    
 Internet     Cyber           Security
            ";

            Console.WriteLine(asciiArt); // Output ASCII Art
        }

        // Method to greet the user
        static void GreetUser()
        {
            // Display greeting message with ASCII art
            DisplayAsciiArt();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello! I am the CyberCat, your cybersecurity awareness assistant!");
            Console.WriteLine("");
            Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.WriteLine("CyberCat>>>  :What is your name?..........can you please write your name your name below !!!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.Write("User>>> :");
            Console.ForegroundColor = ConsoleColor.White;
            // Get user name and display a greeting message
            string userName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please provide your name so I can greet you!");
                userName = Console.ReadLine()?.Trim();
                // Default name if nothing is provided
                Console.ForegroundColor = ConsoleColor.White;
                
                
            }




            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"CyberCat>>> :Nice to meet you,"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine($",{userName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            MainMenu(userName); // Proceed to main menu
        }

        // Main menu with options
        static void MainMenu(string userName)
        {
            bool exit = false;
            while (!exit)
            {

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"CyberCat>>> :What do you want to do," ); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine($",{userName}");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Ask a question");
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine("2. Pet the cat for an advice!");
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("3. Exit");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("CyberCat>>> :Choose an option so that you can proceed");
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.Write($"{userName}>>> :");
                string choice = Console.ReadLine()?.Trim(); // User input for menu selection

                Console.WriteLine("");
                switch (choice)
                {
                    case "1":
                        AskQuestion(userName); // Call the question asking method
                        break;
                    case "2":
                        PetTheCat(userName); // Pet the cat method
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("CyberCat>>>  :Goodbye......");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" { userName} ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("!!!, Stay safe online!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CyberCat>>>  :Invalid input. Please choose 1, 2, or 3.");
                        break;
                }
            }
        }

        // Method to ask questions related to cybersecurity
        static void AskQuestion(string userName)
        {
            // Define a simple dictionary of responses for known topics
            var responses = new System.Collections.Generic.Dictionary<string, string>
            {
                { "what is a password", "A strong password includes a mix of letters, numbers, and special characters to secure your accounts." },
                {"cybersecurity","Cybersecurity is is the practice of protecting systems, networks, and programs from digital attacks.\n These cyberattacks are usually aimed at accessing, changing, or destroying sensitive information; extorting money from users through ransomware" },
                 {"what is cybersecurity","Cybersecurity is is the practice of protecting systems, networks, and programs from digital attacks.\n These cyberattacks are usually aimed at accessing, changing, or destroying sensitive information; extorting money from users through ransomware" },
                  {"tell me about cybersecurity","Cybersecurity is is the practice of protecting systems, networks, and programs from digital attacks.\n These cyberattacks are usually aimed at accessing, changing, or destroying sensitive information; extorting money from users through ransomware" },
                  {"cyber","Cybersecurity is is the practice of protecting systems, networks, and programs from digital attacks.\n These cyberattacks are usually aimed at accessing, changing, or destroying sensitive information; extorting money from users through ransomware" },
                { "tell me about password","A strong password includes a mix of letters, numbers, and special characters to secure your accounts." },
                { "how are you", "I'm feeling great! I'm excited to be teaching you about cybersecurity!" },
                { "what’s your purpose", "My purpose is to help you stay safe online by teaching you about cybersecurity." },
                { "what is a malware", "Malware is malicious software that can harm your computer, like viruses or ransomware." },
                { "malware", "Malware is malicious software that can harm your computer, like viruses or ransomware." },
                { "tell me about malware", "Malware is malicious software that can harm your computer, like viruses or ransomware." },
                { "password", "A strong password includes a mix of letters, numbers, and special characters to secure your accounts." },
                { "tell me about phishing", "Phishing scams trick you into giving away your personal information, usually via email." },
                { "phishing", "Phishing scams trick you into giving away your personal information, usually via email." },
                { "what is phishing", "Phishing scams trick you into giving away your personal information, usually via email." },
                { "tell me about virus", "A virus is a type of malware that can replicate itself and damage your files or system." },
                { "what is a virus", "A virus is a type of malware that can replicate itself and damage your files or system." },
                { "virus", "A virus is a type of malware that can replicate itself and damage your files or system." },
                { "what is safe browsing", "To browse safely, ensure websites are HTTPS, avoid unknown links, and keep your browser up-to-date." },
                { "tell me about safe browsing", "To browse safely, ensure websites are HTTPS, avoid unknown links, and keep your browser up-to-date." },
                { "safe browsing", "To browse safely, ensure websites are HTTPS, avoid unknown links, and keep your browser up-to-date." }
            };
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("CyberCat>>>  :Ask me a cybersecurity question, or type 'quit' to return to the main menu.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{userName}>>>  :");
            string question = Console.ReadLine()?.ToLower()?.Trim();

            if (question == "quit")
            {
                return; // Go back to main menu
            }

            // Check for a response in the dictionary
            if (responses.ContainsKey(question))
            {
                Console.ForegroundColor=ConsoleColor.DarkYellow;
                Console.WriteLine(responses[question]+" \nI hope the feedback was helpful");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, I don't know about that topic. Try to search something related to cybersecurity when you ask a question!\n Try to check if you typed correctly!!!!!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Method for petting the cat
        static void PetTheCat(string userName)
        {
            Console.WriteLine($"ChatBot>>>    :Aw, thanks {userName}! I'm glad you like me!, dont forget to protect your devices from cyber threats!!!!");
        }

        // Main method where execution starts
        static void Main(string[] args)
        {
          new  welcome_massage(){ };
            // Play the voice greeting before starting the program
            
            new logo() { };
            // Greet the user and proceed with the program
            GreetUser();
        }
    }
}
