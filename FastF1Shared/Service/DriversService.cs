using FastF1Shared.Model;
using Serilog;
using System.Text.Json;

namespace FastF1Shared.Service {
	public class driversService {
		private const string dataURL = "https://api.quickf1hub.com";

		/// <summary>
		/// Sends request to url target with parameters and returns result
		/// </summary>
		/// <param name="urlTarget">Target url which is added to dataURL</param>
		/// <param name="paramNames">Names of parameters</param>
		/// <param name="paramValues">Values of parameters</param>
		/// <returns>Value from request, null in case of failure</returns>
		private static async Task<string?> getResultFromUrl(string urlTarget, List<string>? paramNames, List<string>? paramValues) {
			try {
				HttpClient client = new();

				string urlStart = dataURL + "/" + urlTarget;

				if (paramNames != null && paramValues != null) {
					if (paramNames.Count > 0) {
						urlStart += "?";
					}

					if (paramNames.Count != paramValues.Count) {
						Log.Logger.Error($"Number of parameter names and values not equal: {paramNames.Count} {paramValues.Count}");
						return null;
					}

					for (int i = 0; i < paramNames.Count; i++) {
						string param = paramNames[i] + "=" + paramValues[i];
						urlStart += param;

						if (i != paramNames.Count - 1) {
							urlStart += "&";
						}
					}
				} else {
					Log.Logger.Information("No parameters for target: " + urlTarget);
				}

				HttpResponseMessage response = await client.GetAsync(urlStart);
				_ = response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			} catch (Exception e) {
				Log.Logger.Error("Exception thrown: " + e.Message);
				return null;
			}
		}

		/// <summary>
		/// Gets driver list with names and ids from data server
		/// </summary>
		/// <returns>List of driver objects</returns>
		public static async Task<(bool, List<Driver>?)> getDriverList() {
			string? serviceResult = await getResultFromUrl("getDriversList", null, null);

			if (serviceResult != null) {
				List<Driver>? drivers = JsonSerializer.Deserialize<List<Driver>>(serviceResult);

				return (true, drivers);
			} else {
				return (true, null);
			}
		}

		/// <summary>
		/// Get driver with stats with the specificed ID
		/// </summary>
		/// <param name="id">ID of the driver</param>
		/// <returns>Driver object with stats</returns>
		public static async Task<(bool, Driver?)> getDriver(int id) {
			string? serviceResult = await getResultFromUrl("getDriver", new List<string> { "id" }, new List<string> { id.ToString() });

			if (serviceResult != null) {
				Driver? driver = JsonSerializer.Deserialize<Driver>(serviceResult);

				return (true, driver);
			} else {
				return (true, null);
			}
		}

		public static async Task<(bool, List<driverRaceResult>?)> getRaceResults(int year, string round) {
			string? serviceResult = await getResultFromUrl("getRaceResults", new List<string> { "year", "round" }, new List<string> { year.ToString(), round.ToString() });

			if (serviceResult != null) {
				List<driverRaceResult>? results = JsonSerializer.Deserialize<List<driverRaceResult>>(serviceResult);

				return (true, results);
			} else {
				return (true, null);
			}
		}

		public static async Task<(bool, List<driverQualyResult>?)> getQualyResults(int year, string round) {
			string? serviceResult = await getResultFromUrl("getQualyResults", new List<string> { "year", "round" }, new List<string> { year.ToString(), round.ToString() });

			if (serviceResult != null) {
				List<driverQualyResult>? results = JsonSerializer.Deserialize<List<driverQualyResult>>(serviceResult);

				return (true, results);
			} else {
				return (true, null);
			}
		}


		/// <summary>
		/// Returns url to image from top image in wikipedia from passed in url
		/// </summary>
		/// <param name="driverUrl">URL to wikipedia page</param>
		/// <returns>URL to top image on the wikipedia page</returns>
		public static async Task<(bool, string?)> getDriverImageUrl(string driverUrl) {
			int slashIndex = driverUrl.LastIndexOf('/');
			string searchTerm = driverUrl[(slashIndex + 1)..];

			return await wikipediaAPIService.getPageImg(searchTerm);
		}
	}
}
