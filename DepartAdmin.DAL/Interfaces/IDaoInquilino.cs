using DepartAdmin.DAL.Entities;

namespace DepartAdmin.DAL.Interfaces
{
    public interface IDaoInquilino
    {
        void SaveInquilino(Inquilinos inquilino);
        void UpdateInquilino(Inquilinos inquilino);
        void RemoveInquilino(Inquilinos inquilino);
        Inquilinos GetInquilino(int Id);
        List<Inquilinos> GetInquilinos();
        List<Inquilinos> GetInquilinos(Func<Inquilinos, bool> filter);
        bool ExtistsInquilinos(Func<Inquilinos, bool> filter);
    }
}