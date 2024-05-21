using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Repositories
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly IMongoCollection<SensorData> _collection;

        public SensorDataRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("SensorDatabase");
            _collection = database.GetCollection<SensorData>("SensorDataCollection");
        }

        public void InsertMany(IEnumerable<SensorData> sensorDataList)
        {
            _collection.InsertMany(sensorDataList);
        }
    }
}
