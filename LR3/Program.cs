using LR3.Calculation;
using LR3.CustomException;
using LR3.TimeSummary;
using System.Text;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ICalculationService,SimpleCalculationService>();
builder.Services.AddTransient<ITimeSummaryService,TimeSummaryService>();


var app = builder.Build();

app.UseExceptionHandling();
app.UseTimeSummary();
app.UseCalculation();

app.Run();