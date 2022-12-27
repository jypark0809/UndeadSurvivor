using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    const int _tileSize = 20;
    Collider2D _coll;

    private void Awake()
    {
        _coll= GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = Managers.Game.GetPlayer().transform.position;
        Vector3 tilePos = transform.position;

        // get distance between player and tile
        float distX = Mathf.Abs(playerPos.x - tilePos.x);
        float distY = Mathf.Abs(playerPos.y - tilePos.y);

        // get player's input vector
        Vector3 PlayerDir = Managers.Game.GetPlayer().GetComponent<PlayerController>().GetInputVec();
        float dirX = PlayerDir.x < 0 ? -1 : 1;
        float dirY = PlayerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (distX > distY)
                    transform.Translate(Vector3.right * dirX * (_tileSize * 2));
                else if (distX < distY)
                    transform.Translate(Vector3.up * dirY * (_tileSize * 2));
                break;
            case "Enemy":
                if(_coll.enabled)
                {
                    transform.Translate(PlayerDir * _tileSize + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                }
                break;
        }
    }
}
