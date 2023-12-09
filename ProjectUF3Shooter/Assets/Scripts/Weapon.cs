using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private ChangeTextEvent changeTextEvent;
    public delegate void DisplayDelegate();
    public DisplayDelegate DisplayEvent;
    private bool Recharging;

    [SerializeField]
    private PlayerInfo myInformation;

    [SerializeField]
    [DefaultValue(50f)]
    private float Range;

    [SerializeField]
    [DefaultValue(2500f)]
    private float Moment;

    [SerializeField]
    private Camera MyCamera;
    void Awake()
    {
        Recharging = false;
        myInformation.Bullets = 5;
        myInformation.Ammunition = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && myInformation.Bullets > 0)
        {
            
            Shoot();
        }
        else if (Input.GetKey(KeyCode.R) && myInformation.Bullets == 0 && myInformation.Ammunition > 0)
        {
            if(!Recharging) {
                DisplayEvent?.Invoke();
                StartCoroutine(Recharge());
            }
        }
    }
    private void Shoot()
    {
        RaycastHit raycastInfo;
        if (Physics.Raycast(MyCamera.transform.position, MyCamera.transform.forward, out raycastInfo, 500f))
        {
            
            //The name of the target
            print(raycastInfo.transform.tag);
            Debug.DrawLine(MyCamera.transform.position, raycastInfo.point, Color.red, 1f);
            if (raycastInfo.transform.tag == "Enemy")
            {
                raycastInfo.transform.gameObject.GetComponent<NavMeshAgent>().enabled= false;
                raycastInfo.transform.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(-raycastInfo.normal * Moment, raycastInfo.point);
                raycastInfo.transform.gameObject.GetComponent<NavMeshAgent>().enabled = true;
                raycastInfo.transform.gameObject.GetComponent<Enemy>().Hit();
            }
             else if(raycastInfo.transform.tag == "physic_object")
            {
                raycastInfo.transform.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(-raycastInfo.normal * Moment, raycastInfo.point);
            }
            StartCoroutine(Explosion(raycastInfo.point));
            myInformation.Bullets--;
            if (myInformation.Bullets == 0 && myInformation.Ammunition > 0)
            {
                DisplayEvent?.Invoke();
                changeTextEvent?.Raise("You don't have more bullets, press 'R' to reload you wapon",Color.red);
            }
            else if (myInformation.Bullets == 0)
            {
                DisplayEvent?.Invoke();
                changeTextEvent?.Raise("You dont have more ammunition.", Color.red);
            }
        }
    }
    IEnumerator Recharge()
    {
        this.Recharging = true;
        DisplayEvent?.Invoke();
        changeTextEvent?.Raise("Reloading", Color.white);
        yield return new WaitForSeconds(3f);
        this.myInformation.Bullets = 5;
        this.myInformation.Ammunition--;
        this.Recharging = false;
        changeTextEvent?.Raise("Reloaded", Color.white);
        yield return new WaitForSeconds(1.1f);
        DisplayEvent?.Invoke();
    }
    IEnumerator Explosion(Vector3 position_of_target)
    {
        GameObject explosion = transform.GetChild(2).gameObject;
        explosion.SetActive(true);
        explosion.transform.position = position_of_target;
        yield return new WaitForSeconds(0.2f);
        explosion.SetActive(false);
    }
}
