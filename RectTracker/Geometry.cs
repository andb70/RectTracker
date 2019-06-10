namespace RectTracker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Geometry
    {        // https://stackoverflow.com/questions/33065834/how-to-detect-if-a-point-is-contained-within-a-bounding-rect-opecv-python
        public static bool RectInRect(Rect r, Rect t)
        {
            // assume origin on Top Left corner
            // a,b are the top-left coordinate of the rectangle and (c,d) be its width and height.
            // o judge a point(x0,y0) is in the rectangle, just to check if a < x0 < a+c and b < y0 < b + d
            // or 
            // if r.Left is lower than t.Left the r rect is not inside the t rect and so on

            //find centroid and see if it is inside the rect
            Point c = new Point {
                X = r.Left + r.Width / 2,
                Y = r.Top + r.Height / 2
            };
            if (c.X < t.Left)
                return false;
            if (c.Y < t.Top)
                return false;
            if (c.X > t.Left + t.Width)
                return false;
            if (c.Y > t.Top + t.Height)
                return false;

            return true;
        }

        // deprecated: transition from one zone to another can't be detected
        public static bool RectInRectFull(Rect r, Rect t)
        {
            // assume origin on Top Left corner
            // a,b are the top-left coordinate of the rectangle and (c,d) be its width and height.
            // o judge a point(x0,y0) is in the rectangle, just to check if a < x0 < a+c and b < y0 < b + d
            // or 
            // if r.Left is lower than t.Left the r rect is not inside the t rect and so on

            if (r.Left < t.Left)
                return false;
            if (r.Top < t.Top)
                return false;
            if (r.Left + r.Width > t.Left + t.Width)
                return false;
            if (r.Top + r.Height > t.Top + t.Height)
                return false;

            return true;
        }

        public static Zone RectToZone(Rect r, List<Zone> lz)
        {
            foreach (var z in lz)
            {
                if (RectInRect(r, z.Rect))
                {
                    return z;
                }
            }
            return null;
        }

        public static Perimeter LoadPerimeter(string filename)
        {
            // 1. load a JSON containing the Perimeter object
            // or
            // 2. return embedded data as Perimeter object

            // 2.
            Perimeter p = new Perimeter
            {
                // NB: il Rect seguente in questo momento non ha utilizzo specifico,
                // serve a fornire almeno la dimensione dell'immagine da elaborare:
                // se l'immagine ha dimensioni diverse vanno cambiati Width e Height
                // e seguita la procedura descritta in GetZones
                Rect = new Rect { Top = 0, Left = 0, Width = 1280, Height = 720 },
                Zones = GetZones()
            };
            return p;
        }
        private static List<Zone> GetZones()
        {
            // le zone contrassegnate con "e" sono non calpestabili
            // riferirsi al foglio RectGen.xlsm
            // una volta disegnata la mappa, generare il codice, copiarlo e incollarlo
            // qui sotto per popolare la lista
            List<Zone> lz = new List<Zone>() {
                new Zone { Id = 1, Name = "galleria", Rect = new Rect { Left = 0, Top = 0, Width = 128, Height = 720 } }
                , new Zone { Id = 2, Name = "e", Rect = new Rect { Left = 128, Top = 0, Width = 96, Height = 120 } }
                , new Zone { Id = 3, Name = "e", Rect = new Rect { Left = 224, Top = 0, Width = 1056, Height = 24 } }
                , new Zone { Id = 4, Name = "corridoio 1", Rect = new Rect { Left = 224, Top = 24, Width = 64, Height = 672 } }
                , new Zone { Id = 5, Name = "pet", Rect = new Rect { Left = 288, Top = 24, Width = 288, Height = 48 } }
                , new Zone { Id = 6, Name = "corridoio 2", Rect = new Rect { Left = 576, Top = 24, Width = 64, Height = 624 } }
                , new Zone { Id = 7, Name = "snacs", Rect = new Rect { Left = 640, Top = 24, Width = 160, Height = 96 } }
                , new Zone { Id = 8, Name = "corridoio3", Rect = new Rect { Left = 800, Top = 24, Width = 64, Height = 312 } }
                , new Zone { Id = 9, Name = "birre", Rect = new Rect { Left = 864, Top = 24, Width = 192, Height = 96 } }
                , new Zone { Id = 10, Name = "vini", Rect = new Rect { Left = 1056, Top = 24, Width = 224, Height = 192 } }
                , new Zone { Id = 11, Name = "e", Rect = new Rect { Left = 288, Top = 72, Width = 288, Height = 96 } }
                , new Zone { Id = 12, Name = "cassa", Rect = new Rect { Left = 128, Top = 120, Width = 96, Height = 288 } }
                , new Zone { Id = 13, Name = "e", Rect = new Rect { Left = 640, Top = 120, Width = 160, Height = 48 } }
                , new Zone { Id = 14, Name = "e", Rect = new Rect { Left = 864, Top = 120, Width = 128, Height = 48 } }
                , new Zone { Id = 15, Name = "corridoio 4", Rect = new Rect { Left = 992, Top = 120, Width = 64, Height = 576 } }
                , new Zone { Id = 16, Name = "corisa 7", Rect = new Rect { Left = 288, Top = 168, Width = 288, Height = 48 } }
                , new Zone { Id = 17, Name = "corisa 8", Rect = new Rect { Left = 640, Top = 168, Width = 160, Height = 48 } }
                , new Zone { Id = 18, Name = "promo 2", Rect = new Rect { Left = 864, Top = 168, Width = 128, Height = 48 } }
                , new Zone { Id = 19, Name = "e", Rect = new Rect { Left = 288, Top = 216, Width = 288, Height = 72 } }
                , new Zone { Id = 20, Name = "e", Rect = new Rect { Left = 640, Top = 216, Width = 160, Height = 72 } }
                , new Zone { Id = 21, Name = "e", Rect = new Rect { Left = 864, Top = 216, Width = 128, Height = 72 } }
                , new Zone { Id = 22, Name = "servito 1", Rect = new Rect { Left = 1056, Top = 216, Width = 224, Height = 192 } }
                , new Zone { Id = 23, Name = "corsia 5", Rect = new Rect { Left = 288, Top = 288, Width = 288, Height = 48 } }
                , new Zone { Id = 24, Name = "corsia 6", Rect = new Rect { Left = 640, Top = 288, Width = 160, Height = 48 } }
                , new Zone { Id = 25, Name = "promo 1", Rect = new Rect { Left = 864, Top = 288, Width = 128, Height = 48 } }
                , new Zone { Id = 26, Name = "e", Rect = new Rect { Left = 288, Top = 336, Width = 288, Height = 72 } }
                , new Zone { Id = 27, Name = "e", Rect = new Rect { Left = 640, Top = 336, Width = 352, Height = 72 } }
                , new Zone { Id = 28, Name = "e", Rect = new Rect { Left = 128, Top = 408, Width = 96, Height = 96 } }
                , new Zone { Id = 29, Name = "corsia 3", Rect = new Rect { Left = 288, Top = 408, Width = 288, Height = 48 } }
                , new Zone { Id = 30, Name = "corsia 4", Rect = new Rect { Left = 640, Top = 408, Width = 352, Height = 48 } }
                , new Zone { Id = 31, Name = "servito 2", Rect = new Rect { Left = 1056, Top = 408, Width = 224, Height = 168 } }
                , new Zone { Id = 32, Name = "e", Rect = new Rect { Left = 288, Top = 456, Width = 288, Height = 72 } }
                , new Zone { Id = 33, Name = "e", Rect = new Rect { Left = 640, Top = 456, Width = 352, Height = 72 } }
                , new Zone { Id = 34, Name = "ingresso", Rect = new Rect { Left = 128, Top = 504, Width = 96, Height = 144 } }
                , new Zone { Id = 35, Name = "corsia 1", Rect = new Rect { Left = 288, Top = 528, Width = 288, Height = 48 } }
                , new Zone { Id = 36, Name = "corsia 2", Rect = new Rect { Left = 640, Top = 528, Width = 352, Height = 48 } }
                , new Zone { Id = 37, Name = "e", Rect = new Rect { Left = 288, Top = 576, Width = 288, Height = 72 } }
                , new Zone { Id = 38, Name = "e", Rect = new Rect { Left = 640, Top = 576, Width = 352, Height = 72 } }
                , new Zone { Id = 39, Name = "servito 3", Rect = new Rect { Left = 1056, Top = 576, Width = 224, Height = 120 } }
                , new Zone { Id = 40, Name = "e", Rect = new Rect { Left = 128, Top = 648, Width = 96, Height = 72 } }
                , new Zone { Id = 41, Name = "acque", Rect = new Rect { Left = 288, Top = 648, Width = 704, Height = 48 } }
                , new Zone { Id = 42, Name = "e", Rect = new Rect { Left = 224, Top = 696, Width = 1056, Height = 24 } }
            };
            return lz;
        }
    }
}
