using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Payment
{
    public int PaymentId { get; set; }
    public string Url { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentAmount { get; set; }
    public DateOnly PaymentDate { get; set; }
    public int ParticipantId { get; set; }


}