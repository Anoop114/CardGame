#region Reference
// Added to AI_Template and Template under canvas.
#endregion
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cards
{
    public class BulletAndHealth : MonoBehaviour
    {
        #region Variables
        //public
        public GameObject bullet;
        public Slider Health;
        
        //private
        private bool IsFire;
        private int bulletCount = 0;
        
        private List<GameObject> bullets;
        #endregion

        #region UnityFunctions

        //Initialize
        void Start()
        {
            bullets = new List<GameObject>();
            
            GenerateBullets();
        }
        // set Health
        private void OnEnable()
        {
            Health.gameObject.SetActive(true);
            IsFire = true;
        }
        //fire every 2 seconds
        private void Update()
        {
            if (IsFire)
            {
                IsFire = false;
                Invoke(nameof(FiringBullet), 2);
            }
        }
        #endregion

        #region MadeFunction

        // generate 10 bullets.
        private void GenerateBullets()
        {
            for(int i = 0; i < 10; i++)
            {
                GameObject bulletPre = Instantiate(bullet);
                bulletPre.SetActive(false);
                bulletPre.transform.position = Health.transform.position;
                bulletPre.transform.SetParent(transform);
                bullets.Add(bulletPre);
            }
        }
        
        // fire action
        private void FiringBullet()
        {
            if(bulletCount == bullets.Count - 1)
            {
                bulletCount = 0;
            }
            bullets[bulletCount].SetActive(true);
            bulletCount++;
            IsFire = true;
        }
        #endregion
    }
}