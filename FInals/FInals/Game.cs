using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NAudio.Wave;
using static System.Console;

namespace FInals
{
    
    public class Game
    {
        private WaveOutEvent waveOut;


        public void Start()
        {
            Title = "Word Snake!";
            waveOut = new WaveOutEvent();
            start();
            LoadingScreen();
            Console.ReadKey(true);
            StopAudio();
            Console.WriteLine("                           Please click the full screen button to continue and then press enter");
            Console.ReadKey(true);
            song();
            RunMainMenu();
        }
        private void RunMainMenu()
        {
            string prompt = @"
                                                     ▄█     █▄   ▄██████▄     ▄████████ ████████▄          ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████ 
                                                    ███     ███ ███    ███   ███    ███ ███   ▀███        ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███ 
                                                    ███     ███ ███    ███   ███    ███ ███    ███        ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀  
                                                    ███     ███ ███    ███  ▄███▄▄▄▄██▀ ███    ███        ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     
                                                    ███     ███ ███    ███ ▀▀███▀▀▀▀▀   ███    ███      ▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀     
                                                    ███     ███ ███    ███ ▀███████████ ███    ███               ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  
                                                    ███ ▄█▄ ███ ███    ███   ███    ███ ███   ▄███         ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ 
                                                     ▀███▀███▀   ▀██████▀    ███    ███ ████████▀        ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ 
                                                                             ███    ███                                                       ▀                      
                                                           Welcome to our Word Snake Game. I hope you have fun (use ARROW KEYS TO NAVIGATE AND ENTER TO CHOOSE)";

            string[] options = { @"

                                                                                                      ╔═╗╦  ╔═╗╦ ╦
                                                                                                      ╠═╝║  ╠═╣╚╦╝
                                                                                                      ╩  ╩═╝╩ ╩ ╩    ", @"
                                                                                                 ╔╦╗╦ ╦╔╦╗╔═╗╦═╗╦╔═╗╦  
                                                                                                  ║ ║ ║ ║ ║ ║╠╦╝║╠═╣║  
                                                                                                  ╩ ╚═╝ ╩ ╚═╝╩╚═╩╩ ╩╩═╝ ", @"
                                                                                                     ╔═╗╔╗ ╔═╗╦ ╦╔╦╗
                                                                                                     ╠═╣╠╩╗║ ║║ ║ ║ 
                                                                                                     ╩ ╩╚═╝╚═╝╚═╝ ╩    ", @"
                                                                                                   ╔═╗╦═╗╔═╗╔╦╗╦╔╦╗╔═╗
                                                                                                   ║  ╠╦╝║╣  ║║║ ║ ╚═╗
                                                                                                   ╚═╝╩╚═╚═╝═╩╝╩ ╩ ╚═╝ ", @"
                                                                                                       ╔═╗═╗ ╦╦╔╦╗
                                                                                                       ║╣ ╔╩╦╝║ ║ 
                                                                                                       ╚═╝╩ ╚═╩ ╩   " };
            Menu mainMenu = new Menu(prompt, options);
            int SelectedIndex = mainMenu.Run();

            switch (SelectedIndex)
            {
                case 0:
                    
                    RunPlay();
                    break;
                case 1:
                    DisplayTutorial();
                    break; 
                case 2:
                    DisplayAbout();
                    break;
                case 3:
                    DisplayCredits();
                    break;
                case 4:
                    ExitGame();
                    break;

            }

        }
        public string difficulty = "";
        public void RunPlay()
            
        {
            Clear();
            string prompt = @"
                       ██████  ██      ███████  █████  ███████ ███████     ███████ ███████ ██      ███████  ██████ ████████     ██████  ██ ███████ ███████ ██  ██████ ██    ██ ██      ████████ ██    ██ 
                       ██   ██ ██      ██      ██   ██ ██      ██          ██      ██      ██      ██      ██         ██        ██   ██ ██ ██      ██      ██ ██      ██    ██ ██         ██     ██  ██  
                       ██████  ██      █████   ███████ ███████ █████       ███████ █████   ██      █████   ██         ██        ██   ██ ██ █████   █████   ██ ██      ██    ██ ██         ██      ████   
                       ██      ██      ██      ██   ██      ██ ██               ██ ██      ██      ██      ██         ██        ██   ██ ██ ██      ██      ██ ██      ██    ██ ██         ██       ██    
                       ██      ███████ ███████ ██   ██ ███████ ███████     ███████ ███████ ███████ ███████  ██████    ██        ██████  ██ ██      ██      ██  ██████  ██████  ███████    ██       ██                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
";
            string[] options = { @"
                                                                                           ███████  █████  ███████ ██    ██ 
                                                                                           ██      ██   ██ ██       ██  ██  
                                                                                           █████   ███████ ███████   ████   
                                                                                           ██      ██   ██      ██    ██    
                                                                                           ███████ ██   ██ ███████    ██    ", @"
                                                                                ███╗   ███╗███████╗██████╗ ██╗██╗   ██╗███╗   ███╗
                                                                                ████╗ ████║██╔════╝██╔══██╗██║██║   ██║████╗ ████║
                                                                                ██╔████╔██║█████╗  ██║  ██║██║██║   ██║██╔████╔██║
                                                                                ██║╚██╔╝██║██╔══╝  ██║  ██║██║██║   ██║██║╚██╔╝██║
                                                                                ██║ ╚═╝ ██║███████╗██████╔╝██║╚██████╔╝██║ ╚═╝ ██║
                                                                                ╚═╝     ╚═╝╚══════╝╚═════╝ ╚═╝ ╚═════╝ ╚═╝     ╚═╝", @"
                                                                                           ██░ ██  ▄▄▄       ██▀███  ▓█████▄ 
                                                                                          ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▒██▀ ██▌
                                                                                          ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒░██   █▌
                                                                                          ░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ░▓█▄   ▌
                                                                                          ░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒░▒████▓ 
                                                                                           ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░ ▒▒▓  ▒ ", @"
                                                                          ▄▀▀▄ ▄▄   ▄▀▀█▄▄▄▄  ▄▀▀▀▀▄    ▄▀▀▀▀▄     ▄▀▀█▀▄   ▄▀▀▀▀▄  ▄▀▀▄ ▄▄  
                                                                         █  █   ▄▀ ▐  ▄▀   ▐ █    █    █    █     █   █  █ █ █   ▐ █  █   ▄▀ 
                                                                         ▐  █▄▄▄█    █▄▄▄▄▄  ▐    █    ▐    █     ▐   █  ▐    ▀▄   ▐  █▄▄▄█  
                                                                            █   █    █    ▌      █         █          █    ▀▄   █     █   █  
                                                                           ▄▀  ▄▀   ▄▀▄▄▄▄     ▄▀▄▄▄▄▄▄▀ ▄▀▄▄▄▄▄▄▀ ▄▀▀▀▀▀▄  █▀▀▀     ▄▀  ▄▀  
                                                                           █   █     █    ▐     █         █        █       █ ▐       █   █    
                                                                           ▐   ▐     ▐          ▐         ▐        ▐       ▐         ▐   ▐    " };
            Menu mainMenu = new Menu(prompt, options);
            int SelectedIndex = mainMenu.Run();
            
            switch (SelectedIndex)
            {

                case 0:
                    StopAudio();
                    game();
                    Easy easy = new Easy();
                    SnakeEasy snakeEasy = new SnakeEasy();
                    while (snakeEasy.isGameRunning)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        snakeEasy.WhiteBoard();
                        snakeEasy.Input();
                        Console.ForegroundColor = ConsoleColor.Green;
                        snakeEasy.logic();
                    }
                    if (snakeEasy.isGameOver == true)
                    {
                        StopAudio();
                        ded();
                        Console.WriteLine(@"










                                                                  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                                                                  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                                                                 ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                                                                 ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                                                                 ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                                                                ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                                                                ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                                                              ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                                                                    ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                                                                                                 ░                   
");
                        Console.WriteLine(@"


                                                                                  Please Press Enter To return in MainMenu");
                    }
                   
                    if (snakeEasy.isGameFinish == true)
                    {
                        StopAudio();
                        win();
                        Console.WriteLine(@"










                                                                         ██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
                                                                         b██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
                                                                          ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
                                                                           ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
                                                                            ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
                                                                            ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
");
                        Console.WriteLine(@"

                                                                                Please Press Enter To Return in MainMenu");
                    }
                    Console.ReadKey();
                    StopAudio();
                    song();
                    RunMainMenu();
                    Console.ReadKey();

                    break;
                case 1:
                    StopAudio();
                    game();
                    Medium medium = new Medium();
                    SnakeMedium snakeMedium = new SnakeMedium();
                    while (snakeMedium.isGameRunning)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        snakeMedium.WhiteBoard();
                        snakeMedium.Input();
                        Console.ForegroundColor = ConsoleColor.Green;
                        snakeMedium.logic();
                    }
                    if (snakeMedium.isGameOver == true)
                    {
                        StopAudio();
                        ded();
                        Console.WriteLine(@"










                                                                  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                                                                  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                                                                 ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                                                                 ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                                                                 ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                                                                ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                                                                ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                                                              ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                                                                    ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                                                                                                 ░                   
");
                        Console.WriteLine(@"


                                                                                  Please Press Enter To return in MainMenu");
                    }
                    if (snakeMedium.isGameFinish == true)
                    {
                        StopAudio();
                        win();
                        Console.WriteLine(@"










                                                                         ██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
                                                                         b██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
                                                                          ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
                                                                           ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
                                                                            ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
                                                                            ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
");
                        Console.WriteLine(@"

                                                                                Please Press Enter To Return in MainMenu");
                    }
                    Console.ReadKey();
                    StopAudio();
                    song();
                    RunMainMenu();
                    Console.ReadKey();

                    break;
                case 2:
                    StopAudio();
                    game();
                    Hard hard = new Hard();
                    SnakeHard snakeHard = new SnakeHard();
                    while (snakeHard.isGameRunning)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        snakeHard.WhiteBoard();
                        snakeHard.Input();
                        Console.ForegroundColor = ConsoleColor.Green;
                        snakeHard.logic();
                    }
                    if (snakeHard.isGameOver == true)
                    {
                        StopAudio();
                        ded();
                        Console.WriteLine(@"










                                                                  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                                                                  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                                                                 ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                                                                 ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                                                                 ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                                                                ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                                                                ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                                                              ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                                                                    ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                                                                                                 ░                   
");
                        Console.WriteLine(@"


                                                                                  Please Press Enter To return in MainMenu"); 
                    }
                    if (snakeHard.isGameFinish == true)
                    {
                        StopAudio();
                        win() ;
                        Console.WriteLine(@"










                                                                         ██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
                                                                         b██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
                                                                          ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
                                                                           ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
                                                                            ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
                                                                            ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
");
                        Console.WriteLine(@"

                                                                                Please Press Enter To Return in MainMenu");
                    }
                    Console.ReadKey();
                    StopAudio();
                    song();
                    RunMainMenu();
                    Console.ReadKey();
                    break;
                    case 3:
                    StopAudio();
                    game();
                    Hellish hellish = new Hellish();
                    SnakeHellish snakeHellish = new SnakeHellish();
                    while (snakeHellish.isGameRunning)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        snakeHellish.WhiteBoard();
                        snakeHellish.Input();
                        Console.ForegroundColor = ConsoleColor.Green;
                        snakeHellish.logic();
                    }
                    if (snakeHellish.isGameOver == true)
                    {
                        StopAudio();
                        ded();
                        Console.WriteLine(@"










                                                                  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                                                                  ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                                                                 ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                                                                 ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                                                                 ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                                                                ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                                                                ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                                                              ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                                                                    ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                                                                                                 ░                   
");
                        Console.WriteLine(@"


                                                                                  Please Press Enter To return in MainMenu");
                    }
                    if (snakeHellish.isGameFinish == true)
                    {
                        StopAudio();
                        win();
                        Console.WriteLine(@"










                                                                         ██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗
                                                                         b██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║
                                                                          ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║
                                                                           ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║
                                                                            ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║
                                                                            ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝
                                                      
");
                        Console.WriteLine(@"

                                                                                Please Press Enter To Return in MainMenu");
                    }
                    Console.ReadKey();
                    StopAudio();
                    song();
                    RunMainMenu();
                    Console.ReadKey();
                    break;
            }
        }
        private void DisplayTutorial()
        {
            Clear();
            Console.WriteLine(@"

                                  █     █░▓█████  ██▓     ▄████▄   ▒█████   ███▄ ▄███▓▓█████    ▄▄▄█████▓ ▒█████     ▄▄▄█████▓ █    ██ ▄▄▄█████▓ ▒█████   ██▀███   ██▓ ▄▄▄       ██▓    
                                 ▓█░ █ ░█░▓█   ▀ ▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀    ▓  ██▒ ▓▒▒██▒  ██▒   ▓  ██▒ ▓▒ ██  ▓██▒▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒▓██▒▒████▄    ▓██▒    
                                 ▒█░ █ ░█ ▒███   ▒██░    ▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒███      ▒ ▓██░ ▒░▒██░  ██▒   ▒ ▓██░ ▒░▓██  ▒██░▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒▒██▒▒██  ▀█▄  ▒██░    
                                 ░█░ █ ░█ ▒▓█  ▄ ▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ▒▓█  ▄    ░ ▓██▓ ░ ▒██   ██░   ░ ▓██▓ ░ ▓▓█  ░██░░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄  ░██░░██▄▄▄▄██ ▒██░    
                                 ░░██▒██▓ ░▒████▒░██████▒▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░▒████▒     ▒██▒ ░ ░ ████▓▒░     ▒██▒ ░ ▒▒█████▓   ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒░██░ ▓█   ▓██▒░██████▒
                                   ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░     ▒ ░░   ░ ▒░▒░▒░      ▒ ░░   ░▒▓▒ ▒ ▒   ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░▓   ▒▒   ▓▒█░░ ▒░▓  ░
                                     ▒ ░ ░   ░ ░  ░░ ░ ▒  ░  ░  ▒     ░ ▒ ▒░ ░  ░      ░ ░ ░  ░       ░      ░ ▒ ▒░        ░    ░░▒░ ░ ░     ░      ░ ▒ ▒░   ░▒ ░ ▒░ ▒ ░  ▒   ▒▒ ░░ ░ ▒  ░
                                   ░   ░     ░     ░ ░   ░        ░ ░ ░ ▒  ░      ░      ░        ░      ░ ░ ░ ▒       ░       ░░░ ░ ░   ░      ░ ░ ░ ▒    ░░   ░  ▒ ░  ░   ▒     ░ ░   
                                       ░       ░  ░    ░  ░░ ░          ░ ░         ░      ░  ░                ░ ░                 ░                  ░ ░     ░      ░        ░  ░    ░  ░
                                       ░                                                                                                                              

");
            Console.WriteLine(@"



             HOW TO MOVE THE SNAKE                                                                                            WHAT ARE THE MECHANICS OF THE GAME?

            
             PRESS THE LETTER W TO MOVE THE SNAKE UPWARD      ↑                                                              STEP 1: YOU WILL CHOOSE DIFFICULTY AFTER YOU ENTER PLAY 
             PRESS THE LETTER S TO MOVE THE SNAKE DOWNWARD    ↓                                                              STEP 2: DEPENDING ON THE DIFFICULTY YOU CHOOSED YOU WILL GIVEN A RANDOM WORD
             PRESS THE LETTER D TO MOVE THE SNAKE RIGHTWARD   —>                                                             STEP 3: THE LETTER OF THE RANDOM WORD WILL SPAWN ON THE PLAYING FIELD OF YOUR SNAKE 
             PRESS THE LETTER A TO MOVE THE SNAKE LEFTWARD    <—                                                             STEP 4: TRY TO AVOID THE WRONG LETTER AND EAT ONLY THE RIGHT ONE 
                                               

                                                                            PRESS ANY KEY TO RETURN IN MAIN MENU.........

");
            ReadKey(true);
            Console.WriteLine(@"
                                                                         ╔╦╗╦ ╦╔╦╗╔═╗╦═╗╦╔═╗╦    ╔═╗╔═╗╔╦╗╔═╗╦  ╔═╗╔╦╗╔═╗╔╦╗
                                                                          ║ ║ ║ ║ ║ ║╠╦╝║╠═╣║    ║  ║ ║║║║╠═╝║  ║╣  ║ ║╣  ║║
                                                                          ╩ ╚═╝ ╩ ╚═╝╩╚═╩╩ ╩╩═╝  ╚═╝╚═╝╩ ╩╩  ╩═╝╚═╝ ╩ ╚═╝═╩╝                                                     

                                                                            ");
            ReadKey(true);
            RunMainMenu();




        }
        private void DisplayAbout()
        {
            Clear();
            Console.WriteLine(@"

                                                                                      █████  ██████   ██████  ██    ██ ████████ 
                                                                                     ██   ██ ██   ██ ██    ██ ██    ██    ██    
                                                                                     ███████ ██████  ██    ██ ██    ██    ██    
                                                                                     ██   ██ ██   ██ ██    ██ ██    ██    ██    
                                                                                     ██   ██ ██████   ██████   ██████     ██    




                                        ----------------------------------------------------------------------------------------------------------------------------------------                                
                                        |                 The captivating game Word Snake was created as the final project for the Fundamentals in Programming subject.        |
                                        |       Three dedicated individuals worked together to finish this project, testing their programming abilities in the process,        |
                                        |       and the result is this game. Players of Word Snake must make their way through a world of words and letter that tests their    |
                                        |       vocabulary and rapid thinking. The game offers players an enjoyable method to improve their word knowledge and because         |
                                        |       it is made to be both educational and entertaining.The development of Word Snake required cooperation, problem-solving         |
                                        |       abilities, and a firm understand of the fundamentals of programming.We put out a lot of effort, each bringing a special        |
                                        |       set of abilities to the project,and the end product is a game that is interesting, difficult, and a reflection of their        |
                                        |       learning and perseverance over the semester.Word Snake is more than just a game, it's a representation of the skills           |
                                        |       learned in the Fundamentals in Programming subject and the commitment of us developers who made it happen.It is evidence       |
                                        |       of our educational path and our love for computer programming.                                                                 |
                                        |                                                                                                                                      |
                                        |                                                                                                                                      |
                                        |                                                                                                                                      |
                                        |                                            Press any Key to Return in MainMenu............                                           |
                                        ----------------------------------------------------------------------------------------------------------------------------------------

");
            ReadKey(true);
            RunMainMenu();
        }
        private void DisplayCredits() 
        {
            Clear();
            Console.WriteLine(@"
     
                                                                                        
                                                                                        
                                                                                 ██████ ██████  ███████ ██████  ██ ████████ ███████               
                                                                                ██      ██   ██ ██      ██   ██ ██    ██    ██                    
                                                                                ██      ██████  █████   ██   ██ ██    ██    ███████               
                                                                                ██      ██   ██ ██      ██   ██ ██    ██         ██               
                                                                                 ██████ ██   ██ ███████ ██████  ██    ██    ███████                                                                                                                                                                                                                   
                                                                  
                                                                          █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ █████ 
                                                                                                                                                       


                                        ----------------------------------------------------------------------------------------------------------------------------------------                                                     
                                        |      ╔╦╗╔═╗╦  ╦╔═╗╦  ╔═╗╔═╗  ╔╗ ╦ ╦ o                                                                                                |
                                        |       ║║║╣ ╚╗╔╝║╣ ║  ║ ║╠═╝  ╠╩╗╚╦╝                                                                                                  |
                                        |      ═╩╝╚═╝ ╚╝ ╚═╝╩═╝╚═╝╩    ╚═╝ ╩  o                                                                                                |
                                        |                                            ╦╔╦╗╔═╗╔═╗╔╗╔   ╦╦ ╦╔═╗╔╦╗╦╔╗╔╔═╗  ╦═╗╦ ╦╔═╗╔═╗╔═╗╦╔═╗  ╔═╗                               |
                                        |                                            ║║║║╚═╗║ ║║║║   ║║ ║╚═╗ ║ ║║║║║╣   ╠╦╝╠═╣║╣ ║ ╦║ ╦║║╣   ║ ║                               |
                                        |                                            ╩╩ ╩╚═╝╚═╝╝╚╝  ╚╝╚═╝╚═╝ ╩ ╩╝╚╝╚═╝  ╩╚═╩ ╩╚═╝╚═╝╚═╝╩╚═╝  ╚═╝                               |
                                        |                                                          FRONTEND AND BACKEND DEVELOPER                                              |
                                        |                                                 ╔╦╗╔═╗╔╗╔╔╦╗╔═╗╔═╗╔═╗  ╔═╗╦═╗╦ ╦╔═╗╔═╗╔═╗╔╗╔  ╔═╗                                    |
                                        |                                                 ║║║║╣ ║║║ ║║║ ║╔═╝╠═╣  ║ ╦╠╦╝╚╦╝╠═╝╚═╗║ ║║║║  ╠═╣                                    |
                                        |                                                 ╩ ╩╚═╝╝╚╝═╩╝╚═╝╚═╝╩ ╩  ╚═╝╩╚═ ╩ ╩  ╚═╝╚═╝╝╚╝  ╩ ╩                                    |                   
                                        |                                                          FRONTEND AND BACKEND DEVELOPER                                              | 
                                        |                                                 ╔╦╗╔═╗╦  ╔═╗╔═╗╦╔═╗ ╦ ╦╔═╗  ╔═╗╔╗╔╔╦╗╦═╗╔═╗╦  ╔╦╗                                    |
                                        |                                                 ║║║╠═╣║  ╠═╣╚═╗║║═╬╗║ ║║╣   ╠═╣║║║ ║║╠╦╝║╣ ║  ║║║                                    |
                                        |                                                 ╩ ╩╩ ╩╩═╝╩ ╩╚═╝╩╚═╝╚╚═╝╚═╝  ╩ ╩╝╚╝═╩╝╩╚═╚═╝╩  ╩ ╩                                    |
                                        |                                                          FRONTEND AND BACKEND DEVELOPER                                              | 
                                        |                                                                                                                                      |
                                        |                                                                                                                                      |
                                        |     ╔╦╗╦ ╦╔═╗╦╔═╗  ╔╗ ╦ ╦ o                                                                                                          |
                                        |     ║║║║ ║╚═╗║║    ╠╩╗╚╦╝                                                                                                            |
                                        |     ╩ ╩╚═╝╚═╝╩╚═╝  ╚═╝ ╩  o                                                                                                          |
                                        |                                                                                                                                      |
                                        |                                                               ╔═╗╦═╗ ╦╔═╗╔╗ ╔═╗╦ ╦                                                   |
                                        |                                                               ╠═╝║╔╩╦╝╠═╣╠╩╗╠═╣╚╦╝                                                   |
                                        |                                                               ╩  ╩╩ ╚═╩ ╩╚═╝╩ ╩ ╩                                                    |
                                        |                                                                                                                                      |
                                        |                                                                                                                                      |
                                        |                                                                                                                                      |
                                        |                                                               FONTS BY: PATORJk.COM                                                  |
                                        |                                                        Press any Key to Return in MainMenu............                               |           
                                        ----------------------------------------------------------------------------------------------------------------------------------------

");
            ReadKey(true);
            RunMainMenu();

        }
        private void ExitGame()
        {
            Clear();
            Console.WriteLine(@" 
                                   ██████╗ ██████╗ ███████╗███████╗███████╗     █████╗ ███╗   ██╗██╗   ██╗    ██╗  ██╗███████╗██╗   ██╗    ████████╗ ██████╗     ███████╗██╗  ██╗██╗████████╗            
                                   ██╔══██╗██╔══██╗██╔════╝██╔════╝██╔════╝    ██╔══██╗████╗  ██║╚██╗ ██╔╝    ██║ ██╔╝██╔════╝╚██╗ ██╔╝    ╚══██╔══╝██╔═══██╗    ██╔════╝╚██╗██╔╝██║╚══██╔══╝            
                                   ██████╔╝██████╔╝█████╗  ███████╗███████╗    ███████║██╔██╗ ██║ ╚████╔╝     █████╔╝ █████╗   ╚████╔╝        ██║   ██║   ██║    █████╗   ╚███╔╝ ██║   ██║               
                                   ██╔═══╝ ██╔══██╗██╔══╝  ╚════██║╚════██║    ██╔══██║██║╚██╗██║  ╚██╔╝      ██╔═██╗ ██╔══╝    ╚██╔╝         ██║   ██║   ██║    ██╔══╝   ██╔██╗ ██║   ██║               
                                   ██║     ██║  ██║███████╗███████║███████║    ██║  ██║██║ ╚████║   ██║       ██║  ██╗███████╗   ██║          ██║   ╚██████╔╝    ███████╗██╔╝ ██╗██║   ██║               
                                   ╚═╝     ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝       ╚═╝  ╚═╝╚══════╝   ╚═╝          ╚═╝    ╚═════╝     ╚══════╝╚═╝  ╚═╝╚═╝   ╚═╝               
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                                                                                                                                                                      
                             ████████╗██╗  ██╗ █████╗ ███╗   ██╗██╗  ██╗    ██╗   ██╗ ██████╗ ██╗   ██╗    ███████╗ ██████╗ ██████╗     ██████╗ ██╗      █████╗ ██╗   ██╗██╗███╗   ██╗ ██████╗     
                             ╚══██╔══╝██║  ██║██╔══██╗████╗  ██║██║ ██╔╝    ╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔════╝██╔═══██╗██╔══██╗    ██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝██║████╗  ██║██╔════╝     
                                ██║   ███████║███████║██╔██╗ ██║█████╔╝      ╚████╔╝ ██║   ██║██║   ██║    █████╗  ██║   ██║██████╔╝    ██████╔╝██║     ███████║ ╚████╔╝ ██║██╔██╗ ██║██║  ███╗    
                                ██║   ██╔══██║██╔══██║██║╚██╗██║██╔═██╗       ╚██╔╝  ██║   ██║██║   ██║    ██╔══╝  ██║   ██║██╔══██╗    ██╔═══╝ ██║     ██╔══██║  ╚██╔╝  ██║██║╚██╗██║██║   ██║    
                                ██║   ██║  ██║██║  ██║██║ ╚████║██║  ██╗       ██║   ╚██████╔╝╚██████╔╝    ██║     ╚██████╔╝██║  ██║    ██║     ███████╗██║  ██║   ██║   ██║██║ ╚████║╚██████╔╝    
                                ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝       ╚═╝    ╚═════╝  ╚═════╝     ╚═╝      ╚═════╝ ╚═╝  ╚═╝    ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝     
                                                                                                                                                                     

");
            Console.ReadKey(true);
            Environment.Exit(0);
        }



        //=========================================================================================================


        public class Easy
        {
            public char foodChar;
            public int foodIndex = 0;
            public char[] selectedCharArray = ['w'];
            public char wrongLetter;
            public char wrongLetter2;
            public string selectedWord;
            public bool easyBool = false;
            public bool mediumBool = false;
            public bool hardBool = false;
            public bool hellishBool = false;
            public Easy()
            {
                selectedCharArray = easy();
                wrongLetter = LetterPicker();
                wrongLetter2 = LetterPicker();

                // Ensure distinctness for wrongLetter and wrongLetter2
                while (wrongLetter == wrongLetter2 || wrongLetter == foodChar || wrongLetter2 == foodChar)
                {
                    wrongLetter2 = LetterPicker();
                    wrongLetter = LetterPicker();
                }

                selectedWord = new string(selectedCharArray);
                UpdateFoodChar();
            }

            public void UpdateFoodChar()
            {
                if (foodIndex < selectedCharArray.Length)
                {
                    foodChar = selectedCharArray[foodIndex];
                }
                else
                {
                    // Handle the case where foodIndex is out of bounds
                    // This could be an error condition or some default behavior
                    // For now, let's set foodChar to a default value
                    foodChar = ' ';
                }
            }

            public char LetterPicker()
            {
                char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                char selectedLetter = GetRandomLetter(letters);
                return selectedLetter;
            }


            public char[] easy()
            {
                string[] easy = { "DOG", "COW", "CAT", "SEAL", "CRAB", "BEAR", "DUCK" };
                string selectedWord = GetRandomWord(easy);
                char[] charArray = selectedWord.ToCharArray();
                return charArray;
            }

            private static string GetRandomWord(string[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }

            private static char GetRandomLetter(char[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }
        }


        public class SnakeEasy
        {
            private WaveOutEvent waveOut;
            Easy easy = new Easy();
            //size ng box
            int Height = 30;
            int Width = 60;
            // dto ilalagay yung coordinate ng snake
            int[] X = new int[50];
            int[] Y = new int[50];

            //initialization para sa coordinate na lalabasan nung mga letter na kakainin
            int letterX;
            int letterY;
            int letterX2;
            int letterY2;
            int letterX3;
            int letterY3;
            public bool isGameOver = false;
            public bool isGameRunning = true;
            public bool isGameFinish = false;
            int parts = 5;


            // eto nag s store ng kung ano ang pindutin ng user eto din ata yung readline
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            //==============================================================================

            //eto nag h hold ng default direction nung snake
            char key = 'W';
            //==============================================================================

            //pang random 
            Random rnd = new Random();
            //====================================================================================

            // initialize ng unang kakainin pag ka start ng program
            public SnakeEasy()
            {

                X[0] = 5;
                Y[0] = 4;
                letterX3 = rnd.Next(2, Width - 1);
                letterY3 = rnd.Next(2, Height - 1);
                letterX2 = rnd.Next(2, Width - 1);
                letterY2 = rnd.Next(2, Height - 1);
                letterX = rnd.Next(2, Width - 1);
                letterY = rnd.Next(2, Height - 1);
            }

            public void WhiteBoard()
            // whiteboard is the border box 
            {
                Console.Clear();
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, Height - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");

                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(Width - 1, i);
                    Console.Write("■");
                }
                Console.SetCursorPosition(Width + 10, 5);
                Console.Write("The Chosen word is: " + easy.selectedWord);

            }

            public void Input()
            {
                if (Console.KeyAvailable)
                {
                    //Console.ReadKey(true): This method reads the key pressed by the user. The parameter true indicates that the key press should not be displayed on the console. The method returns a ConsoleKeyInfo structure, which contains information about the key pressed.
                    keyInfo = Console.ReadKey(true);
                    // This extracts the character representation of the key from the ConsoleKeyInfo structure. The Char property of ConsoleKeyInfo contains the character of the key that was pressed.
                    key = keyInfo.KeyChar;
                }
            }
            public void WritePoint(int x, int y, char? foodChar = null)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                Console.SetCursorPosition(letterX, letterY);
                Console.Write(easy.foodChar);

            }
            public void WritePoint2(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);

            }
            public void WritePoint3(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void logic()
            {
                waveOut = new WaveOutEvent();

                if (isGameFinish)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                // Check if the game is over
                if (isGameOver)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                if (easy.foodIndex == easy.selectedCharArray.Length)
                {
                    isGameFinish = true;
                    return;
                }
                // Check if the head of the snake is out of bounds
                if (X[0] <= 0 || X[0] >= Width - 1 || Y[0] <= 0 || Y[0] >= Height - 1)
                {
                    isGameOver = true;
                    return;
                }

                // Check if the head of the snake is on the position of the first type of food (word.foodChar)
                if (X[0] == letterX && Y[0] == letterY)
                {
                    yum();
                    letterX = rnd.Next(2, Width - 1);
                    letterY = rnd.Next(2, Height - 1);
                    letterX2 = rnd.Next(2, Width - 1);
                    letterY2 = rnd.Next(2, Height - 1);
                    letterX3 = rnd.Next(2, Width - 1);
                    letterY3 = rnd.Next(2, Height - 1);
                    easy.foodIndex++;
                    easy.UpdateFoodChar();
                    parts++;
                    easy.wrongLetter = easy.LetterPicker();
                    easy.wrongLetter2 = easy.LetterPicker();

                }

                // Check if the head of the snake is on the position of the second type of food (word.selectedWrongLetter)
                if (X[0] == letterX2 && Y[0] == letterY2)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX3 && Y[0] == letterY3)
                {
                    isGameOver = true;
                    return;
                }
                // Move the body of the snake
                for (int i = parts; i > 0; i--)
                {
                    X[i] = X[i - 1];
                    Y[i] = Y[i - 1];
                }

                // Move the head of the snake based on the user input
                switch (key)
                {
                    case 'w':
                        Y[0]--;
                        break;
                    case 's':
                        Y[0]++;
                        break;
                    case 'd':
                        X[0]++;
                        break;
                    case 'a':
                        X[0]--;
                        break;
                }

                // Draw the snake
                for (int i = 0; i < parts; i++)
                {
                    WritePoint(X[i], Y[i]);
                }

                // Draw the first type of food
                WritePoint(letterX, letterY, easy.foodChar);

                // Draw the second type of food
                WritePoint2(letterX2, letterY2, easy.wrongLetter);
                WritePoint3(letterX3, letterY3, easy.wrongLetter2);
                Thread.Sleep(10);
            }
            public void yum()
            {
                // Load your audio file (replace "path/to/your/music/file.mp3" with the actual path)
                string audioFilePath = @"Music\\yum.mp3";
                using (var audioFile = new AudioFileReader(audioFilePath))
                {
                    waveOut.Init(audioFile);
                    waveOut.Play();
                }
            }
            private void StopAudio()
            {
                waveOut.Stop();
            }
        }

        //================================================================================================================================
        public class Medium
        {
            public char foodChar;
            public int foodIndex = 0;
            public char[] selectedCharArray;
            public char wrongLetter;
            public char wrongLetter2;
            public char wrongLetter3;
            public string selectedWord;
            public bool easyBool = false;
            public bool mediumBool = false;
            public bool hardBool = false;
            public bool hellishBool = false;
            public Medium()
            {

                selectedCharArray = medium();
                wrongLetter = LetterPicker();
                wrongLetter2 = LetterPicker();
                wrongLetter3 = LetterPicker();

                // Ensure distinctness for wrongLetter, wrongLetter2, and wrongLetter3
                while (wrongLetter == wrongLetter2 || wrongLetter == wrongLetter3 || wrongLetter == foodChar ||
                       wrongLetter2 == wrongLetter3 || wrongLetter2 == foodChar || wrongLetter3 == foodChar)
                {
                    wrongLetter2 = LetterPicker();
                    wrongLetter3 = LetterPicker();
                    wrongLetter = LetterPicker();
                }

                selectedWord = new string(selectedCharArray);
                UpdateFoodChar();
            }

            public void UpdateFoodChar()
            {
                if (foodIndex < selectedCharArray.Length)
                {
                    foodChar = selectedCharArray[foodIndex];
                }
                else
                {
                    // Handle the case where foodIndex is out of bounds
                    // This could be an error condition or some default behavior
                    // For now, let's set foodChar to a default value
                    foodChar = ' ';
                }
            }

            public char LetterPicker()
            {
                char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                char selectedLetter = GetRandomLetter(letters);
                return selectedLetter;
            }

            
            public char[] medium()
            {
                string[] easy = { "CASUAL", "ABROAD", "AROUND", "BEAKER", "BUDGET","BETTER", "JHONNY" };
                string selectedWord = GetRandomWord(easy);
                char[] charArray = selectedWord.ToCharArray();
                return charArray;
            }
            
            private static string GetRandomWord(string[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }

            private static char GetRandomLetter(char[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }
        }


        public class SnakeMedium
        {
            private WaveOutEvent waveOut;
            Medium medium = new Medium();
            //size ng box
            int Height = 30;
            int Width = 60;
            // dto ilalagay yung coordinate ng snake
            int[] X = new int[50];
            int[] Y = new int[50];

            //initialization para sa coordinate na lalabasan nung mga letter na kakainin
            int letterX;
            int letterY;
            int letterX2;
            int letterY2;
            int letterX3;
            int letterY3;
            int letterX4;
            int letterY4;
            public bool isGameOver = false;
            public bool isGameRunning = true;
            public bool isGameFinish = false;
            int parts = 5;


            // eto nag s store ng kung ano ang pindutin ng user eto din ata yung readline
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            //==============================================================================

            //eto nag h hold ng default direction nung snake
            char key = 'W';
            //==============================================================================

            //pang random 
            Random rnd = new Random();
            //====================================================================================

            // initialize ng unang kakainin pag ka start ng program
            public SnakeMedium()
            {

                X[0] = 5;
                Y[0] = 4;
                letterX4 = rnd.Next(2, Width - 2);
                letterY4 = rnd.Next(2, Height - 2);
                letterX3 = rnd.Next(2, Width - 2);
                letterY3 = rnd.Next(2, Height - 2);
                letterX2 = rnd.Next(2, Width - 2);
                letterY2 = rnd.Next(2, Height - 2);
                letterX = rnd.Next(2, Width - 2);
                letterY = rnd.Next(2, Height - 2);
            }

            public void WhiteBoard()
            // whiteboard is the border box 
            {
                Console.Clear();
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, Height - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");

                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(Width - 1, i);
                    Console.Write("■");
                }
                Console.SetCursorPosition(Width + 10, 5);
                Console.Write("The Chosen word is: " + medium.selectedWord);
            }

            public void Input()
            {
                if (Console.KeyAvailable)
                {
                    //Console.ReadKey(true): This method reads the key pressed by the user. The parameter true indicates that the key press should not be displayed on the console. The method returns a ConsoleKeyInfo structure, which contains information about the key pressed.
                    keyInfo = Console.ReadKey(true);
                    // This extracts the character representation of the key from the ConsoleKeyInfo structure. The Char property of ConsoleKeyInfo contains the character of the key that was pressed.
                    key = keyInfo.KeyChar;
                }
            }
            public void WritePoint(int x, int y, char? foodChar = null)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                Console.SetCursorPosition(letterX, letterY);
                Console.Write(medium.foodChar);

            }
            public void WritePoint2(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);

            }
            public void WritePoint3(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint4(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void logic()
            {
                waveOut = new WaveOutEvent();
                if (isGameFinish)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                // Check if the game is over
                if (isGameOver)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                if (medium.foodIndex == medium.selectedCharArray.Length)
                {
                    isGameFinish = true;
                    return;
                }
                // Check if the head of the snake is out of bounds
                if (X[0] <= 0 || X[0] >= Width - 1 || Y[0] <= 0 || Y[0] >= Height - 1)
                {
                    isGameOver = true;
                    return;
                }

                // Check if the head of the snake is on the position of the first type of food (word.foodChar)
                if (X[0] == letterX && Y[0] == letterY)
                {
                    yum();
                    letterX = rnd.Next(2, Width - 1);
                    letterY = rnd.Next(2, Height - 1);
                    letterX2 = rnd.Next(2, Width - 1);
                    letterY2 = rnd.Next(2, Height - 1);
                    letterX3 = rnd.Next(2, Width - 1);
                    letterY3 = rnd.Next(2, Height - 1);
                    letterX4 = rnd.Next(2, Width - 2);
                    letterY4 = rnd.Next(2, Height - 2);
                    medium.foodIndex++;
                    medium.UpdateFoodChar();
                    parts++;
                    medium.wrongLetter = medium.LetterPicker();
                    medium.wrongLetter2 = medium.LetterPicker();
                }

                // Check if the head of the snake is on the position of the second type of food (word.selectedWrongLetter)
                if (X[0] == letterX3 && Y[0] == letterY3)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX2 && Y[0] == letterY2)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX3 && Y[0] == letterY3)
                {
                    isGameOver = true;
                    return;
                }
                // Move the body of the snake
                for (int i = parts; i > 0; i--)
                {
                    X[i] = X[i - 1];
                    Y[i] = Y[i - 1];
                }

                // Move the head of the snake based on the user input
                switch (key)
                {
                    case 'w':
                        Y[0]--;
                        break;
                    case 's':
                        Y[0]++;
                        break;
                    case 'd':
                        X[0]++;
                        break;
                    case 'a':
                        X[0]--;
                        break;
                }

                // Draw the snake
                for (int i = 0; i < parts; i++)
                {
                    WritePoint(X[i], Y[i]);
                }

                // Draw the first type of food
                WritePoint(letterX, letterY, medium.foodChar);

                // Draw the second type of food
                WritePoint2(letterX2, letterY2, medium.wrongLetter);
                WritePoint3(letterX3, letterY3, medium.wrongLetter2);
                WritePoint4(letterX4, letterY4, medium.wrongLetter3);
                Thread.Sleep(10);
            }
            public void yum()
            {
                // Load your audio file (replace "path/to/your/music/file.mp3" with the actual path)
                string audioFilePath = @"Music\\yum.mp3";
                using (var audioFile = new AudioFileReader(audioFilePath))
                {
                    waveOut.Init(audioFile);
                    waveOut.Play();
                }
            }
            private void StopAudio()
            {
                waveOut.Stop();
            }
        }

        //=================================================================================================================================

        public class Hard
        {
            public char foodChar;
            public int foodIndex = 0;
            public char[] selectedCharArray = ['w'];
            public char wrongLetter;
            public char wrongLetter2;
            public char wrongLetter3;
            public char wrongLetter4;
            public string selectedWord;
            public bool easyBool = false;
            public bool mediumBool = false;
            public bool hardBool = false;
            public bool hellishBool = false;
            public Hard()
            {

                selectedCharArray = hard();
                wrongLetter = LetterPicker();
                wrongLetter2 = LetterPicker();
                wrongLetter3 = LetterPicker();
                wrongLetter4 = LetterPicker();

                // Ensure distinctness for wrongLetter, wrongLetter2, wrongLetter3, and wrongLetter4
                while (wrongLetter == wrongLetter2 || wrongLetter == wrongLetter3 || wrongLetter == wrongLetter4 ||
                       wrongLetter == foodChar || wrongLetter2 == wrongLetter3 || wrongLetter2 == wrongLetter4 ||
                       wrongLetter2 == foodChar || wrongLetter3 == wrongLetter4 || wrongLetter3 == foodChar ||
                       wrongLetter4 == foodChar)
                {
                    wrongLetter2 = LetterPicker();
                    wrongLetter3 = LetterPicker();
                    wrongLetter4 = LetterPicker();
                    wrongLetter = LetterPicker();
                }

                selectedWord = new string(selectedCharArray);
                UpdateFoodChar();
            }

            public void UpdateFoodChar()
            {
                if (foodIndex < selectedCharArray.Length)
                {
                    foodChar = selectedCharArray[foodIndex];
                }
                else
                {
                    // Handle the case where foodIndex is out of bounds
                    // This could be an error condition or some default behavior
                    // For now, let's set foodChar to a default value
                    foodChar = ' ';
                }
            }

            public char LetterPicker()
            {
                char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                char selectedLetter = GetRandomLetter(letters);
                return selectedLetter;
            }
            public char[] hard()
            {
                string[] easy = { "ADVENTURE", "BEAUTIFUL", "COMMUNITY", "EDUCATION", "INFLUENCE", "KNOWLEDGE", "TECHNOLOGY" };
                string selectedWord = GetRandomWord(easy);
                char[] charArray = selectedWord.ToCharArray();
                return charArray;
            }
            private static string GetRandomWord(string[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }

            private static char GetRandomLetter(char[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }
        }


        public class SnakeHard
        {
            private WaveOutEvent waveOut;
            Hard hard = new Hard();
            //size ng box
            int Height = 30;
            int Width = 60;
            // dto ilalagay yung coordinate ng snake
            int[] X = new int[50];
            int[] Y = new int[50];

            //initialization para sa coordinate na lalabasan nung mga letter na kakainin
            int letterX;
            int letterY;
            int letterX2;
            int letterY2;
            int letterX3;
            int letterY3;
            int letterX4;
            int letterY4;
            int letterX5;
            int letterY5;
            public bool isGameOver = false;
            public bool isGameRunning = true;
            public bool isGameFinish = false;
            int parts = 5;


            // eto nag s store ng kung ano ang pindutin ng user eto din ata yung readline
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            //==============================================================================

            //eto nag h hold ng default direction nung snake
            char key = 'W';
            //==============================================================================

            //pang random 
            Random rnd = new Random();
            //====================================================================================

            // initialize ng unang kakainin pag ka start ng program
            public SnakeHard()
            {
                X[0] = 5;
                Y[0] = 4;
                letterX5 = rnd.Next(2, Width - 1);
                letterY5 = rnd.Next(2, Height - 1);
                letterX4 = rnd.Next(2, Width - 1);
                letterY4 = rnd.Next(2, Height - 1);
                letterX3 = rnd.Next(2, Width - 1);
                letterY3 = rnd.Next(2, Height - 1);
                letterX2 = rnd.Next(2, Width - 1);
                letterY2 = rnd.Next(2, Height - 1);
                letterX = rnd.Next(2, Width - 1);
                letterY = rnd.Next(2, Height - 1);
            }

            public void WhiteBoard()
            // whiteboard is the border box 
            {
                Console.Clear();
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, Height - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");

                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(Width - 1, i);
                    Console.Write("■");
                }
                Console.SetCursorPosition(Width + 10, 5);
                Console.Write("The Chosen word is: " + hard.selectedWord);
            }

            public void Input()
            {
                if (Console.KeyAvailable)
                {
                    //Console.ReadKey(true): This method reads the key pressed by the user. The parameter true indicates that the key press should not be displayed on the console. The method returns a ConsoleKeyInfo structure, which contains information about the key pressed.
                    keyInfo = Console.ReadKey(true);
                    // This extracts the character representation of the key from the ConsoleKeyInfo structure. The Char property of ConsoleKeyInfo contains the character of the key that was pressed.
                    key = keyInfo.KeyChar;
                }
            }
            public void WritePoint(int x, int y, char? foodChar = null)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                Console.SetCursorPosition(letterX, letterY);
                Console.Write(hard.foodChar);

            }
            public void WritePoint2(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);

            }
            public void WritePoint3(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint4(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint5(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void logic()
            {
                waveOut = new WaveOutEvent();
                if (isGameFinish)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                // Check if the game is over
                if (isGameOver)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                if (hard.foodIndex == hard.selectedCharArray.Length)
                {
                    isGameFinish = true;
                    return;
                }
                // Check if the head of the snake is out of bounds
                if (X[0] <= 0 || X[0] >= Width - 1 || Y[0] <= 0 || Y[0] >= Height - 1)
                {
                    isGameOver = true;
                    return;
                }

                // Check if the head of the snake is on the position of the first type of food (word.foodChar)
                if (X[0] == letterX && Y[0] == letterY)
                {
                    yum();
                    letterX = rnd.Next(2, Width - 1);
                    letterY = rnd.Next(2, Height - 1);
                    letterX2 = rnd.Next(2, Width - 1);
                    letterY2 = rnd.Next(2, Height - 1);
                    letterX3 = rnd.Next(2, Width - 1);
                    letterY3 = rnd.Next(2, Height - 1);
                    letterX4 = rnd.Next(2, Width - 1);
                    letterY4 = rnd.Next(2, Height - 1);
                    letterX5 = rnd.Next(2, Width - 1);
                    letterY5 = rnd.Next(2, Height - 1);
                    hard.foodIndex++;
                    hard.UpdateFoodChar();
                    parts++;
                    hard.wrongLetter = hard.LetterPicker();
                    hard.wrongLetter2 = hard.LetterPicker();
                }

                // Check if the head of the snake is on the position of the second type of food (word.selectedWrongLetter)
                if (X[0] == letterX2 && Y[0] == letterY2)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX3 && Y[0] == letterY3)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX4 && Y[0] == letterY4)
                {
                    isGameOver = true;
                    return;

                }
                if (X[0] == letterX5 && Y[0] == letterY5)
                {
                    isGameOver = true;
                    return;
                }
                // Move the body of the snake
                for (int i = parts; i > 0; i--)
                {
                    X[i] = X[i - 1];
                    Y[i] = Y[i - 1];
                }

                // Move the head of the snake based on the user input
                switch (key)
                {
                    case 'w':
                        Y[0]--;
                        break;
                    case 's':
                        Y[0]++;
                        break;
                    case 'd':
                        X[0]++;
                        break;
                    case 'a':
                        X[0]--;
                        break;
                }

                // Draw the snake
                for (int i = 0; i < parts; i++)
                {
                    WritePoint(X[i], Y[i]);
                }

                // Draw the first type of food
                WritePoint(letterX, letterY, hard.foodChar);

                // Draw the second type of food
                WritePoint2(letterX2, letterY2, hard.wrongLetter);
                WritePoint3(letterX3, letterY3, hard.wrongLetter2);
                WritePoint4(letterX4, letterY4, hard.wrongLetter3);
                WritePoint5(letterX5, letterY5, hard.wrongLetter4);
                Thread.Sleep(5);
            }
            public void yum()
            {
                // Load your audio file (replace "path/to/your/music/file.mp3" with the actual path)
                string audioFilePath = @"Music\\yum.mp3";
                using (var audioFile = new AudioFileReader(audioFilePath))
                {
                    waveOut.Init(audioFile);
                    waveOut.Play();
                }
            }
            private void StopAudio()
            {
                waveOut.Stop();
            }
        }


        //================================================================================================================================
        public class Hellish
        {
            public char foodChar;
            public int foodIndex = 0;
            public char[] selectedCharArray = ['w'];
            public char wrongLetter;
            public char wrongLetter2;
            public char wrongLetter3;
            public char wrongLetter4;
            public char wrongLetter5;
            public string selectedWord;
            public bool easyBool = false;
            public bool mediumBool = false;
            public bool hardBool = false;
            public bool hellishBool = false;
            public Hellish()
            {

                selectedCharArray = hellish();
                wrongLetter = LetterPicker();
                wrongLetter2 = LetterPicker();
                wrongLetter3 = LetterPicker();
                wrongLetter4 = LetterPicker();
                wrongLetter5 = LetterPicker();

                while (wrongLetter == wrongLetter2 || wrongLetter == wrongLetter3 || wrongLetter == foodChar ||
         wrongLetter2 == wrongLetter3 || wrongLetter2 == foodChar || wrongLetter3 == foodChar ||
         wrongLetter4 == wrongLetter5 || wrongLetter4 == foodChar || wrongLetter5 == foodChar)
                {
                    wrongLetter = LetterPicker();
                    wrongLetter2 = LetterPicker();
                    wrongLetter3 = LetterPicker();
                    wrongLetter4 = LetterPicker();
                    wrongLetter5 = LetterPicker();
                }

                selectedWord = new string(selectedCharArray);
                UpdateFoodChar();
            }

            public void UpdateFoodChar()
            {
                if (foodIndex < selectedCharArray.Length)
                {
                    foodChar = selectedCharArray[foodIndex];
                }
                else
                {
                    // Handle the case where foodIndex is out of bounds
                    // This could be an error condition or some default behavior
                    // For now, let's set foodChar to a default value
                    foodChar = ' ';
                }
            }

            public char LetterPicker()
            {
                char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                char selectedLetter = GetRandomLetter(letters);
                return selectedLetter;
            }
            public char[] hellish()
            {
                string[] easy = { "PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS" };
                string selectedWord = GetRandomWord(easy);
                char[] charArray = selectedWord.ToCharArray();
                return charArray;
            }
            private static string GetRandomWord(string[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }

            private static char GetRandomLetter(char[] array)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(array.Length);
                return array[randomIndex];
            }
        }


        public class SnakeHellish
        {
            private WaveOutEvent waveOut;
            Hellish medium = new Hellish();
            //size ng box
            int Height = 30;
            int Width = 60;
            // dto ilalagay yung coordinate ng snake
            int[] X = new int[50];
            int[] Y = new int[50];

            //initialization para sa coordinate na lalabasan nung mga letter na kakainin
            int letterX;
            int letterY;
            int letterX2;
            int letterY2;
            int letterX3;
            int letterY3;
            int letterX4;
            int letterY4;
            int letterX5;
            int letterY5;
            int letterX6;
            int letterY6;
            public bool isGameOver = false;
            public bool isGameRunning = true;
            public bool isGameFinish = false;
            int parts = 5;


            // eto nag s store ng kung ano ang pindutin ng user eto din ata yung readline
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            //==============================================================================

            //eto nag h hold ng default direction nung snake
            char key = 'W';
            //==============================================================================

            //pang random 
            Random rnd = new Random();
            //====================================================================================

            // initialize ng unang kakainin pag ka start ng program
            public SnakeHellish()
            {
                X[0] = 5;
                Y[0] = 4;
                letterX6 = rnd.Next(2, Width - 1);
                letterY6 = rnd.Next(2, Height - 1);
                letterX5 = rnd.Next(2, Width - 1);
                letterY5 = rnd.Next(2, Height - 1);
                letterX4 = rnd.Next(2, Width - 1);
                letterY4 = rnd.Next(2, Height - 1);
                letterX3 = rnd.Next(2, Width - 1);
                letterY3 = rnd.Next(2, Height - 1);
                letterX2 = rnd.Next(2, Width - 1);
                letterY2 = rnd.Next(2, Height - 1);
                letterX = rnd.Next(2, Width - 1);
                letterY = rnd.Next(2, Height - 1);
            }

            public void WhiteBoard()
            // whiteboard is the border box 
            {
                Console.Clear();
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < Width; i++)
                {
                    Console.SetCursorPosition(i, Height - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");

                }
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(Width - 1, i);
                    Console.Write("■");
                }
                Console.SetCursorPosition(Width + 10, 5);
                Console.Write("The Chosen word is: " + medium.selectedWord);
            }

            public void Input()
            {
                if (Console.KeyAvailable)
                {
                    //Console.ReadKey(true): This method reads the key pressed by the user. The parameter true indicates that the key press should not be displayed on the console. The method returns a ConsoleKeyInfo structure, which contains information about the key pressed.
                    keyInfo = Console.ReadKey(true);
                    // This extracts the character representation of the key from the ConsoleKeyInfo structure. The Char property of ConsoleKeyInfo contains the character of the key that was pressed.
                    key = keyInfo.KeyChar;
                }
            }
            public void WritePoint(int x, int y, char? foodChar = null)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("■");
                Console.SetCursorPosition(letterX, letterY);
                Console.Write(medium.foodChar);

            }
            public void WritePoint2(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);

            }
            public void WritePoint3(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint4(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint5(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void WritePoint6(int x, int y, char foodChar)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(foodChar);
            }
            public void logic()
            {
                waveOut = new WaveOutEvent();
                if (isGameFinish)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                // Check if the game is over
                if (isGameOver)
                {
                    Console.Clear();
                    isGameRunning = false;
                    return;
                }
                if (medium.foodIndex == medium.selectedCharArray.Length)
                {
                    isGameFinish = true;
                    return;
                }
                // Check if the head of the snake is out of bounds
                if (X[0] <= 0 || X[0] >= Width - 1 || Y[0] <= 0 || Y[0] >= Height - 1)
                {
                    isGameOver = true;
                    return;
                }

                // Check if the head of the snake is on the position of the first type of food (word.foodChar)
                if (X[0] == letterX && Y[0] == letterY)
                {
                    yum();
                    letterX = rnd.Next(2, Width - 1);
                    letterY = rnd.Next(2, Height - 1);
                    letterX2 = rnd.Next(2, Width - 1);
                    letterY2 = rnd.Next(2, Height - 1);
                    letterX3 = rnd.Next(2, Width - 1);
                    letterY3 = rnd.Next(2, Height - 1);
                    letterX4 = rnd.Next(2, Width - 1);
                    letterY4 = rnd.Next(2, Height - 1);
                    letterX5 = rnd.Next(2, Width - 1);
                    letterY5 = rnd.Next(2, Height - 1);
                    letterX6 = rnd.Next(2, Width - 1);
                    letterY6 = rnd.Next(2, Height - 1);
                    medium.foodIndex++;
                    medium.UpdateFoodChar();
                    parts++;
                    medium.wrongLetter = medium.LetterPicker();
                    medium.wrongLetter2 = medium.LetterPicker();
                }

                // Check if the head of the snake is on the position of the second type of food (word.selectedWrongLetter)
                if (X[0] == letterX2 && Y[0] == letterY2)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX3 && Y[0] == letterY3)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX4 && Y[0] == letterY4)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX5 && Y[0] == letterY5)
                {
                    isGameOver = true;
                    return;
                }
                if (X[0] == letterX6 && Y[0] == letterY6)
                {
                    isGameOver = true;
                    return;
                }
                // Move the body of the snake
                for (int i = parts; i > 0; i--)
                {
                    X[i] = X[i - 1];
                    Y[i] = Y[i - 1];
                }

                // Move the head of the snake based on the user input
                switch (key)
                {
                    case 'w':
                        Y[0]--;
                        break;
                    case 's':
                        Y[0]++;
                        break;
                    case 'd':
                        X[0]++;
                        break;
                    case 'a':
                        X[0]--;
                        break;
                }

                // Draw the snake
                for (int i = 0; i < parts; i++)
                {
                    WritePoint(X[i], Y[i]);
                }

                // Draw the first type of food
                WritePoint(letterX, letterY, medium.foodChar);

                // Draw the second type of food
                WritePoint2(letterX2, letterY2, medium.wrongLetter);
                WritePoint3(letterX3, letterY3, medium.wrongLetter2);
                WritePoint4(letterX4, letterY4, medium.wrongLetter3);
                WritePoint5(letterX5, letterY5, medium.wrongLetter4);
                WritePoint6(letterX6, letterY6, medium.wrongLetter5);
                Thread.Sleep(1);
            }
            public void yum()
            {
                // Load your audio file (replace "path/to/your/music/file.mp3" with the actual path)
                string audioFilePath = @"Music\\yum.mp3";
                using (var audioFile = new AudioFileReader(audioFilePath))
                {
                    waveOut.Init(audioFile);
                    waveOut.Play();
                }
            }
            private void StopAudio()
            {
                waveOut.Stop();
            }

        }
        private void LoadingScreen()
        {
            Logo();
            Console.CursorVisible = false;
            Console.SetCursorPosition(40, 13);

            for (int i = 0; i < 30; i++)
            {
                Console.Write("[");
                for (int y = 0; y < i; y++)
                {
                    string pb = "■";

                    Console.Write(pb);
                }
                Console.Write("]" + (i + 1 + " / 30"));
                Console.SetCursorPosition(40, 13);
                Console.ForegroundColor = ConsoleColor.Green;
                System.Threading.Thread.Sleep(50);

            }
            Console.WriteLine("PLEASE PRESS THE ENTER 3x.....................");
            Console.ReadLine();
            Console.ReadKey(true);
        }
        private void Logo()
        {
            Console.WriteLine(@"
     ▄█     █▄   ▄██████▄     ▄████████ ████████▄          ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████ 
    ███     ███ ███    ███   ███    ███ ███   ▀███        ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███ 
    ███     ███ ███    ███   ███    ███ ███    ███        ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀  
    ███     ███ ███    ███  ▄███▄▄▄▄██▀ ███    ███        ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     
    ███     ███ ███    ███ ▀▀███▀▀▀▀▀   ███    ███      ▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀     
    ███     ███ ███    ███ ▀███████████ ███    ███               ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  
    ███ ▄█▄ ███ ███    ███   ███    ███ ███   ▄███         ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ 
     ▀███▀███▀   ▀██████▀    ███    ███ ████████▀        ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ 
                             ███    ███                                                       ▀                      ");
        }
        public void song()
        {
            // Load your audio file (replace "path/to/your/music/file.mp3" with the actual path)
            string audioFilePath = @"Music\\song.mp3";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
            }
        }
        public void start()
        {

            string audioFilePath = @"Music\\start.mp3";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
            }
        }
        public void ded()
        {

            string audioFilePath = @"Music\\ded.mp3";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
            }
        }
        public void win()
        {

            string audioFilePath = @"Music\\win.mp3";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
            }
        }
        public void game()
        {

            string audioFilePath = @"Music\\game.mp3";
            using (var audioFile = new AudioFileReader(audioFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
            }
        }
        private void StopAudio()
        {
            waveOut.Stop();
        }
    }
}
