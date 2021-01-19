namespace PlayerRanking.Models
{
    public class PlayerProfileResponse
    {
        public PlayerProfileContent Content { get; set; }
        public PlayerProfileData Data { get; set; }
    }

    public class PlayerProfileContent
    {
        public string Advert { get; set; }
        public PlayerProfileDetailsDTO PlayerProfileDetails { get; set; }
    }

    public class PlayerProfileDetailsDTO
    {
        public string PlayerGladiatorUrl { get; set; }
        public string PlayerHeadshotUrl { get; set; }
        public bool HasGladiator { get; set; }
    }

    public class PlayerProfileData
    {
        public string PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int HeroRank { get; set; }
        public bool DblSpecialist { get; set; }
        public string NatlId { get; set; }
        public string BioPersonal { get; set; }
        public string BioYearToDate { get; set; }
        public string Type { get; set; }
    }
}
