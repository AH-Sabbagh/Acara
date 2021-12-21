using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        public BaseSpecifications()
        {
        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
               new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDecending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IspageingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeRexpression)
        {
            Includes.Add(includeRexpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDecending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IspageingEnabled = true;
        }
    }
}