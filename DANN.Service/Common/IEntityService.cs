﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DANN.Model;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DANN.Service
{
    public interface IEntityService<T> where T : BaseEntity
    {
        IContext _context { get; set; }
        IDbSet<T> _dbset { get; set; }

        void Create(T entity);
        void CreateWithParentID(T entity, int ParentID);
        void Delete(T entity);
        void DeleteAll(Expression<Func<T, bool>> where);
        void Update(T entity);

        void InsertOrUpdate(T entity);
        void InsertOrUpdate2Key(T entity);
        void UpdateWithParentID(T entity, int ParentID);
        void Move(T entity);

        int MaxId();
        int MaxCodeValue(int CodeKindID);
        T GetEntityById(object Id);
        T GetEntityBy2Key(object Id1, object Id2);

        List<T> GetListById(object Id);
        List<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> GetAllAsQueryable();
        IEnumerable<T> GetAllAsIEnumerable();
        T SearchFirst(string searchTerm);

        List<T> SearchToList(string searchTerm);
        IQueryable<T> WhereIn(object mList, string fieldName);
    }
}
