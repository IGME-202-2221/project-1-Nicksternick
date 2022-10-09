using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    // ----- | Variables | -----
    public Text text;
    public Collision refrence;
    public string format;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        format = string.Format($"Stats:" +
                               $"\r\n-Bullet Tracker: ({refrence.PlayerGun.playerBullets.Count})10" +
                               $"\r\n-Spawn Clock: ({Mathf.Floor(refrence.clock)}){refrence.MaxClock}");
        text.text = format;
    }
}
