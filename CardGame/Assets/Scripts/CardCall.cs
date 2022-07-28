#region Reference
// Add this to Manager gameObject.
#endregion
using Assets.Scripts.Cards;
using Assets.Scripts.UI;
using UnityEngine;
namespace Assets.Scripts
{
    public class CardCall : MonoBehaviour
    {
        #region Variables
        //public
        public UI_Slot cardNumber;
        public Card cardData;
        
        //private
        private CardSlot card;
        private bool IsCallComplete;
        [SerializeField] private UI_Slot slot;
        #endregion

        #region UnityFunctions
        // Initialize the variables.
        void Start()
        {
            card = new CardSlot();
            slot.SetInventory(card);
            IsCallComplete = true;
        }
        
        //create virtual card in player side.
        void FixedUpdate()
        {
            if (cardNumber.slotIndex < 5 && IsCallComplete)
            {
                IsCallComplete = false;
                CallCard();
            }
        }
        #endregion

        #region MadeFunctions
        // Creating Card every 3 seconds.
        private void CallCard()
        { 
            Invoke(nameof(CallCard3Seconds), 3);
        }
        
        private void CallCard3Seconds()
        {
            cardData.cardType = (Card.CardType)Random.Range(0, 10);
            card.AddItem(cardData);
            CancelInvoke(nameof(CallCard3Seconds));
            IsCallComplete = true;
        }
        #endregion
    }
}