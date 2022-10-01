namespace PlatformService.Model
{
    public interface IPlatformRepo
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatfomrs();
        Platform? GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}