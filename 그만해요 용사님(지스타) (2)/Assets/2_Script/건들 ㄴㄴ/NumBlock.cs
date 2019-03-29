using UnityEngine;

public class NumBlock : MonoBehaviour
{
    public float blockMoveSpeed;
    public int blockSkillNum = 1;

    private int spriteValue = 0;
    private const int basedNumber = 2;

    private Vector3 targetPosition;
    private NumBlock combinedBlock = null;

    public Sprite[] sprite;

    private int blockNumber;
    private bool isCombine = false; //합체를 하는 쪽의 객체 일경우 true
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public bool IsMove
    {
        get; private set;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        blockNumber = basedNumber * Random.Range(1, 1);
    }

    public void Update()
    {
        if (isCombine)
        {
            if (combinedBlock != null && !IsMove)
            {
                if (!combinedBlock.IsMove)
                    Combine();
            }
        }

        if (IsMove)
        {
            float speed = blockMoveSpeed * Time.deltaTime;
            Vector3 current = transform.position;

            transform.position = Vector3.MoveTowards(current, targetPosition, speed);

            if (transform.position == targetPosition)
                MoveEnd();
        }
    }

    private void Combine()
    {
        if (blockNumber < 128)
        {
            blockNumber *= 2;
            blockSkillNum += 1;
        }

        spriteRenderer.sprite = sprite[++spriteValue];

        Destroy(combinedBlock.gameObject);

        animator.SetTrigger("Combine");
        SwipeCountManager.instance.blockCnt--;
        isCombine = false;
        combinedBlock = null;
    }

    public void TryCombineBlock(NumBlock block)
    {
        combinedBlock = block;
        combinedBlock.IsCombine = true;
        isCombine = true;
    }

    public void Move(Vector3 target)
    {
        IsMove = true;

        targetPosition = target;
    }

    public void MoveEnd()
    {
        IsMove = false;

        targetPosition.Set(-1, -1, -1);
    }

    public int BlockNumber
    {
        get
        {
            return blockNumber;
        }
    }

    public bool IsCombine
    {
        get
        {
            return isCombine;
        }
        set
        {
            isCombine = value;
        }
    }
}