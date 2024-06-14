using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Player player;

    public float groundHeight;
    BoxCollider2D collider;
    float screenRight;
    float groundRight;
    bool didGenerateGround;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        collider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (collider.size.y / 2);
        screenRight = Camera.main.transform.position.x * 2;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        groundRight = transform.position.x + (collider.size.x / 2);
        if (!didGenerateGround)
        {
            if (groundRight < screenRight)
            {
                generateGround();
            }
        }
    }

    void generateGround()
    {
        didGenerateGround = true;

        GameObject go = Instantiate(gameObject);
        Vector2 pos;
        pos.x = screenRight + 10;
        pos.y = transform.position.y;
        go.transform.position = pos;

        Ground ground = go.GetComponent<Ground>();
        ground.groundHeight = go.transform.position.y + (ground.collider.size.y / 2);
    }
}
