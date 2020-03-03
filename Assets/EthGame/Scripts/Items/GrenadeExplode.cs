using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplode : MonoBehaviour
{
    public GameObject Explosions;
    public bool isExploding;

    public void Update()
    {
        if (isExploding == true)
        {
            Instantiate(Explosions, transform.position, Quaternion.identity);
            isExploding = false;
            Destroy(this.gameObject);
        }
    }

    public void Explode()
    {
        isExploding = true;
    }

   }
