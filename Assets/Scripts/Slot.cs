using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
	public Image image;

	public int price;

    private void Start()
    {
		image = GetComponent<Image>();

		if (this.gameObject.transform.childCount > 0)
        {
			price = this.gameObject.transform.GetChild(0).GetComponent<Tower>().price;
		}
	}

    public GameObject item
	{
		get
		{
			if (transform.childCount > 0)
			{
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop(PointerEventData eventData)
	{
		if (!item)
		{
			DragHandeler.itemBeingDragged.transform.SetParent(transform);
		}
	}
    #endregion

    private void Update()
    {
        if (this.gameObject.CompareTag("MenuSlot"))
        {
			if (Manager.Instance.gold < price)
            {
				image.color = Color.red;

				var tempColor = image.color;
				tempColor.a = .30f;
				image.color = tempColor;
			}
			else
            {
				GetComponent<Image>().color = Color.white;

				var tempColor = image.color;
				tempColor.a = .30f;
				image.color = tempColor;
			}
        }
    }
}
