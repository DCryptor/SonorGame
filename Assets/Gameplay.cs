using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class Gameplay : MonoBehaviour
{
    public GameObject wolf;
    public GameObject[] rabbyts;
    public GameObject selected_rabbyt = null;
    public GameObject selected_wolf = null;
    public bool isWork = false;
    public GameObject inst_step_prefab;
    public GameObject inst_step_prefab_wolf;
    // Start is called before the first frame update
    void Start()
    {

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
                        inst_step_prefab.transform.rotation = selected_rabbyt.transform.rotation;
                        selected_rabbyt.transform.rotation = Quaternion.Euler(0f, selected_rabbyt.transform.rotation.y + Input.GetAxis("MouseX") + Input.GetAxis("MouseY"), 0f);
                    }
                    if (hit.collider.gameObject.name == wolf.name)
                    {
                        selected_wolf = hit.collider.gameObject;
                    }
                }
            }
        }

        if (selected_rabbyt)
        {
            if (!isWork)
            {
                DoWork();
            }
        }
        if (selected_wolf)
        {
            if (!isWork)
            {
                DoWorkWolf();
            }
        }
    }
    void DoWork()
    {
        inst_step_prefab = GameObject.Instantiate(Resources.Load("Step", typeof(GameObject)) as GameObject, new Vector3(selected_rabbyt.transform.position.x, selected_rabbyt.transform.position.y, selected_rabbyt.transform.position.z + 0.9817141f), Quaternion.identity);
        inst_step_prefab.transform.SetParent(selected_rabbyt.transform);
        isWork = true;
    }
    void DoWorkWolf()
    {
        inst_step_prefab_wolf = GameObject.Instantiate(Resources.Load("StepWolf", typeof(GameObject)) as GameObject, new Vector3(selected_wolf.transform.position.x, selected_wolf.transform.position.y, selected_wolf.transform.position.z - 1.874386f), Quaternion.identity);
        inst_step_prefab_wolf.transform.SetParent(selected_wolf.transform);
        isWork = true;
    }
}
