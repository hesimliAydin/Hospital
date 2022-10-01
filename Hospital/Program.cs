using Bogus;
using System.Collections.Generic;
using System;
using System.Text;
 
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.ComponentModel;

class Program
{
    static Hospital Hospital = JsonSerializer.Deserialize<Hospital>(File.ReadAllText("hospital.json"));
    static List<Pacient> Pacients = JsonSerializer.Deserialize<List<Pacient>>(File.ReadAllText("pacients.json"));
    static string[] DepartmentNames = { "Pediatriya", "Travmatologiya", "Stamologiya" };


    public static void Fulling()
    {
        
        foreach (var name in DepartmentNames)
        {
            Hospital?.Departments.Add(name, new List<Doctor>());
            for (int i = 0; i < 15; i++)
                Hospital?.Departments[name].Add(Doctor.CreateDoctor());
        }
    }

    static void Main()
    {

        try
        {
            while (true)
            {
                Pacient currentPacient;                                                                             

                if (Pacients?.Count == 0)
                {
                    currentPacient = Pacient.CreatePacient();
                    Pacients.Add(currentPacient);
                }
                else
                {
                    int choice = Control.GetSelect("\n~Please Enter Your Selection", new string[] { "LOG IN", "SIGN UP" }, true);

                    if (choice == Control.ESC)
                        break;
                    else if (choice == 0)
                    {
                        int logInChoice = Control.GetSelect("\n~Please Enter Your Selection", Pacients.ToArray(), true);

                        if (logInChoice == Control.ESC)
                            continue;
                        else currentPacient = Pacients[logInChoice];
                    }
                    else
                    {
                        currentPacient = Pacient.CreatePacient();
                        Pacients?.Add(currentPacient);
                    }
                }

                List<Doctor> doctors = Hospital.Departments[DepartmentNames[Control.GetSelect("\n~ Choose Any Department : ", DepartmentNames)]];
                Doctor doctor = doctors[Control.GetSelect("\n~ Choose Any Doctor : ", doctors.ToArray())];
                Session session = doctor.Sessions[Control.GetSelect("\n~ Choose Any Session : ", doctor.Sessions.ToArray())];

                if (session.OccupiedID == currentPacient.ID)
                {
                    Console.WriteLine($"{currentPacient.Name} {currentPacient.Surname}, " +
                       $"Your Session Between {session.Start} {session.End} has been cancelled !");
                    session.OccupiedID = Guid.Empty;
                }
                else if (session.OccupiedID == Guid.Empty)
                {
                    Console.WriteLine($"Dear {currentPacient.Name} {currentPacient.Surname}, " +
                        $"Your session between {session.Start} {session.End} has been occupied !");
                    session.OccupiedID = currentPacient.ID;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't cancel a session not made by you !");
                    Console.ResetColor();
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }

            File.WriteAllText("pacients.json", JsonSerializer.Serialize(Pacients));
            File.WriteAllText("hospital.json", JsonSerializer.Serialize(Hospital));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
