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
using SqlSugar;
using System.Diagnostics;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace test
{
    public class Order
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "DataSource=" + System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, "ShadowViewer.db"),
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true
            },
           db => {
               db.Aop.OnLogExecuting = (sql, pars) =>
               {
                   Debug.WriteLine(sql);//输出sql,查看执行sql 性能无影响

               };


           });
            var o = new Order() { Id = 2, Name = "1122222" };
            Db.Insertable(o).ExecuteCommand();
            var a  = Db.Queryable<Order>().ToList();
            Debug.WriteLine(a.ToString());
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            //PicaClient.SetProxy(new Uri("http://127.0.0.1:8888"));
            PicaClient.SetToken(@"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1YTk5NzAyYzExYTMxNjRiNzdlMWNmNDYiLCJlbWFpbCI6Imt1bHVqdW4iLCJyb2xlIjoibWVtYmVyIiwibmFtZSI6Iuaer-mcsuWQmyIsInZlcnNpb24iOiIyLjIuMS4zLjMuNCIsImJ1aWxkVmVyc2lvbiI6IjQ1IiwicGxhdGZvcm0iOiJhbmRyb2lkIiwiaWF0IjoxNjg0MDY1NDI4LCJleHAiOjE2ODQ2NzAyMjh9.dZyZ91Ks_TmB2XM4tKLt0RJ_QN1U9N1a_XtBS4OGR6k");
            // await PicaClient.SignIn("kulujun", "bala1234/");
            // await PicaClient.Recommendation("63b19f7b7b16a36d00ebc892");
            // await PicaClient.AdvancedSearch("正太",1);
            await PicaClient.KnightLeaderboard();
            await PicaClient.Leaderboard();
            // await PicaClient.SendCommentChildren("62be7f6d5bf79a9f6917e24a","喜欢");
            //await PicaClient.ComicRandom();
            //await PicaClient.ComicCollections();
            // await PicaClient.TestPut();
            // await PicaClient.Profile();
            // await PicaClient.TestPost();
        }
    }
}
