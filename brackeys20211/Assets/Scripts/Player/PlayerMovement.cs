using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures.TransformGestures;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float ForceMultiplyer = 1;


        public void Shoot(Vector2 direction)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(direction * ForceMultiplyer);
        }

    }
}
