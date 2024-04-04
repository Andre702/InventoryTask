using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour
{

	public Image icon;
	public Button removeButton;

	private bool isMoving = false;
	private Item item;

	public void Start()
    {
		Inventory.onItemMove += SwitchMode;
    }

	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void SwitchMode()
    {
		isMoving = !isMoving;
    }

	public void OnRemoveButton ()
	{
		Inventory.instance.Remove(item);
	}

	public void MoveItem ()
	{
		if (isMoving)
        {
			Inventory.instance.SwapItem(transform.GetSiblingIndex());
		}
		else
        {
			if (item != null)
			{
				Inventory.instance.MoveItem(transform.GetSiblingIndex());
			}
		}
		
	}

    public void OnDestroy()
    {
		Inventory.onItemMove -= SwitchMode;
	}

}
