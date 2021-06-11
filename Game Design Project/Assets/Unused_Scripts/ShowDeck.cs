/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDeck : MonoBehaviour
{
   
    public Text sizeText;
    public PlayerDeck deck;
    public Button warButton;
    private int size;
    public Image image;


    void Start()
    {
        warButton.interactable = false;
    }
    void Update()
    {
        size = deck.getSize();
        sizeText.text = "Grandezza deck: " + size;
        image.fillAmount = (float)(size * 0.1);
        isInteractable(warButton);

    }
    public void isInteractable(Button button)
    {
        if ((size == 10))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;

        }
    }
}
*/