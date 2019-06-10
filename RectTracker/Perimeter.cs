namespace RectTracker
{
    using System.Collections.Generic;

    public class Perimeter
    {
        /// <summary>
        /// This is the bounduary rect for the area defined.
        /// All the zones included ar relative to the Rect Top Left corner:
        /// the top left corner of a zone having Top = 0 and Left = 0 is coincident
        /// with Rect top left Corner
        /// </summary>
        public Rect Rect { get; set; }
        /// <summary>
        /// A list of zones, each defined by their bounduary rect
        /// </summary>
        public List<Zone> Zones { get; set; }
    }
}
