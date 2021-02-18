using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Player
{

    public class Aim : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private bool ableToAim = true;

        private Vector2 dragStartPos;
        private Vector2 dragDiff;

        private RectTransform m_DraggingPlane;
        private RectTransform rTransform;

        private LineRenderer aimLineRenderer;
        
        private Vector3[] aimLinePositions;

        private Action abilityCheck;

        public UnityEvent<Vector2> onFire;

        public float minThreshold = 1;

        void Start()
        {
            aimLineRenderer = GetComponentInChildren<LineRenderer>();
            aimLinePositions = new Vector3[2];
            rTransform = gameObject.transform as RectTransform;
            abilityCheck += stopCheck;
        }

        private void getDragStartPos(PointerEventData data)
        {
            if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
                m_DraggingPlane = data.pointerEnter.transform as RectTransform;

            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
            {
                dragStartPos = globalMousePos;
            }
        }

        private void calculateDragDiff(PointerEventData data)
        {
            if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
                m_DraggingPlane = data.pointerEnter.transform as RectTransform;

            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
            {
                Vector2 vec2MousePos = globalMousePos;
                dragDiff = dragStartPos - vec2MousePos;
            }
        }

        private void stopCheck()
        {
            var rb = gameObject.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude > 0.1)
            {
                ableToAim = false;
            }
            else
            {
                ableToAim = true;
            }
        }

        private void drawAimLine()
        {
            aimLinePositions[0] = new Vector3(rTransform.position.x, rTransform.position.y, 1);
            aimLinePositions[1] = new Vector3(rTransform.position.x + dragDiff.x, rTransform.position.y + dragDiff.y, 1);
            aimLineRenderer.SetPositions(aimLinePositions);
        }

        private void RemoveAimLine()
        {
            aimLinePositions[0] = new Vector3(rTransform.position.x, rTransform.position.y, 1);
            aimLinePositions[1] = new Vector3(rTransform.position.x, rTransform.position.y, 1);
            aimLineRenderer.SetPositions(aimLinePositions);
        }

        public void OnBeginDrag(PointerEventData data)
        {
            abilityCheck.Invoke();
            if(!ableToAim)
            {
                return;
            }

            getDragStartPos(data);
        }

        public void OnDrag(PointerEventData data)
        {
            if (!ableToAim)
            {
                return;
            }

            calculateDragDiff(data);
            drawAimLine();

        }

        

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!ableToAim)
            {
                return;
            }

            RemoveAimLine();
            if(dragDiff.magnitude > minThreshold)
            {
                onFire.Invoke(dragDiff);
            }
            
        }


    }
}