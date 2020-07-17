namespace SnakesAndLeaders.Console
{
    public class Field
    {
        public int Index { get; }

        public Field(int index, bool isFinal)
        {
            Index = index;
            IsFinal = isFinal;
        }

        public bool IsFinal { get; }


    }
}