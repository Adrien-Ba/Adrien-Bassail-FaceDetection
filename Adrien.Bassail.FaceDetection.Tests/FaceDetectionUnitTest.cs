using System.Reflection;
using System.Text.Json;

namespace Adrien.Bassail.FaceDetection.Tests;

public class FaceDetectionUnitTest
{
    [Fact]
    public async Task ObjectShouldBeDetectedCorrectly()
    {
        var executingPath = GetExecutingPath();
        var imageScenesData = new List<byte[]>();
        foreach (var imagePath in
                 Directory.EnumerateFiles(Path.Combine(executingPath, "Scenes")))
        {
            var imageBytes = await File.ReadAllBytesAsync(imagePath);
            imageScenesData.Add(imageBytes);
        }

        var detectObjectInScenesResults = new FaceDetection().DetectInScenes(imageScenesData);
        

        Assert.Equal("[{\"X\":261,\"Y\":62},{\"X\":42,\"Y\":84}]",JsonSerializer.Serialize(detectObjectInScenesResults[0].Points));
        
        Assert.Equal("[{\"X\":97,\"Y\":48},{\"X\":576,\"Y\":296}]",JsonSerializer.Serialize(detectObjectInScenesResults[1].Points));
    }
    private static string GetExecutingPath()
    {
        var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
        var executingPath = Path.GetDirectoryName(executingAssemblyPath);
        return executingPath;
    }
}