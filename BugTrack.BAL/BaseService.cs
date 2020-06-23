using BugTrack.IDAL;
using BugTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private Context _db;

        public BaseService(Context db)
        {
            this._db = db;
        }
        public async Task Create(T model, bool saved=true)
        {
            _db.Set<T>().Add(model);
            if (saved) await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Eidt(T model, bool saved=true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Set<T>().Add(model);
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Select(m => m).AsNoTracking();
        }

        public IQueryable<T> GetAllBypage(int pageSize, int pageIndex)
        {
            return GetAll().Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IQueryable<T> GetAllByPageOrder(int pageSize, int pageIndex, bool asc = true)
        {
            return GetAllOrder(asc).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IQueryable<T> GetAllOrder(bool asc = true)
        {
            var r = GetAll();
            return asc == true ? r.OrderByDescending(m => m.Created) : r.OrderBy(m => m.Created);
        }

        public async Task<T> GetOneById(Guid id)
        {
            return await GetAll().FirstAsync(m => m.Id == id);
        }

        public async Task Remove(Guid id, bool saved=true)
        {
            var t = new T() { Id = id };
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(t).State = EntityState.Unchanged;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public async Task Remove(T model, bool saved)
        {
            await Remove(model.Id, saved);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
