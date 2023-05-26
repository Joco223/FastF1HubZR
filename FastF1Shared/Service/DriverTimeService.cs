using FastF1Shared.Model;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class DriverTimeService {

#if RELEASE
        private const string dataURL = "http://joco223.pythonanywhere.com/";
#else
		private const string dataURL = "http://192.168.0.11:4000/";
#endif
		public static async Task<(bool, List<DriverTime>?)> GetDriverTimeAsync() {
			try {
				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(dataURL);
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				List<DriverTime>? times = JsonSerializer.Deserialize<List<DriverTime>>(result);

				return (true, times);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (false, new List<DriverTime>());
			}
		}
	}
}
