using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyer : MonoBehaviour
{
    [SerializeField]private GameObject _coin;
    
    private void OnTriggerEnter2D()
    {
        Destroy(_coin);
    }

}
