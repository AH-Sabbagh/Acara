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

        protected void AddInclude(Expression<Func<T, object>> includeRexpression)
        {
            Includes.Add(includeRexpression);
        }
    }
}
