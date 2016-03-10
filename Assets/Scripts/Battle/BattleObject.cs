﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Effects;

namespace BattleObjects {

    //BattleObjects encompass Heroes and Enemies.
    //This way, if something treats both the same, you only have to write code once.

    public class BattleObject : MonoBehaviour {

        public float maxHealth {
            get; set;
        }

        public float currentHealth {
            get; set;
        }

        public float healthRegen {
            get; set;
        }

        public float armor {
            get; set;
        }

        public float spirit {
            get; set;
        }

        public float physicalEvasionChance {
            get; set;
        }

        public float magicalEvasionChance {
            get; set;
        }

        public float physicalBlockChance {
            get; set;
        }

        public float physicalBlockModifier {
            get; set;
        }

        public float magicalBlockChance {
            get; set;
        }

        public float magicalBlockModifier {
            get; set;
        }


        public List<Effect> effectList;
        

        //Constructor

        public BattleObject () {

            maxHealth = 0;
            currentHealth = 0;
            healthRegen = 0;
            armor = 0;
            spirit = 0;
            physicalEvasionChance = 0;
            magicalEvasionChance = 0;
            physicalBlockChance = 0;
            physicalBlockModifier = 0;
            magicalBlockChance = 0;
            magicalBlockModifier = 0;
            
        } //end Constructor


        //Native functions

        //eventually this guy will include (int damage, Ability.DamageType damageType)
        public virtual void SpawnDamageText(int damage) {

            GameObject damageTextPrefab = (GameObject)Instantiate(Resources.Load("DamageTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh damageTextMesh = damageTextPrefab.GetComponentInChildren<TextMesh>();
            damageTextMesh.text = damage.ToString();

        } //end SpawnDamageText()


        public virtual void SpawnHealText(int heal) {

            GameObject healTextPrefab = (GameObject)Instantiate(Resources.Load("HealTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh healTextMesh = healTextPrefab.GetComponentInChildren<TextMesh>();
            healTextMesh.text = heal.ToString();

        } //end SpawnHealText()


        public virtual void SpawnMissText() {

            GameObject missTextPrefab = (GameObject)Instantiate(Resources.Load("MissTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh missTextMesh = missTextPrefab.GetComponentInChildren<TextMesh>();
            missTextMesh.text = "Miss!";

        } //end SpawnDamageText()


        public virtual void SpawnBlockText(int damage) {

            GameObject blockTextPrefab = (GameObject)Instantiate(Resources.Load("BlockTextPrefab"),
                transform.position,
                Quaternion.Euler(90, 0, 0)
                );

            TextMesh missTextMesh = blockTextPrefab.GetComponentInChildren<TextMesh>();
            missTextMesh.text = damage.ToString(); 

        } //end SpawnDamageText() 


    } //end BattleObject class

} //end namespace
