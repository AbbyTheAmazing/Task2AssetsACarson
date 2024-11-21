using UnityEngine;

public class GunPewPew : MonoBehaviour
{
    public GameObject originPoint;
    public GameObject projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Instantiate(projectile,originPoint.transform.position,originPoint.transform.rotation);
        }
    }
    
}
