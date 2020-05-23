using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public GameObject part;
    public void Active()
    {
        part.SetActive(true);
    }

    public void Disable()
    {
        part.SetActive(false);

    }
}
