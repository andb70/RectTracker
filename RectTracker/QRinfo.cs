namespace RectTracker
{
    using System;
    public class QRinfo
    {
        public int QRId { get; set; }
        public int ZoneId { get; set; }
        public Rect Rect { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
