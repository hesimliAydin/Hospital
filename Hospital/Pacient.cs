using System;

class Pacient
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public static Pacient CreatePacient()
    {
        Pacient pacient = new Pacient();
        pacient.ID = Guid.NewGuid();

        Console.Write("Enter Your Name : ");
        pacient.Name = Console.ReadLine() ?? "";

        Console.Write("Enter Your Surname : ");
        pacient.Surname = Console.ReadLine() ?? "";

        Console.Write("Enter Your Email : ");
        pacient.Email = Console.ReadLine() ?? "";

        Console.Write("Enter Your Phone Number: ");
        pacient.Phone = Console.ReadLine() ?? "";

        return pacient;
    }

    public override string ToString()
        => $"{ID} - {Name} {Surname}";
}