using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testare_Proiect2
{
    public class Dealer : Participant
    {
        public override int CalculateScore()
        {
            int score = 0;
            int aceCount = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                var card = hand[i];
                score = score + card.Value;
                if (card.CardType == PlayingCard.Type.Ace)
                    aceCount++;
            }
            while (aceCount > 0 && score <= 11)
            {
                score = score + 10;
                aceCount--;
            }

            return score;
        }
    }
}
