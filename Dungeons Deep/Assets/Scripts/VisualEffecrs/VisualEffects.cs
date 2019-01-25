using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualEffects : MonoBehaviour {

    private static GameObject hiteffect;
    private static GameObject expolsionEffect;
    private static GameObject dashEffect;



    public static void spawnHitEffect(Transform location) {

        hiteffect = Resources.Load<GameObject>("hitEffects/ShotEffect");
        GameObject instance = Instantiate(hiteffect);

        instance.transform.position = location.position;
    

    }

    public static void spawnDeathExplosion(Transform location)
    {
        expolsionEffect = Resources.Load<GameObject>("hitEffects/ExplosionEffect");
        GameObject instance = Instantiate(expolsionEffect);

        instance.transform.position = location.position;
    }

    public static void spawnDashEffect(Transform location)
    {
        dashEffect = Resources.Load<GameObject>("hitEffects/DashEffect");
        GameObject instance = Instantiate(dashEffect);

        instance.transform.position = location.position;

    }
}
