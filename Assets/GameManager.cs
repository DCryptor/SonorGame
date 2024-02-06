using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private VariableJoystick joystick_rabbyt;
    private VariableJoystick joystick_wolf;
    private Vector3 direction_rabbyt;
    private Vector3 direction_wolf;
    public GameObject[] rabbyts;
    public GameObject wolf;
    public GameObject selected_rabbyt;
    public GameObject selected_wolf;

    public GameObject step_obj_rabbyt;
    public GameObject step_obj_wolf;
    public bool isWork;

    public bool collision_wall;
    // Start is called before the first frame update
    void Start()
    {
        joystick_rabbyt = GameObject.FindWithTag("joystick_rabbyt").GetComponent<VariableJoystick>();
        joystick_wolf = GameObject.FindWithTag("joystick_wolf").GetComponent<VariableJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                for (int i = 0; i < rabbyts.Length; i++)
                {
                    if (hit.collider.gameObject.name == rabbyts[i].name)
                    {
                        selected_rabbyt = hit.collider.gameObject;

                        if (step_obj_rabbyt)
                        {
                            SetStepObjRabbyt();
                        }
                        else
                        {
                            CreateStepObjRabbyt();
                        }
                    }
                }

                if (hit.collider.gameObject.name == wolf.name)
                {
                    selected_wolf = hit.collider.gameObject;

                    if (!step_obj_wolf)
                    {
                        CreateStepObjWolf();
                    }
                }
            }
        }

        direction_rabbyt.z = joystick_rabbyt.Vertical;
        direction_rabbyt.x = joystick_rabbyt.Horizontal;

        direction_wolf.z = -joystick_wolf.Vertical;
        direction_wolf.x = -joystick_wolf.Horizontal;


        if (selected_rabbyt)
        {
            if (direction_rabbyt.magnitude != 0.0f)
            {
                Quaternion rot = Quaternion.LookRotation(direction_rabbyt);
                selected_rabbyt.transform.rotation = Quaternion.Slerp(selected_rabbyt.transform.rotation, rot, 10 * Time.deltaTime);
            }
        }

        if (selected_wolf)
        {
            if (direction_wolf.magnitude != 0.0f)
            {
                Quaternion rot = Quaternion.LookRotation(direction_wolf);
                selected_wolf.transform.rotation = Quaternion.Slerp(selected_wolf.transform.rotation, rot, 10 * Time.deltaTime);
            }
        }
    }
    public void CreateStepObjRabbyt()
    {
        if (!isWork)
        {
            step_obj_rabbyt = GameObject.Instantiate(Resources.Load("Step", typeof(GameObject)) as GameObject, selected_rabbyt.transform.position + selected_rabbyt.transform.forward * selected_rabbyt.transform.localScale.z, Quaternion.identity);
            step_obj_rabbyt.transform.SetParent(selected_rabbyt.transform);
            isWork = true;
        }
    }

    public void SetStepObjRabbyt()
    {
        if (isWork)
        {
            step_obj_rabbyt.transform.SetParent(selected_rabbyt.transform);
            step_obj_rabbyt.transform.position = selected_rabbyt.transform.position + selected_rabbyt.transform.forward * selected_rabbyt.transform.localScale.z;
        }
    }

    public void StepRabbyt()
    {
        if (isWork && !collision_wall)
        {
            selected_rabbyt.transform.position = step_obj_rabbyt.transform.position;
            Destroy(step_obj_rabbyt);
            isWork = false;
        }
    }

    public void CreateStepObjWolf()
    {
        if (!isWork)
        {
            step_obj_wolf = GameObject.Instantiate(Resources.Load("StepWolf", typeof(GameObject)) as GameObject, selected_wolf.transform.position + selected_wolf.transform.forward * selected_wolf.transform.localScale.z, Quaternion.identity);
            step_obj_wolf.transform.SetParent(selected_wolf.transform);
            isWork = true;
        }
    }

    public void SetStepObjWolf()
    {
        if (isWork)
        {
            step_obj_wolf.transform.SetParent(selected_wolf.transform);
            step_obj_wolf.transform.position = selected_wolf.transform.position + selected_wolf.transform.forward * selected_wolf.transform.localScale.z;
        }
    }

    public void StepWolf()
    {
        if (isWork && !collision_wall)
        {
            selected_wolf.transform.position = step_obj_wolf.transform.position;
            Destroy(step_obj_wolf);
            isWork = false;
        }
    }
}
