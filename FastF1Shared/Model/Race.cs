using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class Race {
		[JsonPropertyName("raceId")]
		public required int raceId { get; set; }

		[JsonPropertyName("round")]
		public required int round { get; set; }

		[JsonPropertyName("raceName")]
		public required string raceName { get; set; }

		[JsonPropertyName("raceDT")]
		public required string raceDT { get; set; }

		[JsonPropertyName("circuitName")]
		public required string circuitName { get; set; }

		[JsonPropertyName("circuitLocation")]
		public required string circuitLocation { get; set; }

		[JsonPropertyName("circuitCountry")]
		public required string circuitCountry { get; set; }

		[JsonPropertyName("circuitLatitude")]
		public required double circuitLatitude { get; set; }

		[JsonPropertyName("circuitLongtitude")]
		public required double circuitLongtitude { get; set; }

		[JsonPropertyName("circuitAltitude")]
		public required string circuitAltitude { get; set; }

		[JsonPropertyName("url")]
		public required string url { get; set; }

		[JsonPropertyName("fp1DT")]
		public required string fp1DT { get; set; }

		[JsonPropertyName("fp2DT")]
		public required string fp2DT { get; set; }

		[JsonPropertyName("fp3DT")]
		public required string fp3DT { get; set; }

		[JsonPropertyName("qualiDT")]
		public required string qualiDT { get; set; }

		[JsonPropertyName("sprintDT")]
		public required string sprintDT { get; set; }

		[JsonPropertyName("type")]
		public required string type { get; set; }

		public List<string> sessions = new();

		public string? country { get; set; }
		public string? city { get; set; }

		public void updateSessions() {
			if (type == "Sprint") {
				sessions.Add("FP1");
				sessions.Add("FP2");
				sessions.Add("Qualifying");
				sessions.Add("Sprint");
				sessions.Add("Race");
			} else {
				sessions.Add("FP1");
				sessions.Add("FP2");
				sessions.Add("FP3");
				sessions.Add("Qualifying");
				sessions.Add("Race");
			}
		}

		public void cleanEmptyStrings() {
			if (raceName.Contains("\\N")) raceName = raceName.Replace("\\N", "");
			if (circuitAltitude.Contains("\\N")) circuitAltitude = circuitAltitude.Replace("\\N", "");
			if (circuitCountry.Contains("\\N")) circuitCountry = circuitCountry.Replace("\\N", "");
			if (circuitLocation.Contains("\\N")) circuitLocation = circuitLocation.Replace("\\N", "");
			if (circuitName.Contains("\\N")) circuitName = circuitName.Replace("\\N", "");
			if (city != null && city.Contains("\\N")) city = city.Replace("\\N", "");
			if (country != null && country.Contains("\\N")) country = country.Replace("\\N", "");
			if (fp1DT != null && fp1DT.Contains("\\N")) fp1DT = fp1DT.Replace("\\N", "");
			if (fp2DT != null && fp2DT.Contains("\\N")) fp2DT = fp2DT.Replace("\\N", "");
			if (fp3DT != null && fp3DT.Contains("\\N")) fp3DT = fp3DT.Replace("\\N", "");
			if (qualiDT != null && qualiDT.Contains("\\N")) qualiDT = qualiDT.Replace("\\N", "");
			if (raceDT != null && raceDT.Contains("\\N")) raceDT = raceDT.Replace("\\N", "");
			if (sprintDT != null && sprintDT.Contains("\\N")) sprintDT = sprintDT.Replace("\\N", "");
		}
	}
}
