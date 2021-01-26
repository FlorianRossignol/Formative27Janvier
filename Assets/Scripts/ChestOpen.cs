using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] private static List<GameObject> hearts_;

    public int heartCount_ = hearts_.Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heartCount_ == 0)
        {
            Destroy(gameObject);
        }
    }
}
