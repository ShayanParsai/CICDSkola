using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/api/encrypt", (string plaintext) =>
{
    // Implementera kryptering
    Console.WriteLine(plaintext);
    return new OkResult();
});

app.MapGet("/api/decrypt", (string encryptedText) =>
{
    // Implementera avkryperting
    Console.WriteLine(encryptedText);
    return new OkResult();
});

app.Run();
