using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour 
{

    #region Public Members
    
    

    public float m_rotationSpeed;
    #endregion

    #region System
    private void Awake()
    {
        m_tr = GetComponent<Transform>();
        m_player = GameObject.FindWithTag("Player").GetComponent<Transform>();    
    }
	
	void Update () 
	{
        Vector3 direction = m_player.position - m_tr.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                              Quaternion.LookRotation(direction), 
                                              m_rotationSpeed * Time.deltaTime);
	}

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    private Transform m_tr;
    private Transform m_player;
    #endregion
}
