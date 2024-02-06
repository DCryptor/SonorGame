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
                // Удаляем объект из списка
                gameManager.rabbyts.Remove(other.gameObject);
                Debug.Log("Объект удален из списка");

                // Преобразуем список в массив
                GameObject[] newObjectsArray = gameManager.rabbyts.ToArray();
                // Присваиваем новый массив к старой переменной
                gameManager.rabbyts = new List<GameObject>(newObjectsArray);
                Destroy(other.gameObject);
                score_value = score_value + 1;
            }
        }
    }
}
