using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IConversationDal : IEntityRepository<Conversation>
    {
        Task<IList<Conversation>> RetrieveAllWithPeople(Expression<Func<Conversation, bool>> filter);
    }
}
