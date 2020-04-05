using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuessMovieGame
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Random rnd = new Random();
        ArrayList rusList = RussianMovieList.RussianMoviesList;
        ArrayList interList = InternationalMovieList.InternationalMoviesList;
        public MainPage()
        {
            InitializeComponent();
        }

        public async void RussianMovieButton_Click(object sender, EventArgs e)
        {
            bool isRusmovie = true;
            int index = rnd.Next(0, rusList.Count);
            Movie rusMovie = GetMovieByIndex(rusList,index);
            await Navigation.PushAsync(new GamePlayPage(rusMovie, isRusmovie));
        }
        public async void InternationalMovieButton_Click(object sender, EventArgs e)
        {
            bool isRusmovie = false;
            int index = rnd.Next(0, interList.Count);
            Movie interMovie = GetMovieByIndex(interList,index);
            await Navigation.PushAsync(new GamePlayPage(interMovie, isRusmovie));
        }

        public Movie GetMovieByIndex(ArrayList newlist,int index)
        {
            Movie movie = (Movie)newlist[index];
            return movie;
        }
    }
}
