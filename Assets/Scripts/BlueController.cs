using System;
using System.Text;
using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    public SerialPort sp = new SerialPort("\\\\.\\COM5", 38400);
    public bool blue = false;
    public static string data = string.Empty;
    private static float x, xn, y, yn;
    void Start()
    {
        
        if (!sp.IsOpen)
        {
            print("Opening COM6, baud 38400");
            sp.Open();
            sp.ReadTimeout=25;
            if (sp.IsOpen) { print("Open"); }

        }
    }

    // Update is called once per frame
    void Update()
    {
     

        if (sp.IsOpen && blue == true)
        {
            data = sp.ReadLine();
            
            //if (data != null) {
            //print("data recieved");
          
            //float step = speed * Time.deltaTime;
            //toPos.Set(data[6],data[7],data[8]);
            //rb.rotation.SetLookRotation(toPos,rb.position);
            //}

        }
    }

    public static float AxisBlue_X()
    {
        if (BlueController.data.Contains("|"))
        {
            x = -float.Parse(BlueController.data.Substring(BlueController.data.IndexOf("|") + 1));
            if (x > 1000)
            {
                xn = Mathf.Lerp(xn, 1, 0.5f);

            }
            else if (x < -1000)
            {
                xn = Mathf.Lerp(xn, -1, 0.5f);
            }
            else
            {
                if (xn > 0)
                {
                    xn--;
                    xn = Mathf.Clamp(xn, 0, 1);

                }
                else
                {
                    xn++;
                    xn = Mathf.Clamp(xn, -1, 0);

                }
            }
            
        }
        return xn;
    }

    public static float AxisBlue_Y()
    {
        if (BlueController.data.Contains("|"))
        {
            y = float.Parse(BlueController.data.Substring(0, BlueController.data.IndexOf("|") - 1));
            if (y > 1800)
            {
                yn = Mathf.Lerp(yn, 1, 0.05f);

            }
            else if (y < -1800)
            {
                yn = Mathf.Lerp(xn, -1, 0.05f);
            }
            else
            {
                if (yn > 0)
                {
                    yn--;
                    yn = Mathf.Clamp(yn, 0, 1);
                }
                else
                {
                    yn++;
                    yn = Mathf.Clamp(yn, -1, 0);
                }
            }
        }
        
        return yn;
    }
    public static bool BlueLeft()
    {

        if (BlueController.data.Equals("L"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool BlueRight()
    {
        if (BlueController.data.Equals("D"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
