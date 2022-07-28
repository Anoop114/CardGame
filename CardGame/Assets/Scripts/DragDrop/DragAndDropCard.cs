#region Reference
//Added to Template under playerpanal that in canvas.
#endregion
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.DragDrop
{
    public class DragAndDropCard : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        #region Variable
        // private
        [SerializeField] private Canvas canvas;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        #endregion

        // Initialize
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        //on card is Start drag then.
        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
        // on Dragging time
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        // on drag complete user leave the card.
        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            
        }
    }
}