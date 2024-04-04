using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public static event UnityAction onItemMove;

	public int space = 20;

	private Item placeholder;
	private int selectedIndex;

	public List<Item> items = new List<Item>();


	void Awake ()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}

	public void MoveItem(int index)
    {
		selectedIndex = index;
		onItemMove.Invoke();
    }

	public void SwapItem(int index)
    {
		placeholder = items[index];
		items[index] = items[selectedIndex];
		items[selectedIndex] = placeholder;

		onItemMove.Invoke();

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	private int FindSpot()
    {
		for (int i = 0; i < space; i++)
		{
			if(items[i] == null)
            {
				return i;
            }
		}
		return -1;
	}

	public bool Add (Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add(item);
			

			if (onItemChangedCallback != null)
			{
				onItemChangedCallback.Invoke();
			}

		}
		return true;
	}

	public void Remove (Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
