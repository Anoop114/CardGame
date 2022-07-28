#region Reference
//Added to DropingPlace_Player under canvas.
#endregion
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UI_Slot_List : MonoBehaviour
    {
        #region Variable
        //private
        [SerializeField] private RectTransform slotRectTransform;
        [SerializeField] private UI_Slot slot;
        private List<RectTransform> cardTransform;
        #endregion

        #region UnityFunction
        // initialize list
        void Start()
        {
            cardTransform = new List<RectTransform>();
        }
        #endregion
        
        #region MadeFunctions

        // Add card in slot
        public void AddTransform(RectTransform card)
        {
            cardTransform.Add(card);
        }
        // card die and remove from slot.
        public void RemoveTransform(RectTransform card)
        {
            cardTransform.Remove(card);
            card.SetParent(slotRectTransform);
            slot.cardSlotTemplates.Add(card);
        }
        #endregion
    }
}