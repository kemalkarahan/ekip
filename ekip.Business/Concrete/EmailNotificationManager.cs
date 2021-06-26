using System;
using System.Collections.Generic;
using ekip.Business.Abstract;
using ekip.Entities.Concrete;
using ekip.Entities.Dtos;

namespace ekip.Business.Concrete
{
    public class EmailNotificationManager : INotificationService
    {
        public void ConfirmEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void ConfirmPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public void ConfirmRecoveryEmail(string recoveryEmail)
        {
            throw new NotImplementedException();
        }

        public void WarnEmailWasChaged(string email)
        {
            throw new NotImplementedException();
        }

        public void WarnRecoveryMailWasChanged(string recoveryEmail)
        {
            throw new NotImplementedException();
        }

        public void WarnPhoneWasChanged(int phone)
        {
            throw new NotImplementedException();
        }

        public void WarnPasswordWasChanged(string email)
        {
            throw new NotImplementedException();
        }

        public void MakeAnnouncement(List<UserNotifierDto> list, string content)
        {
            throw new NotImplementedException();
        }

        public void RemindEvent(Event @event, string email)
        {
            throw new NotImplementedException();
        }
    }
}
