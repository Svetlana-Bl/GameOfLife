namespace GameOfLife.Model
{
    public class Field
    {
        private int fieldSize;

        public int FieldSize
        {
            get
            {
                return fieldSize;
            }
            set
            {
                if(value<3)
                    fieldSize = 3;
                else if(value>20) fieldSize = 30;
                else fieldSize = value;
            }
        }
        public bool[,] UniverseField { get; set; }
    }
}