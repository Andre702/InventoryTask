using UnityEngine;

public class ItemPickUp : Interactable 
{
	public Item itemTarget;

	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	void PickUp ()
	{
		Debug.Log("Picking up " + itemTarget.name);
		bool pickupSuccessful = Inventory.instance.Add(itemTarget);

		if (pickupSuccessful)
			Destroy(gameObject);
	}
}
