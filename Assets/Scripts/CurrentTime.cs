using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    public Text Text;

    void Update()
    {
        Text.text = Time.time.ToString("F1");
        
    }
}
