using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class Driver {
		[JsonPropertyName("driverId")]
		public int? driverId { get; set; }

		[JsonPropertyName("name")]
		public string? name { get; set; }

		[JsonPropertyName("driverRef")]
		public string? driverRef { get; set; }

		[JsonPropertyName("number")]
		public string? number { get; set; }

		[JsonPropertyName("code")]
		public string? code { get; set; }

		[JsonPropertyName("forename")]
		public string? forename { get; set; }

		[JsonPropertyName("surname")]
		public string? surname { get; set; }

		[JsonPropertyName("dob")]
		public string? dob { get; set; }

		[JsonPropertyName("nationality")]
		public string? nationality { get; set; }

		[JsonPropertyName("url")]
		public string? url { get; set; }

		[JsonPropertyName("wins")]
		public int? wins { get; set; }

		[JsonPropertyName("sprintWins")]
		public int? sprintWins { get; set; }

		public int? totalWins => wins + sprintWins;

		[JsonPropertyName("poles")]
		public int? poles { get; set; }

		[JsonPropertyName("championships")]
		public int? championships { get; set; }

		[JsonPropertyName("racePodiums")]
		public int? racePodiums { get; set; }

		[JsonPropertyName("sprintPodiums")]
		public int? sprintPodiums { get; set; }

		public int? totalPodiums => racePodiums + sprintPodiums;

		[JsonPropertyName("raceStarts")]
		public int? raceStarts { get; set; }

		[JsonPropertyName("totalPoints")]
		public float? totalPoints { get; set; }

		public void cleanEmptyStrings() {
			if (code != null && code.Contains("\\N")) code = code.Replace("\\N", "");
			if (number != null && number.Contains("\\N")) number = number.Replace("\\N", "");
		}
	}
}
