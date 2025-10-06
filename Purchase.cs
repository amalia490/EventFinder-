using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Purchase
{
    public int PurchaseId { get; set; }
    
    public string PurchaseMethod { get; set; }
    public string PurchaseAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int ParticipantId { get; set; }


}