using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SevenSegment : MonoBehaviour
{
    public GameObject a, b, c, d, e, f, g;

    public float depth;
    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generate()
    {
        int number = Random.Range(1, 9);
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
                print ("Incorrect intelligence level.");
                break;
        }
    }
}
