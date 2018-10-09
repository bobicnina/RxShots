using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class App1 : MonoBehaviour
{
    public Text TextBlock1;

    private void Start()
    {
        var clickStream = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0));

            clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
                .Where(xs => xs.Count >= 2)
				.SubscribeToText(TextBlock1, xs => "Number of fast shots: " + xs.Count);
        
    }
}