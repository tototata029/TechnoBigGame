using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBreakable : MonoBehaviour 
{
    #region Public Members
    #endregion

    #region System

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    #endregion
}
