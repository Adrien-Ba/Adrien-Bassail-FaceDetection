using Microsoft.AspNetCore.Mvc;

namespace Adrien.Bassail.FaceDetection.WebApi;

[ApiController]
[Route("[controller]")]
public class FaceDetectionController : ControllerBase
{
    private readonly FaceDetection _faceDetection;

    public FaceDetectionController(FaceDetection faceDetection)
    {
        _faceDetection = faceDetection;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
    {
        if (files.Count != 1)
            return BadRequest();
        using var sceneSourceStream = files[0].OpenReadStream();
        using var sceneMemoryStream = new MemoryStream();
        sceneSourceStream.CopyTo(sceneMemoryStream);
        var imageSceneData = sceneMemoryStream.ToArray();
        // Your implementation code
        var imageDataBytes = _faceDetection.DetectInScene(imageSceneData).ImageData;
        
        // La méthode ci-dessous permet de retourner une image depuis un tableau de bytes
        return File(imageDataBytes, "image/png");
    }
}