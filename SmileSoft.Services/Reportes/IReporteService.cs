using SmileSoft.DTO;

namespace SmileSoft.Services.Reportes
{
    public interface IReporteService<TRequest>
    {
        byte[] GenerarReporte(TRequest request);
        Task<byte[]> GenerarReporteAsync(TRequest request);
    }
}