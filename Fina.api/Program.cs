using Fina.api.Data;
using Fina.api.Handlers;
using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Api.Endpoints;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// const string connectionString = "Server=localhost,1433;Database=FinaFlow;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

// builder.Services.AddDbContext<AppDbContext>(
// x => x.UseSqlServer(connectionString));
// builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
// builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();



// var app = builder.Build();

// app.MapEndpoints();

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();


app.Run();
