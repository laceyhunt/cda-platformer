using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class paralx : MonoBehaviour
{
    private float Length, startpos;

    [SerializeField] private float checker;

    [SerializeField] private GameObject cam;

    [SerializeField] private float paralaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - paralaxEffect));

        float distance = (cam.transform.position.x * paralaxEffect);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if(checker != 1)
        {
            if(temp > startpos + Length)
            {
                startpos += Length;
            }
            else if(temp < startpos - Length)
            {
                startpos -= Length;
            }
        }
    }
}
