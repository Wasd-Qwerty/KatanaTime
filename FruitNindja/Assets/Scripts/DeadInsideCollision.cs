using UnityEngine;

public class DeadInsideCollision : MonoBehaviour
{
    private Menu _menu;

    private void Start()
    {
        _menu = GameObject.FindWithTag("TV").GetComponent<Menu>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("DeadInside"))
        {
            _menu.ShowGameOverUI();
            collider.isTrigger = true;
            collider.GetComponent<Rigidbody>().velocity = new Vector3(0, collider.GetComponent<Rigidbody>().velocity.y, 0);
            Destroy(collider.gameObject, 2);
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}