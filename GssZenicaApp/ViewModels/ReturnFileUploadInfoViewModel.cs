using System.IO;

namespace GssZenicaApp.ViewModels
{
    public class ReturnFileUploadInfoViewModel
    {
        public string FileName { get; set; }
        public FileStream FileStream { get; set; }
    }
}
