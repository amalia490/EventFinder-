using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Show
{
    public int ShowId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly DataBegin { get; set; }
    public DateOnly DataEnd { get; set; }
    public int LocatieId { get; set; }
    public int CategoryId { get; set; }

}