using UnityEngine;

public class CoinAnimation : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0));
    }
}
