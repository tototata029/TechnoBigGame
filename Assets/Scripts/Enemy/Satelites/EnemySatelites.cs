using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySatelites : MonoBehaviour 
{
    #region Public Members
    public GameObject m_sateliteModel;
    public Transform m_sateliteHolder;
    public int m_sateliteNumber;
    public float m_radius;
    #endregion

    #region System
	
	void Start () 
	{
        SpawnSatelites();
	}

    #endregion

    #region Main Methods
    void SpawnSatelites()
    {
        float section = 360f / m_sateliteNumber * Mathf.Deg2Rad;

        for(int i = 0; i < m_sateliteNumber; i++)
        {
            Vector3 spawnPosition = new Vector3();
            Vector3 center = transform.position;

            spawnPosition.x = center.x + Mathf.Sin(section * i) * m_radius;
            spawnPosition.y = center.y;
            spawnPosition.z = center.z + Mathf.Cos(section * i) * m_radius;

            Instantiate(m_sateliteModel, spawnPosition, Quaternion.identity, m_sateliteHolder); 
        }
           
    }
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    #endregion
}
