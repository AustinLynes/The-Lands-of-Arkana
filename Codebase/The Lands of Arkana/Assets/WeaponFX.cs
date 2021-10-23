using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFX : MonoBehaviour
{
    public ParticleSystem normalEffect;

    private void Awake()
    {
        normalEffect.Stop();

        if (normalEffect.isStopped)
        {
            normalEffect.Play();
        }
    }
}
