using System;

namespace Testare_Proiect2
{
    public class PlayingCard
    {
        public enum Suit { Club, Diamond, Heart, Spade }///Enum>Static deoarece folosesc un set de constante
        public enum Type { Number, Jack, Queen, King, Ace }

        public Suit CardSuit { get; private set; }
        public Type CardType { get; private set; }
        public int Value { get; private set; }    
        public string ImagePath { get; private set; }

        public PlayingCard(Suit suit, Type type, int value)
        {
            CardSuit = suit;
            CardType = type;
            Value = value;
            ImagePath = GetImagePath();
        }

        private string GetImagePath()
        {
            string suit = CardSuit.ToString();
            string valueStr;

            switch (CardType)
            {
                case Type.Ace:
                    valueStr = "Ace"; 
                    break;
                case Type.Jack: 
                    valueStr = "Jack"; 
                    break;
                case Type.Queen:
                    valueStr = "Queen"; 
                    break;
                case Type.King:
                    valueStr = "King"; 
                    break;
                case Type.Number: 
                    valueStr = Value.ToString(); 
                    break;
                default:
                    valueStr = Value.ToString(); 
                    break;
            }

            return $"imagini/{valueStr}_{suit}.jpg";
        }
    }
}
