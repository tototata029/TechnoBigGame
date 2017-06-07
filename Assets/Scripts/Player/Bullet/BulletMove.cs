using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMove : MonoBehaviour 
{
    #region Public Members
    [Range(0, 500)]
    public float m_speed;

    #endregion

    #region System

    void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_tr = GetComponent<Transform>();
    }

    void Update()
    {
        m_rb.velocity = m_tr.forward * m_speed * Time.deltaTime;
    }

    #endregion
    
    #region Main Methods
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members
    private Rigidbody m_rb;
    private Transform m_tr;
    #endregion
}
