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
                xCoord = new List<DataPoint>(readingStore.Count) { };
                yCoord = new List<DataPoint>(readingStore.Count) { };
                zCoord = new List<DataPoint>(readingStore.Count) { };
                for (int i = 0; i < readingStore.Count; i++)
                {
                    xCoord.Add(new DataPoint(i, (double)readingStore[i].x / 32767.0 * 2));
                    yCoord.Add(new DataPoint(i, (double)readingStore[i].y / 32767.0 * 2));
                    zCoord.Add(new DataPoint(i, (double)readingStore[i].z / 32767.0 * 2));
                }
            }
        }
    }
}
