using System.Collections;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float maxSpeed = 0.3f;
    public float minSpeed = 0f;
    public float speedChangeInterval = 2.0f;
    public Animator animator;
    public SpriteRenderer sr;

    private Vector3 moveDirection;
    private float timer;
    private bool isChangingSpeed;

    void Start()
    {
        SetRandomDirection(); 
        StartCoroutine(ChangeSpeedPeriodically());
        timer = Random.Range(1, 5);
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
        if (!isChangingSpeed && moveSpeed >0.1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SetRandomDirection();
                timer = Random.Range(1, 5);
            }
            
            if (moveDirection.x < 0)
            {
                sr.flipX = true;
            }
            else if (moveDirection.x > 0)
            {
                sr.flipX = false;
            }

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    void SetRandomDirection()
    {
        float randomAngle = Random.Range(0, 360);
        moveDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
    }

    IEnumerator ChangeSpeedPeriodically()
    {
        while (true)
        {
            isChangingSpeed = true;
            moveSpeed = 0;
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
            moveSpeed = Random.Range(minSpeed, maxSpeed);
            isChangingSpeed = false;
            yield return new WaitForSeconds(speedChangeInterval);
        }
    }
    //public float speed = 0.3f;
    //public float changeDirectionInterval = 3.0f; // Интервал смены направления
    //public float minChangeDirectionInterval = 1.0f; // Минимальный интервал
    //public float maxChangeDirectionInterval = 5.0f; // Максимальный интервал

    //public Animator animator;
    //public SpriteRenderer sr;
    //private Vector3 moveDirection;
    //private float timer;

    //void Start()
    //{
    //    SetRandomDirection();
    //    timer = Random.Range(minChangeDirectionInterval, maxChangeDirectionInterval);
    //}

    //void Update()
    //{
    //    timer -= Time.deltaTime;
    //    if (timer <= 0)
    //    {
    //        SetRandomDirection();
    //        timer = Random.Range(minChangeDirectionInterval, maxChangeDirectionInterval);
    //    }
    //    animator.SetFloat("Speed", speed);
    //    if (moveDirection.x != 0 && moveDirection.x < 0)
    //    {
    //        sr.flipX = true;
    //    }
    //    else if (moveDirection.x != 0 && moveDirection.x > 0)
    //    {
    //        sr.flipX = false;
    //    }
    //    transform.Translate(moveDirection*speed*Time.deltaTime);


    //}

    //void SetRandomDirection()
    //{
    //    float randomAngle = Random.Range(0, 360); // Случайный угол
    //    moveDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward; // Преобразуем угол в направление
    //}

}