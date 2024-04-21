using DepartAdmin.DAL.Entities;

namespace DepartAdmin.Client.Services
{
    public interface IInquilinoServices
    {
        Task<List<Inquilino>> InquilinoList();
    }
}
