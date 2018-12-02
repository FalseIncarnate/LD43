using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    internal int food_spirit_favor = 300;
    internal int drink_spirit_favor = 300;
    internal int produce_spirit_favor = 300;
    internal int flesh_spirit_favor = 300;
    internal int craft_spirit_favor = 300;
    internal int blood_spirit_favor = 300;

    internal GameObject menu_ui;

    public GameObject basic_menu_layout;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

    public GameObject inv_menu_layout;
    public Text inv_category;
    public Text inv_list;

    public GameObject favor_menu_layout;
    public Text favor_list;

    public GameObject action_menu_layout;
    public Text action_text;
    public Text action_progress;

    internal bool doing_activity = false;
    internal int activity_step_count = 0;

    internal PlayerControl player;

    public Sprite[] counter_sprites;

    // Use this for initialization
    void Start () {
        menu_ui = GameObject.Find("Menu_UI");
        ClearAllText();
        ToggleMenuVisibility(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void ToggleMenuVisibility(bool visible) {
        Canvas c = menu_ui.GetComponent<Canvas>();
        c.enabled = visible;
    }

    internal void SetText1(string message) {
        if(message == string.Empty) {
            text1.text = "";
            text1.enabled = false;
            return;
        }
        text1.enabled = true;
        text1.text = message;
    }

    internal void SetText2(string message) {
        if(message == string.Empty) {
            text2.text = "";
            text2.enabled = false;
            return;
        }
        text2.enabled = true;
        text2.text = message;
    }

    internal void SetText3(string message) {
        if(message == string.Empty) {
            text3.text = "";
            text3.enabled = false;
            return;
        }
        text3.enabled = true;
        text3.text = message;
    }

    internal void SetText4(string message) {
        if(message == string.Empty) {
            text4.text = "";
            text4.enabled = false;
            return;
        }
        text4.enabled = true;
        text4.text = message;
    }
    
    internal void SetText5(string message){
        if(message == string.Empty) {
            text5.text = "";
            text5.enabled = false;
            return;
        }
        text5.enabled = true;
        text5.text = message;
    }

    internal void SetText6(string message) {
        if(message == string.Empty) {
            text6.text = "";
            text6.enabled = false;
            return;
        }
        text6.enabled = true;
        text6.text = message;
    }

    internal void ClearAllText() {
        SetText1("");
        SetText2("");
        SetText3("");
        SetText4("");
        SetText5("");
        SetText6("");
    }

}
