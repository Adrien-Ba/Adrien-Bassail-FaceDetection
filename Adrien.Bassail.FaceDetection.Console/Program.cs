// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Adrien.Bassail.FaceDetection;

if (args.Length == 0)
{
    System.Console.WriteLine("Veuillez entrer un ou des chemins vers des images");
}

IList<byte[]> imagesData = new List<byte[]>();
IList<FaceDetectionResult> detectFaceInScencesResults = new List<FaceDetectionResult>();

foreach(var argument in args) {
    
    var imageData = await File.ReadAllBytesAsync(argument);
    imagesData.Add(imageData);
}

detectFaceInScencesResults = new FaceDetection().DetectInScenes(imagesData);

foreach (var detectionResult in detectFaceInScencesResults)
{
    System.Console.WriteLine($"Points:{JsonSerializer.Serialize(detectionResult.Points)}");
} 



