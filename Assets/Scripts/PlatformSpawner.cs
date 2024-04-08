using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject coin;
    private List<GameObject> _createdPlatforms = new List<GameObject>();
    private float _platformLenght = 144f;
    private float _startPos = 0f;
    private int _coinCount = 0;

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
            if (_player.position.z - 110 > _startPos - (platformPrefabs.Length * _platformLenght))
            {
                SpawnPlatform(Random.Range(0, platformPrefabs.Length));
                DeletePlatform();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void SpawnPlatform(int index)
    {
        _coinCount = Random.Range(1, 3);
        GameObject newPlatform = Instantiate(platformPrefabs[index], transform.forward * _startPos, Quaternion.identity);
        for (int i = 0; i < _coinCount; i++)
        {
            GameObject newCoin = Instantiate(coin);
            Vector3 newPosition = new Vector3(Random.Range(-10.5f, 10.5f), 0.55f, Random.Range(_startPos - 72, _startPos + 72));
            newCoin.transform.position = newPosition;
            newCoin.transform.SetParent(newPlatform.transform);
        }
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