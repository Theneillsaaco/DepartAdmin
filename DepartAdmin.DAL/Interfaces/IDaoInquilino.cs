using DepartAdmin.DAL.Entities;

namespace DepartAdmin.DAL.Interfaces
{
    public interface IDaoInquilino
    {
        void SaveInquilino(Inquilino inquilino);
        void UpdateInquilino(Inquilino inquilino);
        void RemoveInquilino(Inquilino inquilino);
        Inquilino GetInquilino(int Id);
        List<Inquilino> GetInquilinos();
        List<Inquilino> GetInquilinos(Func<Inquilino, bool> filter);
        bool ExtistsInquilinos(Func<Inquilino, bool> filter);
    }
}