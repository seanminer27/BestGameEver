﻿using UnityEngine;
using System.Collections;

using Effects;
using BattleObjects;

public class RaiseSpiritsEff : Effect {

    public RaiseSpiritsEff() {

        effectName = "Raise Spirits";
        effectDisplayText = "Spirit Up";
        effectDuration = 10;

    } //end Constructor

    public override void InitEffect(BattleObject host) {
        base.InitEffect(host);
        host.spirit *= 1.7f;
    }

    public override void RemoveEffect(BattleObject host) {
        host.spirit /= 1.7f;
        base.RemoveEffect(host);
    }

} //end SpiritBreak class