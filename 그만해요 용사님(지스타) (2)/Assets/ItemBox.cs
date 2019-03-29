using System.Collections;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private int count = 0;
    public SpriteRenderer ItemBoxSR;
    private Color color;

    private void Start()
    {
        color.a = 1;
        StartCoroutine(ShowReady());
    }

    private IEnumerator ShowReady()
    {
        while (count < 4)
        {
            yield return new WaitForSeconds(0.2f);

            while (color.a > 0.5f)
            {
                color.a -= Time.deltaTime;
                yield return new WaitForSeconds(0.00001f);
                ItemBoxSR.color = new Color(ItemBoxSR.color.r, ItemBoxSR.color.g, ItemBoxSR.color.b, color.a);
            }

            yield return new WaitForSeconds(0.1f);

            while (color.a < 1f)
            {
                color.a += Time.deltaTime;
                yield return new WaitForSeconds(0.00001f);
                ItemBoxSR.color = new Color(ItemBoxSR.color.r, ItemBoxSR.color.g, ItemBoxSR.color.b, color.a);
            }

            yield return new WaitForSeconds(0.3f);
            count++;
        }

        if (count >= 4)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameObject == null)
        {
            //ItemManager.instance.ItemList.Add(gameObject);
        }
    }
}