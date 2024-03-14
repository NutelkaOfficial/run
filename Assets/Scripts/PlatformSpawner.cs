using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //[SerializeField] private List<GameObject> _platforms;
    //[SerializeField] private float _platformLenght;
    //private GameObject _platform;

    //private void Start()
    //{
    //    _platform = Instantiate(_platforms[Random.Range(0, _platforms.Count - 1)], transform.position, Quaternion.identity);
    //}
    //public void Spawn()
    //{
    //    Vector3 position = new Vector3(0, 0, _platform.transform.position.z + _platformLenght);
    //    _platform = Instantiate(_platforms[Random.Range(0, _platforms.Count - 1)], position, Quaternion.identity);

    //}
    public GameObject[] platformPrefabs;
    private List<GameObject> _createdPlatforms = new List<GameObject>();
    private float _platformLenght = 144f;
    private float _startPos = 0f;

    [SerializeField] private Transform _player;

    private void Start()
    {
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length));
        }
    }
    private void Update()
    {
        if (_player.position.z - 80 > _startPos - (platformPrefabs.Length * _platformLenght))
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length));
            DeletePlatform();
        }
    }
    private void SpawnPlatform(int index)
    {
        GameObject newPlatform = Instantiate(platformPrefabs[index], transform.forward * _startPos, Quaternion.identity);
        _createdPlatforms.Add(newPlatform);
        _startPos += _platformLenght;
    }
    private void DeletePlatform()
    {
        Destroy(_createdPlatforms[0] );
        _createdPlatforms.RemoveAt(0);
    }
}