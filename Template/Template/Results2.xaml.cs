using GoogleChartSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Template
{
    public sealed partial class Results2 : Page
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

        public Results2()
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
            data.Add(new int[] { ethnic[0], 0, 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, ethnic[1], 0, 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, ethnic[2], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, ethnic[3], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, ethnic[4], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, ethnic[5], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, ethnic[6], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, 0, 0, ethnic[7] });
            createBarGraph("EthnicBar.png", "Ethnicity Distribution", 400, 200, data, new string[] { "White", "African American", "Asian", "Hispanic", "Pacific Islander", "Native American", "Other" }, BarChartOrientation.Vertical, StatType.Ethnicity);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { fair[0], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, fair[1], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, fair[2], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, fair[3], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, fair[4], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, fair[5] });
            createBarGraph("FairnessBar.png", "Opinions of Judge", 400, 200, data, new string[] { "Completely Unfair", "Unfair", "Neutral", "Fair", "Completely Fair", "Prefer Not to Respond" }, BarChartOrientation.Vertical, StatType.Fairness);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { income[0], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, income[1], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, income[2], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, income[3], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, income[4], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, income[5] });
            createBarGraph("IncomeBar.png", "Different Incomes in the Court", 400, 200, data, new string[] { "Under $25,000", "$25,001-49,999", "$50,000-74,999", "$75,000-100,000", "Over $100,000", "Prefer Not to Respond" }, BarChartOrientation.Vertical, StatType.Income);
            data = new List<int[]>();
            await Task.Delay(TimeSpan.FromSeconds(3));
            data.Add(new int[] { wait[0], 0, 0, 0, 0, 0 });
            data.Add(new int[] { 0, wait[1], 0, 0, 0, 0 });
            data.Add(new int[] { 0, 0, wait[2], 0, 0, 0 });
            data.Add(new int[] { 0, 0, 0, wait[3], 0, 0 });
            data.Add(new int[] { 0, 0, 0, 0, wait[4], 0 });
            data.Add(new int[] { 0, 0, 0, 0, 0, wait[5] });
            await Task.Delay(TimeSpan.FromSeconds(3));
            createBarGraph("WaitBar.png", "Wait times in Court", 400, 200, data, new string[] { "Less than 15 min", "16-45 min", "46 min-1 hr", "1hr-2hr", "Greater than 2 hr", "Prefer not to respond" }, BarChartOrientation.Vertical, StatType.Wait);
            data = new List<int[]>();
        }

        public async void createBarGraph(string fileName, string title, int width, int height, List<int[]> data, string[] labels, BarChartOrientation overload, StatType type)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string url = "";
            BarChart chart = new BarChart(width, height, overload, BarChartStyle.Stacked);
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
