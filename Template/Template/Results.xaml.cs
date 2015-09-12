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
           // createPie();
        }

        public async void createPie(string fileName,GraphType type)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            StorageFile file = await folder.CreateFileAsync("test.png", CreationCollisionOption.ReplaceExisting);
            string url = "https://chart.googleapis.com/chart?cht=p3&chs=250x100&chd=t:60,40&chl=Hello|World";
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
            
        }

      }



}
