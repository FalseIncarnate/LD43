using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    internal const int NORTH = 1;
    internal const int EAST = 2;
    internal const int SOUTH = 4;
    internal const int WEST = 8;

    public Sprite NORTH_SPRITE;
    public Sprite EAST_SPRITE;
    public Sprite SOUTH_SPRITE;
    public Sprite WEST_SPRITE;

    protected bool is_moving = false;
    protected int cur_face_dir = SOUTH;
    protected Vector3 move_goal = Vector3.zero;

    protected SpriteRenderer sr;
    protected Inventory inv;

    // Use this for initialization
    void Start () {
        sr = transform.GetComponent<SpriteRenderer>();
        inv = transform.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!is_moving) {
            if(Input.GetKey("w")) {
                MoveCharacter(NORTH);
            }
            if(Input.GetKey("d")) {
                MoveCharacter(EAST);
            }
            if(Input.GetKey("s")) {
                MoveCharacter(SOUTH);
            }
            if(Input.GetKey("a")) {
                MoveCharacter(WEST);
            }
        }

        HandleMove();

        if(Input.GetKeyDown("up")) {
            FaceDir(NORTH);
        }
        if(Input.GetKeyDown("right")) {
            FaceDir(EAST);
        }
        if(Input.GetKeyDown("down")) {
            FaceDir(SOUTH);
        }
        if(Input.GetKeyDown("left")) {
            FaceDir(WEST);
        }

        if(Input.GetKeyDown("e")) {
            Interact();
        }
    }

    void MoveCharacter(int dir) {
        if(is_moving) {
            HandleMove();
            return;
        }

        FaceDir(dir);

        Vector3 origin_point = transform.position;
        Vector3 end_point = GetEndPoint(origin_point, dir);

        if(!CheckMove(origin_point, end_point)) {
            return;
        }

        is_moving = true;
        move_goal = end_point;
        HandleMove();
    }

    bool CheckMove(Vector3 origin_point, Vector3 end_point) {
        Transform tr = ColliderCheck(origin_point, end_point);
        if(!tr || tr == null) {
            return true;
        }
        BoxCollider2D hit_collider = tr.GetComponent<BoxCollider2D>();
        return hit_collider.isTrigger;
    }

    Transform ColliderCheck(Vector3 origin_point, Vector3 end_point) {
        RaycastHit2D hit;
        hit = Physics2D.Linecast(origin_point, end_point);
        return hit.transform;
    }

    Vector3 GetEndPoint(Vector3 origin_point, int dir) {
        Vector3 end_point = origin_point;
        switch(dir) {
            case NORTH:
                end_point += Vector3.up;
                break;
            case EAST:
                end_point += Vector3.right;
                break;
            case SOUTH:
                end_point += Vector3.down;
                break;
            case WEST:
                end_point += Vector3.left;
                break;
        }
        return end_point;
    }

    void HandleMove() {
        transform.position = Vector3.MoveTowards(transform.position, move_goal, Time.deltaTime * 2.5f);
        if(transform.position == move_goal) {
            is_moving = false;
            return;
        }
    }

    void FaceDir(int dir) {
        switch(dir) {
            case NORTH:
                sr.sprite = NORTH_SPRITE;
                break;
            case EAST:
                sr.sprite = EAST_SPRITE;
                break;
            case SOUTH:
                sr.sprite = SOUTH_SPRITE;
                break;
            case WEST:
                sr.sprite = WEST_SPRITE;
                break;
        }
        cur_face_dir = dir;
    }

    void Interact() {
        Vector3 origin_point = transform.position;
        Vector3 end_point = GetEndPoint(origin_point, cur_face_dir);

        Transform target = ColliderCheck(origin_point, end_point);
        if(!target || target == null) {
            return;
        }
        Interactable_Object io = target.GetComponent<Interactable_Object>();
        io.AttemptInteract(inv);
    }

}
