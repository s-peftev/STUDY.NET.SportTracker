using SportTracker.BL.Model;
using System.Text.Json;

namespace SportTracker.BL.Services.Storage
{
	public class FileStorage() : IDataStorage
	{
		private readonly string _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

		private static readonly JsonSerializerOptions s_readOptions = new()
		{
			WriteIndented = true
		};

		private string GetPath(string dataType)
		{
			return dataType switch
			{
				nameof(User) => "users.json",
				_ => throw new NotImplementedException()
			};
		}
		public List<T> LoadData<T>() 
		{
			using var fs = new FileStream(GetPath(nameof(T)), FileMode.OpenOrCreate);

			if (fs.Length > 0 && JsonSerializer.Deserialize<List<T>>(fs) is List<T> data)
			{
				return data;
			}
			else
			{
				return [];
			}
		}

		public void SaveData<T>(List<T> data)
		{
			using var writeFs = new FileStream(GetPath(nameof(T)), FileMode.Create);
			JsonSerializer.Serialize(writeFs, data, s_readOptions);
		}
	}
}
