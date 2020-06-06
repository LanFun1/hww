using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speed;    

    private Animator _animator;
    private bool _face = true;
    private bool is_ground = false;
    private float _jumpcounter = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger("RightRunning");
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            if (_face != true)
                Flip(); 
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                _animator.SetTrigger("RightRunning");
                transform.Translate(Vector2.right * _speed * Time.deltaTime * -1);
                if (_face == true)
                    Flip();
            }
            else
                _animator.SetTrigger("RunningStop");
        }                        
        if ((Input.GetKeyDown(KeyCode.Space) && is_ground))
        {
            _jumpcounter = 1;
            _animator.SetTrigger("RunningStop");
            _rigidbody2d.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.Space) && _jumpcounter == 1))
            {
                _jumpcounter++;
                _animator.SetTrigger("RunningStop");
                _rigidbody2d.velocity = Vector2.zero;
                _rigidbody2d.AddForce(Vector2.up * _force*1.05f, ForceMode2D.Impulse);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {               
        if (col.tag == "Ground") is_ground = true;      
    }
    void OnTriggerExit2D(Collider2D col)
    {              
        if (col.tag == "Ground") is_ground = false;     
    }



    void Flip()
    {
        _face = !_face;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
