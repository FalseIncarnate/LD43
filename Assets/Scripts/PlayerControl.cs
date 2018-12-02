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

    protected bool in_menu = false;
    internal Interactable_Object cur_menu_target;

    protected GameManager gm;
    protected Interactable_Object pause_menu;
    protected SpriteRenderer sr;
    protected Inventory inv;

    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
        gm.player = this;
        pause_menu = GameObject.Find("Pause_Menu_Holder").GetComponent<Interactable_Object>();
        //print(pause_menu);
        sr = transform.GetComponent<SpriteRenderer>();
        inv = transform.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        if(gm.doing_activity) {
            return;
        }
        if(in_menu) {
            if(Input.GetKeyDown("1")) {
                MenuOption(1);
            }
            if(Input.GetKeyDown("2")) {
                MenuOption(2);
            }
            if(Input.GetKeyDown("3")) {
                MenuOption(3);
            }
            if(Input.GetKeyDown("4")) {
                MenuOption(4);
            }
            if(Input.GetKeyDown("5")) {
                MenuOption(5);
            }
            if(Input.GetKeyDown("6")) {
                MenuOption(6);
            }
            if(Input.GetKeyDown("escape")) {
                MenuOption(-1);
            }
            return;
        }

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

        if(Input.GetKeyDown("escape")) {
            cur_menu_target = pause_menu;
            ShowMenu();
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
        if(io == null) {
            return;
        }
        cur_menu_target = io;
        if(io.AttemptInteract()) {
            ShowMenu();
        }
    }

    void MenuOption(int option) {
        if(!in_menu) {
            return;
        }
        if(option == -1) {
            CloseMenu();
            return;
        }
        if(option < 1 || option > 6) {
            return;
        }
        cur_menu_target.HandleMenuOption(option);
    }

    internal void CloseMenu() {
        if(cur_menu_target != null) {
            cur_menu_target.PreClose();
        }
        in_menu = false;
        cur_menu_target = null;
        gm.ToggleMenuVisibility(false);
        //print("Closing menu");
    }

    internal void ShowMenu() {
        in_menu = true;
        cur_menu_target.UpdateMenu();
        gm.ToggleMenuVisibility(true);
        //print("Showing menu");
    }

}
