using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.Core.Entities.Concrete;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfPermissionDal : EfEntityRepositoryBase<Permission, EkipContext>, IPermissionDal
    {
        public async Task<bool> CheckAddPersonnelPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.AddPersonnel;
            }
        }

        public async Task<bool> CheckRemovePersonnelPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.RemovePersonnel;
            }
        }

        public async Task<bool> CheckEditAboutPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.EditAbout;
            }
        }

        public async Task<bool> CheckEditIconPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.EditIcon;
            }
        }

        public async Task<bool> CheckEditLabelPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.EditLabel;
            }
        }

        public async Task<bool> CheckShareStreamPermission(int streamId, EnumCollection.Roles role)
        {
            using (var context = new EkipContext())
            {
                var permission = await context.Set<Permission>()
                    .FirstOrDefaultAsync(p => p.StreamId == streamId && p.Role == role);
                return permission.ShareStream;
            }
        }
    }
}
