﻿using UnityEngine;

namespace UnityGameUI
{
    public class DragAndDrog : MonoBehaviour
    {
        public GameObject target;
        public bool isMouseDrag;
        public float WindowSizeFactor = 1;
        //private Vector3 screenPosition;
        private Vector3 offset;
        // Use this for initialization
        public void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            GameObjectDragAndDrog();
        }

        //任意拖拽


        //拖拽Updata
        private void GameObjectDragAndDrog()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 WindowSize = target.GetComponent<RectTransform>().rect.size;
                if (Input.mousePosition.x < target.transform.position.x + WindowSize.x * WindowSizeFactor / 2 && Input.mousePosition.x > target.transform.position.x - WindowSize.x * WindowSizeFactor / 2)
                {
                    if (Input.mousePosition.y < target.transform.position.y + WindowSize.y * WindowSizeFactor / 2 && Input.mousePosition.y > target.transform.position.y - WindowSize.y * WindowSizeFactor / 2)
                    {
                        isMouseDrag = true;
                        offset = target.transform.position - Input.mousePosition;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isMouseDrag = false;
            }

            if (isMouseDrag)
            {
                target.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + new Vector2(offset.x, offset.y);
            }
        }
    }
}

