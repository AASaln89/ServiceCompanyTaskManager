using ServiceCompanyTaskManager.Common.Models.Entities;

namespace ServiceCompanyTaskManager.Api.Services.BaseServices
{
    public interface IBaseService<T> where T : IEntity
    {
        T Get(int id);
        bool Create(T entity);
        bool Update(int id, T entity);
        bool Delete(int id);
    }
}
