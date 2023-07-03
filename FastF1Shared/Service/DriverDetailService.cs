using FastF1Shared.Model;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class driverDetailService {
		private const string dataURL = "https://api.quickf1hub.com";
		public static async Task<(bool, detailDriverData?)> getDriver(int id) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getDriver?id={id}");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				detailDriverData? driver = JsonSerializer.Deserialize<detailDriverData>(result);

				driver?.cleanEmptyStrings();

				return (true, driver);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}
	}
}
