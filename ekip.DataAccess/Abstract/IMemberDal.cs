using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IMemberDal : IEntityRepository<Member>
    {
        Task<Member> RetrieveWithStaffInfo(Expression<Func<Member, bool>> filter);
        Task<IList<Member>> RetrieveAlWithStaffInfo(Expression<Func<Member, bool>> filter);
    }
}
