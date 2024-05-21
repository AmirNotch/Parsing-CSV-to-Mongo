using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISensorDataRepository
{
    void InsertMany(IEnumerable<SensorData> sensorDataList);
}