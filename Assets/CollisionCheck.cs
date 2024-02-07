using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    GameManager gameManager;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        sprite.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            sprite.color = Color.red;
            gameManager.collision_wall = true;
            Debug.Log("Collision!");
        }

        if (other.gameObject.CompareTag("rabbyt"))
        {
            if (other.transform.name != transform.parent.name)
            {
                sprite.color = Color.red;
                gameManager.collision_wall = true;
                Debug.Log("Collision!" + transform.parent.name);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            sprite.color = Color.green;
            gameManager.collision_wall = false;
            Debug.Log("Collision Exit!");
        }

        if (other.CompareTag("rabbyt"))
        {
            sprite.color = Color.green;
            gameManager.collision_wall = false;
            Debug.Log("Collision Exit!");
        }
    }
}
