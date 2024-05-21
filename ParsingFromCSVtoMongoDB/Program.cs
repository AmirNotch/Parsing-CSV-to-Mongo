using System.Globalization;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DBProject.Repositories;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "DH_HS5_HS2_E2_Data_corr_V2.csv";
        string relativePath = Path.Combine("Data", fileName);
        string filePath = Path.GetFullPath(relativePath);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        var host = CreateHostBuilder().Build();
        var repository = host.Services.GetRequiredService<ISensorDataRepository>();


        ParseAndInsertCsvData(filePath, repository);

        Console.WriteLine("Data has been successfully inserted into the database.");
    }

    static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
                services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient("mongodb://localhost:27017"))
                        .AddSingleton<ISensorDataRepository, SensorDataRepository>());

    static void ParseAndInsertCsvData(string filePath, ISensorDataRepository repository)
    {
        const int batchSize = 1000;
        var sensorDataList = new List<SensorData>(batchSize);
        using (var reader = new StreamReader(filePath))
        {
            string line;
            var isFirstLine = true;
            while ((line = reader.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                var fields = line.Split(';');
                var sensorData = new SensorData
                {
                    DateTime = DateTime.ParseExact(fields[0], "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    SensorName = fields[1],
                    Value1 = double.Parse(fields[10], CultureInfo.InvariantCulture),
                    Value2 = double.Parse(fields[11], CultureInfo.InvariantCulture)
                };

                sensorDataList.Add(sensorData);

                if (sensorDataList.Count >= batchSize)
                {
                    repository.InsertMany(sensorDataList);
                    sensorDataList.Clear();
                }
            }

            if (sensorDataList.Count > 0)
            {
                repository.InsertMany(sensorDataList);
            }
        }
    }
}