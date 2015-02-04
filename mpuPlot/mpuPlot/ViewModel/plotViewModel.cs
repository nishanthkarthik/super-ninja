using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Wpf;
using Newtonsoft.Json;
using System.IO;
using mpuPlot.Helper;

namespace mpuPlot.ViewModel
{
    class plotViewModel
    {
        public string Title { get; private set; }
        public IList<DataPoint> xCoord { get; set; }
        public IList<DataPoint> yCoord { get; set; }
        public IList<DataPoint> zCoord { get; set; }
        public plotViewModel()
        {
            this.Title = "mpu";
            StreamReader _reader = new StreamReader("mpu.json");
            string readingString = _reader.ReadToEnd();
            IList<readingFormat> readingStore = JsonConvert.DeserializeObject<IList<readingFormat>>(readingString);
            if (readingStore != null)
            {
                xCoord = new List<DataPoint>() { };
                yCoord = new List<DataPoint>() { };
                zCoord = new List<DataPoint>() { };
                for (int i = 0; i < readingStore.Count; i++)
                {
                    xCoord[i] = new DataPoint(i,readingStore[i].x);
                    yCoord[i] = new DataPoint(i, readingStore[i].y);
                    zCoord[i] = new DataPoint(i, readingStore[i].z);
                }
            }
        }
    }
}
