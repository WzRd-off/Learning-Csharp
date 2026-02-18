using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PR3_2
{
    internal class PuzzlePiece: INotifyPropertyChanged
    {
        private int _currentRow;
        private int _currentColumn;
        private int _correctRow;
        private int _correctColumn;
        private ImageSource _image;

        public PuzzlePiece(int currentRow, int currentColumn, int correctRow, int correctColumn, ImageSource image)
        {
            this._currentRow = currentRow;
            this._currentColumn = currentColumn;
            this._correctRow = correctRow;
            this._correctColumn = correctColumn;
            this._image = image;
        }

        public int CurrentRow 
        { 
            get => _currentRow;
            set 
            {
                _currentRow = value;
                OnPropertyChanged("CurrentRow");
            } 
        }
        public int CurrentColumn 
        { 
            get => _currentColumn;
            set 
            {
                _currentColumn = value;
                OnPropertyChanged("CurrentColumn");
            }  
        }
        public int CorrectRow { get => _correctRow; }
        public int CorrectColumn { get => _correctColumn; }
        public ImageSource Image { get => _image; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
