using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class detailDriverData {
		[JsonPropertyName("driverId")]
		public required int driverID { get; set; }

		[JsonPropertyName("driverRef")]
		public required string driverRef { get; set; }

		[JsonPropertyName("number")]
		public required string number { get; set; }

		[JsonPropertyName("code")]
		public required string code { get; set; }

		[JsonPropertyName("forename")]
		public required string forename { get; set; }

		[JsonPropertyName("surname")]
		public required string surname { get; set; }

		[JsonPropertyName("dob")]
		public required string dob { get; set; }

		[JsonPropertyName("nationality")]
		public required string nationality { get; set; }

		[JsonPropertyName("url")]
		public required string url { get; set; }

		public void cleanEmptyStrings() {
			if (code != null && code.Contains("\\N")) code = code.Replace("\\N", "");
			if (number != null && number.Contains("\\N")) number = number.Replace("\\N", "");
		}
	}
}
