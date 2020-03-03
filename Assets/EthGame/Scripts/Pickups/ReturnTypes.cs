using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTypes : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("int: " + ReturnInt() + ", float: " + ReturnFloat() + ", string: " + ReturnString());
    }

    void ReturnNothing()
    {

    }

    int ReturnInt()
    {
        return 1;
    }

    float ReturnFloat()
    {
        return 0.1f;
    }

    string ReturnString()
    {
        return "how dee doo";
    }
}
