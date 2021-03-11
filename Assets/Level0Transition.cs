using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level0Transition : MonoBehaviour
{
    public Scene scene;

    void OnTriggerEnter2D(Collider2D cols)
    {
        if (cols.gameObject.name.Equals("physics"))
        {
            if (cols.transform.parent.gameObject.name.Equals("player"))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
