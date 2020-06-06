using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] public GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private int _ch;
    private float _counter = 5f;

    private void Update()
    {
        _counter -= Time.deltaTime;
        if(_counter <= 0)
        {
            _counter = 5f;
            CoinPos();            
            var coin = Instantiate(_coinPrefab, _spawnPoints[_ch].transform.position, Quaternion.identity );
            coin.transform.position = new Vector3(_spawnPoints[_ch].transform.position.x, _spawnPoints[_ch].transform.position.y, 0);
        }       
    }
    
    private void CoinPos()
    {
        _ch = Random.Range(0, _spawnPoints.Length);
    }
}
