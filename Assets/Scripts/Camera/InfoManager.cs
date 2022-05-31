using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public TMP_Text tmpro;

    private readonly Dictionary<string, string> triggerHandler = new Dictionary<string, string>();

    private void Start()
    {
        triggerHandler["info_door"] = "Должно быть от эти ворота открываются кнопкой";
        triggerHandler["info_button"] = "Эта кнопка, которая открывает ворота";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerHandler.ContainsKey(collision.gameObject.name))
        {
            ShowMessage(triggerHandler[collision.gameObject.name]);
            Destroy(collision.gameObject);
            StartCoroutine(ClearTextAfterSeconds(10f));
        }
    }

    private void ShowMessage(string message)
    {
        tmpro.text = message;
    }

    private IEnumerator ClearTextAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        ClearText();
    }

    private void ClearText()
    {
        tmpro.text = "";
    }
}
