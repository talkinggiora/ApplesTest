using UnityEngine;
using UnityEngine.EventSystems;
public class DragDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    //объ€вл€ем переменные, с которыми будем работать
    private Rigidbody2D rb2D;
    private CanvasGroup cGroup;
    private RectTransform rectTransform;

    //задаЄм первоначальные данные переменным
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rb2D = GetComponent<Rigidbody2D>();
        cGroup = GetComponent<CanvasGroup>();
    }

    //устанавливаем статичный тип дл€ Rigidbody, разрешаем считывать raycasts, увеличиваем размер переносимого предмета дл€ косметического эффекта
    public void OnBeginDrag(PointerEventData eventData)
    {
        rb2D.bodyType = RigidbodyType2D.Static;
        cGroup.blocksRaycasts = false;
        rectTransform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    //задаЄм перемещение, заодно подстраиваемс€ под неточности, возникающие из-за размеров холста
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //при "отпускании" возвращаем динамический тип, чтобы симулировать гравитацию, разрешаем блокироовать raycasts, возвращаем первоначальный размер спрайту
    public void OnEndDrag(PointerEventData eventData)
    {
        rb2D.bodyType = RigidbodyType2D.Dynamic;

        cGroup.blocksRaycasts = true;
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
    //проверка соприкосновени€ объекта с триггером, задаЄм объекту статичный тип тела, чтобы гравитаци€ не свалила €блоко с полки
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AppleDestination"))
            rb2D.bodyType = RigidbodyType2D.Static;
        
    }


}
