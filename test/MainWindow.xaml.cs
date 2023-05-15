// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using PicaComic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            PicaClient.SetProxy(new Uri("http://127.0.0.1:8888"));
            PicaClient.SetToken(@"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1YTk5NzAyYzExYTMxNjRiNzdlMWNmNDYiLCJlbWFpbCI6Imt1bHVqdW4iLCJyb2xlIjoibWVtYmVyIiwibmFtZSI6Iuaer-mcsuWQmyIsInZlcnNpb24iOiIyLjIuMS4zLjMuNCIsImJ1aWxkVmVyc2lvbiI6IjQ1IiwicGxhdGZvcm0iOiJhbmRyb2lkIiwiaWF0IjoxNjg0MDY1NDI4LCJleHAiOjE2ODQ2NzAyMjh9.dZyZ91Ks_TmB2XM4tKLt0RJ_QN1U9N1a_XtBS4OGR6k");
            // await PicaClient.SignIn("kulujun", "bala1234/");
            // await PicaClient.Recommendation("63b19f7b7b16a36d00ebc892");
            await PicaClient.AdvancedSearch("ÕýÌ«",1);

            //await PicaClient.CommentChildren("62be7f6d5bf79a9f6917e24a", 1);
            //await PicaClient.ComicRandom();
            //await PicaClient.ComicCollections();
            // await PicaClient.TestPut();
            // await PicaClient.Profile();
            // await PicaClient.TestPost();
        }
    }
}
