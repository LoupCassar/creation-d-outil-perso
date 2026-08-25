using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindows : MonoBehaviour
{
    public RectTransform uIWindowsRectTransform;
    public RectTransform uIPanelRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        uIWindowsRectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
