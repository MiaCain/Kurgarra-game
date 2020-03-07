using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item Guide:
//0 Nothing
//1 Stones
//2 Grenades
//3 Shield
//4 Lyre
//5 Crook
//6 Flail
//7 Head
//8 Headgear
//9 Boat
//10 Tablet
//11 Statue
//12 Ring
//13 Sandal
//14 Ladder
//15 Jar
//16 Key

public class UseItem : MonoBehaviour
{
    [Header("General")]
    public int ItemType;
    public PickupCounter PickupCounter;
    public CharacterControllerOldSword CharContr;
    public ItemsOwned ItemOwn;

    [Header("GrenadeInput")]
    public GameObject GrenadeItem;
    public float GrenadeVelocity;

    [Header("StoneInput")]
    public GameObject StoneItem;
    public float StoneVelocity;

    //Non public
    private bool IsSpawning = false;
    private int CharMovement;
    private bool OwnsItem;

    private void Start()
    {
        //apply scripts
        PickupCounter = this.gameObject.GetComponent<PickupCounter>();
        CharContr = this.gameObject.GetComponent<CharacterControllerOldSword>();
    }

    // Update is called once per frame
    void Update()
    {
        //track direction
        CharMovement = CharContr.movementDirection;

        //check if item is owned
        if(ItemOwn.hasItem[ItemType - 1])
        {
            OwnsItem = true;
        }

        else
        {
            OwnsItem = false;
        }

        //get input
        if (Input.GetButtonDown("a") && OwnsItem)
        {
            IsSpawning = true;

            if(ItemType == 0)
            {
                IsSpawning = false;
            }

            else if (ItemType == 1)
            {
                if (PickupCounter.currentStones > 0)
                {
                    SpawnItem(StoneItem, StoneVelocity);
                    PickupCounter.currentStones = PickupCounter.currentStones - 1;
                }
            }

            else if (ItemType == 2)
            {
                if(PickupCounter.currentGrenades > 0)
                {
                    SpawnItem(GrenadeItem, GrenadeVelocity);
                    PickupCounter.currentGrenades = PickupCounter.currentGrenades - 1;
                }
            }


        }
    }

    void SpawnItem(GameObject ItemToSpawn, float speed)
    {
        GameObject Item;
        Rigidbody2D ItemVel;

        //South
        if (IsSpawning && CharMovement == 1)
        {
            Item = Instantiate(ItemToSpawn, transform.position + new Vector3(0, -1, 0), transform.rotation);
            ItemVel = Item.GetComponent<Rigidbody2D>();
            ItemVel.velocity = (new Vector2(speed * 0, speed * -1));
            IsSpawning = false;
        }

        //North
        if (IsSpawning && CharMovement == 2)
        {
            Item = Instantiate(ItemToSpawn, transform.position + new Vector3(0,1,0), transform.rotation);
            ItemVel = Item.GetComponent<Rigidbody2D>();
            ItemVel.velocity = (new Vector2(speed * 0, speed * 1));
            IsSpawning = false;
        }

        //West
        if (IsSpawning && CharMovement == 3)
        {
            Item = Instantiate(ItemToSpawn, transform.position + new Vector3(-1, 0, 0), transform.rotation);
            ItemVel = Item.GetComponent<Rigidbody2D>();
            ItemVel.velocity = (new Vector2(speed * -1, speed * 0));
            IsSpawning = false;
        }

        //East
        if (IsSpawning && CharMovement == 4)
        {
            Item = Instantiate(ItemToSpawn, transform.position + new Vector3(1, 0, 0), transform.rotation);
            ItemVel = Item.GetComponent<Rigidbody2D>();
            ItemVel.velocity = (new Vector2(speed * 1, speed * 0));
            IsSpawning = false;
        }
    }


}
