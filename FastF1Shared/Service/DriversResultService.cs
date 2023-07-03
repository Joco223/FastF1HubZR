using FastF1Shared.Model;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class DriversResultService {

		private const string dataURL = "https://api.quickf1hub.com";
		public static async Task<(bool, List<driverRaceResult>?)> getRaceResults(int year, string round) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getRaceResults?year={year}&round={round}");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<driverRaceResult>? times = JsonSerializer.Deserialize<List<driverRaceResult>>(result);

				return (true, times);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}

		public static async Task<(bool, List<driverQualyResult>?)> getQualyResults(int year, string round) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getQualyResults?year={year}&round={round}");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<driverQualyResult>? times = JsonSerializer.Deserialize<List<driverQualyResult>>(result);

				if (times != null) {
					foreach (driverQualyResult time in times) {
						time.cleanEmptyStrings();
					}
				}

				return (true, times);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}
	}
}
