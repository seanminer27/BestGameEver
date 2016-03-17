﻿using UnityEngine;
using System.Collections;

using Abilities;
using Effects;

public class ArmorBreakAbility : Ability {

    public ArmorBreakAbility () {

        abilityName = "Armor Breaker";
        abilityType = AbilityType.Burst;
        targetScope = TargetScope.SingleEnemy;
        primaryDamageType = DamageType.Physical;

        chargeDuration = 4;
        cooldownDuration = 8;
        procDamage = 100;
        
    }


    public override void AbilityMap() {
        CheckTarget();
        ApplyEffectSingle(effectApplied, targetEnemy);
        DetermineHitOutcomeSingle(abilityOwner, targetEnemy);
        ExitAbility();
    }


} //end ArmorBreakAbility class