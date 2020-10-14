using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
