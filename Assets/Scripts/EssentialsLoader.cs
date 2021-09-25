using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{

    public GameObject UICanvas;
    public GameObject Player;
    public GameObject Manager;

    // Use this for initialization
    void Start()
    {
        if (UIFade.instance == null) UIFade.instance = Instantiate(UICanvas).GetComponent<UIFade>();
        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(Player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if(GameManager.instance == null)
        {
            Instantiate(Manager);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
