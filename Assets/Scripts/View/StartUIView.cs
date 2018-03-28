using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIView : UIView
{
    private Text text;
    private void Awake()
    {
        text = transform.Find("Text").GetComponent<Text>();
        ViewEvent.AddListener(ViewEventType.StartLogin, ShowText);
    }

    void ShowText(Model model)
    {
        text.text = (model as StartModel).data;
    }

    public override void OnEnter()
    {

    }
}
