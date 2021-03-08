using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightBar : MonoBehaviour
{
    public Slider _weightBar;


    // Start is called before the first frame update
    void Start()
    {
        _weightBar = GetComponent<Slider>();
        _weightBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeight(int level)
    {
        _weightBar.value = level;
    }
}