#region Reference
//Added to (DropItem,DropItem1,DropItem2) under DropingPlace_Player that in canvas.
#endregion

using Assets.Scripts.Cards;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrop : MonoBehaviour, IDropHandler
{
    #region Variable
    //private
    
    [SerializeField] private UI_Slot cardSlot;
    [SerializeField] private UI_Slot_List cardAddList;
    
    RectTransform cardRect;
    Card currentCardData;
    #endregion

    /// <summary>
    /// If card is Placed by Player then the card start fire.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            cardRect = eventData.pointerDrag.GetComponent<RectTransform>();
            
            //set position to the position slot
            cardRect.anchorMin = Vector2.one / 2f;
            cardRect.anchorMax = Vector2.one / 2f;
            
            cardRect.SetParent(GetComponent<RectTransform>().parent);
            cardRect.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
            currentCardData = cardRect.GetComponent<CardTemplate>().card;

            // bullet fire start
            cardRect.GetComponent<BulletAndHealth>().enabled = true;

            // add in pool and remove from previous pool.
            cardSlot.inventory.RemoveItem(currentCardData);
            cardSlot.cardSlotTemplates.Remove(cardRect);
            
            cardAddList.AddTransform(cardRect);
            
            cardSlot.slotIndex--;
        }
    }
}
