using System.Collections.Generic;

class Doctor
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Experience { get; set; }
    public List<Session> Sessions { get; set; } = new List<Session>();

    public Doctor()
    {
        Sessions.Add(new Session() { Start = new Time(9, 00), End = new Time(11, 00) });
        Sessions.Add(new Session() { Start = new Time(12, 00), End = new Time(14, 00) });
        Sessions.Add(new Session() { Start = new Time(15, 00), End = new Time(17, 00) });
    }

    //public static Doctor CreateDoctor()
    //    => new Doctor()
    //    {
    //        Name = Faker.NameFaker.FirstName(),
    //        Surname = Faker.NameFaker.LastName(),
    //        Experience = (int)Faker.NumberFaker.Number(1, 30)
    //    };

    public override string ToString() => $"{Name} {Surname} - {Experience} Years";
}
