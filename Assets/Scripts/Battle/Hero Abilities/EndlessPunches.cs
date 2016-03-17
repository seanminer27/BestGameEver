﻿using UnityEngine;
using System.Collections;
using Abilities;

public class EndlessPunches : Ability {

    public EndlessPunches() {

        abilityName = "Endless Punches";
        abilityType = AbilityType.InfBarrage;
        targetScope = TargetScope.SingleEnemy;
        primaryDamageType = DamageType.Physical;

        chargeDuration = 2.0f;
        procDamage = 90;
        procSpacing = 0.7f;

        hasCooldown = false;

    }


    public override void AbilityMap() {

        if(nextProcTimer <= Time.time) {
            CheckTarget();
            DetermineHitOutcomeSingle(abilityOwner, targetEnemy);
            nextProcTimer = Time.time + procSpacing;
        }
        
    } //end AbilityMap()


} //end EndlessPunches() (HAHAHA)