﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using BattleObjects;
using Effects;

public class EffectController : MonoBehaviour {

    //GameObject effectManager = GameObject.Find("EffectManager");

    public Effect effectApplied {
        get; set;
    }

    public List<HostController> hostControllerList = new List<HostController>();
    public List<HostController> hostControllerToRemoveList = new List<HostController>();

    public class HostController {

        public BattleObject host;
        public GameObject effectIcon;
        public TextMesh iconTextMesh;
        public EffectDisplayController effectDisplayController;
        public float expirationTimer;
        public int stackCount;

    } //end effectStruct

  
    //public List<BattleObject> affectedBattleObjectList = new List<BattleObject>();
    //public List<int> stackCountList = new List<int>();
    //public List<GameObject> effectIconList = new List<GameObject>();



    void Update () {
        
        if (hostControllerList.Count <= 0) {
            //effectManager.GetComponent<EffectManager>().activeEffectControllerList.Remove(this);
            Destroy(this);
        }

        foreach (HostController hostController in hostControllerList) {
            CheckForExpiration(hostController);
        }

        foreach (HostController hostController in hostControllerToRemoveList) {
            hostControllerList.Remove(hostController);
        }

        hostControllerToRemoveList.Clear();

        //hostControllerList.RemoveAll(item => item == null);

    } //end Update()


    private void CheckForExpiration (HostController hostController) {

        if (hostController.expirationTimer < Time.time) {
            if (effectApplied.effectType == Effect.EffectType.Lump) {
                SetHostControllerForRemoval(hostController);
            }
            else if (effectApplied.effectType == Effect.EffectType.Stacking) {
                if (hostController.stackCount <= 1) {
                    SetHostControllerForRemoval(hostController);
                }
                else {
                    UpdateStacks(hostController, -1);
                }
            }
        }

    } //end CheckForExpiration (1)


    public void UpdateStacks(HostController hostController, int stacksToApply) {

        effectApplied.UpdateEffectPerStack(hostController.host, hostController.stackCount, (hostController.stackCount + stacksToApply));

        hostController.stackCount += (stacksToApply);
        hostController.iconTextMesh.text = hostController.stackCount.ToString();
        hostController.expirationTimer = Time.time + ApplyTenacity(hostController.host, effectApplied.stackDuration);
        
    } //end UpdateStacks (2)
     

    public void SetHostControllerForRemoval(HostController hostController) {

        hostControllerToRemoveList.Add(hostController);
        hostController.effectDisplayController.displayEffectIconList.Remove(hostController.effectIcon);

        effectApplied.RemoveEffectPerStack(hostController.host, hostController.stackCount);
        effectApplied.RemoveEffect(hostController.host);

        Destroy(hostController.effectIcon);
        hostController.effectDisplayController.UpdateEffectIconPositions();

        //Remove from reallist

    } //end SetHostControllerForRemoval(1)


    public void InitHostController(BattleObject host) {

        HostController hostController = new HostController();

        hostController.host = host;
        hostController.effectIcon = SpawnDisplayIcon(host);
        hostController.iconTextMesh = hostController.effectIcon.GetComponentInChildren<TextMesh>();
        hostController.effectDisplayController = host.GetComponentInChildren<EffectDisplayController>();
        hostController.expirationTimer = Time.time + ApplyTenacity(host, effectApplied.effectDuration);

        hostControllerList.Add(hostController);

    } //end InitStruct (1)
    

    public void InitHostControllerStacking(BattleObject host, int initialStacks) {

        HostController hostController = new HostController();

        hostController.host = host;
        hostController.effectIcon = SpawnDisplayIcon(host);
        hostController.iconTextMesh = hostController.effectIcon.GetComponentInChildren<TextMesh>();
        hostController.effectDisplayController = host.GetComponentInChildren<EffectDisplayController>();

        hostController.expirationTimer = Time.time + ApplyTenacity(host, effectApplied.stackDuration);
        hostController.stackCount = initialStacks;
        hostController.iconTextMesh.text = initialStacks.ToString();

        hostControllerList.Add(hostController);

        effectApplied.InitEffectPerStack(host, initialStacks);

    } //end InitStructStacking


    public GameObject SpawnDisplayIcon(BattleObject host) {

        GameObject effectIcon = new GameObject();
        EffectDisplayController effectDisplayController = host.GetComponentInChildren<EffectDisplayController>();

        if (effectApplied.effectType == Effect.EffectType.Lump) {

            effectIcon = (GameObject)Instantiate(Resources.Load("EffectIconLump"),
                effectDisplayController.displayPositionList[effectDisplayController.displayEffectIconList.Count],
                Quaternion.identity
                );

            if (effectApplied.statType == Effect.StatType.Magical) {
                effectIcon.GetComponentInChildren<Renderer>().material =
                    Resources.Load("Magic Icon Material", typeof(Material)) as Material;
            }
            else if (effectApplied.statType == Effect.StatType.Physical) {
                effectIcon.GetComponentInChildren<Renderer>().material =
                    Resources.Load("Physical Icon Material", typeof(Material)) as Material;
            }

            effectIcon.GetComponentInChildren<TextMesh>().text = effectApplied.effectIconText;

        } //end if lump
        else if (effectApplied.effectType == Effect.EffectType.Stacking) {

            effectIcon = (GameObject)Instantiate(Resources.Load("EffectIconStacking"),
                effectDisplayController.displayPositionList[effectDisplayController.displayEffectIconList.Count],
                Quaternion.identity
                );

        } //end if Stacking

        effectDisplayController.displayEffectIconList.Add(effectIcon);
        
        return effectIcon;

    } //end SpawnDisplayIcon (1)


    public float ApplyTenacity(BattleObject host, float duration) {

        return (duration *= (1 - (host.ApplyStatModifications(host.tenacity, host.tenacityMultMod, host.tenacityAddMod) / 100)));

    } //end ApplyTenacity (2)

    
    //Misc. functions


    public int CountAllStacks () {

        int count = 0;

        foreach (HostController hostController in hostControllerList) {
            count += hostController.stackCount;
        }

        return count;

    } //end CountAllStacks()

    
} //end EffectController class
