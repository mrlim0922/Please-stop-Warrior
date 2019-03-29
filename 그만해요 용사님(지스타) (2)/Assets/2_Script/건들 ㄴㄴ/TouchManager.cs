using System.Collections;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Vector2 mousePos = new Vector2(0, 0);
    private Vector2 mouseEndPos = new Vector2(0, 0);
    private Vector2 wp = new Vector2(0, 0);

    public GameObject[] touchEff;

    private int RocketLevel;
    
    private Ray2D ray;
    private RaycastHit2D hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && SwipeCountManager.instance.blockCnt > 1)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ray = new Ray2D(wp, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (hit.collider != null && hit.collider.CompareTag("NumBlockManeger")
                && hit.collider.GetComponent<NumBlock>().BlockNumber > 2
                && CheckDistance())
            {
                RocketLevel = hit.collider.GetComponent<NumBlock>().blockSkillNum;

                AudioManager.instance.Play("TileUse");
                FamilierController.instance.CreateSkill(RocketLevel);
                ScoreManager.instance.UseTileScore(RocketLevel);
                SwipeCountManager.instance.blockCnt--;

                Instantiate(touchEff[0], hit.transform.position, Quaternion.identity);

                Destroy(hit.collider.gameObject);
            }
        }
    }

    private bool CheckDistance()
    {
        return mouseEndPos.x <= mousePos.x + 0.5f && mouseEndPos.x >= mousePos.x - 0.5f;
    }
}