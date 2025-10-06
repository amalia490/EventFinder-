using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Location
{
    public int LocationId { get; set; }
  
    public string Name { get; set; }

    public int Capacity { get; set; }
    
}