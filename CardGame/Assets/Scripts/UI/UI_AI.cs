#region Reference
//Added to SafeArea under canvas.
#endregion
using Assets.Scripts.Cards;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UI_AI : MonoBehaviour
    {
        #region variables
        //public
        public Card cardCreator;

        public int slotIndex = 0;
        public List<RectTransform> cardSlotPlaced;
        
        //Private
        [SerializeField] private RectTransform cardSlotContainer;
        [SerializeField] private RectTransform cardSlotTemplate;
        [SerializeField] private List<RectTransform> cardSlotTemplates;
        [SerializeField] private RectTransform[] cardAISlot;
        
        private bool slot1,slot2,slot3,IsCallComplete,IsPlaceCard;
        #endregion

        #region UnityFunctions
        // Initialize
        private void Awake()
        {
            cardCreator = new Card();
            cardSlotTemplates = new List<RectTransform>();
            cardSlotPlaced = new List<RectTransform>();
            slot1 = slot2 = slot3 = IsCallComplete = IsPlaceCard = true;
            CreatePoolCard();
        }
        
        // Check slot and Deck to create and place the card
        private void FixedUpdate()
        {

            if (slotIndex < 4 && IsCallComplete)
            {
                IsCallComplete = false;
                CallCard();
            }
            if (IsPlaceCard)
            {
                IsPlaceCard = false;
                Invoke(nameof(PlaceCard), 4);
            }
        }
        #endregion

        #region MadeFunctions

        // Check the available slot and Place the current card on that slot
        private void PlaceCard()
        {
            if (slot1)
            {
                slot1 = false;
                PlaceCurrentCard(0);
            }
            else if (slot2)
            {
                slot2 = false;
                PlaceCurrentCard(1);
            }
            else if (slot3)
            {
                slot3 = false;
                PlaceCurrentCard(2);
            }
        }

        // Create card in Every 3 seconds
        private void CallCard()
        {
            Invoke(nameof(RefreshInventoryItems), 3);
        }

        // Placing the card on the slot that is called
        private void PlaceCurrentCard(int slot)
        {
            foreach (RectTransform cardTemplate in cardSlotTemplates)
            {
                if (cardTemplate.gameObject.activeSelf)
                {
                    // placing the card
                    cardTemplate.gameObject.SetActive(false);
                    cardTemplate.SetParent(cardAISlot[slot].GetComponent<RectTransform>().parent);
                    cardTemplate.anchorMin = Vector2.one / 2f;
                    cardTemplate.anchorMax = Vector2.one / 2f;
                    cardTemplate.anchoredPosition = cardAISlot[slot].GetComponent<RectTransform>().anchoredPosition;

                    // bullet fire is active
                    BulletAndHealth bulletHelth = cardTemplate.gameObject.GetComponent<BulletAndHealth>();
                    bulletHelth.Health.gameObject.SetActive(true);
                    bulletHelth.enabled = true;

                    cardTemplate.gameObject.GetComponent<AiIndex>().Index = slot;
                    cardSlotTemplates.Remove(cardTemplate);
                    cardSlotPlaced.Add(cardTemplate);
                    
                    slotIndex--;
                    
                    cardTemplate.gameObject.SetActive(true);
                    break;
                }
            }
            if (slot == 0)
            {
                slot1 = false;
            }
            else if (slot == 1)
            {
                slot2 = false;
            }
            else if (slot == 2)
            {
                slot3 = false;
            }
            CancelInvoke(nameof(PlaceCard));
            IsPlaceCard = true;

        }

        // Create 10 virtual cards that is going to used in game.
        private void CreatePoolCard()
        {

            for (int i = 0; i < 10; i++)
            {
                RectTransform cardTemplate = Instantiate(cardSlotTemplate);
                cardTemplate.SetParent(cardSlotContainer);
                cardSlotTemplates.Add(cardTemplate);
            }
        }
        
        // Place the card in Deck
        private void RefreshInventoryItems()
        {
            if (slotIndex < 4)
            {
                cardCreator.cardType = (Card.CardType)Random.Range(0, 10);
                foreach (Transform cardTemplate in cardSlotTemplates)
                {
                    if (!cardTemplate.gameObject.activeSelf)
                    {
                        Image image = cardTemplate.GetComponent<Image>();
                        image.sprite = cardCreator.GetSprite();
                        
                        cardTemplate.gameObject.SetActive(true);
                        break;
                    }
                }
                
            }
            IsCallComplete = true;
            if (slotIndex == 4) return;
            slotIndex++;
        }
    
        // if Card health is get below 0 it get back to deck.
        public void RemoveSlot(RectTransform card,int slot)
        {
            card.gameObject.SetActive(false);
            cardSlotPlaced.Remove(card);
            card.SetParent(cardSlotTemplates[cardSlotTemplates.Count - 1].parent);
            cardSlotTemplates.Add(card);
            if (slot == 0)
            {
                slot1 = true;
            }else if(slot == 1)
            {
                slot2 = true;
            }
            else if(slot == 2)
            {
                slot3 = true;
            }
            Invoke(nameof(PlaceCard),0);
            //PlaceCurrentCard(slot);
            slotIndex--;
        }
        #endregion
    }

}