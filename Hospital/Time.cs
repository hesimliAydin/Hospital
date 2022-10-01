struct Time
{
    public int Hour { get; set; }
    public int Minute { get; set; }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public override string ToString()
        => $"{Hour:00}:{Minute:00}";
}
