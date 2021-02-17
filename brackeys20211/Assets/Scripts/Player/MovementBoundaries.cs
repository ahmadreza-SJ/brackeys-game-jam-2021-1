using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MovementBoundaries : MonoBehaviour
    {
        private Camera MainCam;
        private Rigidbody2D cameraRigidbody;

        private void AddCollider(float x, float y)
        {
            EdgeCollider2D col = MainCam.gameObject.AddComponent<EdgeCollider2D>();
            List<Vector2> points = new List<Vector2>();
            points.Add(new Vector2(x, -y));
            points.Add(new Vector2(x, y));
            col.SetPoints(points);
        }

        // Start is called before the first frame update
        void Start()
        {
            MainCam = Camera.main;
            cameraRigidbody = MainCam.gameObject.AddComponent<Rigidbody2D>();
            cameraRigidbody.gravityScale = 0;
            cameraRigidbody.bodyType = RigidbodyType2D.Static;
            AddCollider(GameManager.Instance.screenHalfWidth, GameManager.Instance.screenHalfHeight);
            AddCollider(-GameManager.Instance.screenHalfWidth, GameManager.Instance.screenHalfHeight);
        }
    }
}
