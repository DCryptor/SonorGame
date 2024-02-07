using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rabbyt_points : MonoBehaviour
{
    public bool point_1, point_2, point_3;
    GameManager gameManager;

    public bool isStepped = false;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("point1") && !point_1)
        {
            point_1 = true;
            gameManager.RabbytPoint = gameManager.RabbytPoint + 1;
        }
        if (other.CompareTag("point2") && !point_2)
        {
            point_2 = true;
            gameManager.RabbytPoint = gameManager.RabbytPoint + 1;
        }
        if (other.CompareTag("point3") && !point_3)
        {
            point_3 = true;
            gameManager.RabbytPoint = gameManager.RabbytPoint + 1;
            //gameManager.RabbytWinPoint = gameManager.RabbytWinPoint + 1;
            if (gameManager.rabbyts.Contains(this.gameObject))
            {
                // Удаляем объект из списка
                gameManager.rabbyts.Remove(this.gameObject);
                Debug.Log("Объект удален из списка");

                // Преобразуем список в массив
                GameObject[] newObjectsArray = gameManager.rabbyts.ToArray();
                // Присваиваем новый массив к старой переменной
                gameManager.rabbyts = new List<GameObject>(newObjectsArray);
                Destroy(this.gameObject);
                if (gameManager.rabbyt_step > 0)
                {
                    gameManager.rabbyt_step = gameManager.rabbyt_step - 1;
                }
            }
        }
    }
}
