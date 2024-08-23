using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public TextMeshPro text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = "" + Mathf.RoundToInt(timer);
    }
}
