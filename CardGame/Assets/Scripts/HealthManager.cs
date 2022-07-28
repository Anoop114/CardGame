#region Reference
// Added to canvas child gameObjects(PlayePanal,AI,Template,Ai_Template)
#endregion
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI;
using Assets.Scripts.Cards;
namespace Assets.Scripts
{
    public class HealthManager : MonoBehaviour
    {
        #region Variables
        // public
        
        public GameObject WinLoose;
        
        public GameManager gameManager;
        public UI_Slot_List playerCardList;
        public UI_AI AICardList;
        
        public TMP_Text WinLooseText;
        public Slider HealthBar;
        
        public int healthUnit;
        
        public bool Playerbase, EnemyBase,Player,Enemy;
        
        // private
        RectTransform card;

        private int healthData;
        #endregion

        #region UnityFunctions
        private void Awake()
        {
            card = GetComponent<RectTransform>();
            healthData = healthUnit;
        }

        private void OnEnable()
        {
            HealthBar.maxValue = healthUnit;
            HealthBar.value = healthUnit;
        }
        #endregion

        #region MadeFunctions

        // Check Health for various game objects.
        public void ChangeHealth(int damageRate)
        {
            healthUnit -= damageRate;
            HealthBar.value = healthUnit;
            if(healthUnit < 0)
            {
                if (EnemyBase)
                {
                    //enemy die
                    WinLooseText.text = "You Win";
                    WinLooseText.color = Color.green;
                    WinLoose.SetActive(true);
                    gameManager.PauseGame();
                }
                else if (Playerbase)
                {
                    //player die
                    WinLooseText.text = "You Loose";
                    WinLooseText.color = Color.red;
                    WinLoose.SetActive(true);
                    gameManager.PauseGame();
                }
                else if(Enemy)
                {
                    //enemy card die.
                    gameObject.SetActive(false);
                    gameObject.GetComponent<BulletAndHealth>().Health.gameObject.SetActive(false);
                    gameObject.GetComponent<BulletAndHealth>().enabled = false;
                    int slot = gameObject.GetComponent<AiIndex>().Index;
                    AICardList.RemoveSlot(card, slot);
                }                    
                else if (Player)
                {
                    //player card die.
                    gameObject.GetComponent<BulletAndHealth>().Health.gameObject.SetActive(false);
                    gameObject.GetComponent<BulletAndHealth>().enabled = false;
                    gameObject.SetActive(false);
                    playerCardList.RemoveTransform(card);
                }
            }
        }
        #endregion
    }
}