using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;


public class Review
{
    public int ReviewId { get; set; }
    public string Url { get; set; }
    public string Text { get; set; }
    public int ShowId { get; set; }
    public int ParticipantId { get; set; }

}