#!/usr/bin/env -S dotnet --

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/union

// begin-snippet: cannot-implicitly-convert-powerdrill-to-tool
// Cannot implicitly convert PowerDrill to Tool
// Tool myTool = new PowerDrill(true, true, false);
// end-snippet

// begin-snippet: using-union-types
Tool myTool = new Drill(new PowerDrill(true, true, false));

switch (myTool)
{
    case Hammer h:
        Console.WriteLine($"Hammer: {h.Type}");
        break;
    case Screwdriver s:
        Console.WriteLine($"Screwdriver: {s.Type}");
        break;
    case Drill d:
        switch (d)
        {
            case PowerDrill pd:
                Console.WriteLine($"PowerDrill: Hammer={pd.Hammer}, Reversible={pd.Reversible}, Cordless={pd.Cordless}");
                break;
            case ManualDrill md:
                Console.WriteLine("ManualDrill");
                break;
        }
        break;
}
// end-snippet

// begin-snippet: switch-expression-with-union-types
var t = myTool switch 
{
    Hammer h => $"Hammer: {h.Type}",
    Screwdriver s => $"Screwdriver: {s.Type}",
    Drill d => d switch
    {
        PowerDrill pd => $"PowerDrill: Hammer={pd.Hammer}, Reversible={pd.Reversible}, Cordless={pd.Cordless}",
        //ManualDrill md => "ManualDrill"
    }
};
// end-snippet

// begin-snippet: before-union-types
public abstract record Pet;
public record Dog : Pet;
public record Cat : Pet;
// end-snippet

// begin-snippet: after-union-types
public enum HammerType
{
    Claw,
    Sledge
}
public record Hammer(HammerType Type);

public enum ScrewdriverType
{
    Flathead,
    Phillips
}
public record Screwdriver(ScrewdriverType Type);

public record PowerDrill(bool Hammer, bool Reversible, bool Cordless);
public record ManualDrill();

public union Drill(PowerDrill, ManualDrill);

public union Tool(Hammer, Screwdriver, Drill);
// end-snippet

