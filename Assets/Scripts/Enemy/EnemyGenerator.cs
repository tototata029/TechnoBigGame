using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour 
{
    #region Public Members
    public List<Transform> m_enemyCollection;
    [Range(.5f, 10)]
    public float m_timeBetweenCreation;
    #endregion

    #region System
	
	void Start () 
	{
        StartCoroutine(CreateEnemy());
	}

    #endregion

    #region Main Methods
    #endregion

    #region Utils
    IEnumerator CreateEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_timeBetweenCreation);
            int choosenEnemy = Random.Range(0, m_enemyCollection.Count);

            Instantiate(m_enemyCollection[choosenEnemy]);
        }
    }
    #endregion

    #region Private and Protected Members
    #endregion
}
