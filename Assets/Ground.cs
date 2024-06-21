using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Player player;

    public float groundHeight;
    public float groundRight;
    public BoxCollider2D collider;
    public float screenRight;
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
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 10.0f * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime;

        groundRight = transform.position.x + (collider.size.x / 2);

        if (groundRight < 0)
        {
            Destroy(gameObject);
            return;
        }

        if (!didGenerateGround && groundRight < screenRight)
        {
            didGenerateGround = true;
            generateGround();
        }

        transform.position = pos;
    }

    void generateGround()
    {

        GameObject go = Instantiate(gameObject);
        BoxCollider2D goCollider = go.GetComponent<BoxCollider2D>();
        Vector2 pos;
        pos.x = screenRight + 30;
        pos.y = transform.position.y;
        go.transform.position = pos;

        Ground ground = go.GetComponent<Ground>();
        ground.groundHeight = go.transform.position.y + (ground.collider.size.y / 2);
    }
}