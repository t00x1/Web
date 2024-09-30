using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Domain.Interfaces;
/*using Infrastructure.FileManagement;*/
using businessLogic.Services;

using Domain.ModelOfSettings;
using Domain.Functions.Files.InterfacesAbstract;


using Domain.error;
using businessLogic.Service;
using Domain.Models;
[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
   // private readonly IImageService _fileProvider;
    ImageService imageService;


    public ImageController(IImageService fileProvider)
    {
        // _fileProvider = fileProvider;
        imageService = new ImageService();
    }




    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);

            var imageUploadDto = new ImageUploadDto
            {
                FileName = file.FileName,
                Content = memoryStream.ToArray(),
                Size = file.Length // Получаем размер файла
            };

            imageService.UploadImageAsync(imageUploadDto);
            /*if (result.Success)
            {
                return Ok(new { Message = "Файл успешно загружен." });
            }*/
            /* return BadRequest(new { Message = result.ErrorMessage });*/
            return Ok();
        }




        /*if (file == null || file.Length == 0)
        {
            return BadRequest(new { ErrorCode = Codes.ErrorCode.EmptyFile, Message = "Файл не был загружен или пуст." });
        }

        IFile imageFile = new ImageFile(file);

        try
        {
            bool uploadResult = await imageFile.Upload();

            if (uploadResult)
            {
                return Ok(new { Message = "Файл успешно загружен." });
            }
            else
            {
                return StatusCode((int)Codes.ErrorCode.ServerError, new { ErrorCode = Codes.ErrorCode.ServerError, Message = "Произошла ошибка при загрузке файла." });
            }
        }
        catch (FileNotFoundException ex)
        {
            return NotFound(new { ErrorCode = Codes.ErrorCode.FileNotFound, Message = $"Файл не найден: {ex.Message}" });
        }
        catch (IOException ex)
        {
            return StatusCode((int)Codes.ErrorCode.ServerError, new { ErrorCode = Codes.ErrorCode.ServerError, Message = $"Ошибка ввода-вывода: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return StatusCode((int)Codes.ErrorCode.ServerError, new { ErrorCode = Codes.ErrorCode.ServerError, Message = $"Произошла ошибка: {ex.Message}" });
        }*/
        return Ok();
    }

        [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok(new int[] { 1, 3 });
    }
}
