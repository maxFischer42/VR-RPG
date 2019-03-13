using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerEngine;

namespace PlayerEngine
{
    public class MovePlayer : MonoBehaviour
    {
        public float maxDistanceDelta = 0.1f;
        public float directionMultiplier = 1;
        public Transform forwardObj;
        public Transform rightObj;
        public Transform player;

        void Update()
        {
          //  float x = Input.GetAxis("Oculus_GearVR_LThumbstickX");
          //  float y = Input.GetAxis("Oculus_GearVR_LThumbstickY");
         //   float x = Input.GetAxisRaw("Horizontal");
          //  float y = Input.GetAxisRaw("Vertical");
            /* Vector3 velocity = Vector3.zero;
              velocity = new Vector3(x, 0f, y);
              velocity *= directionMultiplier;
              Vector3 target = velocity + transform.position;
              Debug.Log(target);*/
            /*Debug.Log(y);
            if (y != 0)
            {                
                player.position = Vector3.MoveTowards(transform.position, transform.position + (new Vector3(0,0,1 * y)), maxDistanceDelta);
            }*/
        }
    }
}

