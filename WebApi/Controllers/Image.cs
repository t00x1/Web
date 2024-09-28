using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Domain.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageService _fileProvider;

    // Конструктор класса
    
    public ImageController(IImageService fileProvider)
    {
        _fileProvider = fileProvider;
    }

    /// <summary>
    /// Загружает файл на сервер
    /// </summary>
    /// <param name="file">Файл для загрузки</param>
    /// <returns>Информация о загруженном файле</returns>
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        Console.WriteLine(file.Headers);

        if (file == null || file.Length == 0)
            return BadRequest("Файл не был загружен или пуст.");

        /*// Получаем путь к директории через провайдер файлов
        var fileInfo = _fileProvider.GetFileInfo("uploads");

        // Создаем папку, если она не существует
        if (!Directory.Exists(fileInfo.PhysicalPath))
        {
            Console.WriteLine("dir is not exist");
            Directory.CreateDirectory(fileInfo.PhysicalPath);
        }

        // Уникальное имя файла
        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.Combine(fileInfo.PhysicalPath, fileName);

        // Сохраняем файл в директорию
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }*/

        return Ok(new { message = "Файл успешно загружен",/* fileName = fileName */});
    }
    
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok(new int { 1, 2 });
    }

}
