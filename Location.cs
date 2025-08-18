using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Location
{
    public int LocationId { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Show> Shows { get; set; }
}