using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] public GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private int _coinPos;
    private float _counter = 5f;

    private void Update()
    {
        _counter -= Time.deltaTime;
        if(_counter <= 0)
        {
            _counter = 5f;
            CoinPosChanger();            
            var coin = Instantiate(_coinPrefab, _spawnPoints[_coinPos].transform.position, Quaternion.identity );
            coin.transform.position = new Vector3(_spawnPoints[_coinPos].transform.position.x, _spawnPoints[_coinPos].transform.position.y, 0);
        }       
    }
    
    private void CoinPosChanger()
    {
        _coinPos = Random.Range(0, _spawnPoints.Length);
    }
}
