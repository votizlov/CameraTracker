using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DataStructs
{
    
    [Serializable]
    public struct Keyframe
    {

        [FormerlySerializedAs("Position")] public Vector3 position;
        [FormerlySerializedAs("Rotation")] public Quaternion rotation;
        [FormerlySerializedAs("FrameIndex")] public int frameIndex;
        
        
        
        
        internal Keyframe(Vector3 position, Quaternion rotation, int frameIndex)
        {
            this.position = position;
            this.rotation = rotation;
            this.frameIndex = frameIndex;
        }

        internal void SetPosition(Vector3 position) => this.position = position;
        
        internal void SetRotation(Quaternion rotation) => this.rotation = rotation;

        internal void SetFrameIndex(int index) => frameIndex = index;

    }
}


