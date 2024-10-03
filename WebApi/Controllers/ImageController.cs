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
    IImageService imageService;


    public ImageController(IImageService fileProvider)
    {
        // _fileProvider = fileProvider;
        imageService = fileProvider;
    }




    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            string directory = @"..\..\Images";
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0; // Сбрасываем позицию потока???

            ImageUploadDto imageUploadDto = new ImageUploadDto
            {
                FileName = file.FileName,
                Content = file.OpenReadStream(),
                Size = file.Length 
            };
            

            try
            {
                await imageService.UploadImageAsync(imageUploadDto, directory);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            /*if (result.Success)
            {*/
                return Ok(new { Message = "Файл успешно загружен." });
           /* }*/
            /* return BadRequest(new { Message = result.ErrorMessage });*/

        }





        
       
    }
    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> GetFile(string fileName)
    {
       
        var filePath = @"..\..\Images\bc8c0dcc-78de-466b-97b9-6949d9647e07.jpg";

       
      

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Файл не найден.");
        }

        
        var memory = new MemoryStream();
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;

   
        var contentType = "application/octet-stream"; 

  
        return File(memory, contentType, Path.GetFileName(filePath));
    }
  Queryableq

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok(new int[] { 1, 3 });
    }
}
