using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace ParsingFromCSVtoMongoDB.Test
{
    [TestClass]
    public class SensorDataTests
    {
        private IMongoDatabase database;
        private IMongoCollection<SensorData> collection;

        [TestInitialize]
        public void TestInitialize()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("TestSensorDatabase");
            collection = database.GetCollection<SensorData>("SensorDataCollection");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            database.DropCollection("SensorDataCollection");
        }

        [TestMethod]
        public void InsertAndRetrieveSensorDataTest()
        {
            // Arrange
            var sensorData = new SensorData
            {
                SensorName = "Sensor1",
                DateTime = DateTime.UtcNow,
                Value1 = 10.5,
                Value2 = 20.5
            };

            // Act
            collection.InsertOne(sensorData);
            var retrievedData = collection.Find(_ => true).ToList();

            // Assert
            Assert.AreEqual(1, retrievedData.Count);

            var expected = sensorData;
            var actual = retrievedData.First();

            Assert.AreEqual(expected.SensorName, actual.SensorName);
            Assert.AreEqual(expected.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), actual.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(expected.Value1, actual.Value1);
            Assert.AreEqual(expected.Value2, actual.Value2);
        }
    }
}