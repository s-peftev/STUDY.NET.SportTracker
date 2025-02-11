namespace SportTracker.BL.Services.Storage
{
	public interface IDataStorage
	{
		List<T> LoadData<T>();
		void SaveData<T>(List<T> data);
	}
}
