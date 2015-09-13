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

        public Results()
        {
            this.InitializeComponent();
            doTheGraphs();
        }

        public async void doTheGraphs()
        {
            DoData doData = new DoData();
            doData.doAges();
            await Task.Delay(TimeSpan.FromSeconds(5));
            doData.doEthnic();
            await Task.Delay(TimeSpan.FromSeconds(5));
            doData.doIncome();
            await Task.Delay(TimeSpan.FromSeconds(5));
            doData.doWait();
            await Task.Delay(TimeSpan.FromSeconds(5));
            doData.doFairness();
            List<int[]> data = new List<int[]>();
            createPiGraph("FairPie.png", "Community Opinion of Judge", 400, 200, doData.getFair(), new string[] { "Completely Unfair", "Unfair", "Neutral", "Fair", "Completely Fair", "Prefer Not to Respond" }, StatType.Fairness);
            createPiGraph("EthnicPie.png", "Ethnic Diversity in Courts", 400, 200, doData.getEthnic(), new string[] { "White", "African American", "Asian", "Hispanic", "Pacific Island", "Native American", "Other", "Prefer not to respond" }, StatType.Ethnicity);
            createPiGraph("IncomePie.png", "Income Diversity in Courts", 400, 200, doData.getIncome(), new string[] { "Under $25,000", "$25,001-49,999", "$50,000-74,999", "$75,000-100,000", "Over $100,000", "Prefer Not to Respond" }, StatType.Income);
            createPiGraph("WaitPie.png", "Wait Time in Courts", 400, 200, doData.getWait(), new string[] { "Less than 15 min", "16-45 min", "46 min-1 hr", "1hr-2hr", "Greater than 2 hr", "Prefer not to respond" }, StatType.Wait);
            createPiGraph("AgePie.png", "Age Diversity in Courts", 400, 200, doData.getWait(), new string[] { "Under 18", "18-25", "26-35", "36-45", "46-55", "56-65", "Over 65", "Prefer not to respond" }, StatType.Age);
            await Task.Delay(TimeSpan.FromSeconds(30));
            data.Add(new int[] { doData.getEthnic()[0], 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, doData.getEthnic()[1], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, doData.getEthnic()[2], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, doData.getEthnic()[3], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, doData.getEthnic()[4], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, doData.getEthnic()[5], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, doData.getEthnic()[6] });
            createBarGraph("EthnicBar.png", "Number of Ethnicities", 400, 200, data, new string[] { "White", "African American", "Asian", "Hispanic", "Pacific Islander", "Native American", "Other" }, BarChartOrientation.Vertical, StatType.Ethnicity);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { doData.getFair()[0], 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, doData.getFair()[1], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, doData.getFair()[2], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, doData.getFair()[3], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, doData.getFair()[4], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, doData.getFair()[5], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, doData.getFair()[6] });
            createBarGraph("FairnessBar.png", "Opinions of Judge", 400, 200, data, new string[] { "Completely Unfair", "Unfair", "Neutral", "Fair", "Completely Fair", "Prefer Not to Respond" }, BarChartOrientation.Vertical, StatType.Fairness);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { doData.getIncome()[0], 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, doData.getIncome()[1], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, doData.getIncome()[2], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, doData.getIncome()[3], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, doData.getIncome()[4], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, doData.getIncome()[5], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, doData.getIncome()[6] });
            createBarGraph("IncomeBar.png", "Different Incomes in the Court", 400, 200, data, new string[] { "Under $25,000", "$25,001-49,999", "$50,000-74,999", "$75,000-100,000", "Over $100,000", "Prefer Not to Respond" }, BarChartOrientation.Vertical, StatType.Income);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { doData.getWait()[0], 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, doData.getWait()[1], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, doData.getWait()[2], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, doData.getWait()[3], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, doData.getWait()[4], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, doData.getWait()[5], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, doData.getWait()[6] });
            await Task.Delay(TimeSpan.FromSeconds(3));
            createBarGraph("WaitBar.png", "Wait times in Court", 400, 200, data, new string[] { "Less than 15 min", "16-45 min", "46 min-1 hr", "1hr-2hr", "Greater than 2 hr", "Prefer not to respond" }, BarChartOrientation.Vertical, StatType.Wait);
            data = new List<int[]>();
        }
        public async void createPiGraph(string fileName, string title, int width, int height, int[] data, string[] labels, StatType type)
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

        public async void createBarGraph(string fileName, string title, int width, int height, List<int[]> data, string[] labels, BarChartOrientation overload, StatType type)
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
                if (type == StatType.Age)
                {
                    barAge.Source = bitmapImage;
                }
                else if (type == StatType.Ethnicity)
                {
                    barEthnic.Source = bitmapImage;
                }
                else if (type == StatType.Fairness)
                {
                    barFair.Source = bitmapImage;
                }
                else if (type == StatType.Income)
                {
                    barIncome.Source = bitmapImage;
                }
                else
                {
                    barWait.Source = bitmapImage;
                }
                //barImg.Source = bitmapImage;
            }
        }
    }
}
