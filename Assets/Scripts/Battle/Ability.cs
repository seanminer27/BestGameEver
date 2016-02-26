﻿using UnityEngine;
using System.Collections;

using Heroes;
using Enemies;

namespace Abilities {

    public abstract class Ability : MonoBehaviour {

        //Name and hero

        public string abilityName {
            get; set;
        }

        public Hero abilityOwner;
            

        //Ability type-defining variables

        public bool requiresCharge {
            get; set;
        }

        public DamageType primaryDamageType {
            get; set;
        }

        public enum DamageType {
            Null,
            Physical,
            Magical,
            Healing
        }

        public bool requiresTarget {
            get; set;
        }

        public TargetScope targetScope {
            get; set;
        }

        public enum TargetScope {
            Null,
            Untargeted,
            SingleHero,
            SingleEnemy,
            SingleHeroOrEnemy,
            AllHeroes,
            AllEnemies,
            AllHeroesOrAllEnemies,
            FreeTargetAOE
        }


        //Targeting

        public bool targetSelected {
            get; set;
        }

        public Enemy targetEnemy {
            get; set;
        }

        public Hero targetHero {
            get; set;
        }


        //Timekeeping

        public float chargeDuration {
            get; set;
        }

        public float chargeEndTimer {
            get; set;
        }

        public float abilityDuration {
            get; set;
        }

        public float abilityEndTimer {
            get; set;
        }

        public float cooldownDuration {
            get; set;
        }

        public float cooldownEndTimer {
            get; set;
        }



        //Proc handlers 
            //NOTE: useful for single-proc-type abilities, which will be MOST of them, 
            //but abilities with multiple procs will have to create their own variables 
            //and reflect this in the AbilityMap().

        public float nextProcTimer {
            get; set;
        }

        public int procCounter {
            get; set;
        }

        public int procLimit {
            get; set;
        }

        public float procSpacing {
            get; set;
        }

        public float procDamage {
            get; set;
        }

        public float procHeal {
            get; set;
        }


        //Other stuff


        public string resource {
            get; set;
        }

        public int cost {
            get; set;
        }

        

        //Virtual functions (to be overridden in each ability as needed)

        public virtual void AbilityMap() { }


        public virtual void InitCharge() {
            chargeEndTimer = Time.time + chargeDuration;
            abilityOwner.currentBattleState = Hero.BattleState.Charge;
        }


        public virtual void CheckCharge() {
            if (chargeEndTimer <= Time.time) {
                InitAbility();
            }
        } //end CheckCharge()


        public virtual void InitAbility() {
            abilityEndTimer = Time.time + abilityDuration;
            //Each ability needs to set a battlestate in here!
        } //end InitAbility()


        public virtual void ExitAbility() {
            targetSelected = false;
            cooldownEndTimer = Time.time + cooldownDuration;
            abilityOwner.currentAbility = null;
            abilityOwner.currentBattleState = Hero.BattleState.Wait;
        } //end ExitAbility()


        public virtual void DamageProc(Hero attacker, Enemy defender) {
            defender.currentHealth -= procDamage;
        }


        public virtual void HealingProc(Hero healer, Hero healee) {
            healee.currentHealth += healer.currentAbility.procHeal;
            if(healee.currentHealth >= healee.maxHealth) {
                healee.currentHealth = healee.maxHealth;
            }
        }

      
        //Ability constructor

        public Ability() {

            abilityOwner = null;

            requiresCharge = true;

            requiresTarget = true;
            targetScope = TargetScope.Null;
            targetSelected = false;

            chargeDuration = 0.0f;
            chargeEndTimer = 0.0f;

            abilityDuration = 0.0f;
            abilityEndTimer = 0.0f;

            cooldownDuration = 0.0f;
            cooldownEndTimer = 0.0f;

  
            nextProcTimer = 0.0f;
            procCounter = 0;
            procLimit = 0;
            procSpacing = 0.0f;
            procDamage = 0.0f;
            procHeal = 0.0f;

            resource = "";
            cost = 0;
            primaryDamageType = DamageType.Null;

        } //end constructor

    } //end Ability class

} //end Ability namespace