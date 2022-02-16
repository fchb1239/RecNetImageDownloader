using System;
using System.Collections.Generic;

namespace RecNetImageDownloader
{
    class Image
    {
        public ulong Id { get; set; }
        public int Type { get; set; }
        public int Accessibility { get; set; }
        public bool AccessibilityLocked { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public ulong PlayerId { get; set; }
        public List<ulong> TaggedPlayerIds { get; set; }
        public ulong RoomId { get; set; }
        //it dies if i have this on - because most of the time this is null on the api D:
        //public ulong PlayerEventId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
