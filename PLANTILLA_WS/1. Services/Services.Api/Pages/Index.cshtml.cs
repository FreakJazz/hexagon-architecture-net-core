using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Models;

namespace Services.Api.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OpenApiContact Contact { get; set; }
        public OpenApiLicense License { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Version = "TemplateCore8v1.0.0";
            Title = "GENERAL TEMPLATE NET CORE HEXAGON ARCHITECTURE WITH SWAGGER with PostgreSQL";
            Description = "General template - Swagger Surface";
            Contact = new OpenApiContact
            {
                Name = "Jazmin Rodriguez",
                Email = "jazzrb2307@gmail.com",
                Url = new Uri("https://github.com/FreakJazz/")
            };
            License = new OpenApiLicense
            {
                Name = "GNU GENERAL PUBLIC LICENSE",
                Url = new Uri("https://fsf.org/")
            };
        }
    }
}
