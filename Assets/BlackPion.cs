using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPion : MonoBehaviour {
    public GameObject PionBlack;
    // Use this for initialization
    void Start () {
        CreatePionyBlack();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void CreatePionyBlack()
    {
        for (int i = 5; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (i % 2 ==1)
                {
                    if (j%2==1)
                    {
                        CreatePion(PionBlack, "PionB_", i, (float)(0.2), j);
                    }

                }
                else if (j % 2 == 0)
                {
                    CreatePion(PionBlack, "PionB_", i, (float)(0.2), j);
                }

            }
        }
    }
    void CreatePion(GameObject Cube, string nameWhiteOrBlack, int i, float y, int j)
    {
        Cube = Instantiate(Cube, new Vector3(i, y, j), Quaternion.identity);
        Cube.name = nameWhiteOrBlack + i + "_" + j;
        

        Cube.transform.SetParent(this.transform);
    }

}
