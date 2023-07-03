using System.Text.Json.Serialization;

namespace FastF1Shared.Model {
	public class Season {
		[JsonPropertyName("year")]
		public required int year { get; set; }

		[JsonPropertyName("url")]
		public required string url { get; set; }
	}
}
