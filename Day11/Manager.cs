using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    public int rounds = 20;
    public static bool canContinue;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        canContinue = true;
        StartCoroutine("Execute");
    }

    IEnumerator Execute()
    {
        for (i = 0; i < rounds; i++)
        {
            foreach (Transform mTransform in transform)
            {
                yield return new WaitForSeconds(0f);

                while (!canContinue)
                {
                    yield return new WaitForSeconds(0f);
                }

                canContinue = false;
                Monkey monkey = mTransform.gameObject.GetComponent<Monkey>();
                monkey.DoStuff();
            }
        }

        long[] totals = new long[8];
        int j = 0;

        foreach (Transform mTransform in transform)
        {
            totals[j] = mTransform.gameObject.GetComponent<Monkey>().itemCounter;
            Debug.Log("Monkey " + j + " inspected " + totals[j] + " items");

            j++;
        }

        Array.Sort(totals);

        long mBusiness = totals[6] * totals[7];

        Debug.Log("Level of monkey business is " + mBusiness);
    }
}
