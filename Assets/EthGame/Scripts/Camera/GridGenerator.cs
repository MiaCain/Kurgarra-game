using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;
    public GameObject MainCam;
    public GameObject gridPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject gridEmpty = Instantiate(gridPrefab, new Vector3 (transform.position.x + i * 12, transform.position.y + j * 8, -5), Quaternion.identity);
                gridEmpty.GetComponent<EnterGridSquare>().MainCam = this.MainCam;
            }
        }
    }
}
