using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DemoContent
{
    public class VisualizingManager : MonoBehaviour
    {
        private static VisualizingManager _instance;

        public static VisualizingManager GetInstance() => _instance;

        public float AvgHeight = 1f;

        public void SetAvgHeight(float value) => AvgHeight = value;
        

        private void Awake() => _instance = this;
    }
}


