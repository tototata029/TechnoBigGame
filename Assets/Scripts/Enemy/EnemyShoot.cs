using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour 
{
    #region Public Members

    public enum e_bulletType
    {
        DESTRUCTIBLE,
        UNDESTRUCTIBLE,
        ALTERNATE
    }

    public e_bulletType m_bulletType;
    public Transform m_bulletDestructibleModel;
    public Transform m_bulletUndestructibleModel;
    public bool m_spirale;
    public float m_timeBetweenBullet;
    public float m_bulletScale;

    #endregion

    #region System

    private void Awake()
    {
        m_tr = GetComponent<Transform>();
        m_canShoot = true;
    }
	
	void Update () 
	{
		if(m_canShoot)
        {
            Transform modelToInstantiate = m_bulletDestructibleModel;
            switch(m_bulletType)
            {
                case e_bulletType.DESTRUCTIBLE:
                    modelToInstantiate = m_bulletDestructibleModel;
                    break;
                case e_bulletType.UNDESTRUCTIBLE:
                    modelToInstantiate = m_bulletUndestructibleModel;
                    break;
                case e_bulletType.ALTERNATE:
                    modelToInstantiate = m_ping ? m_bulletUndestructibleModel : m_bulletDestructibleModel;
                    m_ping = !m_ping;
                    break;
            }

            Transform bullet = Instantiate(modelToInstantiate, transform.position, transform.rotation) ;

            if (m_spirale)
            {
                bullet.parent = m_tr.parent.parent;
            }
            else
            {
                bullet.parent = m_tr.parent;
                
            }
            bullet.localScale = new Vector3(m_bulletScale, m_bulletScale, m_bulletScale);
            StartCoroutine(WaitUntilNextBullet());
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

    private bool m_canShoot;
    private bool m_ping;
    private Transform m_tr;
    #endregion
}
