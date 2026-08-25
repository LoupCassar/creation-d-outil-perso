using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPanelResizer : MonoBehaviour
{
    bool uIResizer;
    public RectTransform uIParentPanelRect;
    // Start is called before the first frame update
    void Start()
    {
        uIParentPanelRect = GetComponent<RectTransform>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition == uIParentPanelRect.transform.localPosition)
        {
            Debug.Log("cool");
        }
    }
}
