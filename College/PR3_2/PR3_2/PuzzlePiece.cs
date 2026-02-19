using System.ComponentModel;
using System.Windows.Media;

namespace PR3_2
{
    public class PuzzlePiece : INotifyPropertyChanged
    {
        private int _currentRow;
        private int _currentColumn;
        private double _x;
        private double _y;
        private int _zIndex;

        public int CurrentRow
        {
            get => _currentRow;
            set
            {
                _currentRow = value;
                OnPropertyChanged(nameof(CurrentRow));
            }
        }

        public int CurrentColumn
        {
            get => _currentColumn;
            set
            {
                _currentColumn = value;
                OnPropertyChanged(nameof(CurrentColumn));
            }
        }

        public int CorrectRow { get; }
        public int CorrectColumn { get; }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        public double Width { get; }
        public double Height { get; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                OnPropertyChanged(nameof(ZIndex));
            }
        }

        public ImageSource Image { get; }

        public PuzzlePiece(int correctRow, int correctColumn, ImageSource image, double width, double height)
        {
            CorrectRow = correctRow;
            CorrectColumn = correctColumn;
            CurrentRow = correctRow;
            CurrentColumn = correctColumn;
            Image = image;
            Width = width;
            Height = height;
            X = CurrentColumn * width;
            Y = CurrentRow * height;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}