
using Autofac;
using ekip.Business.Abstract;
using ekip.Business.Concrete;
using ekip.Core.Utilities.Security.Jwt;
using ekip.DataAccess.Abstract;
using ekip.DataAccess.Concrete.EntityFramework;

namespace ekip.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Data Access
            builder.RegisterType<EfAttachmentDal>().As<IAttachmentDal>();
            builder.RegisterType<EfBoardDal>().As<IBoardDal>();
            builder.RegisterType<EfBoardContextDal>().As<IBoardContextDal>();
            builder.RegisterType<EfConversationDal>().As<IConversationDal>();
            builder.RegisterType<EfEventDal>().As<IEventDal>();
            builder.RegisterType<EfInstitutionDal>().As<IInstitutionDal>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();
            builder.RegisterType<EfParticipantDal>().As<IParticipantDal>();
            builder.RegisterType<EfPermissionDal>().As<IPermissionDal>();
            builder.RegisterType<EfPreferenceDal>().As<IPreferenceDal>();
            builder.RegisterType<EfScheduleDal>().As<IScheduleDal>();
            builder.RegisterType<EfStreamDal>().As<IStreamDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            //Business
            builder.RegisterType<AttachmentManager>().As<IAttachmentService>();
            builder.RegisterType<BoardManager>().As<IBoardService>();
            builder.RegisterType<BoardContextManager>().As<IBoardContextService>();
            builder.RegisterType<ConversationManager>().As<IConversationService>();
            builder.RegisterType<EventManager>().As<IEventService>();
            builder.RegisterType<InstitutionManager>().As<IInstitutionService>();
            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<ParticipantManager>().As<IParticipantService>();
            builder.RegisterType<PermissionManager>().As<IPermissionService>();
            builder.RegisterType<PreferenceManager>().As<IPreferenceService>();
            builder.RegisterType<ScheduleManager>().As<IScheduleService>();
            builder.RegisterType<StreamManager>().As<IStreamService>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthSevice>();
            builder.RegisterType<EmailNotificationManager>().As<INotificationService>();

            //Helper
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
