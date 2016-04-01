﻿using UnityEngine;
using System.Collections;
using Abilities;

public class EbbAndFlow : HeroAbility {

	public EbbAndFlow() {

        abilityName = "Ebb and Flow";
        abilityType = AbilityType.InfBarrage;
        targetScope = TargetScope.Untargeted;
        primaryDamageType = DamageType.Magical;
        costsMana = false;

        chargeDuration = 3;
        procDamage = 90;
        procHeal = 75;
        procSpacing = 0.8f;

        requiresTargeting = false;
        hasCooldown = false;
        
    }

    public override void AbilityMap() {

        if (nextProcTimer <= Time.time) {

            if ((procCounter == 0) | (procCounter % 2 == 0)) {
                targetingManager.TargetRandomEnemy(this);
                DetermineHitOutcomeSingle(abilityOwner, targetEnemy);
                nextProcTimer = Time.time + procSpacing;
                procCounter++;
            } //end if even, damage random enemy
            else {
                targetingManager.TargetRandomHero(this);
                HealProcSingle(abilityOwner, targetHero);
                nextProcTimer = Time.time + procSpacing;
                procCounter++;
            } //end if odd, heal random hero
            
        } //end if time to proc
        
    } //end AbilityMap()
    
} //end EbbAndFlow class