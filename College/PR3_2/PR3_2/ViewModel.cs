using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PR3_2
{
    public class ViewModel : INotifyPropertyChanged
    {
        private BitmapImage _image;
        private int _columns = 3;
        private int _rows = 3;
        private int _moves = 0;

        public ObservableCollection<PuzzlePiece> PuzzlePieces { get; set; }

        public BitmapImage Image
        {
            get => _image;
            set { _image = value; OnPropertyChanged(nameof(Image)); }
        }

        public int Columns
        {
            get => _columns;
            set { _columns = value; OnPropertyChanged(nameof(Columns)); }
        }

        public int Rows
        {
            get => _rows;
            set { _rows = value; OnPropertyChanged(nameof(Rows)); }
        }

        public int Moves
        {
            get => _moves;
            set { _moves = value; OnPropertyChanged(nameof(Moves)); }
        }

        public ICommand SelectImageCommand { get; }
        public ICommand CreatePuzzleCommand { get; }
        public ICommand ShuffleCommand { get; }

        public ViewModel()
        {
            PuzzlePieces = new ObservableCollection<PuzzlePiece>();
            SelectImageCommand = new RelayCommand(SelectImage);
            CreatePuzzleCommand = new RelayCommand(CreatePuzzle, o => Image != null);
            ShuffleCommand = new RelayCommand(Shuffle, o => PuzzlePieces.Count > 0);
        }

        private void SelectImage(object obj)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
            if (ofd.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(ofd.FileName));
                Image.CacheOption = BitmapCacheOption.OnLoad;
                PuzzlePieces.Clear();
                Moves = 0;
            }
        }

        private void CreatePuzzle(object obj)
        {
            if (Image == null || Rows <= 0 || Columns <= 0) return;

            PuzzlePieces.Clear();
            Moves = 0;

            int piecePixelWidth = Image.PixelWidth / Columns;
            int piecePixelHeight = Image.PixelHeight / Rows;

            double displayWidth = 100;
            double displayHeight = 100;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Int32Rect rect = new Int32Rect(j * piecePixelWidth, i * piecePixelHeight, piecePixelWidth, piecePixelHeight);
                    CroppedBitmap cropped = new CroppedBitmap(Image, rect);
                    PuzzlePieces.Add(new PuzzlePiece(i, j, cropped, displayWidth, displayHeight));
                }
            }
        }

        private void Shuffle(object obj)
        {
            Random rnd = new Random();
            Moves = 0;

            var positions = new List<(int r, int c)>();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    positions.Add((r, c));
                }
            }

            int n = positions.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                var value = positions[k];
                positions[k] = positions[n];
                positions[n] = value;
            }

            int i = 0;
            foreach (var piece in PuzzlePieces)
            {
                if (i >= positions.Count) break;

                piece.CurrentRow = positions[i].r;
                piece.CurrentColumn = positions[i].c;

                piece.X = positions[i].c * piece.Width;
                piece.Y = positions[i].r * piece.Height;
                i++;
            }
        }

        public void CheckWinCondition()
        {
            bool won = true;
            foreach (var piece in PuzzlePieces)
            {
                if (piece.CurrentRow != piece.CorrectRow || piece.CurrentColumn != piece.CorrectColumn)
                {
                    won = false;
                    break;
                }
            }

            if (won && PuzzlePieces.Count > 0)
            {
                MessageBox.Show($"Вітаю! Ви зібрали пазл за {Moves} кроків.", "Перемога!", MessageBoxButton.OK, MessageBoxImage.Information);
                Moves = 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}