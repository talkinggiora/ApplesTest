using UnityEngine;
using UnityEngine.EventSystems;
public class DragDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    //��������� ����������, � �������� ����� ��������
    private Rigidbody2D rb2D;
    private CanvasGroup cGroup;
    private RectTransform rectTransform;

    //����� �������������� ������ ����������
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rb2D = GetComponent<Rigidbody2D>();
        cGroup = GetComponent<CanvasGroup>();
    }

    //������������� ��������� ��� ��� Rigidbody, ��������� ��������� raycasts, ����������� ������ ������������ �������� ��� �������������� �������
    public void OnBeginDrag(PointerEventData eventData)
    {
        rb2D.bodyType = RigidbodyType2D.Static;
        cGroup.blocksRaycasts = false;
        rectTransform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    //����� �����������, ������ �������������� ��� ����������, ����������� ��-�� �������� ������
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //��� "����������" ���������� ������������ ���, ����� ������������ ����������, ��������� ������������ raycasts, ���������� �������������� ������ �������
    public void OnEndDrag(PointerEventData eventData)
    {
        rb2D.bodyType = RigidbodyType2D.Dynamic;

        cGroup.blocksRaycasts = true;
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
    //�������� ��������������� ������� � ���������, ����� ������� ��������� ��� ����, ����� ���������� �� ������� ������ � �����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AppleDestination"))
            rb2D.bodyType = RigidbodyType2D.Static;
        
    }


}
