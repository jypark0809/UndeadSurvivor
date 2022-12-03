using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector2 _inputVec;

    [SerializeField]
    float _speed;

    Rigidbody2D _rigid;
    SpriteRenderer _spriteRenderer;
    Animator _anim;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _inputVec.x = Input.GetAxisRaw("Horizontal"); // x : -1, 0, 1
        _inputVec.y = Input.GetAxisRaw("Vertical"); // y : -1, 0, 1
    }

    void FixedUpdate()
    {
        Vector2 nextVec = _inputVec.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
    }

    void LateUpdate()
    {
        _anim.SetFloat("Speed", _inputVec.magnitude);

        // Flip Player
        if (_inputVec.x != 0)
        {
            _spriteRenderer.flipX = (_inputVec.x < 0);
        }
    }
}
