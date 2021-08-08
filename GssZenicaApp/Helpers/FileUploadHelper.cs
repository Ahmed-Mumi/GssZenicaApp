using GssZenicaApp.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GssZenicaApp.Helpers
{
    public static class FileUploadHelper
    {
        public static string EquipmentReceipt { get; set; } = "EquipmentReceipt";
        public static async Task<string> UploadFileGetDocumentName(string rootPath, string documentName,
            IFormFile documentFile, string folderName)
        {
            if (!String.IsNullOrEmpty(documentName))
            {
                RemoveFileHelper(rootPath, documentName, folderName);
            }
            var uploadData = UploadFileHelper(rootPath, documentFile.FileName, folderName);
            await documentFile.CopyToAsync(uploadData.FileStream);
            uploadData.FileStream.Close();
            return uploadData.FileName;
        }
        public static ReturnFileUploadInfoViewModel UploadFileHelper(string rootPath, string fileName, string folderName)
        {
            var returnData = new ReturnFileUploadInfoViewModel();
            string createFileName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            returnData.FileName = createFileName += DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(rootPath + "/" + folderName, createFileName);
            returnData.FileStream = new FileStream(path, FileMode.Create);
            return returnData;
        }
        public static void RemoveFileHelper(string rootPath, string documentName, string folderName)
        {
            var filePath = Path.Combine(rootPath, folderName, documentName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
