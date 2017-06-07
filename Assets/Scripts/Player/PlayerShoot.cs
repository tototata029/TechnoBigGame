using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
    #region Public Members

    public GameObject m_bulletModel;
    [Range(.2f, 2f)]
    public float m_timeBetweenBullet = 0.2f;

    public Transform m_aim;
    public bool m_autoFire = false;

    #endregion

    #region System
	
	void Start () 
	{
        m_canShoot = true;
	}
	
	void Update () 
	{
		if(Input.GetButton("Jump") || m_autoFire)
        {
            if(m_canShoot)
            {
                Instantiate(m_bulletModel, m_aim.transform.position, transform.rotation, gameObject.transform);
                StartCoroutine(WaitUntilNextBullet());
            }
        }
	}

    #endregion

    #region Main Methods
    #endregion

    #region Utils

    private IEnumerator WaitUntilNextBullet()
    {
        m_canShoot = false;
        yield return new WaitForSeconds(m_timeBetweenBullet);
        m_canShoot = true;
    }
    #endregion

    #region Private and Protected Members

    private bool m_canShoot = true;

    #endregion
}
