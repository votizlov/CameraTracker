using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoContent
{
    public class VisualizePointComponent : MonoBehaviour
    {

        private void OnInstantiateSettings()
        {
            var position = transform.position;
            GetComponent<MeshRenderer>().material.color = new Color(1 - position.y/(VisualizingManager.GetInstance().AvgHeight * 2), 
                position.y/(VisualizingManager.GetInstance().AvgHeight * 2), 0, 1);
        }
        
        // Start is called before the first frame update
        void Start()
        {
            OnInstantiateSettings();
        }
    }
}


