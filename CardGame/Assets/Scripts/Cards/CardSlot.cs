using System;
using System.Collections.Generic;

namespace Assets.Scripts.Cards
{
    public class CardSlot
    {
        //Class help to Add card on slot (Player side).
        public event EventHandler OnItemListChanged;

        private List<Card> cardList;

        public CardSlot()
        {
            cardList = new List<Card>();
        }

        // Add card event
        public void AddItem(Card item)
        {
            cardList.Add(item);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }

        // Remove Card event.
        public void RemoveItem(Card item)
        {
            cardList.Remove(item);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }

        public List<Card> GetItemList()
        {
            return cardList;
        }
    }
}