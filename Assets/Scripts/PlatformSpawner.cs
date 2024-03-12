using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _platforms;
    [SerializeField] private float _platformLenght;
    private GameObject _platform;

    private void Start()
    {
        _platform = Instantiate(_platforms[Random.Range(0, _platforms.Count - 1)], transform.position, Quaternion.identity);
    }
    public void Spawn()
    {
        Vector3 position = new Vector3(0, 0, _platform.transform.position.z + _platformLenght);
        _platform = Instantiate(_platforms[Random.Range(0, _platforms.Count - 1)], position, Quaternion.identity);
    }
}