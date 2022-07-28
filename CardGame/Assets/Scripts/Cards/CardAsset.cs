#region Reference
// Added to Manager gameObject.
#endregion
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class CardAsset : MonoBehaviour
    {
        // create singleton so every one can access without any object creation.
        #region Variables

        // set all card sprites

        //public
        public Sprite card1;
        public Sprite card2;
        public Sprite card3;
        public Sprite card4;
        public Sprite card5;
        public Sprite card6;
        public Sprite card7;
        public Sprite card8;
        public Sprite card9;
        public Sprite card10;
        #endregion
        
        public static CardAsset Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        
        
    }
}