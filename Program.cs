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
        const string TrainingMessage = "Do you want to start training, Sir {0}? (Write YES or NO)";
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

            // Si la opción ingresada es válida, ejecutamos la lógica del switch
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
                        do
                        {
                            Console.WriteLine(TrainingMessage, wizardName);
                            starttraining = Console.ReadLine();

                            if (starttraining == "YES")
                            {
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
                                else if (totalpower >= 80)
                                {
                                    Console.WriteLine(EasterEgg);
                                    rank = "The June Savior of the ITB";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Well we wake up a little bit lazy today...");
                            }
                        } while (starttraining != "YES");
                        break;

                    case 2:
                        Random rnd = new Random();
                        int codedoor = rnd.Next(1, 6);
                        int door = 1, triesDoors = 3, resposta;
                        bool lastDoor = false;
                        
                        Console.WriteLine(MsgEDungeon);

                        do
                        {
                            
                            Console.WriteLine(MsgDoors, door);
                            Console.WriteLine(codedoor);
                            resposta = Convert.ToInt32(Console.ReadLine());
                            if (resposta == codedoor)
                            {
                                door = door + 1;
                                Console.WriteLine(MsgCorrectCode);
                                triesDoors = 3;
                                if (door == 4)
                                {
                                    lastDoor = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine(MsgIncorrectCode, triesDoors);
                                triesDoors = triesDoors - 1;
                            }
                        } while (triesDoors > 0 && door < 3);

                        if (lastDoor)
                        {
                            Console.WriteLine(DoorsEnd);
                        }
                        else
                        {
                            Console.WriteLine(NoTriesDoor);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Looting the mine... (Nivel no implementado aún)");
                        break;

                    case 0:
                        Console.WriteLine("Exiting game. Goodbye!");
                        break;
                }
            }

            
        } while (!isValid || option != 0);
    }
}