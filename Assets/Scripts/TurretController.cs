using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class TurretController : MonoBehaviour
{
    public Transform tx_turret, ty_turret;
    private Quaternion qx_turret, qy_turret;
    private Vector3 vx_turret, vy_turret;
    public Animator animController;
    public GameObject bullet;
    public Transform bulletPoint;
 

    public float forceShooting;
    [Range(0, 100)]
    [SerializeField]

    private float rotSpeed;
    void Start() {

    }
    int count = 0;
    public float rate = 1;
    float lastRate = 0.0f;
    float x, y, z;
    float xn, yn;
    void Update() {
       
               
                vx_turret.y += BlueController.AxisBlue_X();
                // print(Convert.ToDecimal( BlueController.data.Replace("p", "")));
            

            

                vy_turret.z += BlueController.AxisBlue_Y();
              //  print(yn);
                //print("roll");
                // print(yn);
            

       
        
        


        //Axis x 
      
           
        
        
        vx_turret.y = Mathf.Clamp(vx_turret.y, -90, 90);
        qx_turret = Quaternion.Euler(vx_turret);

        tx_turret.rotation = Quaternion.Lerp(tx_turret.rotation, qx_turret, 0.05f);

        //Axis Y

        
         
        
       
        vy_turret.z = Mathf.Clamp(vy_turret.z, -50, 20);
        vy_turret.y = vx_turret.y;
        qy_turret = Quaternion.Euler(vy_turret);
        ty_turret.rotation = Quaternion.Lerp(ty_turret.rotation, qy_turret, 0.05f);

     

        if (BlueController.BlueLeft())
        {

            Shooting();
            count++;

        }
         
       
        
        





    }

    private void Shooting()
    {
        if (Time.time > rate + lastRate) {
            animController.SetTrigger("shoot");
          
            GameObject ins = (GameObject)Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
            ins.GetComponent<Rigidbody>().velocity = bulletPoint.forward * forceShooting;
            Destroy(ins, 5000);
            lastRate = Time.time;

        }





    }

}
