using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyDamage : MonoBehaviour 
{
    #region Public Members

    public int m_lifePoint;

    #endregion

    #region System

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBullet"))
        {
            m_lifePoint -= 1;
            if(IsDead())
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region Main Methods
    #endregion

    #region Utils

    bool IsDead()
    {
        return m_lifePoint < 1;
    }
    #endregion

    #region Private and Protected Members
    #endregion
}
