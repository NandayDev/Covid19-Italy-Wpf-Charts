using CovidCharts.Data;
using CovidCharts.Views;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CovidCharts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
            DataContext = this;
            Loaded += async delegate
            {
                await DataRepository.Instance.Initialize();
                loadingIndicator.Visibility = Visibility.Collapsed;
                mainGrid.Visibility = Visibility.Visible;
                ChangePage(CovidPage.MAIN);
            };
        }

        internal static MainWindow Instance { get; private set; }

        private List<TransitionerSlide> _slides;


        public List<TransitionerSlide> Slides
        {
            get
            {
                if (_slides == null)
                {
                    _slides = new List<TransitionerSlide>
                    {
                        // Main user control //
                        new TransitionerSlide{ Content = new MainPage() },
                        // Andamento nazionale //
                        new TransitionerSlide(),
                        // Province //
                        new TransitionerSlide()
                    };
                    _slides.ForEach(s =>
                    {
                        s.OpeningEffect = new TransitionEffect(TransitionEffectKind.SlideInFromRight, TimeSpan.FromMilliseconds(500));
                    });

                }
                return _slides;
            }
        }

        private int _selectedSlide = -1;
        public int SelectedSlide
        {
            get => _selectedSlide;
            set => ChangeProperty(ref _selectedSlide, value);
        }

        internal void ChangePage(CovidPage page)
        {
            switch (page)
            {
                case CovidPage.MAIN:
                    SelectedSlide = 0;
                    backControlPanel.Visibility = Visibility.Hidden;
                    break;
                case CovidPage.ANDAMENTO_NAZIONALE:
                    Slides[1].Content = new AndamentoNazionalePage();
                    SelectedSlide = 1;
                    backControlPanel.Visibility = Visibility.Visible;
                    break;
                case CovidPage.PROVINCE:
                    Slides[2].Content = new ProvincePage();
                    SelectedSlide = 2;
                    backControlPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal void ChangeProperty<T>(ref T privateField, T value, [CallerMemberName] string propertyName = "")
        {
            privateField = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GoBack(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangePage(CovidPage.MAIN);
        }

        private void Exit(object sender, System.Windows.Input.MouseButtonEventArgs e) => Close();
    }

    internal enum CovidPage
    {
        MAIN,
        ANDAMENTO_NAZIONALE,
        PROVINCE
    }
}
