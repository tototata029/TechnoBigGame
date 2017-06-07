using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteLookAway : MonoBehaviour 
{
    #region Public Members
    
    public float m_rotationSpeed;
    #endregion

    #region System
	
	void Awake () 
	{
        m_target = transform.parent;
        m_tr = GetComponent<Transform>();
	}
	
	void Update () 
	{
        Vector3 direction = m_target.position - m_tr.position;
        direction.y = 0;
        //direction *= -1f;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), m_rotationSpeed * Time.deltaTime);
	}

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members

    private Transform m_tr;
    private Transform m_target;
    #endregion
}
