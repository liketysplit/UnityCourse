﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float damage = 100f;

    public void Hit(){
        Destroy(gameObject);
    }
    

    public float getDamage(){
        return damage;
    }

    public float setDamage(){
        return damage;
    }
}
