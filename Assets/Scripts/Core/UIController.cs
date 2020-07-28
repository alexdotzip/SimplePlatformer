using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;


    public Image heart1, heart2, heart3;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    //public int heartContainers;
    //public int playerCurrentHealth;

    public Text myGemText;

    public Image fadeScreen;
    public float fadeSpeed;

    private bool shouldFadeToBlack, shouldFadeFromBlack;
     

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        UpdateGemCount();
        FadeFromBlack();
    }
    void Update()
    {
        if(shouldFadeToBlack)
        {
            
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            
            if (fadeScreen.color.a == 1f)
            {
                
                shouldFadeToBlack = false;
            }


        }

        if (shouldFadeFromBlack)
        {

            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {

                shouldFadeFromBlack = false;
            }


        }
    }

    public void UpdateHearts()
    {


        switch (PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;

            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfFullHeart;
                break;

            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;

            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = halfFullHeart;
                heart3.sprite = emptyHeart;
                break;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            case 1:
                heart1.sprite = halfFullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

            default:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;


        }

    }

    public void UpdateGemCount()
    {
        myGemText.text = LevelManager.instance.gemsCollected.ToString();
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }

}
