using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	public int price;

    private void Start()
    {
		price = GetComponent<Tower>().price;
    }

    #region IBeginDragHandler implementation

    private void Update()
    {
		if (transform.parent.CompareTag("MenuSlot"))
        {
			if (Manager.Instance.gold < price)
			{
				GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			else
			{
				GetComponent<CanvasGroup>().blocksRaycasts = true;
			}
		}
	}

    public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (transform.parent == startParent)
		{
			transform.position = startPosition;
		}
		else
        {
			Manager.Instance.gold -= price;

			GameObject tmp = Instantiate(this.gameObject);
			tmp.transform.position = startPosition;
			tmp.transform.SetParent(startParent);

			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	#endregion
}
