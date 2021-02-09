namespace Chess.Game.Commons
{
    using System;

    public class Position
    {
        public Position(int row, int col)
        {
            this.Col = col;
            this.Row = row;
        }

        public Position()
        {

        }

        public int Col { get; set; }

        public int Row { get; set; }

        public override string ToString() 
        {
            return "{" + this.Col + ", " + this.Row + "}";
        }
    }
}
