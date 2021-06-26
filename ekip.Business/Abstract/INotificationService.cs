using System.Collections.Generic;
using ekip.Entities.Concrete;
using ekip.Entities.Dtos;

namespace ekip.Business.Abstract
{
    public interface INotificationService
    {
        void ConfirmEmail(string email);
        void ConfirmPhone(int phone);
        void ConfirmRecoveryEmail(string recoveryEmail);
        void WarnEmailWasChaged(string email);
        void WarnRecoveryMailWasChanged(string recoveryEmail);
        void WarnPhoneWasChanged(int phone);
        void WarnPasswordWasChanged(string email);
        void MakeAnnouncement(List<UserNotifierDto> list, string content);
        void RemindEvent(Event @event, string email);
    }
}
