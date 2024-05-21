using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SensorData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public DateTime DateTime { get; set; }
    public string SensorName { get; set; }
    public double Value1 { get; set; }
    public double Value2 { get; set; }
}

