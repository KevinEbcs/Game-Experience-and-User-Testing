using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SevenSegment : MonoBehaviour
{
    public GameObject a, b, c, d, e, f, g;

    public float depth;

    public int number;
    public int max=5;
    
    Vector3 posA,posB,posC,posD,posE,posF,posG;
    // Start is called before the first frame update
    void Start()
    {
        posA = a.transform.position;
        posB = b.transform.position;
        posC = c.transform.position;
        posD = d.transform.position;
        posE = e.transform.position;
        posF = f.transform.position;
        posG = g.transform.position;
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        number = Random.Range(1, max);
        switch (number)
        {
            case 9:
                a.transform.Translate(a.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                e.transform.Translate(e.transform.forward * depth);
                f.transform.Translate(f.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                break;
            case 8:
                a.transform.Translate(a.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                d.transform.Translate(d.transform.forward * depth);
                e.transform.Translate(e.transform.forward * depth);
                f.transform.Translate(f.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                break;
            case 7:
                a.transform.Translate(a.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                f.transform.Translate(f.transform.forward * depth);
                break;
            case 6:
                b.transform.Translate(b.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                d.transform.Translate(d.transform.forward * depth);
                e.transform.Translate(e.transform.forward * depth);
                f.transform.Translate(f.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                break;
            case 5:
                f.transform.Translate(f.transform.forward * depth);
                e.transform.Translate(e.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                break;
            case 4:
                e.transform.Translate(e.transform.forward * depth);
                a.transform.Translate(a.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                break;
            case 3:
                f.transform.Translate(f.transform.forward * depth);
                a.transform.Translate(a.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                break;
            case 2:
                f.transform.Translate(f.transform.forward * depth);
                a.transform.Translate(a.transform.forward * depth);
                g.transform.Translate(g.transform.forward * depth);
                d.transform.Translate(d.transform.forward * depth);
                c.transform.Translate(c.transform.forward * depth);
                break;
            case 1:
                a.transform.Translate(a.transform.forward * depth);
                b.transform.Translate(b.transform.forward * depth);
                break;
            default:
                
                break;
        }
    }

    public void Reset()
    {
        a.transform.position = posA;
        b.transform.position = posB;
        c.transform.position = posC;
        d.transform.position = posD;
        e.transform.position = posE;
        f.transform.position = posF;
        g.transform.position = posG;
    }
}
