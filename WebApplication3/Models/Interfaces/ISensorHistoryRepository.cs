using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Models.Interfaces
{
    public interface ISensorHistoryRepository
    {
        List<SensorHistory> GetAllSensorsHistory();
        SensorHistory GetSensorHistory(int sensorId);
        List<SensorHistory> GetSensorsByHouseIdHistory(int houseId);
        List<SensorHistory> GetTemperatureSensorsByHouseIdHistory(int houseId, int dataAmount);
        List<SensorHistory> GetHumiditySensorsByHouseIdHistory(int houseId, int dataAmount);
        List<SensorHistory> GetSmokeSensorsByHouseIdHistory(int houseId, int dataAmount);
        List<SensorHistory> GetMotionSensorsByHouseIdHistory(int houseId, int dataAmount);
        Task<int> AddHumiditySensorHistory(HumiditySensor sensor);
        Task<int> AddMotionSensorHistory(MotionSensor sensor);
        Task<int> AddSmokeSensorHistory(SmokeSensor sensor);
        Task<int> AddTemperatureSensorHistory(TemperatureSensor sensor);
    }
}
