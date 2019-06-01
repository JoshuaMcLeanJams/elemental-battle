﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell", order = 1)]
public class Spell : ScriptableObject
{
    [SerializeField] private int m_cost = 1;
    [SerializeField] private int m_elementPower = 1;
    [SerializeField] private int m_damage = 1;

    public int Cost {  get { return m_cost; } }
    public int Damage {  get { return m_damage; } }
    public int ElementPower {  get { return m_elementPower; } }
}