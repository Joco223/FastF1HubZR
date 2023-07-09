using FastF1Shared.Model;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class driversService {
		private const string dataURL = "https://api.quickf1hub.com";

		public static async Task<(bool, List<Driver>?)> getDriverList() {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getDriversList");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<Driver>? drivers = JsonSerializer.Deserialize<List<Driver>>(result);

				return (true, drivers);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}

		public static async Task<(bool, Driver?)> getDriverWithStats(int id) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getDriverWithStats?id={id}");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				Driver? driver = JsonSerializer.Deserialize<Driver>(result);

				driver?.cleanEmptyStrings();

				return (true, driver);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}

		public static async Task<(bool, string?)> getDriverImageUrl(string driverUrl) {
			int slashIndex = driverUrl.LastIndexOf('/');
			string searchTerm = driverUrl[(slashIndex + 1)..];

			return await wikipediaAPIService.getPageImg(searchTerm);
		}
	}
}
