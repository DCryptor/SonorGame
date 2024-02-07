using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheckWolf : MonoBehaviour
{
    GameManager gameManager;
    SpriteRenderer sprite;

    public bool isStepped = false;
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
            gameManager.collision_wall = true;
            sprite.color = Color.red;
            Debug.Log("Collision!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            gameManager.collision_wall = false;
            sprite.color = Color.green;
            Debug.Log("Collision Exit!");
        }
    }
}
