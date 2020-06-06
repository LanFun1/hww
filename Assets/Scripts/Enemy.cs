using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private int _ch = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_ch].transform.position, _speed * Time.deltaTime);
        if(transform.position == _points[_ch].transform.position)
        {
            _ch++;
            if (_ch > 1)
                _ch = 0;
        }
    }
}
