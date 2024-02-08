using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/api/encrypt", (string plaintext) =>
{
    int shift = 3; // Byter till 3 bokstäver längre fram i alfabetet
    string encryptedText = CaesarCipherEncrypt(plaintext, shift);
    Console.WriteLine($"Plaintext: {plaintext}, Encrypted: {encryptedText}");
    return Results.Ok(encryptedText);
});

app.MapGet("/api/decrypt", (string encryptedText) =>
{
    int shift = 3; // Byter till 3 bokstäver längre fram i alfabetet
    string decryptedText = CaesarCipherDecrypt(encryptedText, shift); //skickas in som minus för att ta bak 3 bokstäver
    Console.WriteLine($"Encrypted: {encryptedText}, Decrypted: {decryptedText}");
    return Results.Ok(decryptedText);
});

app.Run();

// Caesar cipher, man byter x antal bokstäver fram eller bak i alfabetet
string CaesarCipherEncrypt(string input, int shift)
{
    string result = string.Empty;
    foreach (char ch in input)
    {
        if (char.IsLetter(ch))
        {
            char shiftedChar = (char)(ch + shift);
            if (char.IsUpper(ch))
            {
                if (shiftedChar > 'Z')
                    shiftedChar = (char)(shiftedChar - 26);
            }
            else
            {
                if (shiftedChar > 'z')
                    shiftedChar = (char)(shiftedChar - 26);
            }
            result += shiftedChar;
        }
        else
        {
            result += ch;
        }
    }
    return result;
}

string CaesarCipherDecrypt(string input, int shift)
{
    return CaesarCipherEncrypt(input, -shift);
}
