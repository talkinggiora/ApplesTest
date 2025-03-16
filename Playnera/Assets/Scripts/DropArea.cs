using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    // ��� ���������� ������� � ���� ���� ����� ����� �������� ������� �������
    public void OnDrop(PointerEventData eventData)
    {
      if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
