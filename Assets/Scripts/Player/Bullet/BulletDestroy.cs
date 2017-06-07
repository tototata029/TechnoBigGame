using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour 
{
	#region Public Members
    
    [Range(0, 30)]
    public float m_timeBeforeDestruction;
    #endregion

    #region System
	
	void Start () 
	{
        StartCoroutine(WaitUntilDestroy());
	}

    #endregion

    #region Main Methods
    private IEnumerator WaitUntilDestroy()
    {
        yield return new WaitForSeconds(m_timeBeforeDestruction);
        Destroy(gameObject);
    }
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    #endregion
}
