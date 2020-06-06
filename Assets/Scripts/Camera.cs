using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private Vector3 offset;
    private void Start()
    {
        offset = Character.transform.position + transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Character.transform.position + (offset / 10);
    }
}
