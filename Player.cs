using System;

namespace RecNetImageDownloader
{
    class Player
    {
        public ulong accountId { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string profileImage { get; set; }
        public string bannerImage { get; set; }
        public bool isJunior { get; set; }
        public int platforms { get; set; }
        public int personalPronouns { get; set; }
        public int identityFlags { get; set; }
        public DateTime createdAt { get; set; }
    }
}
