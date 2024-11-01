namespace TestApp.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string foldername)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", foldername);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(folderPath, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            Console.WriteLine($"File saved to: {filePath}"); // Logging the file path

            return fileName;
        }
    }
}
