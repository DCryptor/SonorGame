using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class eat_rabbyt : MonoBehaviour
{
    GameManager gameManager;
    public Text score;
    public int score_value = 0;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        score.text = "" + score_value;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rabbyt"))
        {
            if (gameManager.rabbyts.Contains(other.gameObject))
            {
                // if (gameManager.Rabbyt_Step_True == true && gameManager.Wolf_Step_True == false)
                //{
                // Удаляем объект из списка
                gameManager.rabbyts.Remove(other.gameObject);
                Debug.Log("Объект удален из списка");

                // Преобразуем список в массив
                GameObject[] newObjectsArray = gameManager.rabbyts.ToArray();
                // Присваиваем новый массив к старой переменной
                gameManager.rabbyts = new List<GameObject>(newObjectsArray);
                GameObject fx_death_obj = GameObject.Instantiate(gameManager.fx_death, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), Quaternion.identity);
                Destroy(fx_death_obj, 2f);
                GameObject fx_impact_obj = GameObject.Instantiate(gameManager.fx_impact, other.transform.position, Quaternion.identity);
                Destroy(fx_impact_obj, 2f);
                GameObject fx_plus_obj = GameObject.Instantiate(gameManager.fx_plus, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
                Destroy(fx_plus_obj, 2f);
                Destroy(other.gameObject);
                score_value = score_value + 1;

                if (gameManager.rabbyt_step > 0)
                {
                    gameManager.rabbyt_step = gameManager.rabbyt_step - 1;
                }
                // }
            }
        }
    }
}
