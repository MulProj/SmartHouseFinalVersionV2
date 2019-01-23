using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Models.Interfaces
{
    public interface ISensorRepository
    {
        List<Sensor> GetAllSensors();
        Sensor GetSensor(int sensorId);
        List<Sensor> GetSensorsByHouseId(int houseId);
        List<Sensor> GetAllOnSensors();
        List<Sensor> GetTemperatureSensorsByHouseId(int houseId);
        List<Sensor> GetHumiditySensorsByHouseId(int houseId);
        List<Sensor> GetSmokeSensorsByHouseId(int houseId);
        List<Sensor> GetMotionSensorsByHouseId(int houseId);
        Task<int> AddTemperatureSensor(TemperatureSensor sensor, House house);
        Task<int> AddHumiditySensor(HumiditySensor sensor, House house);
        Task<int> AddSmokeSensor(SmokeSensor sensor, House house);
        Task<int> AddMotionSensor(MotionSensor sensor, House house);
        Task<int> UpdateTemperatureSensor(TemperatureSensor sensor);
        Task<int> UpdateHumiditySensor(HumiditySensor sensor);
        Task<int> UpdateSmokeSensor(SmokeSensor sensor);
        Task<int> UpdateMotionSensor(MotionSensor sensor);
        void DeleteSensor(Sensor sensor);
    }
}
