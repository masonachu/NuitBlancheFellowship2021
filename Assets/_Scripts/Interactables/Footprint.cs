using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{
    [Tooltip("This is how long the decal will stay before it shrinks away")]
    
    private SpriteRenderer foot;
    private Color color;
    private float mark;
    private Vector3 OrigSize;

    public float Lifetime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        mark = Time.time;
        foot = GetComponentInChildren<SpriteRenderer>();
        //OrigSize = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float ElapsedTime = Time.time - mark;
        if (ElapsedTime != 0)
        {
            //The lifetime value of the prefab when instantiated from 100-0
            float PercentTimeLeft = Mathf.Clamp01((Lifetime - ElapsedTime) / Lifetime);

            //The image fades away over percent time left
            foot.color = new Color(1, 1, 1, PercentTimeLeft);

            //this.transform.localScale = new Vector3(OrigSize.x * PercentTimeLeft, OrigSize.y * PercentTimeLeft, OrigSize.z * PercentTimeLeft);


            if(ElapsedTime > Lifetime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
