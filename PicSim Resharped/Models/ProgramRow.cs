namespace PicSim_Resharped.Models;

public class ProgramRow
{
    public bool HasBreakpoint { get; set; } = false;
    public string PC { get; set; }
    public string Command { get; set; }

    public ProgramRow(string command, string pc)
    {
        Command = command;
        PC = pc;
    }
}