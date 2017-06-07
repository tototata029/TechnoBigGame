using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
    #region Public Members
    
    [Range(1f, 10f)]
    public float m_timerBetweenTwoRandomDirections;

    public enum e_moveType
    {
        NONE,
        RANDOM,
        FOLLOW_PLAYER,
        ESCAPE_PLAYER,
        CIRCLE
    }
    public e_moveType m_moveType;

    public float m_speed;
    public float m_radius;
    

    #endregion

    #region System
	
	void Awake () 
	{
        m_player = GameObject.FindWithTag("Player").transform;
        m_tr = GetComponent<Transform>();
        StartCoroutine(MoveChange());
        m_center = m_tr.position;
	}
	
	void Update () 
	{
		if(m_player)
        {
            switch(m_moveType)
            {
                case e_moveType.NONE:
                    break;

                case e_moveType.RANDOM:
                    m_movement.x = Mathf.Cos(m_direction);
                    m_movement.z = Mathf.Sin(m_direction);

                    m_movement.x *= m_speed * Time.deltaTime;
                    m_movement.z *= m_speed * Time.deltaTime;

                    Move();
                    break;

                case e_moveType.FOLLOW_PLAYER:
                    m_toTarget = m_player.position - m_tr.position;
                    transform.Translate(m_toTarget * m_speed * Time.deltaTime);
                    break;

                case e_moveType.ESCAPE_PLAYER:
                    m_toTarget = m_tr.position - m_player.position;
                    transform.Translate(m_toTarget * m_speed * Time.deltaTime);
                    break;

                case e_moveType.CIRCLE:
                    m_angle += m_speed * Time.deltaTime;
                    m_tr.position = new Vector3((m_center.x  + Mathf.Cos(m_angle) * m_radius),
                                                m_center.y,
                                                (m_center.z + Mathf.Sin(m_angle) * m_radius));
                    break;
            }
        }
	}

    #endregion

    #region Main Methods
    void Move()
    {
        m_oldPos = m_tr.position;
        m_oldPos += m_movement;
        m_tr.position = m_oldPos;
    }
    #endregion

    #region Utils
    private IEnumerator MoveChange()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_timerBetweenTwoRandomDirections);
            m_direction = Random.Range(0, 2 * Mathf.PI);
        }
    }
    #endregion

    #region Private and Protected Members
    private Transform m_tr;
    private Vector3 m_movement;
    private Vector3 m_oldPos;
    private float m_direction = 1f;
    private Vector3 m_toTarget;
    private float m_angle;
    private Transform m_player;
    private Vector3 m_center;
    #endregion
}
