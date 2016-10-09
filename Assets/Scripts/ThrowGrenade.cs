using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {

    public GameObject grenadePrefab;
    private Transform myTransform;
    public float propulsionForce = 30;

	void Start ()
    {
        myTransform = transform;
	}
	
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnGrenade();
        }
	}

    void SpawnGrenade()
    {
       GameObject go =  (GameObject)Instantiate(grenadePrefab, myTransform.TransformPoint(0, 0, 0.5f), myTransform.rotation);
        go.GetComponent<Rigidbody>().AddForce(myTransform.forward * propulsionForce, ForceMode.Impulse);
        //Destroy(go, 10);
    }

   
}
