using System;
using UnityEngine;

namespace UnityGameUI
{
    internal class TooltipGUI : MonoBehaviour
    {
       public bool EnableTooltip = false;
        public string Tooltip = "";
        public float WindowSizeFactor = 1;
        public GameObject target = null;
        private GUIStyle tooltipStyle;

        public void Update()
        {
            var mousepos = UnityEngine.Input.mousePosition;

            if (target != null)
            {
                Vector2 size = target.GetComponent<RectTransform>().rect.size;
                if (mousepos.x < target.transform.position.x + size.x * WindowSizeFactor / 2 && mousepos.x > target.transform.position.x - size.x * WindowSizeFactor / 2)
                {
                    if (mousepos.y < target.transform.position.y + size.y * WindowSizeFactor / 2 && mousepos.y > target.transform.position.y - size.y * WindowSizeFactor / 2)
                    {
                        EnableTooltip = true;
                        return;
                    }
                }
            }

            EnableTooltip = false;
        }
        public void OnGUI()
        {
            var mousepos = UnityEngine.Input.mousePosition;
            if (Tooltip != "" && EnableTooltip == true)
            {
                GUI.backgroundColor = Color.black;
                GUIContent content = new GUIContent(Tooltip);

                tooltipStyle = new GUIStyle(GUI.skin.box);
                tooltipStyle.normal.textColor = Color.white;
                tooltipStyle.fontSize = (int)(18 * WindowSizeFactor);

                float width = tooltipStyle.CalcSize(content).x;
                float height = tooltipStyle.CalcSize(content).y;

                //var mousepos = EventSystem.current.currentInputModule.input.mousePosition; // Instead of Input.mousePosition
                GUI.Box(new Rect(mousepos.x + 15, Screen.height - mousepos.y + 15, width, Math.Max(25f, height)), content, tooltipStyle); // The +15 are cursor offsets                
            }
        }
    }
}
