using DepartAdmin.DAL.Entities;

namespace DepartAdmin.Client.Services
{
    public interface IInquilinoService
    {
        Task<List<Inquilinos>> List();
        Task<Inquilinos> Search(int id);
        Task<int> Save(Inquilinos inquilinos);
        Task<int> Edit(Inquilinos inquilinos);
        Task<bool> Delete(int id);
    }
}
