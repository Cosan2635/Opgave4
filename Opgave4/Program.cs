using Opgave4.Repository;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSingleton<CarRepository>(new CarRepository());

        var app = builder.Build();


        app.UseSwagger();
           app.UseSwaggerUI();
        // Configure the HTTP request pipeline.


        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}