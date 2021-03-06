using UnityEngine;

public class TriggerPlataform : MonoBehaviour
{
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            BallController.plataformsCount++;
            PlataformCreator.countOfPlataformsAlreadyCreated--;
            rb.useGravity = true;
            rb.isKinematic = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
