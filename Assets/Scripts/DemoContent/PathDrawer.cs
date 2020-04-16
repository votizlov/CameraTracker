using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoContent
{
    public class PathDrawer : MonoBehaviour
    {

        [SerializeField] private Transform referenceArCamera;
        
        [SerializeField] private GameObject pointPrefab;

        [SerializeField] private int frameRate = 30;

        [SerializeField] private float pointLifetime = 3f;
        
        // Start is called before the first frame update
        public void StartVisualizing()
        {
            StartCoroutine(Visualizing());
        }

        private IEnumerator Visualizing()
        {
            while (true)
            {
                Destroy(Instantiate(pointPrefab, referenceArCamera.position, referenceArCamera.rotation, transform), pointLifetime);
            
                yield return new WaitForSeconds(1f/frameRate);
            }
        }
    }
}


