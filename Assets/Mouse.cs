using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Unit selectedUnit;
    int positionY = 0;
    int positionX = 0;

    int[] destinyPositionX = new int[4];
    int[] destinyPositionZ =  new int[4];

    int positionObjToDestroyX = 0;
    int positionObjToDestroyZ = 0;
    GameObject[] Enemies = new GameObject[5];
    bool CanHit = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo;

        if (Physics.Raycast(ray, out rayHitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject HitObject = rayHitInfo.collider.transform.parent.gameObject;

                if (HitObject.GetComponentInParent<Unit>() != null)
                {
                    MouseOver_Unit(HitObject);
                }

                if (selectedUnit != null)
                {
                    MoveWhitePION(HitObject);
                    MoveBlackPION(HitObject);

                }
            }
        }
    }


    void MoveWhitePION(GameObject HitObject)
    {
        CanHit = false;
        if (selectedUnit.transform.parent.name == "WhitePiony")
        {
            FindPositionObj(selectedUnit);
            FindAroundEnemies("PionB_");

            if (CanHit == true)
            {
                if (HitObject.GetComponentInParent<Field>() != null)
                {
                    for(int i =0;i<4; i++)
                    {
                        Debug.Log(destinyPositionX[i]+ "=="+ (int)Mathf.Round(HitObject.transform.position.x)+ " &&" + destinyPositionZ[i]+ " ==" +(int)Mathf.Round(HitObject.transform.position.z));

                        if (destinyPositionX[i] == (int)Mathf.Round(HitObject.transform.position.x) && destinyPositionZ[i] == (int)Mathf.Round(HitObject.transform.position.z))
                        {       
                            selectedUnit.destination = HitObject.transform.position;
                            selectedUnit.destination.y = 0.2f;
                            ChangeName(selectedUnit, "PionW_");
                            i = 4;
                        }
                    }
                }
            }
            else if (CanHit == false)
            {
                if (HitObject.GetComponentInParent<Field>() != null)
                {
                    if (selectedUnit.CheckDistanceWhite(HitObject, selectedUnit) == true)
                    {
                        selectedUnit.destination = HitObject.transform.position;
                        selectedUnit.destination.y = 0.2f;
                        ChangeName(selectedUnit, "PionW_");
                    }
                }
            }
        }
    }

    void MoveBlackPION(GameObject HitObject)
    {
        CanHit = false;
        if (selectedUnit.transform.parent.name == "BlackPiony")
        {
            FindPositionObj(selectedUnit);
            FindAroundEnemies("PionW_");

            if (CanHit == true)
            {
                if (HitObject.GetComponentInParent<Field>() != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Debug.Log(destinyPositionX[i] + "==" + (int)Mathf.Round(HitObject.transform.position.x) + " &&" + destinyPositionZ[i] + " ==" + (int)Mathf.Round(HitObject.transform.position.z));

                        if (destinyPositionX[i] == (int)Mathf.Round(HitObject.transform.position.x) && destinyPositionZ[i] == (int)Mathf.Round(HitObject.transform.position.z))
                        {
                            selectedUnit.destination = HitObject.transform.position;
                            selectedUnit.destination.y = 0.2f;
                            ChangeName(selectedUnit, "PionB_");
                            i = 4;
                        }
                    }
                }
            }
            else if (CanHit == false)
            {
                if (HitObject.GetComponentInParent<Field>() != null)
                {
                    if (selectedUnit.CheckDistanceWhite(HitObject, selectedUnit) == true)
                    {
                        selectedUnit.destination = HitObject.transform.position;
                        selectedUnit.destination.y = 0.2f;
                        ChangeName(selectedUnit, "PionB_");
                    }
                }
            }
        }
    }

    void MouseOver_Unit(GameObject HitObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit = HitObject.GetComponent<Unit>();
        }
    }

    void FindPositionObj(Unit selectedUnit)
    {
        positionY = int.Parse(selectedUnit.name[6].ToString());
        positionX = int.Parse(selectedUnit.name[8].ToString());
    }

    void FindAroundEnemies(string EnPionWorB)
    {
        int y = positionY - 1;
        int x = positionX - 1;
        Enemies[0] = GameObject.Find(EnPionWorB + y + "_" + x);
        

        y = positionY + 1;
        x = positionX - 1;
        Enemies[1] = GameObject.Find(EnPionWorB + y + "_" + x);
        

        y = positionY - 1;
        x = positionX + 1;
        Enemies[2] = GameObject.Find(EnPionWorB + y + "_" + x);
        

        y = positionY + 1;
        x = positionX + 1;
        Enemies[3] = GameObject.Find(EnPionWorB + y + "_" + x);
        

        HitObjcet();
    }

    void HitObjcet()
    {
        for (int i = 0; i <4; i++)
        {
            if (Enemies[i] != null)
            {
                if (i == 3)
                {
                    if (FindObjInPostion((positionY + 2), (positionX + 2)) == false)
                    {
                        CanHit = true;
                        destinyPositionX[3] = (positionY + 2);
                        destinyPositionZ[3] = (positionX + 2);
                    }
                    else
                    {
                        CanHit = false;
                    }
                }
                else if (i == 2)
                {
                    if (FindObjInPostion((positionY - 2), (positionX + 2)) == false)
                    {
                        CanHit = true;
                        destinyPositionX[2] = (positionY - 2);
                        destinyPositionZ[2] = (positionX + 2);
                    }
                    else
                    {
                        CanHit = false;
                    }
                }
                else if (i == 1)
                {
                    if (FindObjInPostion((positionY + 2), (positionX - 2)) == false)
                    {
                        CanHit = true;
                        destinyPositionX[1] = (positionY + 2);
                        destinyPositionZ[1] = (positionX - 2);
                    }
                    else
                    {
                        CanHit = false;
                    }
                }
                else if (i == 0)
                {
                    if (FindObjInPostion((positionY - 2), (positionX - 2)) == false)
                    {
                        CanHit = true;
                        destinyPositionX[0] = (positionY - 2);
                        destinyPositionZ[0] = (positionX - 2);
                    }
                    else
                    {
                        CanHit = false;
                    }
                }

            }
        }
    }

    bool FindObjInPostion(int x, int z)
    {
        GameObject obB = GameObject.Find(("PionB_" + x + "_" + z));
        GameObject obW = GameObject.Find((("PionW_" + x + "_" + z)));

        if (obB == null && obW == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    string CheckName()
    {
        if (selectedUnit.name[4].ToString() == "W")
        {
            return "PionW_";
        }
        else
        {
            return "PionB_";
        }

    }

    void ChangeName(Unit selected, string name)
    {
        selected.name = name + selected.destination.x + "_" + selected.destination.z;
    }

    void FindandDestroyObj(string nameobjtodestryo)
    {
        GameObject GO = GameObject.Find(nameobjtodestryo);
        Debug.Log(nameobjtodestryo);
        Destroy(GO);
    }

    void Destroy(string nameobj,int x,int z)
    {
        int X = (int)selectedUnit.transform.position.x + x;
        int Z = (int)selectedUnit.transform.position.z + z;
        Debug.Log(X+ " "+ Z);

        FindandDestroyObj(nameobj + X + "_" + Z);
    }
}