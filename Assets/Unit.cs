using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Vector3 destination;
    float speed = 5;
    public float X = 0;
    public float Z = 0;
    // Use this for initialization
    void Start () {
        destination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = destination - transform.position;
        Vector3 valocity = direction.normalized * speed * Time.deltaTime;
        valocity = Vector3.ClampMagnitude(valocity, direction.magnitude);
        transform.Translate(valocity);
	}
    public bool CheckDistanceWhite(GameObject go, Unit selected)
    {
        Vector3 Check = selected.destination - go.transform.position;
        float X = Check.x;
        float Z = Check.z;

        if (X >= -1.5 && X <= -0.5 && Z >= - 1.5 && Z <= 1.5) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckDistanceBlack(GameObject go, Unit selected)
    {
        Vector3 Check = selected.destination - go.transform.position;
        float X = Check.x;
        float Z = Check.z;

        if (X >= 0.5 && X <= 1.5 && Z >= -1.5 && Z <= 1.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckDistance2x(GameObject go, Unit selected)
    {
        Vector3 v3 = selected.destination - go.transform.position;
        X = v3.x;
        Z = v3.z;

        if (X >= -2.5  && X <= 2.5 && Z >= -2.5 && Z <= 2.5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
