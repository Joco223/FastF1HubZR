using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class driverRaceResult {

		[JsonPropertyName("Position")]
		public required string position { get; set; }

		[JsonPropertyName("Name")]
		public required string driverName { get; set; }

		[JsonPropertyName("Abrv")]
		public required string driverAbrv { get; set; }

		[JsonPropertyName("Number")]
		public required string driverNumber { get; set; }

		[JsonPropertyName("Constructors")]
		public required string constructors { get; set; }

		[JsonPropertyName("points")]
		public required double points { get; set; }

		[JsonPropertyName("Status")]
		public required string status { get; set; }

		[JsonPropertyName("url")]
		public required string url { get; set; }

		[JsonPropertyName("driverId")]
		public required int driverID { get; set; }
	}
}

