using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class driverQualyResult {
		[JsonPropertyName("position")]
		public required int position { get; set; }

		[JsonPropertyName("Name")]
		public required string name { get; set; }

		[JsonPropertyName("ConstructorsName")]
		public required string constructorsName { get; set; }

		[JsonPropertyName("q1")]
		public string? q1 { get; set; }

		[JsonPropertyName("q2")]
		public string? q2 { get; set; }

		[JsonPropertyName("q3")]
		public string? q3 { get; set; }

		[JsonPropertyName("url")]
		public required string url { get; set; }

		[JsonPropertyName("driverId")]
		public required int driverID { get; set; }

		public void cleanEmptyStrings() {
			if (name.Contains("\\N")) name = name.Replace("\\N", "");
			if (constructorsName.Contains("\\N")) constructorsName = constructorsName.Replace("\\N", "");
			if (q1 != null && q1.Contains("\\N")) q1 = q1.Replace("\\N", "");
			if (q2 != null && q2.Contains("\\N")) q2 = q2.Replace("\\N", "");
			if (q3 != null && q3.Contains("\\N")) q3 = q3.Replace("\\N", "");
		}
	}
}
