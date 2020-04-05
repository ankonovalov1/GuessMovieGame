using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessMovieGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMoviePage : ContentPage
    {        
        public CreateMoviePage()
        {
            InitializeComponent();
        }

        public async void AddMovieButton_Clicked(object sender, EventArgs e)
        {
            if(addMovieName.Text != null && addMovieDesc.Text != null)
            {
                Movie newMovie = new Movie(addMovieName.Text, addMovieDesc.Text);
                if (RusMovieCheckBox.IsChecked && InterMovieCheckBox.IsChecked == false)
                {
                    RussianMovieList.RussianMoviesList.Add(newMovie);
                    await DisplayAlert("Ура", "Кинчик добавлен", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                if (InterMovieCheckBox.IsChecked && RusMovieCheckBox.IsChecked == false)
                {
                    InternationalMovieList.InternationalMoviesList.Add(newMovie);
                    await DisplayAlert("Ура", "Кинчик добавлен", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                if(RusMovieCheckBox.IsChecked && InterMovieCheckBox.IsChecked)
                {
                    await DisplayAlert("Внимание", "Выберите одну категорию", "OK");
                }
                if (RusMovieCheckBox.IsChecked == false && InterMovieCheckBox.IsChecked == false)
                {
                    await DisplayAlert("Внимание", "Выберите хоть какую-то категорию", "OK");
                }
            }
            else
            {
                await DisplayAlert("Внимание", "Добавьте все данные", "OK");
            }

        }

    }
}