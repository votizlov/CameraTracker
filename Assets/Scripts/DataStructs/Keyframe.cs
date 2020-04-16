using UnityEngine;

namespace DataStructs
{
    public struct Keyframe
    {

        public Vector3 Position;
        public Quaternion Rotation;
        public int FrameIndex;
        
        
        
        
        internal Keyframe(Vector3 position, Quaternion rotation, int frameIndex)
        {
            Position = position;
            Rotation = rotation;
            FrameIndex = frameIndex;
        }

        internal void SetPosition(Vector3 position) => Position = position;
        
        internal void SetRotation(Quaternion rotation) => Rotation = rotation;

        internal void SetFrameIndex(int index) => FrameIndex = index;

    }
}


