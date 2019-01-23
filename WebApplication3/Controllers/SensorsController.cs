using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Models.Interfaces;

namespace WebApplication3.Controllers
{
    [Produces("application/json")]
    [Route("api/Sensors")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly IHouseRepository _houseRepository;

        public SensorsController(ISensorRepository sensorRepository, IHouseRepository houseRepository)
        {
            _sensorRepository = sensorRepository;
            _houseRepository = houseRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddHumiditySensor([FromBody] HumiditySensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = _houseRepository.GetHouse(sensor.HouseId);

            if (house == null)
            {
                return NotFound("Cannot find house with provided houseId.");
            }

            await _sensorRepository.AddHumiditySensor(sensor, house);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMotionSensor([FromBody] MotionSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = _houseRepository.GetHouse(sensor.HouseId);

            if (house == null)
            {
                return NotFound("Cannot find house with provided houseId.");
            }

            await _sensorRepository.AddMotionSensor(sensor, house);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSmokeSensor([FromBody] SmokeSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = _houseRepository.GetHouse(sensor.HouseId);

            if (house == null)
            {
                return NotFound("Cannot find house with provided houseId.");
            }

            await _sensorRepository.AddSmokeSensor(sensor, house);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTemperatureSensor([FromBody] TemperatureSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var house = _houseRepository.GetHouse(sensor.HouseId);

            if (house == null)
            {
                return NotFound("Cannot find house with provided houseId.");
            }

            await _sensorRepository.AddTemperatureSensor(sensor, house);

            return new JsonResult(sensor.SensorId);
        }

        [HttpGet("[action]")]
        public IActionResult DeleteSensor(int sensorId)
        {
            if (sensorId <= 0)
            {
                return BadRequest();
            }

            var sensor = _sensorRepository.GetSensor(sensorId);

            if (sensor == null)
            {
                return NotFound("Cannot find sensor with provided sensorId.");
            }

            _sensorRepository.DeleteSensor(sensor);

            return new JsonResult(sensorId);
        }


        [HttpGet("[action]")]
        public IActionResult GetSensors()
        {
            return new JsonResult(_sensorRepository.GetAllSensors());
        }

        [HttpGet("[action]")]
        public IActionResult GetOnSensors()
        {
            return new JsonResult(_sensorRepository.GetAllOnSensors());
        }

        [HttpGet("[action]")]
        public IActionResult GetSensor(int sensorId)
        {
            if (sensorId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetSensor(sensorId));
        }

        [HttpGet("[action]")]
        public IActionResult GetSensorsByHouseId(int houseId)
        {
            if (houseId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetSensorsByHouseId(houseId));
        }

        [HttpGet("[action]")]
        public IActionResult GetTemperatureSensorsByHouseId(int houseId)
        {
            if (houseId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetTemperatureSensorsByHouseId(houseId));
        }

        [HttpGet("[action]")]
        public IActionResult GetHumiditySensorsByHouseId(int houseId)
        {
            if (houseId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetHumiditySensorsByHouseId(houseId));
        }

        [HttpGet("[action]")]
        public IActionResult GetSmokeSensorsByHouseId(int houseId)
        {
            if (houseId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetSmokeSensorsByHouseId(houseId));
        }

        [HttpGet("[action]")]
        public IActionResult GetMotionSensorsByHouseId(int houseId)
        {
            if (houseId <= 0)
            {
                return BadRequest();
            }

            return new JsonResult(_sensorRepository.GetMotionSensorsByHouseId(houseId));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateHumiditySensor([FromBody] HumiditySensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorRepository.UpdateHumiditySensor(sensor);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateMotionSensor([FromBody] MotionSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorRepository.UpdateMotionSensor(sensor);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateSmokeSensor([FromBody] SmokeSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorRepository.UpdateSmokeSensor(sensor);

            return new JsonResult(sensor.SensorId);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTemperatureSensor([FromBody] TemperatureSensor sensor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sensorRepository.UpdateTemperatureSensor(sensor);

            return new JsonResult(sensor.SensorId);
        }
    }
}