﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int Speed { get { return m_speed; } }

    [SerializeField] private int m_hpMax = 10;
    [SerializeField] private int m_attack = 1;
    [SerializeField, Tooltip("Lower = faster")] private int m_speed = 10;

    private int m_hp = 0;

    private void Start() {
        m_hp = m_hpMax;
    }
}
