using System;

class Session
{
    public Time Start { get; set; }
    public Time End { get; set; }
    public Guid OccupiedID { get; set; } = Guid.Empty;

    public override string ToString()
        => $"{Start.ToString()} - {End.ToString()} | "
            + (OccupiedID == Guid.Empty ? "EMPTY" : "FULL");
}