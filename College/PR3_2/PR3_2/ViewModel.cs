using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;


namespace PR3_2
{
    internal class ViewModel : INotifyPropertyChanged
    {

        private BitmapImage _image;
        private int _columns;
        private int _rows;
        private PuzzlePiece _selectedPiece;

        public ObservableCollection<PuzzlePiece> PuzzlePieces { get; set; }

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public int Columns{
            get { return _columns; }
            set
            {
                _columns = value;
                OnPropertyChanged("Columns");
            }
        }

        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                OnPropertyChanged("Rows");
            }
        }

        public PuzzlePiece SelectedPiece 
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                OnPropertyChanged("SelectedPiece");
            }
        }

        public ViewModel() 
        {
            PuzzlePieces = new ObservableCollection<PuzzlePiece>();
        }

        private void btnCreatePuzzle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this._rows = int.Parse(txtRows.Text);
                this._columns = int.Parse(txtColumns.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid numbers for rows and columns.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CroppedBitmap[,] pieces = new CroppedBitmap[this._rows, this._columns];
            for (int i = 0; i < this._rows; i++)
            {
                for (int j = 0; j < this._columns; j++)
                {
                    pieces[i, j] = new CroppedBitmap(this._image, new Int32Rect(j * 100, i * 100, 100, 100));
                    this.PuzzlePieces.Add(new PuzzlePiece(i, j, i, j, pieces[i, j]));
                }
            }
        }

        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            foreach (PuzzlePiece item in PuzzlePieces)
            {
                item.CurrentRow = new Random().Next(0, this._rows);
                item.CurrentColumn = new Random().Next(0, this._columns);
            }
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog() == true)
            {
                this._image = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
