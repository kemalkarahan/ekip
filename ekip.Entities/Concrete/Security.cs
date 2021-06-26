namespace ekip.Entities.Concrete
{
    public class Security : Preference
    {
        public bool TwoFactorAuth { get; set; }
        public string RecoveryMail { get; set; }
        public bool MatchPhoneWithAccount { get; set; }
        public bool MatchEmailWithAccount { get; set; }
        public bool IsMailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public bool IsRecoveryMailConfirmed { get; set; }
    }
}
