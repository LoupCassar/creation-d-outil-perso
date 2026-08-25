using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private Canvas Canvas;
    private RectTransform CanvasRectTransform;
    [SerializeField]private GameObject PrefabMenuPanel;
    [SerializeField]private List<GameObject> MenuPanelList = new List<GameObject>();
    [SerializeField]private GameObject PrefabButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Canvas = GetComponent<Canvas>();
        CanvasRectTransform = Canvas.GetComponent<RectTransform>();
        //CreateVerticalMenuPanel("Main Menu Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateVerticalMenuPanel(string panelName)
    {
        GameObject menuPanel = Instantiate(PrefabMenuPanel, Canvas.transform);
        menuPanel.name = panelName;
        RectTransform panelRectTransform = menuPanel.GetComponent<RectTransform>();
        panelRectTransform.sizeDelta = new Vector2(CanvasRectTransform.sizeDelta.x, CanvasRectTransform.sizeDelta.y);

        menuPanel.AddComponent<VerticalLayoutGroup>().childControlWidth = true;
        MenuPanelList.Add(menuPanel);
    }
}
