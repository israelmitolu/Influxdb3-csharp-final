# InfluxDB C# Client Sample - Updated Version

This is an updated version of the [InfluxDB C# Client Sample](https://github.com/jamesmh/influxdb-csharp-client-sample) repository, based on the tutorial from [Getting Started with C# and InfluxDB](https://www.influxdata.com/blog/getting-started-with-c-and-influxdb).

## What's New in This Version

This updated version includes several modernizations and improvements over the original:

- **Updated to .NET 9** - Uses the latest .NET framework
- **InfluxDB 3.x Client** - Updated to use the modern InfluxDB3.Client package (v1.4.0)
- **SQL Queries** - Uses SQL instead of Flux for querying data
- **Coravel Scheduler** - Uses Coravel for background task scheduling
- **Modern C# Features** - Leverages nullable reference types and implicit usings

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [InfluxDB 3.x](https://www.influxdata.com/products/influxdb/) (Cloud, Enterprise, or OSS)

## Running the Application

1. Clone this repository
2. Update the configuration with your InfluxDB details in the `appsettings.json` file
3. Run the application:

```bash
dotnet run
```

4. Open your browser to `https://localhost:5451` (or the URL shown in the console)

## Learning More

- [InfluxDB 3.x Documentation](https://docs.influxdata.com/influxdb/v3/)
- [InfluxDB C# Client Documentation](https://github.com/InfluxCommunity/influxdb3-csharp)
- [Coravel Documentation](https://docs.coravel.net/)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
