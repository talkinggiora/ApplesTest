using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    // при отпускании объектв в этой зоне задаём новое значение позиции объекта
    public void OnDrop(PointerEventData eventData)
    {
      if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
