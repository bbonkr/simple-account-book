using kr.bbon.Core.Models;

namespace SimpleAccountBook.App.Models
{
    public class ApiErrorModel : ErrorModel
    {
        public string Instance { get; set; }

        public string Method { get; set; }

        public string Path { get; set; }
    }
}
