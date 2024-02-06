using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCheckWolf : MonoBehaviour
{
    GameManager gameManager;
    Color color;

    public bool isStepped = false;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        color = GetComponent<Renderer>().material.color = Color.green;
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
            color = GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Collision!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            gameManager.collision_wall = false;
            color = GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Collision Exit!");
        }
    }
}
