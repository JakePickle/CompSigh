using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using System.Runtime.InteropServices.WindowsRuntime;
using GoogleChartSharp;
using Windows.UI.Xaml.Media.Imaging;

namespace Template
{
    public enum StatType
    {
        Age,
        Ethnicity,
        Income,
        Wait,
        Fairness
    }

    public sealed partial class Results : Page
    {
        MainPage rootPage = MainPage.Current;
        int[] fair = null;
        int[] ethnic = null;
        int[] age = null;
        int[] income = null;
        int[] wait = null;
        int count = 0;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        int count6 = 0;
        int count7 = 0;

        public Results()
        {
            this.InitializeComponent();
            doTheGraphs();
        }

        public async void doTheGraphs()
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var ageFile = await local.OpenStreamForReadAsync(@"Age.txt");

            // Read the data.
            using (StreamReader streamReader = new StreamReader(ageFile))
            {
                string line = "";
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (Int32.Parse(line[0] + "") == 0)
                    {
                        count++;
                    }
                    else if (Int32.Parse(line[0] + "") == 1)
                    {
                        count1++;
                    }
                    else if (Int32.Parse(line[0] + "") == 2)
                    {
                        count2++;
                    }
                    else if (Int32.Parse(line[0] + "") == 3)
                    {
                        count3++;
                    }
                    else if (Int32.Parse(line[0] + "") == 4)
                    {
                        count4++;
                    }
                    else if (Int32.Parse(line[0] + "") == 5)
                    {
                        count5++;
                    }
                    else if (Int32.Parse(line[0] + "") == 6)
                    {
                        count6++;
                    }
                    else
                    {
                        count7++;
                    }
                }
            }
            ageFile.Dispose();
            age = new int[] { count, count1, count2, count3, count4, count5, count6, count7 };
            count = count1 = count2 = count3 = count4 = count5 = count6 = count7 = 0;

            var ethFile = await local.OpenStreamForReadAsync(@"Ethnic.txt");
            // Read the data.
            using (StreamReader streamReader = new StreamReader(ethFile))
            {
                string line = "";
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (Int32.Parse(line[0] + "") == 0)
                    {
                        count++;
                    }
                    else if (Int32.Parse(line[0] + "") == 1)
                    {
                        count1++;
                    }
                    else if (Int32.Parse(line[0] + "") == 2)
                    {
                        count2++;
                    }
                    else if (Int32.Parse(line[0] + "") == 3)
                    {
                        count3++;
                    }
                    else if (Int32.Parse(line[0] + "") == 4)
                    {
                        count4++;
                    }
                    else if (Int32.Parse(line[0] + "") == 5)
                    {
                        count5++;
                    }
                    else if (Int32.Parse(line[0] + "") == 6)
                    {
                        count6++;
                    }
                    else
                    {
                        count7++;
                    }
                }
            }
            ethFile.Dispose();
            ethnic = new int[] { count, count1, count2, count3, count4, count5, count6, count7 };
            count = count1 = count2 = count3 = count4 = count5 = count6 = count7 = 0;

            var IncomeFile = await local.OpenStreamForReadAsync(@"Income.txt");
            // Read the data.
            using (StreamReader streamReader = new StreamReader(IncomeFile))
            {
                string line = "";
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (Int32.Parse(line[0] + "") == 0)
                    {
                        count++;
                    }
                    else if (Int32.Parse(line[0] + "") == 1)
                    {
                        count1++;
                    }
                    else if (Int32.Parse(line[0] + "") == 2)
                    {
                        count2++;
                    }
                    else if (Int32.Parse(line[0] + "") == 3)
                    {
                        count3++;
                    }
                    else if (Int32.Parse(line[0] + "") == 4)
                    {
                        count4++;
                    }
                    else if (Int32.Parse(line[0] + "") == 5)
                    {
                        count5++;
                    }
                    else if (Int32.Parse(line[0] + "") == 6)
                    {
                        count6++;
                    }
                    else
                    {
                        count7++;
                    }
                }
            }
            IncomeFile.Dispose();
            income = new int[] { count, count1, count2, count3, count4, count5 };
            count = count1 = count2 = count3 = count4 = count5 = count6 = count7 = 0;

            var WaitFile = await local.OpenStreamForReadAsync(@"Wait.txt");
            // Read the data.
            using (StreamReader streamReader = new StreamReader(WaitFile))
            {
                string line = "";
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (Int32.Parse(line[0] + "") == 0)
                    {
                        count++;
                    }
                    else if (Int32.Parse(line[0] + "") == 1)
                    {
                        count1++;
                    }
                    else if (Int32.Parse(line[0] + "") == 2)
                    {
                        count2++;
                    }
                    else if (Int32.Parse(line[0] + "") == 3)
                    {
                        count3++;
                    }
                    else if (Int32.Parse(line[0] + "") == 4)
                    {
                        count4++;
                    }
                    else if (Int32.Parse(line[0] + "") == 5)
                    {
                        count5++;
                    }
                    else if (Int32.Parse(line[0] + "") == 6)
                    {
                        count6++;
                    }
                    else
                    {
                        count7++;
                    }
                }
            }
            WaitFile.Dispose();
            wait = new int[] { count, count1, count2, count3, count4, count5 };
            count = count1 = count2 = count3 = count4 = count5 = count6 = count7 = 0;

            var FairnessFile = await local.OpenStreamForReadAsync(@"Fairness.txt");
            // Read the data.
            using (StreamReader streamReader = new StreamReader(FairnessFile))
            {
                string line = "";
                while (!streamReader.EndOfStream)
                {
                    line = streamReader.ReadLine();
                    if (Int32.Parse(line[0] + "") == 0)
                    {
                        count++;
                    }
                    else if (Int32.Parse(line[0] + "") == 1)
                    {
                        count1++;
                    }
                    else if (Int32.Parse(line[0] + "") == 2)
                    {
                        count2++;
                    }
                    else if (Int32.Parse(line[0] + "") == 3)
                    {
                        count3++;
                    }
                    else if (Int32.Parse(line[0] + "") == 4)
                    {
                        count4++;
                    }
                    else if (Int32.Parse(line[0] + "") == 5)
                    {
                        count5++;
                    }
                    else if (Int32.Parse(line[0] + "") == 6)
                    {
                        count6++;
                    }
                    else
                    {
                        count7++;
                    }
                }
            }
            FairnessFile.Dispose();
            fair = new int[] { count, count1, count2, count3, count4, count5 };
            count = count1 = count2 = count3 = count4 = count5 = count6 = count7 = 0;
            List<int[]> data = new List<int[]>();
            createPiGraph("FairPie.png", "Community Opinion of Judge", 400, 200, fair, new string[] { "Completely Unfair", "Unfair", "Neutral", "Fair", "Completely Fair", "Prefer Not to Respond" }, StatType.Fairness);
            createPiGraph("EthnicPie.png", "Ethnic Diversity in Courts", 400, 200, ethnic, new string[] { "White", "African American", "Asian", "Hispanic", "Pacific Island", "Native American", "Other", "Prefer not to respond" }, StatType.Ethnicity);
            createPiGraph("IncomePie.png", "Income Diversity in Courts", 400, 200, income, new string[] { "Under $25,000", "$25,001-49,999", "$50,000-74,999", "$75,000-100,000", "Over $100,000", "Prefer Not to Respond" }, StatType.Income);
            createPiGraph("WaitPie.png", "Wait Time in Courts", 400, 200,wait, new string[] { "Less than 15 min", "16-45 min", "46 min-1 hr", "1hr-2hr", "Greater than 2 hr", "Prefer not to respond" }, StatType.Wait);
            createPiGraph("AgePie.png", "Age Diversity in Courts", 400, 200, age, new string[] { "Under 18", "18-25", "26-35", "36-45", "46-55", "56-65", "Over 65", "Prefer not to respond" }, StatType.Age);
        }

        public async void createPiGraph(string fileName, string title, int width, int height, int[] data, string[] labels, StatType type)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            PieChart chart = new PieChart(width, height, PieChartType.TwoD);
            chart.SetTitle(title);
            chart.SetPieChartLabels(labels);
            chart.SetData(data);
            chart.AddSolidFill(new SolidFill(ChartFillTarget.Background, @"00000000"));
            url = chart.GetUrl();
            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(url);
            // returned values are returned as a stream, then read into a string
            String lsResponse = string.Empty;
            using (var lxResponse = await lxRequest.GetResponseAsync())
            {
                using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                    await FileIO.WriteBufferAsync(file, lnByte.AsBuffer());
                }
            }
            await Task.Delay(TimeSpan.FromSeconds(2));
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap 
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelWidth = width; //match the target Image.Width, not shown
                bitmapImage.DecodePixelHeight = height;
                await bitmapImage.SetSourceAsync(fileStream);
                if(type==StatType.Age)
                {
                    pieAge.Source = bitmapImage;
                }
                else if(type==StatType.Ethnicity)
                {
                    pieEthnic.Source = bitmapImage;
                }
                else if(type==StatType.Fairness)
                {
                    pieFair.Source = bitmapImage;
                }
                else if(type==StatType.Income)
                {
                    pieIncome.Source = bitmapImage;
                }
                else
                {
                    pieWait.Source = bitmapImage;
                }
                //pieImg.Source = bitmapImage;
            }
        }

        public async void createGraph(string fileName, string title, int width, int height, List<int[]> data, string[] labels)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            LineChart chart = new LineChart(width, height,LineChartType.MultiDataSet);
            chart.SetTitle(title);
            chart.SetLegend(labels);
            chart.SetData(data);
            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            chart.AddSolidFill(new SolidFill(ChartFillTarget.Background, @"00000000"));
            url = chart.GetUrl();
            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(url);
            // returned values are returned as a stream, then read into a string
            String lsResponse = string.Empty;
            using (var lxResponse = await lxRequest.GetResponseAsync())
            {
                using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                    await FileIO.WriteBufferAsync(file, lnByte.AsBuffer());
                }
            }
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap 
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelWidth = width; //match the target Image.Width, not shown
                bitmapImage.DecodePixelHeight = height;
                await bitmapImage.SetSourceAsync(fileStream);
                //scatterImg.Source = bitmapImage;
            }
        }

        public async void createGraph(string fileName, string title, int width, int height, List<int[]> data, string[] labels, int overload)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            ScatterPlot chart = new ScatterPlot(width, height);
            chart.SetTitle(title);
            chart.SetData(data);
            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            chart.AddSolidFill(new SolidFill(ChartFillTarget.Background, @"00000000"));
            url = chart.GetUrl();
            
            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(url);
            // returned values are returned as a stream, then read into a string
            String lsResponse = string.Empty;
            using (var lxResponse = await lxRequest.GetResponseAsync())
            {
                using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                    await FileIO.WriteBufferAsync(file, lnByte.AsBuffer());
                }
            }
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap 
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelWidth = width; //match the target Image.Width, not shown
                bitmapImage.DecodePixelHeight = height;
                await bitmapImage.SetSourceAsync(fileStream);
                //scatterImg.Source = bitmapImage;
            }
        }

      
    }
}
