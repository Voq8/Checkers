using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plansza : MonoBehaviour {

    public GameObject CubeBlack;
    public GameObject CubeWhite;


    int width = 8;
    int height = 8;

	// Use this for initialization

	void Start () {
        CreateMap();
	}

    // Update is called once per frame
    void Update()
    {

    }
    void CreateMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (j % 2 == 0)
                {

                    if (i == 1 || i == 3 || i == 5 || i == 7)
                    {
                        CreateWhiteField(CubeWhite, i, j);
                    }
                    else
                    {
                        CreateBlackField(CubeBlack, i, j);
                    }
                }
                else
                {
                    if (i == 1 || i == 3 || i == 5 || i == 7)
                    {
                        CreateBlackField(CubeBlack, i, j);
                    }
                    else
                    {
                        CreateWhiteField(CubeWhite, i, j);
                    }
                }

            }
        }
    }

    void CreateBlackField(GameObject Cube,int i,int j)
    {
        Cube = Instantiate(Cube, new Vector3(i, 0, j), Quaternion.identity);
        Cube.name = "Black_" + i +"_"+j;

        Cube.GetComponent<Field>().x = i;
        Cube.GetComponent<Field>().y = j;

        Cube.transform.SetParent(this.transform);
    }

    void CreateWhiteField(GameObject Cube, int i, int j)
    {
        Cube = Instantiate(Cube, new Vector3(i, 0, j), Quaternion.identity);
        Cube.name = "White_" + i + "_" + j;

        Cube.transform.SetParent(this.transform);
    }

}
