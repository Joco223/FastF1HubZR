using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class DriverTime {

		[JsonPropertyName("driver")]
		public required string name { get; set; }

		[JsonPropertyName("gap")]
		public double time { get; set; }
	}
}
