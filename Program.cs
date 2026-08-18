using System.Net;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string endPoint = "kmc08311_gmail_com";
app.MapGet(endPoint, (string? x, string? y) =>
{
    if ( !BigInteger.TryParse(x, out BigInteger bigX) || bigX <= 0 ||
        !BigInteger.TryParse(y, out BigInteger bigY) || bigY <= 0)
    {
        return Results.Text("NaN", "text/plain");
    }  
    BigInteger gcd = BigInteger.GreatestCommonDivisor(bigX, bigY);
    Console.WriteLine(gcd);
    BigInteger lcm = (bigX * bigY) / gcd;
    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();
