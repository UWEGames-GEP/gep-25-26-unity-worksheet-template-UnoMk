using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameManager gameManager;

    Transform worldItemsTransform;

    public List<Items> items = new List<Items>();

    public void AddItem(Items item)
    {
        items.Add(item);
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
    }

    public void RemoveItem()
    {
        if (gameManager.state == GameManager.GameState.GAMEPLAY && items.Count > 0)
        {
            Items item = items[0];

            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;
            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Items collisionItem = hit.gameObject.GetComponent<Items>();

        if (collisionItem != null)
        {
            items.Add(collisionItem);
            collisionItem.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        Transform worldItemsTransform = GameObject.Find("WorldItems").transform;
    }

    void Update()
    {
        if (gameManager.state != GameManager.GameState.GAMEPLAY)
        {
            return;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem("Generic Item");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem("Generic Item");
        }
        */

    }
}
