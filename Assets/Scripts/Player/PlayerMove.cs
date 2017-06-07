using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Public Members
    [Header("Movement")]
    [Space(5)]
    [Tooltip("The travel speed of the player")]
    [Range(0, 10)]
    public float m_speed = 3f;

    [Space(15)]
    [Header("Input Parameters")]
    [Space(5)]
    [Tooltip("If false, the input will be smoothed")]
    public bool m_rawInput = false;
    public bool m_invertedHorizontal = false;
    public bool m_invertedVertical = false;

    #endregion

    #region System

    void Awake()
    {
        m_tr = GetComponent<Transform>();
    } 

    void Update()
    {
        GetInput();
        Move();
        Rotate();
    }

    #endregion

    #region Main Methods

    private void GetInput()
    {
        m_movement = Vector3.zero;

        if (m_rawInput)
        {
            m_movement.x = Input.GetAxisRaw("Horizontal");
            m_movement.z = Input.GetAxisRaw("Vertical");
        }
        else
        {
            m_movement.x = Input.GetAxis("Horizontal");
            m_movement.z = Input.GetAxis("Vertical");
        }

        m_movement.x *= m_speed * Time.deltaTime;
        m_movement.z *= m_speed * Time.deltaTime;

        if (m_invertedHorizontal)
        {
            m_movement.x *= -1;
        }
        if (m_invertedVertical)
        {
            m_movement.z *= -1;
        }
    }

    private void Move()
    {
        m_oldPos = m_tr.position;
        m_oldPos += m_movement;
        m_tr.position = m_oldPos;
    }

    private void Rotate()
    {
        if (m_movement != Vector3.zero)
        {
            m_tr.rotation = Quaternion.LookRotation(m_movement);
        }
    }
    #endregion

    #region Utils
    #endregion

    #region Private and Protected Members

    private Transform m_tr;
    Vector3 m_movement;
    Vector3 m_oldPos;

    #endregion

}
