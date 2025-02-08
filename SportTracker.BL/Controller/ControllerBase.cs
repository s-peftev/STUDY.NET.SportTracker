
using SportTracker.BL.Model;
using System.Text.Json;

namespace SportTracker.BL.Controller
{
	public abstract class ControllerBase
	{
		private static readonly JsonSerializerOptions s_readOptions = new()
		{
			WriteIndented = true
		};

		protected static List<T> LoadData<T>(string filePath)
		{
			using var fs = new FileStream(filePath, FileMode.OpenOrCreate);

			if (fs.Length > 0 && JsonSerializer.Deserialize<List<T>>(fs) is List<T> data)
			{
				return data;
			}
			else
			{
				return [];
			}
		}

		protected static void SaveData<T>(string filePath, List<T> data)
		{
			using var writeFs = new FileStream(filePath, FileMode.Create);
			JsonSerializer.Serialize(writeFs, data, s_readOptions);
		}
	}
}
