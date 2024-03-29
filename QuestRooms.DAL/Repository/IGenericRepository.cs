﻿using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QuestRooms.DAL.Repositoriy
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
        TEntity Last();
    }
}
