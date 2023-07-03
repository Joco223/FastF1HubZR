using FastF1Shared.Model;
using Microsoft.AspNet.SignalR.Client;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class raceOverviewService {
		private const string dataURL = "https://api.quickf1hub.com";
		public static async Task<(bool, List<Race>?)> getRaces(int year) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getRaces?year={year}");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<Race>? events = JsonSerializer.Deserialize<List<Race>>(result);

				if (events != null) {
					foreach (Race e in events) {
						e.updateSessions();
						e.cleanEmptyStrings();
					}
				}

				return (true, events);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}

		public static async Task<(bool, List<Season>?)> getSeasons() {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"{dataURL}/getSeasons");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<Season>? seasons = JsonSerializer.Deserialize<List<Season>>(result);

				return (true, seasons);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}

		public static async void connectLive() {
			HubConnection conn = new("https://livetiming.formula1.com/signalr/connect?clientProtocol=1.5");

			await conn.Start();
		}
	}
}
