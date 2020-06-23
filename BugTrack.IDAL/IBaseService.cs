using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.IDAL
{
    public interface IBaseService<T> : IDisposable where T : BaseEntity
    {
        Task Create(T model, bool saved = true);
        Task Eidt(T model, bool saved = true);
        Task Remove(Guid id, bool saved = true);
        Task Remove(T model, bool saved = true);
        Task Save();
        Task<T> GetOneById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllBypage(int pageSize = 0, int pageIndex = 0);
        IQueryable<T> GetAllOrder(bool asc = true);
        IQueryable<T> GetAllByPageOrder(int pageSize = 0, int pageIndex = 0, bool asc = true);
    }
}
