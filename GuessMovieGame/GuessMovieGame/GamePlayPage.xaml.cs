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
    public partial class GamePlayPage : ContentPage
    {
        readonly char[] movieLetters;
        readonly List<Label> labelList;
        private int winCount = 0;
        public GamePlayPage(Movie movie, bool type)
        {
            InitializeComponent();

            filmDescription.Text = movie.HelpDiscription;
            movieLetters = movie.Name.ToCharArray();

            labelList = new List<Label>();
            for (int i = 0; i < movieLetters.Length; i++)
            {
                var label = new Label { Text = movieLetters[i].ToString(), FontSize = 18, IsVisible = false, TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
                this.Content = mainLayout;
                letterLayout.Children.Add(label);
                labelList.Add(label);
            }

        }
        
        private async void entryLetter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            for (int i = 0; i < movieLetters.Length; i++)
            {
                if (e.NewTextValue.ToLower() == movieLetters[i].ToString().ToLower())
                {
                    labelList[i].IsVisible = true;
                    winCount++;
                }
            }
            
            int attemptsCount = Convert.ToInt32(attemptsQuantity.Text);


            if (attemptsCount != 0 && attemptsQuantity.Text != null)
            {
                attemptsCount--;
                attemptsQuantity.Text = attemptsCount.ToString();
            }
            if (attemptsCount == 0)
            {
                await DisplayAlert("Печалька", "Ты проиграл!", "OK");
                entryLetter.IsReadOnly = true;

                AddChoseButtons();

            }
            if (attemptsCount != 0 && winCount == labelList.Count)
            {
                await DisplayAlert("Ура", "Ты победил!", "OK");
                entryLetter.IsReadOnly = true;

                AddChoseButtons();
            }

        }

        public async void CreateMovieButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateMoviePage());
        }
        public async void ToMainPageButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void AddChoseButtons()
        {
            var button1 = new Button
            {
                Text = "На главную страницу",
                FontSize = 18,
                TextColor = Color.Black,
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            button1.Clicked += ToMainPageButton_Click;
            this.Content = mainLayout;
            mainLayout.Children.Add(button1);

            var button2 = new Button
            {
                Text = "Добавить фильм",
                FontSize = 18,
                TextColor = Color.Black,
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            button2.Clicked += CreateMovieButton_Click;
            this.Content = mainLayout;
            mainLayout.Children.Add(button2);
        }
    }
}