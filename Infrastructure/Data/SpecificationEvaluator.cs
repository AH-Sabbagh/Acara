using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
             ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDecending != null)
            {
                query = query.OrderByDescending(spec.OrderByDecending);
            }
            if (spec.IspageingEnabled)
            {
                query=query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (currrent, include) => currrent.Include(include));
            return query;
        }
    }
}
