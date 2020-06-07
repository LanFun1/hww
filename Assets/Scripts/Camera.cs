using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private Vector3 _offset;
    private void Start()
    {
        _offset = Character.transform.position + transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Character.transform.position + (_offset / 10);
    }
}
