using MyGameExpand;
using UnityEngine;

namespace MyGameUtility {
    public static class UIUtility {
    public static Rect GetRectFromChildren(RectTransform parent) {
        float xMin = float.MaxValue;
        float xMax = float.MinValue;
        float yMin = float.MaxValue;
        float yMax = float.MinValue;

        foreach (RectTransform child in parent.GetComponentsInChildren<RectTransform>()) {
            if (child == parent.GetComponent<RectTransform>()) {
                continue;
            }

            float childPosXMin = child.position.x - child.rect.width * (child.pivot.x);
            float childPosXMax = child.position.x + child.rect.width * (1 - child.pivot.x);
            float childPosYMin = child.position.y - child.rect.height * (child.pivot.y);
            float childPosYMax = child.position.y + child.rect.height * (1 - child.pivot.y);

            if (childPosXMin < xMin) {
                xMin = childPosXMin;
            }

            if (childPosXMax > xMax) {
                xMax = childPosXMax;
            }

            if (childPosYMin < yMin) {
                yMin = childPosYMin;
            }

            if (childPosYMax > yMax) {
                yMax = childPosYMax;
            }
        }

        return new Rect(new Vector2(xMin, yMin), new Vector2(xMax - xMin, yMax - yMin));
    }

    public static void Move_2DFollowMouse(RectTransform target, Camera renderCamera, Vector3 offset) {
        Canvas canvas = target.GetComponent<Canvas>();
        if (canvas == null) {
            canvas = target.FindCanvas();
        }

        if (target.FindCanvas().renderMode == RenderMode.ScreenSpaceOverlay) {
            target.position = Input.mousePosition;
        }
        else {
            Vector3 dist     = renderCamera.WorldToScreenPoint(target.position);
            Vector3 curPos   = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist.z);
            Vector3 worldPos = renderCamera.ScreenToWorldPoint(curPos);
            target.position = worldPos;
        }

        target.position += offset;
    }

    public static void Move_3DFollow2D(Transform target3D, RectTransform target2D, Camera renderCamera, Vector3 offset) {
        Canvas canvas = target2D.GetComponent<Canvas>();
        if (canvas == null) {
            canvas = target2D.FindCanvas();
        }

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) {
            float   z        = target3D.position.z - renderCamera.transform.position.z;
            Vector3 mousePos = new Vector3(target2D.position.x, target2D.position.y, z);
            target3D.position = renderCamera.ScreenToWorldPoint(mousePos) + offset;
        }
        else {
            target3D.position = target2D.position.SetZ(target3D.position.z);
        }
    }

    public static void Move_3DFollowMouse(Transform target3D, Camera renderCamera, Vector3 offset) {
        float   z        = target3D.position.z - renderCamera.transform.position.z;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        target3D.position = renderCamera.ScreenToWorldPoint(mousePos) + offset;
    }

    public static void Move_2DFollow3D(RectTransform target2D, Transform target3D, Camera rendererCamera2D, Camera rendererCamera3D, Vector3 offset) {
        Canvas canvas = target2D.GetComponent<Canvas>();
        if (canvas == null) {
            canvas = target2D.FindCanvas();
        }

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) {
            Vector3 screenPos = rendererCamera3D.WorldToScreenPoint(target3D.position);
            target2D.position = screenPos + offset;
            // Vector3 screenPos = renderCamera.WorldToScreenPoint(target3D.position - new Vector3(0,0,renderCamera.transform.position.z));
        }
        else {
            Vector3 screenPos = rendererCamera3D.WorldToScreenPoint(target3D.position);
            target2D.position = rendererCamera2D.ScreenToWorldPoint(screenPos) + offset;
        }
    }
    public static void Move_2DFollow3D(RectTransform target2D, Vector3 target3DPos, Camera rendererCamera2D, Camera rendererCamera3D, Vector3 offset) {
        Canvas canvas = target2D.GetComponent<Canvas>();
        if (canvas == null) {
            canvas = target2D.FindCanvas();
        }

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) {
            Vector3 screenPos = rendererCamera3D.WorldToScreenPoint(target3DPos);
            target2D.position = screenPos + offset;
        }
        else {
            Vector3 screenPos = rendererCamera3D.WorldToScreenPoint(target3DPos);
            target2D.position = rendererCamera2D.ScreenToWorldPoint(screenPos) + offset;
        }
    }

    public static void UIMustInScreen(RectTransform target, Canvas canvas = null) {
        if (canvas == null) {
            canvas = target.FindCanvas();
        }
        
        RectTransform canvasRect = canvas.transform as RectTransform;
        RectTransform parentRect = target.parent.GetComponent<RectTransform>();
        Camera        cam        = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
        Vector2       screenPos  = RectTransformUtility.WorldToScreenPoint(cam, target.position);

        float minX = target.pivot.x * target.rect.size.x;
        float maxX = canvasRect.rect.size.x - (1 - target.pivot.x) * target.rect.size.x;
        float minY = target.pivot.y * target.rect.size.y;
        float maxY = canvasRect.rect.size.y - (1 - target.pivot.y) * target.rect.size.y;
        
        screenPos.x = Mathf.Clamp(screenPos.x, minX, maxX);
        screenPos.y = Mathf.Clamp(screenPos.y, minY, maxY);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, screenPos, cam, out Vector2 anchoredPos);
        target.localPosition = anchoredPos;
        Debug.Log($"测试UI必须在屏幕中，修改后的局部坐标【{anchoredPos}】");
    }
    }
}