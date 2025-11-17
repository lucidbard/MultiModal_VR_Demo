using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    // Start is called before the first frame update
    // Dim the ambient lights
    public void OnButtonPress()
    {
        RenderSettings.ambientLight = Color.black;
        // Set intensity multiplier down
        RenderSettings.ambientIntensity = 0.1f;
    }
}
