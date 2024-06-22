using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ground : MonoBehaviour
{
    private Player player;
    private BoxCollider boxCollider;
    public bool shouldGenerateGround = true;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity * Time.fixedDeltaTime;

        if (transform.position.x < -16)
        {
            Destroy(gameObject);
            return;
        }

        if (shouldGenerateGround && transform.position.x < 40)
        {
            generateGround();
            shouldGenerateGround = false;
        }

        transform.position = pos;
    }

    void generateGround()
    {
        float y = Random.Range(Math.Max(transform.position.y - 4.5f, 3.0f), Math.Min(transform.position.y + 4.5f, 10.0f));
        Instantiate(gameObject, new Vector3(80.0f, y, -0.501f), transform.rotation);

    }
}
