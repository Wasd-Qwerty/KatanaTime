using System.Collections;
using UnityEngine;

public class BeforeDestroy : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private float second;

    public void DestroyObj(float second)
    {
        this.second = second;
        _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        StartCoroutine("Death");
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(second);
        if ((_scoreManager.edibleLayer & (1 << gameObject.layer)) != 0)
        {
            _scoreManager.countOfEdible++;
        }
        Destroy(gameObject);
    }
}
