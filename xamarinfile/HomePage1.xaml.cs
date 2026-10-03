//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using Xamarin.Forms.Xaml;
//using XFShopApp.Models;
//using XFShopApp.Views.Pages;

//namespace XFShopApp.Views.TabbedPages
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class HomePage
//    {
//        public HomePage()
//        {
//            InitializeComponent();

//            //string email = txtEmail.Text?.Trim();
//            //string pass = txtPassword.Text?.Trim();


//            //string jsonData = JsonConvert.SerializeObject(loginObj);

//           // var content = new StringContent(jsonData, Encoding.UTF8, "application/json");



//            string mainurl = "http://ahmedmokhtar10-002-site1.anytempurl.com/api/Category";

//            string url_category = "Category";


//            string url = mainurl + url_category;

//            Uri uri = new Uri(url);
//            WebClient client = new WebClient();
//            client.DownloadDataAsync(uri);
//            client.DownloadDataCompleted += Client_DownloadDataCompleted;

//            //string result = await response.Content.ReadAsStringAsync();

//            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(url);




//            PreviousViewedList1.ItemsSource = ProductLists;
//            PreviousViewedList.ItemsSource = ProductLists;
//            ListViewCategory.ItemsSource = CategoryList;
//            CarouselView.ItemsSource = CarouselList;
//        }

//        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
//        {
//            var joson = Encoding.UTF8.GetString(e.Result);
//            var Category1 = JsonConvert.DeserializeObject<List<Category>>(joson);
//            foreach (var item in Category1)
//            {
//                CategoryList.Add(new Category
//                {
//                    Category_id = item.Category_id,

//                    Category_Name = item.Category_Name,

//                    Category_image = "http://ahmedmokhtar10-002-site1.anytempurl.com/api/Category" + item.Category_image
//                }
//                    );
//                //Category_id =item.Category_id,

//            }
//        }
//        //CategoryList.Add(new Category
//        //{
//        //    CategoryName = "Brushs",
//        //    Image = "barberBrush.png"
//        //}); CategoryList.Add(new Category
//        private async void ProductDetailClick(object sender, EventArgs e)
//        {
//            await Navigation.PushAsync(new ProductDetail());
//        }
//        private async void ClickCategoryDetail(object sender, EventArgs e)
//        {
//            await Navigation.PushAsync(new CategoryDetailPage());
//        }
//    }
//}









using System.Collections.ObjectModel;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShopApp.Models;

namespace XFShopApp.Views.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        List<Category> CategoryList = new List<Category>();
        //List<Product> ProductLists = new List<Product>();
        //List<Slider> CarouselList = new List<Slider>();
       // PreviousViewedList1.ItemsSource = ProductLists;
//            PreviousViewedList.ItemsSource = ProductLists;
//            ListViewCategory.ItemsSource = CategoryList;
//            CarouselView.ItemsSource = CarouselList;
        public HomePage()
        {
            InitializeComponent();

            string url = "http://ahmedmokhtar10-002-site1.anytempurl.com/api/Category/";

            Uri uri = new Uri(url);
            WebClient client = new WebClient();

            client.DownloadDataCompleted += Client_DownloadDataCompleted;
            client.DownloadDataAsync(uri);

            PreviousViewedList1.ItemsSource = ProductLists;
            PreviousViewedList.ItemsSource = ProductLists;
            ListViewCategory.ItemsSource = CategoryList;
            CarouselView.ItemsSource = CarouselList;
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DisplayAlert("Error", e.Error.Message, "OK");
                return;
            }

            var json = Encoding.UTF8.GetString(e.Result);

            var categories = JsonConvert.DeserializeObject<List<Category>>(json);

            CategoryList.Clear();

            foreach (var item in categories)
            {
                CategoryList.Add(new Category
                {
                    Category_id = item.Category_id,
                    Category_Name =  item.Category_Name,
                    Category_image = "http://ahmedmokhtar10-002-site1.anytempurl.com/images/category/" + item.Category_image
                });
            }


            ListViewCategory.ItemsSource = CategoryList;
        }
        private void ClickCategoryDetail11(object sender, EventArgs e)
        {
            // العنصر الذي تم الضغط عليه
            var btn = sender as Button;

            if (btn == null)
                return;

            // أخذ ID من CommandParameter
            var categoryId = btn.CommandParameter?.ToString();

            DisplayAlert("Category Clicked", categoryId, "OK");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // العنصر الذي تم الضغط عليه
            var btn = sender as Button;

            if (btn == null)
                return;

            // أخذ ID من CommandParameter
            var categoryId = btn.CommandParameter?.ToString();

            DisplayAlert("Category Clicked", categoryId, "OK");
        }

        private void ProductDetail_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}
