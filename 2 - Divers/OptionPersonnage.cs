using System.Collections.Generic;

public class COption
{
    public bool PlanningActive;
    public Dictionary<string, bool[]> Planning = new Dictionary<string, bool[]>()
    {
        {
            "Lundi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Mardi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Mercredi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Jeudi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Vendredi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Samedi",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        },
        {
            "Dimanche",
            new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true }
        }
    };
}
