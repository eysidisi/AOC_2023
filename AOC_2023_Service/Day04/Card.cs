namespace AOC_2023_Service.Day04;

public class Card
{
    private List<int> winningNumbers;
    private List<int> numbersIHave;
    public int Id { get; private set; }

    public Card(List<int> winningNumbers, List<int> numbersIHave, int cardId = 0)
    {
        this.winningNumbers = winningNumbers;
        this.numbersIHave = numbersIHave;
        Id = cardId;
    }

    public int CalculatePoints()
    {
        int numberOfMatches = CalculateNumberOfMatches();
        return (int)MathF.Pow(2, numberOfMatches - 1);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Card otherCard = (Card)obj;

        return winningNumbers.SequenceEqual(otherCard.winningNumbers) &&
               numbersIHave.SequenceEqual(otherCard.numbersIHave);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var item in winningNumbers)
            {
                hash = hash * 23 + item.GetHashCode();
            }
            foreach (var item in numbersIHave)
            {
                hash = hash * 23 + item.GetHashCode();
            }
            return hash;
        }
    }

    private int CalculateNumberOfMatches()
    {
        int result = 0;

        foreach (var numberIHave in numbersIHave)
        {
            if (winningNumbers.Contains(numberIHave))
            {
                result++;
            }
        }

        return result;
    }

    public List<int> CalculateWonCardIds()
    {
        var score = CalculateNumberOfMatches();

        var result = new List<int>();

        for (int i = 1; i <= score; i++)
        {
            result.Add(Id + i);
        }

        return result;
    }
}