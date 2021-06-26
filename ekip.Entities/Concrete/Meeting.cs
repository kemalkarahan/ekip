namespace ekip.Entities.Concrete
{
    public class Meeting : Preference
    {
        public bool IsMicrophoneMuted { get; set; }
        public bool IsCameraClosed { get; set; }
        public bool IsFullScreen { get; set; }
        public bool AreParticipantsWithNoCameraDisplayed { get; set; }
    }
}
