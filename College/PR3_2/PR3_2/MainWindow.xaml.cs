using System;
using System.Linq; // Додано для пошуку елементів (FirstOrDefault)
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace PR3_2
{
    public partial class MainWindow : Window
    {
        private bool _isDragging = false;
        private Point _clickPosition;
        private PuzzlePiece _draggedPiece;
        private ViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
        }

        private void Piece_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is PuzzlePiece piece)
            {
                _isDragging = true;
                _draggedPiece = piece;
                _draggedPiece.ZIndex = 100;

                _clickPosition = e.GetPosition(element);
                element.CaptureMouse();
            }
        }

        private void Piece_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _draggedPiece != null && sender is FrameworkElement element)
            {
                var parent = VisualTreeHelper.GetParent(element);
                while (!(parent is Canvas) && parent != null)
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is Canvas canvas)
                {
                    Point mousePos = e.GetPosition(canvas);
                    _draggedPiece.X = mousePos.X - _clickPosition.X;
                    _draggedPiece.Y = mousePos.Y - _clickPosition.Y;
                }
            }
        }

        private void Piece_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging && _draggedPiece != null && sender is FrameworkElement element)
            {
                _isDragging = false;
                element.ReleaseMouseCapture();
                _draggedPiece.ZIndex = 0;

                int targetCol = (int)Math.Round(_draggedPiece.X / _draggedPiece.Width);
                int targetRow = (int)Math.Round(_draggedPiece.Y / _draggedPiece.Height);

                targetCol = Math.Max(0, Math.Min(_viewModel.Columns - 1, targetCol));
                targetRow = Math.Max(0, Math.Min(_viewModel.Rows - 1, targetRow));

                int oldRow = _draggedPiece.CurrentRow;
                int oldCol = _draggedPiece.CurrentColumn;

                PuzzlePiece pieceAtTarget = _viewModel.PuzzlePieces.FirstOrDefault(p =>
                    p.CurrentRow == targetRow &&
                    p.CurrentColumn == targetCol &&
                    p != _draggedPiece);

                if (pieceAtTarget != null)
                {
                    pieceAtTarget.CurrentRow = oldRow;
                    pieceAtTarget.CurrentColumn = oldCol;
                    pieceAtTarget.X = oldCol * pieceAtTarget.Width;
                    pieceAtTarget.Y = oldRow * pieceAtTarget.Height;
                }

                _draggedPiece.CurrentColumn = targetCol;
                _draggedPiece.CurrentRow = targetRow;

                _draggedPiece.X = targetCol * _draggedPiece.Width;
                _draggedPiece.Y = targetRow * _draggedPiece.Height;

                _viewModel.Moves++;
                _viewModel.CheckWinCondition();

                _draggedPiece = null;
            }
        }
    }
}