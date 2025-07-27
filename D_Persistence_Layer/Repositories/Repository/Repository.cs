﻿using D_Domain_Layer.Extensions;
using D_Persistence_Layer.AppDbContext;
using D_Persistence_Layer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace D_Persistence_Layer.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return entity;

            }
            return null;
        }

        public async Task Delete(Guid id)
        {
            var entity = await Table.FindAsync(id);

            Table.Remove(entity);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entities = await Table.ToListAsync();
            if (entities is not null)
            {
                return entities;
            }
            return null;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<PageResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            int totalCount = await query.CountAsync();

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            List<T> items = await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            return new PageResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.AnyAsync();
        }

        public async Task<T> Update(Guid id, T entity)
        {
            var value = await Table.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(value).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;

        }


    }
}
