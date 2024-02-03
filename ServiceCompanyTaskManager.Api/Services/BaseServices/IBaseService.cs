using ServiceCompanyTaskManager.Common.Models.Entities;

namespace ServiceCompanyTaskManager.Api.Services.BaseServices
{
    public interface IBaseService<T> where T : IEntity
    {
        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
    }
}
