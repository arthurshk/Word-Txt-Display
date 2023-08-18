using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

public class HomeController : Controller
{
	private readonly ApplicationContext _context;

	public HomeController(ApplicationContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		return View();
	}

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            string content = await reader.ReadToEndAsync();
            string[] words = content.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                _context.Words.Add(new Word { Value = word });
            }

            await _context.SaveChangesAsync();
            var wordList = await _context.Words.ToListAsync();
            ViewData["WordList"] = wordList;
        }

        return View(nameof(Index));
    }


    public async Task<IActionResult> WordList()
	{
		var words = await _context.Words.ToListAsync();
		return View(words);
	}
}
