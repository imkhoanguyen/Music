using Microsoft.AspNetCore.Http;
using Music.Application.Dtos;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Application.Helpers
{
    public static class FileHelper
    {
        // Maximum allowed file size (5MB)
        private const long MaxImageSize = 5 * 1024 * 1024;
        
        // Allowed image extensions
        private static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        
        // Default base folder for uploads (e.g., in wwwroot)
        private const string DefaultImagesFolder = "images";

        public static async Task<TData<string>> SaveImageAsync(IFormFile file, string webRootPath, string folderName)
        {
            var result = new TData<string>();

            if (file == null || file.Length == 0)
            {
                result.SetError("File is empty.");
                return result;
            }

            // Validation: Max Size
            if (file.Length > MaxImageSize)
            {
                result.SetError($"File size exceeds the limit of {MaxImageSize / (1024 * 1024)}MB.");
                return result;
            }

            // Validation: Allowed Extensions
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !AllowedImageExtensions.Contains(extension))
            {
                result.SetError($"Invalid file type. Only {string.Join(", ", AllowedImageExtensions)} are allowed.");
                return result;
            }

            try
            {
                var uploadsFolder = Path.Combine(webRootPath, DefaultImagesFolder, folderName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                string fileExt = Path.GetExtension(file.FileName);
                string uniqueFileName = file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                int counter = 1;
                while (File.Exists(filePath))
                {
                    uniqueFileName = $"{fileNameWithoutExtension} ({counter}){fileExt}";
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    counter++;
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Return the relative path
                result.SetSuccess($"/{DefaultImagesFolder}/{folderName}/{uniqueFileName}");
                return result;
            }
            catch (Exception ex)
            {
                result.SetError($"Error saving file: {ex.Message}");
                return result;
            }
        }
    }
}
