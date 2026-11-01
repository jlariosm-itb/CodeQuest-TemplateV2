using System;

public class Program
{
    static void Main()
    {
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";

        const string ErrorNotNumber = "Error: you must type a number, not text.";
        const string ErrorTooBig = "Error: that number is too big.";
        const string ErrorRange = "Error: the option must be between 0 and 3.";
        const string ErrorNoInput = "Error: no input received.";

        const string NameMessage = "Oooohhh, little wizard… your name, tell me, hmmm? :";
        const string TrainingMessage = "Do you want to start training, Sir {0}? (Write YES or NO): ";
        const string FirstRank = "Repeteixes a 2a convocatòria, has obtingut el rang de: Raoden Elantrí";
        const string SecondRank = "Encara confons la vareta amb una cullera, has obtingut el rang de: Zyn el Bugejat";
        const string ThirdRank = "Ets un Invocador de Brises Màgiques. Has obtingut el rang de: Arka Nullpointer";
        const string FourdRank = "Uau! Pots invocar dracs sense cremar el laboratori! Has obtingut el rang de: Elarion de les Brases.";
        const string FifthRank = "Has assolit el rang de Mestre dels Arcans! Has obtinut el rang ITB-Wizard el Gris";
        const string EasterEgg = "LOOK WHAT U HAVE DONE!!! YOU UNLOCK THE SECRET RANK: THE JUNE SAVIOR OF THE ITB. Now you are able to save your team from the evil June";
        const string DayFinished = "A day of exhausting training has finished successfully. You archved {0} of training hours and you gained {1} points of power.";
        const string TrainingFinished = "You has completed your training and you earned {0} of training hours and {1} of power points. ";

        const string MsgEDungeon = "Wellcome to the dungeon wizard, here you will find 3 doors, each door need a single code to unlock it, you have 3 tires for each door. ";
        const string MsgDoors = "You are in front of door {0}, please, enter de code to cross:";
        const string MsgCorrectCode = "El drac 🐲 et respecta. Has desbloquejat el següent nivell!";
        const string MsgIncorrectCode = "The code is incorrect, try again, you have {0} tries more...";
        const string NoTriesDoor = "El drac 🐲 ha detectat la teva presència i t’ha expulsat del servidor!";
        const string DoorsEnd = "Has desbloquejat el nivell final. Pots quedar-te amb el tresor 💎del drac 🐲!";

        const string MineStartMessage = "You enter the mine. You have 5 attempts to find coins!";
        const string EnterXCoordinatesMessage = "Enter coordinates (X between 0 and 4): ";
        const string EnterYCoordinatesMessage = "Enter coordinates (Y between 0 and 4): ";
        const string FoundCoinMessage = "Congratulations! You found a coin and earned {0} bits!";
        const string NoCoinMessage = "Sorry, no coin here. Try again!";
        const string InvalidCoordinatesMessage = "Invalid coordinates! Please enter values between 0 and 4.";
        const string MineDisplayMessage = "Current Mine Map:";
        const string MineAttemps = "You have {0} attempts left.";
        const string Mined = "This cell has already been mined.";
        const string GameOverMine = "Game over! You found a total of {0} bits.";

        const int GridSize = 5;
        const int MaxAttempts = 5;

        int option = -1;
        bool isValid;

        string wizardName = "", rank;
        int hourstraining = 0, wizardpower = 0, totalpower = 0, totalhours = 0;
        int day = 0;
        var random = new Random();
        string starttraining = "";

        do
        {
            isValid = false;

            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            try
            {
                option = int.Parse(Console.ReadLine());

                if (option < 0 || option > 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(option), ErrorRange);
                }

                isValid = true;
                Console.WriteLine($"You chose: {option}");
            }
            catch (FormatException)
            {
                Console.WriteLine(ErrorNotNumber);
            }
            catch (OverflowException)
            {
                Console.WriteLine(ErrorTooBig);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(ErrorNoInput);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(ErrorRange);
            }
            finally
            {
                Console.WriteLine("----------------------------");
            }

            if (isValid)
            {
                switch (option)
                {
                    case 1:
                        if (wizardName == "")
                        {
                            Console.WriteLine(NameMessage);
                            wizardName = Console.ReadLine();
                        }

                        Console.Write(TrainingMessage, wizardName);
                        starttraining = Console.ReadLine()?.Trim().ToUpper();

                        if (starttraining == "YES")
                        {
                            totalhours = 0;
                            totalpower = 0;

                            for (day = 1; day <= 5; day++)
                            {
                                Console.WriteLine($"Wellcome {wizardName}, you are on your training arc...");
                                hourstraining = random.Next(1, 25);
                                wizardpower = random.Next(1, 11);
                                totalhours += hourstraining;
                                totalpower += wizardpower;

                                Console.WriteLine(DayFinished, hourstraining, wizardpower);
                            }

                            Console.WriteLine(TrainingFinished, totalhours, totalpower);

                            if (totalpower < 20)
                            {
                                Console.WriteLine(FirstRank);
                                rank = "Raoden el Elantrí";
                            }
                            else if (totalpower >= 20 && totalpower < 30)
                            {
                                Console.WriteLine(SecondRank);
                                rank = "Zyn el Buguejat";
                            }
                            else if (totalpower >= 30 && totalpower < 35)
                            {
                                Console.WriteLine(ThirdRank);
                                rank = "Arka Nullpointer";
                            }
                            else if (totalpower >= 35 && totalpower < 40)
                            {
                                Console.WriteLine(FourdRank);
                                rank = "Elarion de les Brases";
                            }
                            else if (totalpower >= 40 && totalpower < 80)
                            {
                                Console.WriteLine(FifthRank);
                                rank = "ITB-Wizard el Gris";
                            }
                            else
                            {
                                Console.WriteLine(EasterEgg);
                                rank = "The June Savior of the ITB";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Well we wake up a little bit lazy today...");
                        }
                        break;

                    case 2:
                        Random rnd = new Random();
                        int door = 1;
                        bool dungeonCompleted = true;

                        Console.WriteLine(MsgEDungeon);

                        while (door <= 3)
                        {
                            int codedoor = rnd.Next(1, 6);
                            int triesDoors = 3;
                            bool doorPassed = false;

                            while (triesDoors > 0 && !doorPassed)
                            {
                                Console.WriteLine(MsgDoors, door);
                                if (int.TryParse(Console.ReadLine(), out int resposta))
                                {
                                    if (resposta == codedoor)
                                    {
                                        Console.WriteLine(MsgCorrectCode);
                                        doorPassed = true;
                                        door++;
                                    }
                                    else
                                    {
                                        triesDoors--;
                                        Console.WriteLine(MsgIncorrectCode, triesDoors);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ErrorNotNumber);
                                }
                            }

                            if (triesDoors == 0)
                            {
                                dungeonCompleted = false;
                                break;
                            }
                        }

                        if (dungeonCompleted)
                        {
                            Console.WriteLine(DoorsEnd);
                        }
                        else
                        {
                            Console.WriteLine(NoTriesDoor);
                        }
                        break;

                    case 3:
                        int totalBits = 0;
                        string[,] visibleGrid = new string[GridSize, GridSize];
                        int[,] hiddenGrid = new int[GridSize, GridSize];
                        Random rand = new Random();

                        for (int i = 0; i < GridSize; i++)
                        {
                            for (int j = 0; j < GridSize; j++)
                            {
                                visibleGrid[i, j] = "➖";
                                hiddenGrid[i, j] = rand.Next(0, 2);
                            }
                        }

                        Console.WriteLine(MineStartMessage);
                        int attempts = MaxAttempts;

                        while (attempts > 0)
                        {
                            Console.WriteLine(MineAttemps, attempts);
                            Console.WriteLine(MineDisplayMessage);

                            for (int i = 0; i < GridSize; i++)
                            {
                                for (int j = 0; j < GridSize; j++)
                                {
                                    Console.Write(visibleGrid[i, j] + " ");
                                }
                                Console.WriteLine();
                            }

                            int x = -1;
                            while (x < 0 || x >= GridSize)
                            {
                                Console.Write(EnterXCoordinatesMessage);
                                if (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= GridSize)
                                {
                                    Console.WriteLine(InvalidCoordinatesMessage);
                                }
                            }

                            int y = -1;
                            while (y < 0 || y >= GridSize)
                            {
                                Console.Write(EnterYCoordinatesMessage);
                                if (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= GridSize)
                                {
                                    Console.WriteLine(InvalidCoordinatesMessage);
                                }
                            }

                            if (visibleGrid[x, y] != "➖")
                            {
                                Console.WriteLine(Mined);
                                continue;
                            }

                            if (hiddenGrid[x, y] == 1)
                            {
                                visibleGrid[x, y] = "🪙";
                                int gainedBits = rand.Next(5, 51);
                                totalBits += gainedBits;
                                Console.WriteLine(FoundCoinMessage, gainedBits);
                            }
                            else
                            {
                                visibleGrid[x, y] = "❌";
                                Console.WriteLine(NoCoinMessage);
                            }

                            attempts--;
                        }

                        Console.WriteLine(GameOverMine, totalBits);
                        break;

                    case 0:
                        Console.WriteLine("Exiting game. Goodbye!");
                        break;
                }
            }

        } while (option != 0);
    }
}