using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ImageProcessing
{
   
    public class MultiThreadExecution : IExecution
    {
       
        public Bitmap Execute(Bitmap initial, Filter filter)
        {
            var threadCount = System.Environment.ProcessorCount;
            Color[,] result = new Color[initial.Height,initial.Width];
            

            BitmapToColorArrayConverter bitmapToColorArray = new BitmapToColorArrayConverter();

            Color[,] colMatrix = bitmapToColorArray.Convert(initial);
            int size = initial.Height / threadCount;
            
            List<Thread> threadList = new List<Thread>();

            for (int i = 0, start = 0; i < threadCount; i++)
            {
                int finish = start + size;

                ImageProcessInfo info = new ImageProcessInfo(start, finish, colMatrix, filter);

                var thread = new Thread(delegate ()
                {
                    Convolution.Process(info,result);
                });


                threadList.Add(thread);

                thread.Start();

                start += size;
            }

            threadList.ForEach(thread => thread.Join());
            ColorArrayToBitmapConverter colorArrayToBitmap = new ColorArrayToBitmapConverter();
            
            return colorArrayToBitmap.Convert(result);
        }
    }
}
