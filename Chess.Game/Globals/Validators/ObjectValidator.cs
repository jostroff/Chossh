namespace Chess.Game.Globals.Validators
{
    using Chess.Game.Commons;
    using System;

    public static class ObjectValidator
    {
        public static void CheckIfObjectIsValid(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new NullReferenceException(errorMessage);
            }
        }

        public static void CheckIfPositionIsValid(Position position, string errorMessage)
        {
            if (position.Row < 0 || position.Row > 7)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (position.Col < 0 || position.Col > 7)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
    }
}
