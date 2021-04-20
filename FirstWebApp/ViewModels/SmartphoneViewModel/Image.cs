using Microsoft.AspNetCore.Http;

namespace FirstWebApp.ViewModels
{
    public class Image
    {
        public string Path { get; set; }

        public IFormFile fullInfo { get; set; }
    }
}