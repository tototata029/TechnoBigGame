using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerDamage : MonoBehaviour 
{

    #region Public Members

    public int m_lifePoint = 3;

    #endregion

    #region System

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyBullet"))
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

    private bool IsDead()
    {
        return m_lifePoint < 1;
    }
    #endregion

    #region Private and Protected Members
    #endregion
}
