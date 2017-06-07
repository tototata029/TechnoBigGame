using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{

    #region Public Members
    public float m_speed;
    #endregion

    #region System
	
	void Update () 
	{
        transform.Rotate(Vector3.down * m_speed * Time.deltaTime);
    }

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    #endregion
}
