﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Actor : MonoBehaviour
{
    [SerializeField] private ActorDef m_actorDef = null;
    [SerializeField] private int m_startLevel = 1;

    public Element Element {  get { return m_actorDef.Element; } }
    public bool IsDead {  get { return m_hitPoints <= 0; } }
    public int TurnStep { get { return BattleManager.instance.SpeedMax / Speed; } }

    public string Stats {
        get {
            var stats = $"{name} {m_hitPoints}/{HitPointsMax}hp";
            if ( m_isDefending ) stats += " (defending)";
            return stats;
        }
    }

    public Spell[] Spells {  get { return SpellList.ToArray(); } }

    private int Strength { get { return m_attributes.Strength; } }
    private int HitPointsMax { get { return m_attributes.HitPointsMax; } }
    private int Speed { get { return m_attributes.Speed; } }
    private List<Spell> SpellList { get { return m_attributes.spellList; } }

    private ActorAttributes m_attributes = null;
    private int m_hitPoints = 0;
    private bool m_isDefending = false;

    public int Attack( Actor a_target ) {
        return a_target.Damage( Strength );
    }

    public int CastSpell( int a_index, Actor a_target ) {
        var spell = SpellList[a_index];
        var damage = spell.Damage;
        if ( Element == a_target.Element )
            damage = Mathf.FloorToInt( damage * BattleManager.instance.ResistMultiplier );
        else if ( BattleManager.instance.OpposingElement[Element] == a_target.Element )
            damage = Mathf.FloorToInt( damage * BattleManager.instance.WeaknessMultiplier );

        return a_target.Damage( damage );
    }

    public void Defend() {
        m_isDefending = true;
    }

    public void StartTurn() {
        m_isDefending = false;
    }

    private int Damage( int a_damage ) {
        if ( m_isDefending ) a_damage /= 2;
        a_damage = Mathf.Max( a_damage, 1 );
        m_hitPoints -= a_damage;
        return a_damage;
    }

    private void Start() {
        if( m_actorDef == null ) {
            Debug.LogError( $"[Actor] Failed to create {name}; missing ActorDef. Destroying." );
            Destroy( this );
            return;
        }
        m_attributes = m_actorDef.GetAttributesForLevel( m_startLevel );
        m_hitPoints = HitPointsMax;
    }
}
