using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public Canvas canvas;
    public GameObject healthbar;
    public UnityEngine.UI.Text healthText;

    // Start is called before the first frame update
    void Start()
    {
    //     foreach (Transform children in canvas.transform)
    //     {
    //         //expand this pattern to all objects within, that youll need a handle for

    //         if (children.gameObject.name.Equals("healthbar"))
    //             healthbar = children.gameObject;
    //     }

        
    //     //TODO: CHANGE THIS INTO A LEGIT BAR LMAO
    //     healthText = healthbar.GetComponentInChildren<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthbar();
    }

    void UpdateHealthbar()
    {
        healthText.text = PlayerStatusController.psc.currHealth.ToString();
    }
}
