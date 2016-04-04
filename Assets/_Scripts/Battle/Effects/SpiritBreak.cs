﻿using UnityEngine;
using System.Collections;

using Effects;
using BattleObjects;

public class SpiritBreak : Effect {

    public SpiritBreak() {

        effectName = "Spirit Break";
        effectDisplayText = "Spirit down";
        effectIconText = "S-";
        effectDuration = 8;
        effectType = EffectType.Lump;
        statType = StatType.Magical;
        

    } //end Constructor

    public override void InitEffect(BattleObject host) {
        base.InitEffect(host);
        host.spirit /= 2;
    }

    public override void RemoveEffect(BattleObject host) {
        host.spirit *= 2;
        base.RemoveEffect(host);
    }

} //end SpiritBreak class