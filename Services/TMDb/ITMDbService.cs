using TMDbLib.Client;

namespace Services.TMDb
{
    public interface ITMDbService
    {
        TMDbClient Client { get; }

        string GetImagePath(string size, string filePath);
    }
}