using System;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    // Card template by used this the card is created.
    [Serializable]
    public class Card
    {
        // Enum card state
        public enum CardType
        {
            Card1,
            Card2,
            Card3, 
            Card4, 
            Card5, 
            Card6, 
            Card7, 
            Card8, 
            Card9,
            Card10
        }

        public CardType cardType;
        
        // return sprite of selected card.
        public Sprite GetSprite()
        {
            switch (cardType)
            {
                default:
                case CardType.Card1:    return CardAsset.Instance.card1;
                case CardType.Card2:    return CardAsset.Instance.card2;
                case CardType.Card3:    return CardAsset.Instance.card3;
                case CardType.Card4:    return CardAsset.Instance.card4;
                case CardType.Card5:    return CardAsset.Instance.card5;
                case CardType.Card6:    return CardAsset.Instance.card6;
                case CardType.Card7:    return CardAsset.Instance.card7;
                case CardType.Card8:    return CardAsset.Instance.card8;
                case CardType.Card9:    return CardAsset.Instance.card9;
                case CardType.Card10:   return CardAsset.Instance.card10;
            }
        }
    }
}