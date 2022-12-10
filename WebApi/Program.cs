using Trainer_ml;

namespace WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("Predict/{collection}/{mintAddress}", async (
            string collection,
            string mintAddress) =>
        {
            using var client = new HttpClient();
            var metadata = await client.GetFromJsonAsync<Metadata>($"https://api-mainnet.magiceden.dev/v2/tokens/{mintAddress}");
            var sampleData = new Y00tPricePrediction.ModelInput()
            {
                Background = metadata.Attributes[0].Value,
                Fur = metadata.Attributes[1].Value,
                Face = metadata.Attributes[2].Value,
                Clothes = metadata.Attributes[3].Value,
                Eyewear = metadata.Attributes[4].Value,
                Head = metadata.Attributes[5].Value,
                Unique = Utils.IsUnique(metadata.Attributes[6].Value),
                DateTime = DateTime.UtcNow
            };

            //Load model and predict output
            var result = Y00tPricePrediction.Predict(sampleData);
            metadata.Price = new float[] { result.Score * 1.1f, result.Score, result.Score * 0.9f };


            return metadata;
            //await client.GetFromJsonAsync
        }).WithName("GetPredict").WithOpenApi();

        app.Run();
    }
}