using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTorus : MonoBehaviour
{
    [SerializeField] private LayerMask _deathLayer;

    public event Action OnDeath;

    private void OnCollisionEnter(Collision collision)
    {
        if ((_deathLayer.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            OnDeath?.Invoke();
        }
    }
}
