using System.Text.Json;

namespace Adrien.Bassail.FaceDetection;

public class FaceDetection
{

    public IList<FaceDetectionResult> DetectInScenes(IList<byte[]>
    imagesSceneData)
    {
        IList<FaceDetectionResult> results = new List<FaceDetectionResult>();
        var tasks = new List<Task>();
        foreach (var image in imagesSceneData)
        {
            var task = Task.Run(() => results.Add(new FaceDetectionResult().FaceDetectionInScene(image)));
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());
        
        //results.Add(new FaceDetectionResult().FaceDetectionInScene(imagesSceneData[0]));
        //results.Add(new FaceDetectionResult().FaceDetectionInScene(imagesSceneData[1]));
        //results.Add(new FaceDetectionResult().FaceDetectionInScene(imagesSceneData[2]));
        
        return results;
    }

    public FaceDetectionResult DetectInScene(byte[] imageData)
    {
        return new FaceDetectionResult().FaceDetectionInScene(imageData);
    }

}
