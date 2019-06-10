namespace RectTracker
{
    public class Zone
    {
        /// <summary>
        /// A zone defines a rectangular area inside a perimeter, therefore the position
        /// is relative to the perimeter Top Left Corner
        /// Id and Name are used to identify the zone inside the perimeter
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public Rect Rect { get; set; }
    }
}
