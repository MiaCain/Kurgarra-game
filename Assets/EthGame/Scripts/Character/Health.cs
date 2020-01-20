using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject[] HeartImage;


    public Texture HeartRed;
    public Texture HeartBlue;
    public Texture HeartBlack;
    public GameObject FaceController;

    private RawImage HeartToChange;


    //check how many hearts the player has. set the others to black
    void Start()
    {
        int BlackHearts = 12 - maxHealth;
        for (int i = maxHealth; i < 12; i++)
        {
            HeartToChange = HeartImage[i].GetComponent<RawImage>();
            HeartToChange.texture = HeartBlack;
        }
    }

    //set currentHealth hearts to red, check for damage, update currentHealth
    void Update()
    {
        for (int i = 0; i < currentHealth; i++)
        {
            HeartToChange = HeartImage[i].GetComponent<RawImage>();
            HeartToChange.texture = HeartRed;          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyCom")
        {
            Animator CollAnim = FaceController.GetComponent<Animator>();
            CollAnim.SetTrigger("Hurt");
            currentHealth = currentHealth - 1;
            HeartToChange = HeartImage[currentHealth].GetComponent<RawImage>();
            HeartToChange.texture = HeartBlue;
        }

    }
}
