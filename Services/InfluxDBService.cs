using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfluxDB3.Client;
using InfluxDB3.Client.Write;
using Microsoft.Extensions.Configuration;

namespace app.Services
{
    public class InfluxDBService
    {
        private readonly string _url;
        private readonly string _database;
        private readonly string _token;

        public InfluxDBService(IConfiguration configuration)
        {
            _url = configuration.GetValue<string>("InfluxDB:Url")
                ?? throw new ArgumentNullException("InfluxDB:Url", "InfluxDB URL is not configured");
            _database = configuration.GetValue<string>("InfluxDB:Database")
                ?? throw new ArgumentNullException("InfluxDB:Database", "InfluxDB database is not configured");
            _token = configuration.GetValue<string>("InfluxDB:Token")
                ?? throw new ArgumentNullException("InfluxDB:Token", "InfluxDB token is not configured");
        }

        public async Task WriteAsync(PointData point)
        {
            using var client = new InfluxDBClient(_url, _token);
            await client.WritePointAsync(point, _database);
        }

        public async Task<IReadOnlyList<object?[]>> Query(string sql)
        {
            using var client = new InfluxDBClient(_url, _token);
            var rows = new List<object?[]>();
            await foreach (var row in client.Query(sql, database: _database))
            {
                rows.Add(row);
            }
            return rows;
        }
    }
}