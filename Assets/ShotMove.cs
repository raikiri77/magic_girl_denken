using System.Collections;
using UnityEngine;


public class ShotMove : MonoBehaviour
{
    public ShotMoveEnum sme;
    [SerializeField] private float moveSpeed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sme == ShotMoveEnum.Straight)
        {
            StartCoroutine(Straight());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Straight()
    {
        while (true)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
