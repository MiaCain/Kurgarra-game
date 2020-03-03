using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public bool CanBeDamaged = true;
    public float InviTime = 1.0f;


    public int maxHealth;
    public int currentHealth;
    public GameObject[] HeartImage;


    public Texture HeartRed;
    public Texture HeartBlue;
    public Texture HeartBlack;
    public GameObject FaceController;

    private RawImage HeartToChange;
    Animator CollAnim;


    //check how many hearts the player has. set the others to black
    void Start()
    {
        CollAnim = FaceController.GetComponent<Animator>();

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

        if (currentHealth >= 2)
        {
            CollAnim.SetBool("LowHealth", false);
        }

        if (currentHealth <= 1)
        {
            Debug.Log("doiajwoidj");
            CollAnim.SetBool("LowHealth", true);
        }

        if (currentHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.tag == "EnemyCom")
            {

                  if (CanBeDamaged == true)
                  {                     
                      CanBeDamaged = false;
                      CollAnim.SetTrigger("Hurt");
                      currentHealth = currentHealth - 1;
                      HeartToChange = HeartImage[currentHealth].GetComponent<RawImage>();
                      HeartToChange.texture = HeartBlue;
                      StartCoroutine(WaitForDamage());

                   }

             }

    }


    private IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(InviTime);
        CanBeDamaged = true;
    }
}
