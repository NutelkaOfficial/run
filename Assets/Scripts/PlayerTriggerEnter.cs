using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerEnter : MonoBehaviour
{
    [SerializeField] private PlatformSpawner _platformSpawner;

    private void OnTriggerEnter(Collider other)
    {
        _platformSpawner.Spawn();
    }
}
