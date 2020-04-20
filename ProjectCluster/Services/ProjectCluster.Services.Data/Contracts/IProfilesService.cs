namespace ProjectCluster.Services.Data
{
    public interface IProfilesService
    {
        T GetById<T>(string id);
    }
}
