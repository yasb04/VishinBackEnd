var builder = WebApplication.CreateBuilder(args);

// Lägg till stöd för Controllers och Swagger
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aktivera Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// VIKTIGT: Koppla in dina Controllers
app.MapControllers(); 

app.Run();