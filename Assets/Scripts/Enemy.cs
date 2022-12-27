using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseController
{
    [SerializeField]
    float _speed;

    [SerializeField]
    Rigidbody2D _target;

    bool _isLive = true;

    Rigidbody2D _rigid;
    SpriteRenderer _sp;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        WorldObjectType = Define.WorldObject.Enemy;
    }

    void Start()
    {
        _target = Managers.Game.GetPlayer().GetComponent<Rigidbody2D>(); ;
    }

    void FixedUpdate()
    {
        if (!_isLive)
            return;

        Vector2 dirVec = _target.position - _rigid.position;
        Vector2 nextVec = dirVec.normalized * _speed * Time.fixedDeltaTime;
        _rigid.MovePosition(_rigid.position + nextVec);
        _rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!_isLive)
            return;

        _sp.flipX = (_target.position.x < _rigid.position.x);
    }
}
