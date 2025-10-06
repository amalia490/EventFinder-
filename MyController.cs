using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using static System.Net.Mime.MediaTypeNames;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("add-category")]
    public IActionResult AddItem(Category cat)
    {
        //var cat1 = new Category { Name = "Cinema" };
        // cat1.Shows.Add(new Show { Name = "Cadre Secventiale", Description = "Scurtmetraj independent si cinema urban", BeginDate = new DateTime(2025, 7, 5, 18, 0, 0), EndDate = new DateTime(2025, 7, 6, 23, 0, 0), LocatieId})
        _context.Categories.Add(cat);
        _context.SaveChanges();
        return Ok(cat);
    }

    [HttpPost("add-location")]
    public IActionResult AddLocation(Location loc)
    {
        _context.Locations.Add(loc);
        _context.SaveChanges();
        return Ok(loc);
    }

    [HttpPost("add-show")]
    public async Task<IActionResult> AddShow(Show show, IFormFile image)
    {
        if (image == null || image.Length == 0)
            return BadRequest("no file uploaded.");
        var imagesfolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        var filename = Path.GetFileName(image.FileName);
        var filepath = Path.Combine(imagesfolder, filename);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }
        show.PathImage = Path.Combine("Images", filename);
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();
        return Ok(show);
    }

    [HttpPost("add-participant")]
    public IActionResult AddParticipant(Participant participant)
    {
        _context.Participants.Add(participant);
        _context.SaveChanges();
        return Ok(participant);
    }

    [HttpPost("add-ticketType")]
    public IActionResult AddTicketType(TicketType ticketType)
    {
        _context.TicketTypes.Add(ticketType);
        _context.SaveChanges();
        return Ok(ticketType);
    }

    //[HttpPost("add-image")]
    //public async  Task<IActionResult> AddImage(IFormFile image)
    //{
    //    if (image == null || image.Length == 0)
    //        return BadRequest("No file uploaded.");
    //    var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    //    var fileName = Path.GetFileName(image.FileName);
    //    var filePath = Path.Combine(imagesFolder, fileName);

    //}

    [HttpPut("update-Show/{showid}")]
    public async Task<IActionResult> UpdateLocation(int showid, IFormFile img)
    {
        var show = _context.Shows.Find(showid);
        if (show == null)
            return NotFound();
        if (img == null || img.Length == 0)
            return BadRequest("no file uploaded.");
        var imagesfolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        var filename = Path.GetFileName(img.FileName);
        var filepath = Path.Combine(imagesfolder, filename);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await img.CopyToAsync(stream);
        }
        show.PathImage = $"Images/{filename}";
        await _context.SaveChangesAsync();
        return Ok(show);
    }

    [HttpPut("update-ShowDetails/{showid}")]
    public async Task<IActionResult> UpdateShowDetails(int showid, Show updatedShow)
    {
        var show = await _context.Shows.FindAsync(showid);
        if (show == null)
            return NotFound();
        show.Name = updatedShow.Name;
        await _context.SaveChangesAsync();
        return Ok(show);
    }

    [HttpGet("get-shows")]
    public async Task<ActionResult<IEnumerable<Show>>> GetShows()
    {
        var shows = await _context.Shows.ToListAsync();
        if (shows == null || shows.Count == 0)
            return NotFound();
        return Ok(shows);
    }

    [HttpGet("get-participant")] 
    public async Task<ActionResult<Participant>> GetParticipant(int id)
    {
        var partItem = await _context.Participants.FindAsync(id);
        if (partItem == null)
            return NotFound();
        return partItem;
    }

    [HttpGet("get-Ticket")]
    public async Task<ActionResult<Ticket>> GetTicket(int id)
    {
        var TickItem = await _context.Tickets.FindAsync(id);
        if (TickItem == null)
            return NotFound();
        return TickItem;
    }

    [HttpGet("get-TicketType")]
    public async Task<ActionResult<TicketType>> GetTicketType(int id)
    {
        var TtItem = await _context.TicketTypes.FindAsync(id);
        if (TtItem == null)
            return NotFound();
        return TtItem;
    }


    [HttpDelete("delete-category/{id}")]
    public IActionResult DeleteItem(int id)
    {
        var cat = _context.Categories.Find(id);
        _context.Categories.Remove(cat);
        _context.SaveChanges();
        return Ok(cat);
    }

    [HttpDelete("delete-ticketType/{id}")]
    public IActionResult DeleteTicketTypes(int id)
    {
        var ticketT = _context.TicketTypes.Find(id);
        _context.TicketTypes.Remove(ticketT);
        _context.SaveChanges();
        return Ok(ticketT);
    }
}