using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebsiteMiniProjekt.Pages
{
    public class IndexModel4 : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel4(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}