using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public bool multiply;
    public long opNumber;
    public long divider;
    public GameObject trueThrow;
    public GameObject falseThrow;
    public long itemCounter = 0;
    public GameObject temp;

    private long worry;

    public void DoStuff()
    {
        foreach (Transform iTransform in transform)
        {
            GameObject tempItem = Instantiate(iTransform.gameObject, temp.transform);
            tempItem.name = "Item";

            if (multiply)
            {
                if (opNumber == 0)
                {
                    worry = iTransform.gameObject.GetComponent<Item>().worry;
                    worry = worry * worry;
                }

                else
                {
                    worry = iTransform.gameObject.GetComponent<Item>().worry;
                    worry = worry * opNumber;
                }
            }

            else
            {
                worry = iTransform.gameObject.GetComponent<Item>().worry;
                worry = worry + opNumber;
            }

            // multiple of all dividers, keeps worry reasonably small
            while (worry > (2 * 9699690))
            {
                worry -= 9699690;
            }

            Debug.Log(worry);

            tempItem.GetComponent<Item>().worry = worry;

            if (worry % (divider) == 0)
            {
                tempItem.transform.parent = trueThrow.transform;
            }

            else
            {
                tempItem.transform.parent = falseThrow.transform;
            }

            itemCounter++;
        }

        foreach (Transform iTransform in transform)
        {
            Destroy(iTransform.gameObject);
        }

        int i = 0;

        foreach (Transform iTransform in trueThrow.transform)
        {
            iTransform.localPosition = new Vector3(0f, i, 0f);
            i++;
        }

        i = 0;

        foreach (Transform iTransform in falseThrow.transform)
        {
            iTransform.localPosition = new Vector3(0f, i, 0f);
            i++;
        }

        Manager.canContinue = true;
    }
}
