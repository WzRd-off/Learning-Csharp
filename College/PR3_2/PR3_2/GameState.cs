using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3_2
{
    internal class GameState
    {
        public string ImagePath { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Moves { get; set; }
        public List<PieceState> Pieces { get; set; } = new List<PieceState>();

        public GameState(string imagePath, int rows, int columns, int moves, List<PieceState> pieces)
        {
            ImagePath = imagePath;
            Rows = rows;
            Columns = columns;
            Moves = moves;
            Pieces = pieces;
        }

    }

    public class PieceState
    {
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }
        public int CorrectRow { get; set; }
        public int CorrectColumn { get; set; }
    }
}
