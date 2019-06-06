using System;
using System.Collections.Generic;

namespace RectTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rect> rects = GetRects();
            // check every rect to see if anyone is contained in any other one
            for (int i = 0; i < rects.Count-1; i++)
            {
                var r = rects[i];
                for (int j = i+1; j < rects.Count; j++)
                {
                    var t = rects[j];
                    if (RectInRect(r, t))
                    {
                        Console.WriteLine($"rect {i             } is contained in rect {j}");
                        Console.WriteLine($"     {r.Top},{r.Left}       Top, Left      {t.Top},{t.Left}");
                        Console.WriteLine($"     {r.Top + r.Height},{r.Left + r.Width}     Bottom, Right    {t.Top + t.Height},{t.Left + t.Width}");
                    }
                }
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        // https://stackoverflow.com/questions/33065834/how-to-detect-if-a-point-is-contained-within-a-bounding-rect-opecv-python
        static bool RectInRect(Rect r, Rect t)
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
        static List<Rect> GetRects()
        {
            var l = new List<Rect> {
                new Rect { Left = 170, Top = 199, Width = 239, Height = 222 }   ,
                new Rect { Left = 82, Top = 236, Width = 193, Height = 99 } ,
                new Rect { Left = 247, Top = 65, Width = 240, Height = 209 }    ,
                new Rect { Left = 107, Top = 45, Width = 50, Height = 180 } ,
                new Rect { Left = 48, Top = 141, Width = 31, Height = 207 } ,
                new Rect { Left = 162, Top = 132, Width = 100, Height = 27 }    ,
                new Rect { Left = 98, Top = 174, Width = 209, Height = 87 } ,
                new Rect { Left = 186, Top = 53, Width = 24, Height = 50 }  ,
                new Rect { Left = 163, Top = 201, Width = 149, Height = 89 }    ,
                new Rect { Left = 63, Top = 157, Width = 107, Height = 165 }    ,
                new Rect { Left = 143, Top = 126, Width = 90, Height = 5 }  ,
                new Rect { Left = 19, Top = 70, Width = 35, Height = 85 }   ,
                new Rect { Left = 214, Top = 83, Width = 54, Height = 33 }  ,
                new Rect { Left = 179, Top = 104, Width = 153, Height = 83 }    ,
                new Rect { Left = 104, Top = 130, Width = 180, Height = 135 }   ,
                new Rect { Left = 20, Top = 125, Width = 236, Height = 244 }    ,
                new Rect { Left = 216, Top = 227, Width = 142, Height = 33 }    ,
                new Rect { Left = 195, Top = 47, Width = 208, Height = 4 }  ,
                new Rect { Left = 162, Top = 221, Width = 184, Height = 187 }   ,
                new Rect { Left = 150, Top = 55, Width = 36, Height = 60 }  ,
                new Rect { Left = 185, Top = 173, Width = 178, Height = 175 }   ,
                new Rect { Left = 87, Top = 160, Width = 227, Height = 177 }    ,
                new Rect { Left = 249, Top = 53, Width = 141, Height = 38 } ,
                new Rect { Left = 250, Top = 5, Width = 250, Height = 165 } ,
                new Rect { Left = 178, Top = 184, Width = 89, Height = 65 } ,
                new Rect { Left = 69, Top = 238, Width = 222, Height = 85 } ,
                new Rect { Left = 39, Top = 89, Width = 175, Height = 126 } ,
                new Rect { Left = 201, Top = 20, Width = 27, Height = 165 } ,
                new Rect { Left = 189, Top = 50, Width = 80, Height = 42 }  ,
                new Rect { Left = 60, Top = 249, Width = 122, Height = 154 }    ,
                new Rect { Left = 201, Top = 97, Width = 137, Height = 5 }  ,
                new Rect { Left = 98, Top = 109, Width = 233, Height = 228 }    ,
                new Rect { Left = 111, Top = 152, Width = 137, Height = 245 }   ,
                new Rect { Left = 150, Top = 47, Width = 172, Height = 9 }  ,
                new Rect { Left = 246, Top = 113, Width = 97, Height = 193 }    ,
                new Rect { Left = 71, Top = 60, Width = 24, Height = 127 }  ,
                new Rect { Left = 106, Top = 93, Width = 132, Height = 43 } ,
                new Rect { Left = 239, Top = 106, Width = 19, Height = 222 }    ,
                new Rect { Left = 225, Top = 40, Width = 125, Height = 44 } ,
                new Rect { Left = 13, Top = 42, Width = 200, Height = 75 }  ,
                new Rect { Left = 235, Top = 109, Width = 87, Height = 196 }    ,
                new Rect { Left = 22, Top = 98, Width = 184, Height = 16 }  ,
                new Rect { Left = 119, Top = 50, Width = 187, Height = 32 } ,
                new Rect { Left = 226, Top = 99, Width = 247, Height = 42 } ,
                new Rect { Left = 161, Top = 197, Width = 204, Height = 233 }   ,
                new Rect { Left = 59, Top = 21, Width = 135, Height = 49 }  ,
                new Rect { Left = 200, Top = 42, Width = 57, Height = 103 } ,
                new Rect { Left = 82, Top = 177, Width = 109, Height = 49 } ,
                new Rect { Left = 194, Top = 151, Width = 23, Height = 107 }    ,
                new Rect { Left = 160, Top = 243, Width = 142, Height = 126 }   ,
                new Rect { Left = 33, Top = 83, Width = 242, Height = 75 }  ,
                new Rect { Left = 46, Top = 111, Width = 99, Height = 67 }  ,
                new Rect { Left = 44, Top = 41, Width = 151, Height = 54 }  ,
                new Rect { Left = 102, Top = 111, Width = 120, Height = 164 }   ,
                new Rect { Left = 70, Top = 192, Width = 185, Height = 139 }    ,
                new Rect { Left = 86, Top = 188, Width = 173, Height = 181 }    ,
                new Rect { Left = 94, Top = 212, Width = 209, Height = 218 }    ,
                new Rect { Left = 177, Top = 129, Width = 6, Height = 218 } ,
                new Rect { Left = 128, Top = 24, Width = 211, Height = 231 }    ,
                new Rect { Left = 147, Top = 85, Width = 174, Height = 232 }    ,
                new Rect { Left = 237, Top = 184, Width = 187, Height = 225 }   ,
                new Rect { Left = 221, Top = 38, Width = 108, Height = 236 }    ,
                new Rect { Left = 117, Top = 86, Width = 107, Height = 175 }    ,
                new Rect { Left = 74, Top = 223, Width = 164, Height = 152 }    ,
                new Rect { Left = 133, Top = 12, Width = 228, Height = 39 } ,
                new Rect { Left = 149, Top = 99, Width = 171, Height = 3 }  ,
                new Rect { Left = 121, Top = 154, Width = 76, Height = 210 }    ,
                new Rect { Left = 202, Top = 182, Width = 167, Height = 71 }    ,
                new Rect { Left = 235, Top = 85, Width = 188, Height = 191 }    ,
                new Rect { Left = 178, Top = 150, Width = 236, Height = 235 }   ,
                new Rect { Left = 137, Top = 235, Width = 151, Height = 90 }    ,
                new Rect { Left = 84, Top = 89, Width = 210, Height = 165 } ,
                new Rect { Left = 31, Top = 6, Width = 117, Height = 218 }  ,
                new Rect { Left = 68, Top = 93, Width = 242, Height = 243 } ,
                new Rect { Left = 56, Top = 39, Width = 39, Height = 176 }  ,
                new Rect { Left = 115, Top = 149, Width = 161, Height = 55 }    ,
                new Rect { Left = 37, Top = 118, Width = 65, Height = 111 } ,
                new Rect { Left = 207, Top = 74, Width = 35, Height = 35 }  ,
                new Rect { Left = 156, Top = 194, Width = 84, Height = 152 }    ,
                new Rect { Left = 108, Top = 109, Width = 205, Height = 101 }   ,
                new Rect { Left = 183, Top = 205, Width = 234, Height = 146 }   ,
                new Rect { Left = 54, Top = 199, Width = 224, Height = 235 }    ,
                new Rect { Left = 111, Top = 225, Width = 148, Height = 12 }    ,
                new Rect { Left = 190, Top = 13, Width = 150, Height = 42 } ,
                new Rect { Left = 202, Top = 233, Width = 104, Height = 130 }   ,
                new Rect { Left = 130, Top = 58, Width = 152, Height = 57 } ,
                new Rect { Left = 80, Top = 234, Width = 99, Height = 244 } ,
                new Rect { Left = 47, Top = 66, Width = 126, Height = 53 }  ,
                new Rect { Left = 191, Top = 74, Width = 163, Height = 83 } ,
                new Rect { Left = 242, Top = 98, Width = 32, Height = 75 }  ,
                new Rect { Left = 85, Top = 217, Width = 129, Height = 63 } ,
                new Rect { Left = 142, Top = 240, Width = 209, Height = 24 }    ,
                new Rect { Left = 30, Top = 142, Width = 250, Height = 232 }    ,
                new Rect { Left = 246, Top = 66, Width = 176, Height = 32 } ,
                new Rect { Left = 162, Top = 94, Width = 188, Height = 98 } ,
                new Rect { Left = 224, Top = 233, Width = 128, Height = 239 }   ,
                new Rect { Left = 138, Top = 161, Width = 165, Height = 9 } ,
                new Rect { Left = 112, Top = 69, Width = 188, Height = 75 } ,
                new Rect { Left = 164, Top = 72, Width = 16, Height = 95 }  ,
                new Rect { Left = 141, Top = 229, Width = 168, Height = 156 }
        };
            return l;
        }
    }
}
