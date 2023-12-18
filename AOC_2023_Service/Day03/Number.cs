
namespace AOC_2023_Service.Day03
{
    public class Number
    {
        private readonly Coordinate startingCoord;
        private readonly Coordinate endingCoord;

        public int Val { get; private set; }

        public Number(int num, Coordinate startingCoord, Coordinate numberEndingCoord)
        {
            this.startingCoord = startingCoord;
            this.endingCoord = numberEndingCoord;
            this.Val = num;
        }

        public Number(int num, Coordinate coordinate) : this(num, coordinate, coordinate)
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = obj as Number;

            return (other.Val == this.Val) && (other.startingCoord.Equals(this.startingCoord)) && (other.endingCoord.Equals(this.endingCoord));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; // Choose a prime or any number you prefer as the initial value
                hash = hash * 23 + Val.GetHashCode();
                hash = hash * 23 + (startingCoord != null ? startingCoord.GetHashCode() : 0);
                return hash;
            }
        }

        public bool OverLaps(Coordinate coord)
        {
            return startingCoord.X == coord.X && startingCoord.Y <= coord.Y && endingCoord.Y >= coord.Y;
        }
    }
}
