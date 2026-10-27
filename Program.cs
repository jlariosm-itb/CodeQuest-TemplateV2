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
        const string FinalTrain = "After all that hard work you achieved the rank {0}";
        const string FirstRank = "Repeteixes a 2a convocatòria, has obtingut el rang de: Raoden Elantrí";
        const string SecondRank = "Encara confons la vareta amb una cullera, has obtingut el rang de: Zyn el Bugejat";
        const string ThirdRank = "Ets un Invocador de Brises Màgiques. Has obtingut el rang de: Arka Nullpointer";
        const string FourdRank = "Uau! Pots invocar dracs sense cremar el laboratori! Has obtingut el rang de: Elarion de les Brases.";
        const string FifthRank = "Has assolit el rang de Mestre dels Arcans! Has obtinut el rang ITB-Wizard el Gris";
        const string EasterEgg = "LOOK WHAT U HAVE DONE!!! YOU UNLOCK THE SECRET RANK: THE JUNE SAVIOR OF THE ITB. Now you are able to save your team from the evil June";
        const string DayFinished = "A day of exhausting training has finished successfully. You archved {0} of training hours and you gained {1} points of power.";
        const string TrainingFinished = "You has completed your training and you earned {0} of training hours and {1} of power points. ";

        // Valor centinella: -1 NO és una opció vàlida.
        // El necessitem perquè el compilador no garanteix que 'option' s'assigni
        // dins del try (pot saltar una excepció abans d'arribar a l'assignació).
        int option = -1;
        bool isValid;

        int op = 0;
        string wizardName = "", rank;
        int wizardlvl, hourstraining = 0, wizardpower = 0, totalpower = 0, totalhours = 0;
        int day = 0;
        var random = new Random();
        string starttraining = "";


        do
        {
            isValid = false; // A cada volta suposem que l'entrada NO és vàlida

            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            try
            {
                // int.Parse pot llançar: FormatException, OverflowException
                // o ArgumentNullException (si ReadLine retorna null amb Ctrl+Z / Ctrl+D)
                option = int.Parse(Console.ReadLine());

                // Validació de rang: si no es compleix, LLANÇEM nosaltres l'excepció
                if (option < 0 || option > 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(option), ErrorRange);
                }

                // Si arribem aquí no ha saltat cap excepció: entrada vàlida
                isValid = true;
                Console.WriteLine($"You chose: {option}");
            }
            catch (FormatException)              // Text que no és un número: "abc", "3.5", ""
            {
                Console.WriteLine(ErrorNotNumber);
            }
            catch (OverflowException)            // Número que no cap en un int: "99999999999"
            {
                Console.WriteLine(ErrorTooBig);
            }
            catch (ArgumentNullException)        // ReadLine ha retornat null
            {
                Console.WriteLine(ErrorNoInput);
            }
            catch (ArgumentOutOfRangeException)  // La que hem llançat nosaltres pel rang
            {
                Console.WriteLine(ErrorRange);
            }
            finally
            {
                // S'executa SEMPRE: hi hagi error o no
                Console.WriteLine("----------------------------");
            }

            // Repetim si l'entrada ha estat invàlida O si no han demanat sortir.
            // Comprovem primer !isValid perquè, amb un error, 'option' pot
            // valer 0 d'una volta anterior.
        } while (!isValid || option != 0);

        switch (op)
        {
            case 1:
                if (wizardName == "")
                {
                    Console.WriteLine(NameMessage);
                    wizardName = Console.ReadLine();
                }
                wizardlvl = 1;
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
        }


    }
}

