using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptToDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Battery level: " + SystemInfo.batteryLevel.ToString());
        Debug.Log("Battery status: " + SystemInfo.batteryStatus.ToString());
        Debug.Log("Device model: " + SystemInfo.deviceModel.ToString());
        Debug.Log("Device name: " + SystemInfo.deviceName.ToString());
        Debug.Log("Device type: " + SystemInfo.deviceType.ToString());
        Debug.Log("Device unique identifier: " + SystemInfo.deviceUniqueIdentifier.ToString());
        Debug.Log("Operating syetm: " + SystemInfo.operatingSystem.ToString());
        Debug.Log("Operating syetm family: " + SystemInfo.operatingSystemFamily.ToString());
        Debug.Log("Processor count: " + SystemInfo.processorCount.ToString());
        Debug.Log("Processor frequency: " + SystemInfo.processorFrequency.ToString());
        Debug.Log("Processor type: " + SystemInfo.processorType.ToString());
        Debug.Log("Supports vibration: " + SystemInfo.supportsVibration.ToString());
        Debug.Log("System memory size: " + SystemInfo.systemMemorySize.ToString());
        
    }
}
