using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProgressLightManger : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D progressLights;
    [SerializeField] private float objectiveProgress;
    [SerializeField] private float maxProgress;
    // Start is called before the first frame update
    void Start()
    {
        progressLights.intensity = 0.01f;
        objectiveProgress = 0;
        
    }
    
    // Update is called once per frame
    public void UpdateProgressLights()
    {
        objectiveProgress  = ObjectiveControl.ObjectiveProgress;
        maxProgress = ObjectiveControl.MaxProgress;
        progressLights.intensity = (float)objectiveProgress / maxProgress;
    }

}
