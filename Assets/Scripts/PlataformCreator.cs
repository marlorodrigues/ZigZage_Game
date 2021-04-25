using System.Collections;
using UnityEngine;

public class PlataformCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private GameObject coins;
    [SerializeField]
    private float heighXZ;
    [SerializeField]
    private Vector3 lastPos;

    private int limiteOfLevel = 100;
    private int countOfPlataformsAlreadyCreated = 0;


    void Start()
    {
        lastPos = ground.transform.position;
        heighXZ = ground.transform.localScale.x;

        for (int i = 0; i < 10; i++)
            createGround();

        StartCoroutine(createGroundProcedural());
    }

    void createX()
    {
        Vector3 tmp = lastPos;
        heighXZ = ground.transform.localScale.x;

        tmp.x += heighXZ;
        lastPos = tmp;

        Instantiate(ground, tmp, Quaternion.identity);

        createCoin(tmp);
    }

    void createZ()
    {
        Vector3 tmp = lastPos;
        heighXZ = ground.transform.localScale.z;

        tmp.z += heighXZ;
        lastPos = tmp;

        Instantiate(ground, tmp, Quaternion.identity);

        createCoin(tmp);
    }

    private void createGround()
    {
        int tmp = Random.Range(0, 10);

        if (tmp < 5)
            createX();
        else
            createZ();

    }

    private void createCoin(Vector3 tmp)
    {
        int randomic = Random.Range(0, 10);

        if (randomic < 3)
            Instantiate(coins, new Vector3(tmp.x, tmp.y + 0.2f, tmp.z), coins.transform.rotation);
    }


    IEnumerator createGroundProcedural()
    {
        while (!BallController.GameOver)
        {
            yield return new WaitForSeconds(0.4f);

            if (countOfPlataformsAlreadyCreated >= limiteOfLevel)
                createGround();
            else
                BallController.GameOver = true;
        }
    }

}
