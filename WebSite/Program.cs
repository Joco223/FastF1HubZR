using Serilog;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Debug()
	.WriteTo.File("log.txt")
	.CreateLogger();


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

try {
	// Add services to the container.
	_ = builder.Services.AddRazorPages();
	_ = builder.Services.AddServerSideBlazor();
	_ = builder.Services.AddSingleton<FastF1Shared.Service.raceOverviewService>();

	WebApplication app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment()) {
		_ = app.UseExceptionHandler("/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		_ = app.UseHsts();
	}

	_ = app.UseHttpsRedirection();

	_ = app.UseStaticFiles();

	_ = app.UseRouting();

	_ = app.MapBlazorHub();
	_ = app.MapFallbackToPage("/_Host");

	app.Run();
} catch (Exception ex) {
	Log.Fatal(ex, "Application terminated unexpectedly");
} finally {
	Log.CloseAndFlush();
}

