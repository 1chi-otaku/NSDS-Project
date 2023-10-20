using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float slowSpeed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Animator animator;
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (view != null && view.IsMine)
        {
            RaycastHit hit;
            Vector3 castpos = transform.position;
            castpos.y += 1;

            if (Physics.Raycast(castpos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
            {

                if (hit.collider != null)
                {
                    Vector3 movepos = transform.position;
                    movepos.y = hit.point.y + groundDist;
                    transform.position = movepos;
                }

            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");


            animator.SetFloat("Speed", Mathf.Abs(x));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(y));
            Vector3 moveDir = new Vector3(x, 0, (float)(y * (speed / 1.6)));


            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = moveDir * slowSpeed;
            }
            else
            {
                rb.velocity = moveDir * speed;
            }

            if (x != 0 && x < 0)
            {
                sr.flipX = true;
            }
            else if (x != 0 && x > 0)
            {
                sr.flipX = false;
            }
        }
    }
}
