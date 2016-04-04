﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Effects;

namespace BattleObjects {

    //BattleObjects encompass Heroes and Enemies.
    //This way, if something treats both the same, you only have to write code once.

    //Note "AddMod" and "MultMod" - additive modifiers and multiplicative modifiers. 
    //These are all initialized at 1, and buffs modify these rather than the base stats, 
    //Which should only be modified by level things? God maybe.

    public class BattleObject : MonoBehaviour {
        
        //Health & modifiers

        public float maxHealth {
            get; set;
        }

        public float currentHealth {
            get; set;
        }


        public float healthRegen {
            get; set;
        }

        public float healthRegenAddMod {
            get; set;
        }

        public float healthRegenMultMod {
            get; set;
        }


        //Offensive stats & modifiers
        
        public float physicalPenetration {
            get; set;
        }

        public float physicalPenetrationAddMod {
            get; set;
        }

        public float physicalPenetrationMultMod {
            get; set;
        }


        public float physicalAccuracy {
            get; set;
        }

        public float physicalAccuracyAddMod {
            get; set;
        }

        public float physicalAccuracyMultMod {
            get; set;
        }


        public float physicalFinesse {
            get; set;
        }

        public float physicalFinesseAddMod {
            get; set;
        }

        public float physicalFinesseMultMod {
            get; set;
        }


        public float magicalPenetration {
            get; set;
        }

        public float magicalPenetrationAddMod {
            get; set;
        }

        public float magicalPenetrationMultMod {
            get; set;
        }


        public float magicalAccuracy {
            get; set;
        }

        public float magicalAccuracyAddMod {
            get; set;
        }

        public float magicalAccuracyMultMod {
            get; set;
        }


        public float magicalFinesse {
            get; set;
        }

        public float magicalFinesseAddMod {
            get; set;
        }

        public float magicalFinesseMultMod {
            get; set;
        }



        //Defensive stats & modifiers

        public float armor {
            get; set;
        }

        public float armorAddMod {
            get; set;
        }

        public float armorMultMod {
            get; set;
        }


        public float spirit {
            get; set;
        }

        public float spiritAddMod {
            get; set;
        }

        public float spiritMultMod {
            get; set;
        }


        public float physicalEvasionChance {
            get; set;
        }

        public float physicalEvasionChanceAddMod {
            get; set;
        }

        public float physicalEvasionChanceMultMod {
            get; set;
        }


        public float magicalEvasionChance {
            get; set;
        }
        
        public float magicalEvasionChanceAddMod {
            get; set;
        }

        public float magicalEvasionChanceMultMod {
            get; set;
        }


        public float physicalBlockChance {
            get; set;
        }
        
        public float physicalBlockChanceAddMod {
            get; set;
        }

        public float physicalBlockChanceMultMod {
            get; set;
        }


        public float physicalBlockModifier {
            get; set;
        }

        public float physicalBlockModifierAddMod {
            get; set;
        }

        public float physicalBlockModifierMultMod {
            get; set;
        }


        public float magicalBlockChance {
            get; set;
        }

        public float magicalBlockChanceAddMod {
            get; set;
        }

        public float magicalBlockChanceMultMod {
            get; set;
        }

        
        public float magicalBlockModifier {
            get; set;
        }

        public float magicalBlockModifierAddMod {
            get; set;
        }

        public float magicalBlockModifierMultMod {
            get; set;
        }


        public float physicalLifesteal {
            get; set;
        }

        public float physicalLifestealAddMod {
            get; set;
        }

        public float physicalLifestealMultMod {
            get; set;
        }


        public float magicalLifesteal {
            get; set;
        }
        
        public float magicalLifestealAddMod {
            get; set;
        }

        public float magicalLifestealMultMod {
            get; set;
        }

        
        public List<Effect> effectList;
        

        //Constructor

        public BattleObject () {

            maxHealth = 0;
            currentHealth = 0;

            healthRegen = 0;
            healthRegenAddMod = 1;
            healthRegenMultMod = 1;

            physicalPenetration = 0;
            physicalPenetrationAddMod = 1;
            physicalPenetrationMultMod = 1;

            physicalAccuracy = 0;
            physicalAccuracyAddMod = 1;
            physicalAccuracyMultMod = 1;

            physicalFinesse = 0;
            physicalFinesseAddMod = 1;
            physicalFinesseMultMod = 1;

            magicalPenetration = 0;
            magicalPenetrationAddMod = 1;
            magicalPenetrationMultMod = 1;

            magicalAccuracy = 0;
            magicalAccuracyAddMod = 1;
            magicalAccuracyMultMod = 1;

            magicalFinesse = 0;
            magicalFinesseAddMod = 1;
            magicalFinesseMultMod = 1;
            
            armor = 0;
            armorAddMod = 1;
            armorMultMod = 1;

            spirit = 0;
            spiritAddMod = 1;
            spiritMultMod = 1;
            
            physicalEvasionChance = 0;
            physicalEvasionChanceAddMod = 1;
            physicalEvasionChanceMultMod = 1;

            magicalEvasionChance = 0;
            magicalEvasionChanceAddMod = 1;
            magicalEvasionChanceMultMod = 1;

            physicalBlockChance = 0;
            physicalBlockChanceAddMod = 1;
            physicalBlockChanceMultMod = 1;

            physicalBlockModifier = 0;
            physicalBlockModifierAddMod = 1;
            physicalBlockModifierMultMod = 1;

            magicalBlockChance = 0;
            magicalBlockChanceAddMod = 1;
            magicalBlockChanceMultMod = 1;

            magicalBlockModifier = 0;
            magicalBlockModifierAddMod = 1;
            magicalBlockModifierMultMod = 1;

            physicalLifesteal = 0;
            physicalLifestealAddMod = 1;
            physicalLifestealMultMod = 1;

            magicalLifesteal = 0;
            magicalLifestealAddMod = 1;
            magicalLifestealMultMod = 1;
            
        } //end Constructor


        //Native functions

        //eventually this guy will include (int damage, Ability.DamageType damageType)
        public virtual void SpawnDamageText(int damage, Abilities.Ability.DamageType damageType) {

            GameObject damageTextPrefab = (GameObject)Instantiate(Resources.Load("DamageTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh damageTextMesh = damageTextPrefab.GetComponentInChildren<TextMesh>();
            damageTextMesh.text = damage.ToString();
            
            if (damageType == Abilities.Ability.DamageType.Physical) {
                damageTextMesh.color = Color.red;
                damageTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.PhysicalHit;
            }
            else if (damageType == Abilities.Ability.DamageType.Magical) {
                damageTextMesh.color = Color.blue;
                damageTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.MagicalHit;
            }
            
        } //end SpawnDamageText()


        public virtual void SpawnHealText(int heal) {

            GameObject healTextPrefab = (GameObject)Instantiate(Resources.Load("HealTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh healTextMesh = healTextPrefab.GetComponentInChildren<TextMesh>();
            healTextMesh.text = heal.ToString();
            
            healTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.Heal;

        } //end SpawnHealText()


        public virtual void SpawnMissText(Abilities.Ability.DamageType damageType) {

            GameObject missTextPrefab = (GameObject)Instantiate(Resources.Load("MissTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh missTextMesh = missTextPrefab.GetComponentInChildren<TextMesh>();
            missTextMesh.text = "Miss!";
            
            if (damageType == Abilities.Ability.DamageType.Physical) {
                missTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.PhysicalMiss;
            }
            else {
                missTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.MagicalMiss;
            }

        } //end SpawnDamageText()


        public virtual void SpawnBlockText(int damage, Abilities.Ability.DamageType damageType) {

            GameObject blockTextPrefab = (GameObject)Instantiate(Resources.Load("BlockTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh blockTextMesh = blockTextPrefab.GetComponentInChildren<TextMesh>();
            blockTextMesh.text = damage.ToString();

            if (damageType == Abilities.Ability.DamageType.Physical) {
                blockTextMesh.color = new Color(1, 0.5f, 0.5f, 1);
                blockTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.PhysicalBlock;
            }
            else {
                blockTextMesh.color = new Color(0.5f, 0.5f, 1, 1);
                blockTextPrefab.GetComponentInChildren<DamageTextObjects.DamageTextController>().hitType = DamageTextObjects.DamageTextController.HitType.MagicalBlock;
            }

        } //end SpawnDamageText() 


    } //end BattleObject class

} //end namespace
