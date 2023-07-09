using Newtonsoft.Json.Linq;

namespace FastF1Shared.Service {
	public class wikipediaAPIService {

		public static async Task<(bool, string?)> getPageImg(string page) {
			try {
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync($"https://en.wikipedia.org/w/api.php?action=query&titles={page}&prop=pageimages&format=json&pithumbsize=1000");
				_ = response.EnsureSuccessStatusCode();
				string result = await response.Content.ReadAsStringAsync();

				JObject jsonObj = JObject.Parse(result);

				JToken p1 = jsonObj["query"];
				if (p1 != null) {
					JToken p2 = p1["pages"].First.First;

					if (p2 != null) {
						JToken p3 = p2["thumbnail"];

						if (p3 != null) {
							JToken p4 = p3["source"];
							string url = p4.Value<string>();
							return (true, url);
						}
					}
				}

				return (true, null);
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine("Error: " + e.ToString());
				return (true, null);
			}
		}
	}
}
