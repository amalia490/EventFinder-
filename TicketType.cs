using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class TicketType
{
    public int TicketTypeId { get; set; }
    
    public int ShowId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public string Description { get; set; }
    public int availableTickets { get; set; }

}