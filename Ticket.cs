using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Ticket
{
    public int TicketId { get; set; }
  
    public string PurchaseId { get; set; }
    public string ParticipantId { get; set; }
    public string Email { get; set; }

    public string TicketType { get; set; }

}