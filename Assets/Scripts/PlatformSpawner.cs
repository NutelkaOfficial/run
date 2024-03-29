using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
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
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            platformPrefabs[i].SetActive(false);
        }
        StartCoroutine(SpawnCall());
    }
    private IEnumerator SpawnCall()
    {
        while (true)
        {
            if (_player.position.z - 90 > _startPos - (platformPrefabs.Length * _platformLenght))
            {
                SpawnPlatform(Random.Range(0, platformPrefabs.Length));
                DeletePlatform();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void SpawnPlatform(int index)
    {
        GameObject newPlatform = Instantiate(platformPrefabs[index], transform.forward * _startPos, Quaternion.identity);
        newPlatform.SetActive(true);
        _createdPlatforms.Add(newPlatform);
        _startPos += _platformLenght;
    }
    private void DeletePlatform()
    {
        Destroy(_createdPlatforms[0] );
        _createdPlatforms.RemoveAt(0);
    }
}