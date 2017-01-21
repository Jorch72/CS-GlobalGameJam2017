﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : Instrument {
    public GameObject Amp;
    Transform AmpPos;
    public bool AmpDropped;
    float attackTime,mainAttackTime;
    public float AttackCoolDown, AggroLightCoolDown, AggroHeavyCoolDown, UtilityCoolDown, DefenseCoolDown;
    // Use this for initialization
    void Start () {
        //set up normal attack note
        //Amp.GetComponent<Renderer>().enabled = false;
        attackTime = 0;
        AttackCoolDown = 0.5f;
        AmpPos = gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (attackTime > 0) {
            attackTime -= Time.deltaTime;
        }
        if (mainAttackTime > 0)
        {
            mainAttackTime -= Time.deltaTime;
        }
    }

    public override void Attack(Vector3 Direction) {
        if (mainAttackTime <= 0)
        {
            Projectile note = new Projectile();
            if (!AmpDropped)
            {
               note = Instantiate(Note, transform.position, transform.rotation);
            }
            else
            {
               note = Instantiate(Note, AmpPos.position, AmpPos.rotation);
            }
            note.GetComponent<Rigidbody>().velocity = Direction * 6;
            mainAttackTime = AttackCoolDown;
        }
    }
    public override void AggroLight() {
        if (attackTime < 0) {
        }
    }
    public override void AggroHeavy() { }
    public override void Utility() {
        if (AmpDropped == false)
        {
            //GameObject DroppedAmp = Amp;
            AmpDropped = true;
            //DroppedAmp.GetComponent<Amp>().Dropped(true);
            GameObject amp = Instantiate(Amp, transform.position, transform.rotation) as GameObject;
            amp.GetComponent<Amp>().Dropped(true);
            AmpPos = amp.transform;
            print(AmpPos);
        }
    }
    public override void Defense() {
       
    }
}
