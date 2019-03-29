using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberBlockManegement : MonoBehaviour
{
    private const float blockMoveSpeed = 1.0f;

    public GameObject[] arrayObject;

    public int arraySize;

    public GameObject numberBlockPrefab;


    private bool isBlockMove = false;
    private GameObject[,] numBlockBase;
    private GameObject[,] numBlocks;

    private void Awake()
    {
        numBlockBase = new GameObject[4, 4];
        numBlocks = new GameObject[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                numBlockBase[i, j] = null;
                numBlocks[i, j] = null;
            }
        }
    }

    public void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                numBlockBase[i, j] = transform.GetChild(i).GetChild(j).gameObject;
            }
        }

        GameStart();
    }
    private void Update()
    {
        if (isBlockMove)
        {
            bool once = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (numBlocks[i, j] != null)
                    {
                        if (numBlocks[i, j].GetComponent<NumBlock>().IsMove) once = true;
                    }
                }
            }

            if (!once)
            {
                isBlockMove = false;
            }
        }
    }

    public void GameStart()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateNumberBlock();
        }
    }

    public void ToLeft()
    {
        if (!isBlockMove)
        {
            bool isMove = false;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bX;
                        for (bX = 0; bX < 4; bX++)
                        {
                            if (bX >= x)
                            {
                                break;
                            }

                            if (numBlocks[y, bX] == null)
                            {
                                MoveBlock(x, y, bX, y);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (numBlocks[y, x] == null)
                    {
                        break;
                    }

                    if (numBlocks[y, x - 1] == null)
                    {
                        MoveBlock(x, y, x - 1, y);
                    }
                    else
                    {
                        if (numBlocks[y, x - 1].GetComponent<NumBlock>().BlockNumber == numBlocks[y, x].GetComponent<NumBlock>().BlockNumber
                            && !(numBlocks[y, x - 1].GetComponent<NumBlock>().IsCombine || numBlocks[y, x].GetComponent<NumBlock>().IsCombine)
                            && numBlocks[y, x - 1].GetComponent<NumBlock>().BlockNumber < 128)
                        {
                            MoveBlock(x, y, x - 1, y, false);
                            CombineBlock(x, y, x - 1, y);
                            isMove = true;
                        }
                    }
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bX;
                        for (bX = 0; bX < 4; bX++)
                        {
                            if (bX >= x)
                            {
                                break;
                            }

                            if (numBlocks[y, bX] == null)
                            {
                                MoveBlock(x, y, bX, y);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isMove)
            {
                CreateNumberBlock();
            }

            isBlockMove = true;
        }
    }

    public void ToRight()
    {
        if (!isBlockMove)
        {
            bool isMove = false;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bX;
                        for (bX = 3; bX >= 0; bX--)
                        {
                            if (bX <= x)
                            {
                                break;
                            }

                            if (numBlocks[y, bX] == null)
                            {
                                MoveBlock(x, y, bX, y);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 2; x >= 0; x--)
                {
                    if (numBlocks[y, x] == null)
                    {
                        break;
                    }

                    if (numBlocks[y, x + 1] == null)
                    {
                        MoveBlock(x, y, x + 1, y);
                    }
                    else
                    {
                        if (numBlocks[y, x + 1].GetComponent<NumBlock>().BlockNumber == numBlocks[y, x].GetComponent<NumBlock>().BlockNumber
                            && !(numBlocks[y, x + 1].GetComponent<NumBlock>().IsCombine || numBlocks[y, x].GetComponent<NumBlock>().IsCombine)
                            && numBlocks[y, x + 1].GetComponent<NumBlock>().BlockNumber < 128)
                        {
                            MoveBlock(x, y, x + 1, y, false);
                            CombineBlock(x, y, x + 1, y);
                            isMove = true;
                        }
                    }
                }
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bX;
                        for (bX = 3; bX >= 0; bX--)
                        {
                            if (bX <= x)
                            {
                                break;
                            }

                            if (numBlocks[y, bX] == null)
                            {
                                MoveBlock(x, y, bX, y);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isMove)
            {
                CreateNumberBlock();
            }

            isBlockMove = true;
        }
    }

    public void ToUp()
    {
        if (!isBlockMove)
        {
            bool isMove = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bY;
                        for (bY = 0; bY < 4; bY++)
                        {
                            if (bY >= y)
                            {
                                break;
                            }

                            if (numBlocks[bY, x] == null)
                            {
                                MoveBlock(x, y, x, bY);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (numBlocks[y, x] == null)
                    {
                        break;
                    }

                    if (numBlocks[y - 1, x] == null)
                    {
                        MoveBlock(x, y, x, y - 1);
                    }
                    else
                    {
                        if (numBlocks[y - 1, x].GetComponent<NumBlock>().BlockNumber == numBlocks[y, x].GetComponent<NumBlock>().BlockNumber
                            && !(numBlocks[y - 1, x].GetComponent<NumBlock>().IsCombine || numBlocks[y, x].GetComponent<NumBlock>().IsCombine)
                            && numBlocks[y - 1, x].GetComponent<NumBlock>().BlockNumber < 128)
                        {
                            MoveBlock(x, y, x, y - 1, false);
                            CombineBlock(x, y, x, y - 1);
                            isMove = true;
                        }
                    }
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bY;
                        for (bY = 0; bY < 4; bY++)
                        {
                            if (bY >= y)
                            {
                                break;
                            }

                            if (numBlocks[bY, x] == null)
                            {
                                MoveBlock(x, y, x, bY);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isMove)
            {
                CreateNumberBlock();
            }

            isBlockMove = true;
        }
    }

    public void ToDown()
    {
        if (!isBlockMove)
        {
            bool isMove = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bY;
                        for (bY = 3; bY >= 0; bY--)
                        {
                            if (bY <= y)
                            {
                                break;
                            }

                            if (numBlocks[bY, x] == null)
                            {
                                MoveBlock(x, y, x, bY);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    if (numBlocks[y, x] == null)
                    {
                        break;
                    }

                    if (numBlocks[y + 1, x] == null)
                    {
                        MoveBlock(x, y, x, y + 1);
                    }
                    else
                    {

                        if (numBlocks[y + 1, x].GetComponent<NumBlock>().BlockNumber == numBlocks[y, x].GetComponent<NumBlock>().BlockNumber
                            && !(numBlocks[y + 1, x].GetComponent<NumBlock>().IsCombine || numBlocks[y, x].GetComponent<NumBlock>().IsCombine)
                            && numBlocks[y + 1, x].GetComponent<NumBlock>().BlockNumber < 128)
                        {
                            MoveBlock(x, y, x, y + 1, false);
                            CombineBlock(x, y, x, y + 1);
                            isMove = true;
                        }
                    }
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (numBlocks[y, x] != null)
                    {
                        int bY;
                        for (bY = 3; bY >= 0; bY--)
                        {
                            if (bY <= y)
                            {
                                break;
                            }

                            if (numBlocks[bY, x] == null)
                            {
                                MoveBlock(x, y, x, bY);
                                isMove = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isMove)
            {
                CreateNumberBlock();
            }

            isBlockMove = true;
        }
    }

    public bool CanBlockMove()
    {
        if (CheckBlocksAllAssign())
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    NumBlock numBlock = numBlocks[y, x].GetComponent<NumBlock>();
                    if (x + 1 < 3)
                    {
                        if (numBlock.BlockNumber == numBlocks[y, x + 1].GetComponent<NumBlock>().BlockNumber)
                        {
                            return true;
                        }
                    }

                    if (y + 1 < 3)
                    {
                        if (numBlock.BlockNumber == numBlocks[y + 1, x].GetComponent<NumBlock>().BlockNumber)
                        {
                            return true;
                        }
                    }

                    if (x - 1 >= 0)
                    {
                        if (numBlock.BlockNumber == numBlocks[y, x - 1].GetComponent<NumBlock>().BlockNumber)
                        {
                            return true;
                        }
                    }

                    if (y - 1 >= 0)
                    {
                        if (numBlock.BlockNumber == numBlocks[y - 1, x].GetComponent<NumBlock>().BlockNumber)
                        {
                            return true;
                        }
                    }
                }
            }
            return true;
        }

        return true;
    }

    private bool CreateNumberBlock()
    {
        if (CheckBlocksAllAssign()) //블럭이 다 채워져있으면 false
        {
            return false;
        }

        for (; ; )
        {
            int x = Random.Range(0, 4);
            int y = Random.Range(0, 4);

            if (numBlocks[y, x] == null)
            {
                numBlocks[y, x] = Instantiate(numberBlockPrefab, numBlockBase[y, x].transform.position, Quaternion.identity);
                SwipeCountManager.instance.blockCnt++;
                break;
            }
        }

        return true;
    }

    /// <summary>
    /// 블럭이 다 채워져있는지 체크
    /// </summary>
    /// <returns></returns>
    private bool CheckBlocksAllAssign()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (numBlocks[i, j] == null)
                {
                    return false; //비어 있는게 있으면 false
                }
            }
        }

        return true; //비어 있지 않으면 true
    }

    private void MoveBlock(int fromX, int fromY, int byX, int byY, bool isAssign = true)
    {
        int deltaX = byX - fromX;
        int deltaY = byY - fromY;

        if (deltaX == 0 && deltaY == 0)
        {
            return;
        }

        numBlocks[fromY, fromX].GetComponent<NumBlock>().Move(numBlockBase[byY, byX].transform.position);

        if (isAssign)
        {
            numBlocks[byY, byX] = numBlocks[fromY, fromX];
            numBlocks[fromY, fromX] = null;
        }

        isBlockMove = true;
    }

    private void CombineBlock(int x, int y, int cX, int cY)
    {
        numBlocks[y, x].GetComponent<NumBlock>().TryCombineBlock(numBlocks[cY, cX].GetComponent<NumBlock>());
        numBlocks[cY, cX] = null;
    }

    public bool IsBlockMove
    {
        get
        {
            return isBlockMove;
        }
    }
}
