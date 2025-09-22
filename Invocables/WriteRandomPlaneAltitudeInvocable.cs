using System;
using System.Threading.Tasks;
using app.Services;
using Coravel.Invocable;
using InfluxDB3.Client.Write;

namespace app.Invocables
{
public class WriteRandomPlaneAltitudeInvocable : IInvocable
{
private readonly InfluxDBService _service;
private static readonly Random _random = new Random();

        public WriteRandomPlaneAltitudeInvocable(InfluxDBService service)
        {
            _service = service;
        }

        public async Task Invoke()
        {
           var point = PointData.Measurement("altitude")
                .SetTag("plane", "test-plane")
                .SetField("value", _random.Next(1000, 5000))
                .SetTimestamp(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), WritePrecision.Ms);

            await _service.WriteAsync(point);
        }
    }

}