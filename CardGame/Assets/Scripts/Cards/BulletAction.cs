#region Reference
// Added to Bullet gameObject in canvas under( AI_Template, Template)
#endregion
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class BulletAction : MonoBehaviour
    {
        #region Variables
        // public
        
        public float speed;
        public bool AI;
        
        //private
        private RectTransform bulletTransform;
        
        private Vector3 pos;
        #endregion

        #region UnityFunctions

        // Initialize
        private void Start()
        {
            bulletTransform = GetComponent<RectTransform>();
            pos = transform.position;
        }

        // move bullet
        void Update()
        {
            if (AI)
            {
                bulletTransform.localPosition -= speed * Time.deltaTime * Vector3.up;
            }
            else
            {
                bulletTransform.localPosition += speed * Time.deltaTime * Vector3.up;
            }
        }

        // check Collision
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (AI)
            {
                // if Ai bullet then it hit player.
                if (collision.CompareTag("Player") || collision.CompareTag("PlayerBase"))
                {
                    collision.gameObject.GetComponent<HealthManager>().ChangeHealth(3);
                    gameObject.SetActive(false);
                    
                    //reset position to back.
                    transform.position = pos;
                }
            }
            else
            {
                //if player bullet then it hit enemy.
                if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBase"))
                {
                    collision.gameObject.GetComponent<HealthManager>().ChangeHealth(3);
                    gameObject.SetActive(false);
                    
                    //reset position to back.
                    transform.position = pos;
                }
            }
        }
        #endregion
    }
}