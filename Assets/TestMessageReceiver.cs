/* Copyright (c) 2019 ExT (V.Sigalkin) */

using UnityEngine;
using System.Collections.Generic;
using extOSC;

public class TestMessageReceiver : MonoBehaviour
{
    #region Public Vars

    [Header("OSC Settings")]
    OSCReceiver receiver;

    #endregion

    #region Unity Methods

    protected virtual void Start()
    {
        Debug.LogFormat("begin osc");
        receiver = this.gameObject.AddComponent<OSCReceiver>();
        receiver.LocalPort = 10000;
        receiver.Bind("/accelerometer/x", ReceivedMessage);
        //this.gameObject.transform.Rotate(45.0f, 45.0f, 0.0f);
    }

    #endregion

    #region Private Methods

    private void ReceivedMessage(OSCMessage message)
    {
        Debug.LogFormat("Received: {0}", message);

        List<OSCValue> values = message.Values;
        //this.gameObject.transform.Rotate(values[0].FloatValue * 90.0f, 45.0f, 45.0f);
    }

    #endregion
}