using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupCounter : MonoBehaviour
{
    [Header("Health Settings")]
    public bool CanBeDamaged = true;
    public float InviTime = 1.5f;

    public int maxHealth;
    public int currentHealth;
    public GameObject[] HeartImage;

    public Texture HeartRed;
    public Texture HeartBlue;
    public Texture HeartBlack;
    public GameObject FaceController;

    private RawImage HeartToChange;
    Animator CollAnim;

    [Header("Money Settings")]
    public Text MoneyOwned;
    public int currentMoney;
    public int maxMoney = 256;

    [Header("Key Settings")]
    public Text KeysOwned;
    public int currentKeys;
    public int maxKeys = 10;

    [Header("Stone Settings")]
    public Text StonesOwned;
    public int currentStones;
    public int maxStones = 32;

    [Header("Grenade Settings")]
    public Text GrenadesOwned;
    public int currentGrenades;
    public int maxGrenades = 8;


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


    private void Update()
    {
        KeysOwned.text = ("x" + currentKeys.ToString());
        if (currentKeys > maxKeys)
        {
            currentKeys = maxKeys;
        }

        StonesOwned.text = ("x" + currentStones.ToString());
        if (currentStones > maxStones)
        {
            currentStones = maxStones;
        }

        MoneyOwned.text = ("x" + currentMoney.ToString());
        if (currentMoney > maxMoney)
        {
            currentMoney = maxMoney;
        }

        GrenadesOwned.text = ("x" + currentGrenades.ToString());
        if (currentGrenades > maxGrenades)
        {
            currentGrenades = maxGrenades;
        }

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
            CollAnim.SetBool("LowHealth", true);
        }

        if (currentHealth <= 0)
        {
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
