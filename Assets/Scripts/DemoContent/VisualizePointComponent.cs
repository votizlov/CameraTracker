using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoContent
{
    public class VisualizePointComponent : MonoBehaviour
    {

        private void OnInstantiateSettings()
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


