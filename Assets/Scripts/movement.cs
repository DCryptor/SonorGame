using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool isWork = false;
    public GameObject step_model;

    void OnMouseDrag()
    {
        if (!isWork)
        {
            DoWork();
        }
    }

    void OnMouseDown()
    {
        Destroy(step_model);
        isWork = false;
    }

    void DoWork()
    {
        step_model = GameObject.Instantiate(Resources.Load("Step", typeof(GameObject)) as GameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.9817141f), Quaternion.identity);
        isWork = true;
    }
}