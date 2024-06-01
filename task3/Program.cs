using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using task3;

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add doctor");
            Console.WriteLine("2. View all doctors");
            Console.WriteLine("3. Schedule appointment");
            Console.WriteLine("4. View appointments of doctor");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddDoctor(hospital);
                    break;
                case "2":
                    ViewAllDoctors(hospital);
                    break;
                case "3":
                    ScheduleAppointment(hospital);
                    break;
                case "4":
                    ViewAppointmentsOfDoctor(hospital);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void AddDoctor(Hospital hospital)
    {
        Console.WriteLine("Enter doctor's name:");
        string name = Console.ReadLine();

        hospital.AddDoctor(new Doctor { Name = name });
        Console.WriteLine($"Doctor {name} added successfully.");
    }

    static void ViewAllDoctors(Hospital hospital)
    {
        if (hospital.Doctors.Count == 0)
        {
            Console.WriteLine("No doctors available.");
            return;
        }

        Console.WriteLine("Doctors:");
        foreach (var doctor in hospital.Doctors)
        {
            Console.WriteLine($"- {doctor.Name}");
        }
    }

    static void ScheduleAppointment(Hospital hospital)
    {
        Console.WriteLine("Enter doctor's name:");
        string doctorName = Console.ReadLine();
        var doctor = hospital.Doctors.FirstOrDefault(d => d.Name == doctorName);

        if (doctor == null)
        {
            Console.WriteLine("Doctor not found.");
            return;
        }

        Console.WriteLine("Enter patient name:");
        string patientName = Console.ReadLine();

        Console.WriteLine("Enter appointment date and time (yyyy-MM-dd HH:mm):");
        DateTime appointmentDate;
        if (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
        {
            Console.WriteLine("Invalid date and time format.");
            return;
        }
        TimeSpan appointmentDuration = TimeSpan.FromHours(1);
        if (doctor.Appointments.Any(a => a.Date < appointmentDate + appointmentDuration && a.Date + appointmentDuration > appointmentDate))
        {
            Console.WriteLine("This time slot is already taken. Please choose a different time.");
            return;
        }
        

        doctor.Appointments.Add(new Appointment { PatientName = patientName, Date = appointmentDate });
        Console.WriteLine("Appointment scheduled successfully.");
    }

    static void ViewAppointmentsOfDoctor(Hospital hospital)
    {
        Console.WriteLine("Enter doctor's name:");
        string doctorName = Console.ReadLine();
        var doctor = hospital.Doctors.FirstOrDefault(d => d.Name == doctorName);

        if (doctor == null)
        {
            Console.WriteLine("Doctor not found.");
            return;
        }

        if (doctor.Appointments.Count == 0)
        {
            Console.WriteLine("No appointments found for this doctor.");
            return;
        }

        Console.WriteLine($"Appointments for Dr. {doctor.Name}:");
        foreach (var appointment in doctor.Appointments)
        {
            Console.WriteLine($"- {appointment.PatientName} at {appointment.Date}");
        }
    }
}

