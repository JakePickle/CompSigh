using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Template
{
    public sealed partial class Welcome : Page
    {
        MainPage rootPage = MainPage.Current;

        public Welcome()
        {
            this.InitializeComponent();
        }

        private void continueBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            rootPage.changeToNextScenario();
        }
    }
}
