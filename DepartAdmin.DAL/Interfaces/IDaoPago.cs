using DepartAdmin.DAL.Entities;
using DepartAdmin.DAL.Models;

namespace DepartAdmin.DAL.Interfaces
{
    public interface IDaoPago
    {
        void SavePago(Pago pago);
        void UpdatePago(Pago pago);
        void RemovePago(Pago pago);
        DaoPagoModel GetPago(int Id);
        List<DaoPagoModel> GetPagos();
        List<DaoPagoModel> GetPagos(Func<Pago, bool> filter);
        bool ExtistsPagos(Func<Pago, bool> filter);
    }
}