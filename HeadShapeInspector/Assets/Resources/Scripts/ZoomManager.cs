using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Transform modelTransform;
    
    private void Start() {
        slider.value = modelTransform.localScale.x;
    }

    public void changeZoom()
    {
        
        modelTransform.localScale = new Vector3(slider.value, slider.value, slider.value);

    }


}
