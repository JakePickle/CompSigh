using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace Template
{
    public sealed partial class Scenario1 : Page
    {
        MainPage rootPage = MainPage.Current;

        public Scenario1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            clearFields();

        }

        public void clearFields()
        {
            lastNameText.Text = "";
            firstNameText.Text = "";
            tickNumber.Text = "";
            cmbAgeGroup.SelectedIndex = -1;
            cmbFairBox.SelectedIndex = -1;
            cmbIncomeGroup.SelectedIndex = -1;
            cmbRaceGroup.SelectedIndex = -1;
            cmbTimeBox.SelectedIndex = -1;

        }

        private async void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            bool isValidCitation = false;
            try
            {
                StorageFile ageFile = await local.CreateFileAsync("Age.txt", CreationCollisionOption.FailIfExists);
                StorageFile ethnicFile = await local.CreateFileAsync("Ethnic.txt", CreationCollisionOption.FailIfExists);
                StorageFile waitFile = await local.CreateFileAsync("Wait.txt", CreationCollisionOption.FailIfExists);
                StorageFile incomeFile = await local.CreateFileAsync("Income.txt", CreationCollisionOption.FailIfExists);
                StorageFile fairnessFile = await local.CreateFileAsync("Fairness.txt", CreationCollisionOption.FailIfExists);
            }
            catch (Exception ea)
            {

            }
            if (local != null)
            {
                // Get the file.
                StorageFolder install = Windows.ApplicationModel.Package.Current.InstalledLocation;
                var citationNumber = await install.OpenStreamForReadAsync(@"Assets\citations.csv");

                // Read the data.
                using (StreamReader streamReader = new StreamReader(citationNumber))
                {
                    string line = "";
                    string[] partsOfLine = null;
                    while (!streamReader.EndOfStream || !isValidCitation)
                    {
                        if(streamReader.EndOfStream)
                        {
                            MessageDialog msgbox = new MessageDialog("Citation Number, First Name, and Last Name do not match!", "Court Analyzer");

                            //msgbox.Commands.Clear();
                            //msgbox.Commands.Add(new UICommand { Label = "OK", Id = 0 });
                           
                            var res = await msgbox.ShowAsync();

                            /*
                            if ((int)res.Id == 0)
                            {
                                MessageDialog msgbox2 = new MessageDialog("Hello to you too! :)", "User Response");
                                await msgbox2.ShowAsync();
                            }

                            if ((int)res.Id == 1)
                            {
                                MessageDialog msgbox2 = new MessageDialog("Oh well, too bad! :(", "User Response");
                                await msgbox2.ShowAsync();
                            }

                            if ((int)res.Id == 2)
                            {
                                MessageDialog msgbox2 = new MessageDialog("Nevermind then... :|", "User Response");
                                await msgbox2.ShowAsync();
                            }*/
                            return;
                        }
                        line = streamReader.ReadLine();
                        partsOfLine = line.Split(',');
                        if(partsOfLine[1].Equals(tickNumber.Text))
                        {
                            if(partsOfLine[4].Equals(lastNameText.Text))
                            {
                                if(partsOfLine[3].Equals(firstNameText.Text))
                                {
                                    isValidCitation = true;
                                }
                            }
                        }
                    }
                }
                citationNumber.Dispose();

                // Get the file.
                var ageFile = await local.OpenStreamForWriteAsync("Age.txt",CreationCollisionOption.OpenIfExists);

                // Read the data.
                using (StreamWriter streamWriter = new StreamWriter(ageFile))
                {
                    streamWriter.WriteLine(cmbAgeGroup.SelectedIndex + ";" + DateTime.Now);
                    streamWriter.Flush();
                }
                ageFile.Dispose();
                
                // Get the file.
                var ethnicFile = await local.OpenStreamForWriteAsync("Ethnic.txt", CreationCollisionOption.OpenIfExists);

                // Read the data.
                using (StreamWriter streamWriter = new StreamWriter(ethnicFile))
                {
                    streamWriter.WriteLine(cmbRaceGroup.SelectedIndex + ";" + DateTime.Now);
                    streamWriter.Flush();
                }
                ethnicFile.Dispose();

                // Get the file.
                var waitFile = await local.OpenStreamForWriteAsync("Wait.txt", CreationCollisionOption.OpenIfExists);

                // Read the data.
                using (StreamWriter streamWriter = new StreamWriter(waitFile))
                {
                    streamWriter.WriteLine(cmbTimeBox.SelectedIndex + ";" + DateTime.Now);
                    streamWriter.Flush();
                }
                waitFile.Dispose();

                // Get the file.
                var incomeFile = await local.OpenStreamForWriteAsync("Income.txt", CreationCollisionOption.OpenIfExists);

                // Read the data.
                using (StreamWriter streamWriter = new StreamWriter(incomeFile))
                {
                    streamWriter.WriteLine(cmbIncomeGroup.SelectedIndex + ";" + DateTime.Now);
                    streamWriter.Flush();
                }
                incomeFile.Dispose();


                // Get the file.
                var fairnessFile = await local.OpenStreamForWriteAsync("Fairness.txt", CreationCollisionOption.OpenIfExists);

                // Read the data.
                using (StreamWriter streamWriter = new StreamWriter(fairnessFile))
                {
                    streamWriter.WriteLine(cmbFairBox.SelectedIndex + ";" + DateTime.Now);
                    streamWriter.Flush();
                }
                incomeFile.Dispose();
                clearFields();
                rootPage.changeToNextScenario();
            }
        }
    }
}
