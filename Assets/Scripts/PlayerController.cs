using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using extOSC;
using UnityEngine.Windows;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    new Camera camera;
    [SerializeField]
    Plane plane;
    [SerializeField]
    PlaneHUD planeHUD;

    OSCReceiver receiver;

    Vector3 controlInput;
    PlaneCamera planeCamera;
    AIController aiController;

    string[] splitSerialMsgStr;

    bool rudderMode;

    void Start()
    {
        planeCamera = GetComponent<PlaneCamera>();
        SetPlane(plane);    //SetPlane if var is set in inspector
    }

    /*    private void Awake()
        {
            Debug.LogFormat("begin osc");
            receiver = this.gameObject.AddComponent<OSCReceiver>();
            receiver.LocalPort = 10000;
            receiver.Bind("/accelerometer/x", AccelX);
            receiver.Bind("/accelerometer/y", AccelY);
            receiver.Bind("/accelerometer/z", AccelZ);
            receiver.Bind("/1/fader1", ControlThrottleOSC);
            receiver.Bind("/1/push3", FireMissileOSC);
            receiver.Bind("/1/push1", FireCannonOSC);

        }*/



    void SetPlane(Plane plane)
    {
        this.plane = plane;
        aiController = plane.GetComponent<AIController>();

        if (planeHUD != null)
        {
            planeHUD.SetPlane(plane);
            planeHUD.SetCamera(camera);
        }

        planeCamera.SetPlane(plane);
    }
    public void OnToggleHelp(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        if (context.phase == InputActionPhase.Performed)
        {
            planeHUD.ToggleHelpDialogs();
        }
    }

    public void SetThrottleInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;
        if (aiController.enabled) return;

        plane.SetThrottleInput(context.ReadValue<float>());
    }

    /*public void OnRollPitchInput(InputAction.CallbackContext context) {
        if (plane == null) return;

        var input = context.ReadValue<Vector2>();
       controlInput = new Vector3(input.y, controlInput.y, -input.x);
    }*/

    public void OnRollInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        var input = context.ReadValue<float>();
        controlInput = new Vector3(-input, controlInput.y, controlInput.z);
    }
    public void OnPitchInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        var input = context.ReadValue<float>();
        controlInput = new Vector3(controlInput.x, controlInput.y, -input);
    }



    public void OnYawInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        var input = context.ReadValue<float>();
        controlInput = new Vector3(controlInput.x, input, controlInput.z);
    }

    public void OnCameraInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        var input = context.ReadValue<Vector2>();
        planeCamera.SetInput(input);
    }

    public void OnFlapsInput(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        if (context.phase == InputActionPhase.Performed)
        {
            plane.ToggleFlaps();
        }
    }

    public void OnFireMissile(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        if (context.phase == InputActionPhase.Performed)
        {
            plane.TryFireMissile();
        }
    }

    public void OnFireCannon(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        if (context.phase == InputActionPhase.Started)
        {
            plane.SetCannonInput(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            plane.SetCannonInput(false);
        }
    }

    public void OnToggleAI(InputAction.CallbackContext context)
    {
        if (plane == null) return;

        if (aiController != null)
        {
            aiController.enabled = !aiController.enabled;
        }
    }

    private Vector3 neutralAccel = new Vector3(0, 0, 0); // Use this for calibration (neutral or resting position)
    private float sensitivity = .1f; // Adjust this based on how responsive you want the control

    // Call this during initialization to set the neutral value, assuming accelerometer is steady.
    public void CalibrateNeutralPosition(float x, float y, float z)
    {
        neutralAccel = new Vector3(x, y, z);
    }

    // OSC handler for X axis
    private void AccelX(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0)
        {
            var rawInput = values[0].FloatValue;
            var adjustedInput = (rawInput - neutralAccel.x) * sensitivity * 2; // Adjust based on neutral point and scale
            controlInput = new Vector3(adjustedInput, controlInput.y, controlInput.z); // Update X axis
        }
    }

    // OSC handler for Y axis
    private void AccelY(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0)
        {
            var rawInput = values[0].FloatValue * 5;
            var adjustedInput = (rawInput - neutralAccel.y) * sensitivity * 3; // Adjust based on neutral point and scale
            //controlInput = new Vector3(controlInput.x, adjustedInput, controlInput.z); // Update Y axis
        }
    }

    // OSC handler for Z axis
    private void AccelZ(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0)
        {
            var rawInput = values[0].FloatValue;
            var adjustedInput = (rawInput - neutralAccel.z) * sensitivity / 2; // Adjust based on neutral point and scale
            controlInput = new Vector3(controlInput.x, controlInput.y, -adjustedInput); // Update Z axis
        }
    }

    void FireMissileOSC(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0 && values[0].FloatValue == 1.0f)
        {
            plane.TryFireMissile();
        }
    }
    void FireCannonOSC(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0 && values[0].FloatValue == 1.0f)
        {
            plane.SetCannonInput(true);
        }
        else
        {
            plane.SetCannonInput(false);
        }



    }

    void ControlThrottleOSC(OSCMessage message)
    {
        if (plane == null) return;
        List<OSCValue> values = message.Values;
        if (values.Count > 0)
        {
            plane.SetThrottleInput(values[0].FloatValue);
        }
    }

    void Update()
    {
        if (plane == null) return;
        if (aiController.enabled) return;
        //Debug.Log("rudder :: " + rudderMode);
        plane.SetControlInput(controlInput);
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        splitSerialMsgStr = msg.Split(',');

        //Debug.Log("X::: " + splitSerialMsgStr[0] + "Y::: " + splitSerialMsgStr[1] + "Z::: " + splitSerialMsgStr[2]);
        //Debug.Log("button::: " + splitSerialMsgStr[5]);
        SerAccelX(float.Parse(splitSerialMsgStr[0]));
        //SerAccelY(float.Parse(splitSerialMsgStr[1]));
        SerAccelZ(float.Parse(splitSerialMsgStr[2]));

        if (float.Parse(splitSerialMsgStr[3]) == 1)
            SerButtonA(1);
        else if (float.Parse(splitSerialMsgStr[4]) == 1)
            SerButtonB(1);
        else
        { 
            plane.SetThrottleInput(0);
            controlInput = new Vector3(controlInput.x, 0, controlInput.z); // Update Z axis
        }

        SerRudderMode(splitSerialMsgStr[5]);

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection Successful");
        else
            Debug.Log("Connection failed!");
    }
    void SerAccelX(float x)
    {
        if (plane == null) return;

        var rawInput = x;
        var adjustedInput = (rawInput - neutralAccel.x) * sensitivity ; // Adjust based on neutral point and scale
        controlInput = new Vector3(-adjustedInput, controlInput.y, controlInput.z); // Update X axis
    }

    void SerAccelY(float y)
    {
        if (plane == null) return;
        var rawInput = y;
        var adjustedInput = (rawInput - neutralAccel.y) * sensitivity / 4; // Adjust based on neutral point and scale
        controlInput = new Vector3(controlInput.x, -adjustedInput, controlInput.z); // Update Z axis
    }

    void SerAccelZ(float z)
    {
        if (plane == null) return;
        var rawInput = z;
        var adjustedInput = (rawInput - neutralAccel.z) * sensitivity / 2; // Adjust based on neutral point and scale
        controlInput = new Vector3(controlInput.x, controlInput.y, -adjustedInput); // Update Z axis
    }

    void SerButtonA(float buttonA)
    {
        if (plane == null) return;
        if (!rudderMode)
            plane.SetThrottleInput(-buttonA);
        else
        {
            controlInput = new Vector3(controlInput.x, -1, controlInput.z); // Update Z axis
        }

        /*if (fireMissile == 1.0f)
        {
            plane.TryFireMissile();
        }*/
    }
    void SerButtonB(float buttonB)
    {
        if (plane == null) return;
        if (!rudderMode)
            plane.SetThrottleInput(buttonB);
        else
        {
            controlInput = new Vector3(controlInput.x, 1, controlInput.z); // Update Z axis
        }

        /*if (fireCannon == 1.0f)
        {
            plane.SetCannonInput(true);
        }
        else
        {
            plane.SetCannonInput(false);
        }*/
    }

    void SerRudderMode(string rudderModeStr)
    {
        if (rudderModeStr.Equals ("1"))
        {
            rudderMode = true;
        }
        else
        {
            rudderMode = false;
        }

        
    }
}
