
using System.Collections.Concurrent;

namespace Sudokus.ApiService.Services
{
    public class LimpiezaSesionesService : BackgroundService
    {
        private readonly ConcurrentDictionary<string, Partida> sesiones;

        public LimpiezaSesionesService(ConcurrentDictionary<string, Partida> sesiones)
        {
            this.sesiones = sesiones;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var limiteAntiguedad = DateTime.Now.AddDays(-6);

                //Variable no tan agresiva como otras posibles.
                var DiCaprio = sesiones
                    .Where(p => limiteAntiguedad > p.Value.HoraCreacion)
                    .Select(p => p.Key)
                    .ToList();

                foreach (var key in DiCaprio)
                {
                    sesiones.TryRemove(key, out _);
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
    }
}
