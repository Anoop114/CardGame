#region Reference
//Added to SafeArea under canvas.
#endregion
using Assets.Scripts.Cards;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UI_Slot : MonoBehaviour
    {
        #region Variable
        //public
        public CardSlot inventory;
        public int slotIndex = 0;
        public List<RectTransform> cardSlotTemplates;
        
        //Private
        [SerializeField] private RectTransform cardSlotContainer;
        [SerializeField] private RectTransform cardSlotTemplate;
        #endregion

        #region UnityFunction
        private void Awake()
        {
            cardSlotTemplates = new List<RectTransform>();
            CreatePoolCard();
        }
        #endregion

        #region MadeFunction

        // create 10 virtual card that is used in game.
        private void CreatePoolCard()
        {
            for(int i = 0; i < 10; i++)
            {
                RectTransform cardTemplate = Instantiate(cardSlotTemplate);
                cardTemplate.SetParent(cardSlotContainer);
                cardSlotTemplates.Add(cardTemplate);    
            }
        }

        // Add card call
        public void SetInventory(CardSlot inventory)
        {
            this.inventory = inventory;

            inventory.OnItemListChanged += Inventory_OnItemListChanged;

            RefreshInventoryItems();
        }

        // Event call on every 3 seconds to add card in player deck.
        private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
        {
            RefreshInventoryItems();
        }
        
        // Active card in player deck. 
        private void RefreshInventoryItems()
        {
            foreach (Card cardDt in inventory.GetItemList())
            {
                if (slotIndex < 5)
                {
                    int tempSlot = 0;
                    foreach(RectTransform cardTemplate in cardSlotTemplates)
                    {
                        if (!cardTemplate.gameObject.activeSelf)
                        {
                            Image image = cardTemplate.GetComponent<Image>();
                            cardTemplate.GetComponent<CardTemplate>().card.cardType = cardDt.cardType;
                            image.sprite = cardDt.GetSprite();
                            cardTemplate.gameObject.SetActive(true);

                            break;
                        }
                        tempSlot++;
                    }
                }
                break;
            }

            if (slotIndex == 5) return;
            slotIndex ++;
        }
        #endregion
    }
}