using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbyt_move : MonoBehaviour
{
    FloatingJoystick floatingJoystick;
    GameObject step_obj;
    Vector3 direction;

    bool isWork;
    // Start is called before the first frame update
    void Start()
    {
        floatingJoystick = GameObject.FindWithTag("floatingJoystick").GetComponent<FloatingJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = floatingJoystick.Vertical;
        direction.x = floatingJoystick.Horizontal;

        if (direction.magnitude != 0.0f)
        {
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Step();
        }
        if (Input.GetKey(KeyCode.Q) && !isWork)
        {
            Select();
        }
    }

    public void Select()
    {
        step_obj = GameObject.Instantiate(Resources.Load("Step", typeof(GameObject)) as GameObject, transform.position + transform.forward * transform.localScale.z, Quaternion.identity);
        step_obj.transform.SetParent(this.transform);
        isWork = true;
    }

    public void Step()
    {
        if (isWork)
        {
            transform.position = step_obj.transform.position;
            Destroy(step_obj);
            isWork = false;
        }
    }
}
