using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    public ControllerManager manager;

    private void Start()
    {
        manager.getCards();

    }
}
