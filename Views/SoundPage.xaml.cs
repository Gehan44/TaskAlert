using Plugin.Maui.Audio;
using System;
using System.Collections.ObjectModel;
using TaskAlert.Models;
namespace TaskAlert.Views
{
    public partial class SoundPage : ContentPage
    {
        private ObservableCollection<Sound> MySound { get => CreateSound(); }
        private string currentSongName = string.Empty;
        int count = 0;


        public SoundPage()
        {
            InitializeComponent();
            listSound.ItemsSource = MySound;
        }

        private ObservableCollection<Sound> CreateSound()
        {
            return new ObservableCollection<Sound>
            {
                new Sound {Gname = "E** T*********" , Sname = "Eco Technology", Sraw = "ecotech.mp4" },
                new Sound {Gname = "L***** F***" , Sname = "Little Fish", Sraw = "fish.mp4" },
                new Sound {Gname = "T** M******* o* I****" , Sname = "The Movement of India", Sraw = "india.mp4" },
                new Sound {Gname = "I*********** M***" , Sname = "Interstellar Mood", Sraw = "mood.mp4" },
                new Sound {Gname = "P***** o* R****" , Sname = "Palace of Roses", Sraw = "roses.mp4" },
                new Sound {Gname = "S***** W***" , Sname = "Squirm Worm", Sraw = "track.mp4" }
            };
        }

        public async void listSound_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sound selectS = (Sound)e.SelectedItem;
            currentSongName = selectS.Sname;
            PlayAudio(selectS.Sraw);
            string userGuess = await DisplayPromptAsync("Guess the Song", "Enter your guess:");
            if (string.IsNullOrEmpty(userGuess))
            {
                StopAudio(selectS.Sraw);
                return;
            }

            if (userGuess.Equals(currentSongName, StringComparison.OrdinalIgnoreCase))
            {
                count++;
                CounterBtn.Text = $"Score:{count}";
                StopAudio(selectS.Sraw);
                await DisplayAlert("Correct Guess", "Congratulations! Your guess is correct.", "OK");
            }
            else
            {
                StopAudio(selectS.Sraw);
                await DisplayAlert("Incorrect Guess", "Sorry, your guess is incorrect.", "OK");
            }
        }

        async void PlayAudio(string sraw)
        {
            var audi = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sraw));
            audi.Play();
        }

        private void ButtonS_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public async void StopAudio(string sraw)
        {
            var audi = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sraw));
            audi.Stop();
        }
    }
}
