//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SDKTemplate
{
    /// <summary>
    /// Deleting a file.
    /// </summary>
    public sealed partial class Scenario10 : Page
    {
        MainPage rootPage = MainPage.Current;

        public Scenario10()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rootPage.ValidateFile();
        }

        private async void DeleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = rootPage.sampleFile;
            if (file != null)
            {
                try
                {
                    string filename = file.Name;
                    await file.DeleteAsync();
                    rootPage.sampleFile = null;
                    rootPage.NotifyUser($"The file '{filename}' was deleted", NotifyType.StatusMessage);
                }
                catch (FileNotFoundException)
                {
                    rootPage.NotifyUserFileNotExist();
                }
                catch (Exception ex)
                {
                    // I/O errors are reported as exceptions.
                    rootPage.NotifyUser($"Error deleting file '{file.Name}': {ex.Message}", NotifyType.ErrorMessage);
                }
            }
            else
            {
                rootPage.NotifyUserFileNotExist();
            }
        }
    }
}
