using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Wpf;
using System.Windows.Forms.DataVisualization.Charting;
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
        async public plotViewModel()
        {
            this.Title = "mpu";
            StreamReader _reader = new StreamReader("mpu.json");
            string readingString = await _reader.ReadToEndAsync();
            IList<readingFormat> readingStore = await JsonConvert.DeserializeObjectAsync<IList<readingFormat>>(readingString);
            if (readingStore != null)
            {
                xCoord = new IList<DataPoint>() { };
                yCoord = new IList<DataPoint>() { };
                zCoord = new IList<DataPoint>() { };
                for (int i = 0; i < readingStore.Count; i++)
                {

                }
            }
        }
    }
}
