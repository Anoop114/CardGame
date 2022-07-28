#region Reference
//Added to SafeArea under canvas.
#endregion
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    #region Variable
    //private
    [SerializeField]RectTransform rectTransform;
    
    Rect safeArea;
    Vector2 minAncor;
    Vector2 maxAncor;
    #endregion

    // get the screen size of Device and based on safe area place the Screen.
    private void Awake()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        safeArea = Screen.safeArea;
        minAncor = safeArea.position;
        maxAncor = minAncor + safeArea.size;
            
        minAncor.x /= Screen.width;
        minAncor.y /= Screen.height;
        maxAncor.x /= Screen.width;
        maxAncor.y /= Screen.height;

        rectTransform.anchorMax = maxAncor;
        rectTransform.anchorMin = minAncor;
    }
}
