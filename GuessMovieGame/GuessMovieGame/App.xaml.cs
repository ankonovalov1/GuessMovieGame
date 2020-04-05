using Android.Content.Res;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessMovieGame
{
    public partial class App : Application
    {
        public App()
        {
            RussianMovieList russianMovieList = new RussianMovieList();
            InternationalMovieList internationalMovieList = new InternationalMovieList();
            InitializeComponent();            

            MainPage = new NavigationPage(new MainPage());

            for(int i = 0; i < 10; i++)
            {
                Movie newMovie = new Movie("Бумер", "Братва угнала машинку и гоняет на ней под рингтон на мобилку");
                RussianMovieList.RussianMoviesList.Add(newMovie);
            }
            for(int i = 0; i < 10; i++)
            {
                Movie newMovie = new Movie("Титаник", "В этом фильме есть Ди Каприо и он там хорошо поплавал");
                InternationalMovieList.InternationalMoviesList.Add(newMovie);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
