using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private CarController carController;
    private void Start()
    {
        carController = CarController.Instance;
    }
    private void OnTriggerEnter2D(Collider2D colInfo)
    {
        if (colInfo.CompareTag("Collidable"))
        {
            carController.OnDeath();
        }else if (colInfo.CompareTag("Finish"))
        {
            carController.OnWin();
        }
    }
}
