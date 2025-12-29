using Microsoft.AspNetCore.Mvc;

namespace githubcicd;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        try
        {
            var employeesCount = _context.Employees.Count();
            return Ok($"Employees table has {employeesCount} records.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

