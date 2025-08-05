using UnityEngine;

public class TeleportInteract : MonoBehaviour
{
    public Transform teleportTarget;       // Where to teleport to
    public KeyCode interactKey = KeyCode.E;

    private bool playerInRange = false;
    private GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;
            Debug.Log("Press E to teleport.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            if (teleportTarget != null && player != null)
            {
                player.transform.position = teleportTarget.position;
                Debug.Log("Player teleported!");
            }
        }
    }
}
