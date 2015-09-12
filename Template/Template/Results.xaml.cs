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
    public enum GraphType
    {
        Line,
        Pie,
        Bar,
        Dot
    }

    public sealed partial class Results : Page
    {
        MainPage rootPage = MainPage.Current;

        public Results()
        {
            this.InitializeComponent();
            List<int[]> data = new List<int[]>();
            createGraph("testPie.png", "Community Opinion of Judge as Percentages", 400, 200, new int[] { 25, 25, 25, 25 }, new string[] { "test1", "test2", "test3", "test4" });
            data.Add(new int[] { 10, 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 5, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 20, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 15, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 10, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 5, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, 12 });
            createGraph("testBar.png", "Number of Ethnicities", 400, 200, data, new string[] { "White", "African American", "Asian", "Hispanic", "Pacific Islander", "Native American", "Other" }, BarChartOrientation.Vertical);
            data=new List<int[]>();
            data.Add(new int[] {0,15,30,45,60 });
            data.Add(new int[] { 10, 50, 15, 60, 12});
            createGraph("testScatter.png", "Age Vs. Wait Time", 400, 200, data, new string[] { "" },1);
            //createPie();
        }

        public async void createGraph(string fileName, string title, int width, int height, int[] data, string[] labels)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            PieChart chart = new PieChart(width, height, PieChartType.ThreeD);
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
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap 
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelWidth = width; //match the target Image.Width, not shown
                bitmapImage.DecodePixelHeight = height;
                await bitmapImage.SetSourceAsync(fileStream);
                pieImg.Source = bitmapImage;
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
                scatterImg.Source = bitmapImage;
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
                scatterImg.Source = bitmapImage;
            }
        }

        public async void createGraph(string fileName, string title, int width, int height, List<int[]> data, string[] labels, BarChartOrientation overload)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            BarChart chart = new BarChart(width, height,overload,BarChartStyle.Stacked);
            chart.SetTitle(title);
            chart.SetLegend(labels);
            chart.SetDatasetColors(new string[] { "FF0000", "00AA00", "E6E6FA", "333333", "32cd32", "00FF00", "740001" });
            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
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
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap 
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelWidth = width; //match the target Image.Width, not shown
                bitmapImage.DecodePixelHeight = height;
                await bitmapImage.SetSourceAsync(fileStream);
                barImg.Source = bitmapImage;
            }
        }
    }
}
