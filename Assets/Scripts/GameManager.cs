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

    internal const int BAD_MEDDLE_LEVEL = 100;
    internal const int GOOD_MEDDLE_LEVEL = 500;
    internal const int MAX_FAVOR_LEVEL = 1000;
    internal const int UPGRADE_FAVOR_BONUS = 50;

    internal bool spirits_waiting = false;
    internal const float SPIRIT_TIME = 600;

    internal bool taxes_paid = true;
    internal int taxes_due = 25;
    internal const float TAX_TIME = 1800;
    internal bool taxes_active = true;  //disable to disable taxation, if only it was this simple in real life...
    internal bool taxes_pending = false;

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
        if(taxes_active) {
            StartCoroutine(TaxSchedule(TAX_TIME));
        }
        StartCoroutine(SpiritSchedule(SPIRIT_TIME));
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

    internal IEnumerator SpiritSchedule(float seconds) {
        if(spirits_waiting) {
            yield break;
        }

        spirits_waiting = true;

        yield return new WaitForSeconds(seconds);

        spirits_waiting = false;

        FavorDecay();
        MeddleCheck();
    }

    internal void FavorDecay() {
        //Spirit favor decays over time, each spirit's favor decays a random amount each time (between 0 and 100, in increments of 5, favor decay per interval)
        int favor_decay_amount = 0;
        //Food Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        food_spirit_favor = System.Math.Max(0, food_spirit_favor - favor_decay_amount);
        //Drink Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        drink_spirit_favor = System.Math.Max(0, drink_spirit_favor - favor_decay_amount);
        //Produce Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        produce_spirit_favor = System.Math.Max(0, produce_spirit_favor - favor_decay_amount);
        //Flesh Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        flesh_spirit_favor = System.Math.Max(0, flesh_spirit_favor - favor_decay_amount);
        //Craft Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        craft_spirit_favor = System.Math.Max(0, craft_spirit_favor - favor_decay_amount);
        //Blood Spirit
        favor_decay_amount = (int)Random.Range(0, 20) * 5;
        blood_spirit_favor = System.Math.Max(0, blood_spirit_favor - favor_decay_amount);
    }

    internal void MeddleCheck() {
        int random_spirit = 0;
        random_spirit = (int)Random.Range(1, 6);
        switch(random_spirit) {
            case 1:
                //Produce
                ProduceMeddle();
                break;
            case 2:
                //Flesh
                FleshMeddle();
                break;
            case 3:
                //Blood
                BloodMeddle();
                break;
            case 4:
                //Food
                FoodMeddle();
                break;
            case 5:
                //Drink
                DrinkMeddle();
                break;
            case 6:
                //Craft
                break;
        }
        StartCoroutine(SpiritSchedule(SPIRIT_TIME));
    }

    internal void ProduceMeddle() {
        if(produce_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            } else {
                //Shrine Downgrade
                ProduceShrine shrine_target = GameObject.Find("Produce_Shrine").GetComponent<ProduceShrine>();
                if(shrine_target.upgrade_level > 0) {
                    shrine_target.Tantrum();
                }
            }
        }
    }

    internal void FleshMeddle() {
        if(flesh_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            }
            AnimalPen meddle_target = null;
            int rand = (int)Random.Range(1, 4);
            switch(rand) {
                case 1:
                    //Cow
                    meddle_target = GameObject.Find("Cow_Pen").GetComponent<AnimalPen>();
                    meddle_target.ButcherAnimal(true);
                    break;
                case 2:
                    //Fish
                    meddle_target = GameObject.Find("Fish_Pond").GetComponent<AnimalPen>();
                    meddle_target.ButcherAnimal(true);
                    break;
                case 3:
                    //Chicken
                    meddle_target = GameObject.Find("Cow_Pen").GetComponent<AnimalPen>();
                    meddle_target.ButcherAnimal(true);
                    break;
                case 4:
                    //Shrine Downgrade
                    BloodShrine shrine_target = GameObject.Find("Blood_Shrine").GetComponent<BloodShrine>();
                    if(shrine_target.upgrade_level > 0) {
                        shrine_target.Tantrum();
                    }
                    break;
            }
        }
    }

    internal void BloodMeddle() {
        if(blood_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            } else {
                //Shrine Downgrade
                BloodShrine shrine_target = GameObject.Find("Blood_Shrine").GetComponent<BloodShrine>();
                if(shrine_target.upgrade_level > 0) {
                    shrine_target.Tantrum();
                }
            }
        }
    }

    internal void FoodMeddle() {
        if(food_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            }
            int rand = (int)Random.Range(1, 4);
            switch(rand) {
                case 1:
                    //Kitchen Downgrade
                    Cooking cooking_target = GameObject.Find("Cooking").GetComponent<Cooking>();
                    if(cooking_target.upgrade_level > 0) {
                        cooking_target.upgrade_level--;
                        cooking_target.OnUpgrade();
                    }
                    break;
                case 2:
                    //Steal Chicken Feed
                    AnimalPen chicken_target = GameObject.Find("Chicken_Pen").GetComponent<AnimalPen>();
                    chicken_target.fed_level--;
                    chicken_target.CheckFedLevel();
                    break;
                case 3:
                    //Steal Cow Feed
                    AnimalPen cow_target = GameObject.Find("Cow_Pen").GetComponent<AnimalPen>();
                    cow_target.fed_level--;
                    cow_target.CheckFedLevel();
                    break;
                case 4:
                    //Shrine Downgrade
                    FoodShrine shrine_target = GameObject.Find("Food_Shrine").GetComponent<FoodShrine>();
                    if(shrine_target.upgrade_level > 0) {
                        shrine_target.Tantrum();
                    }
                    break;
            }
        }
    }

    internal void DrinkMeddle() {
        if(drink_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            } else {
                //Shrine Downgrade
                DrinkShrine shrine_target = GameObject.Find("Drink_Shrine").GetComponent<DrinkShrine>();
                if(shrine_target.upgrade_level > 0) {
                    shrine_target.Tantrum();
                }
            }
        }
    }

    internal void CraftMeddle() {
        if(craft_spirit_favor <= BAD_MEDDLE_LEVEL) {
            if(67 >= (int)Random.Range(0, 100)) {
                return;
            } else {
                //Shrine Downgrade
                CraftShrine shrine_target = GameObject.Find("Craft_Shrine").GetComponent<CraftShrine>();
                if(shrine_target.upgrade_level > 0) {
                    shrine_target.Tantrum();
                }
            }
        }
    }

    internal IEnumerator TaxSchedule(float seconds) {
        if(taxes_active && taxes_pending) {
            yield break;
        }

        taxes_pending = true;

        yield return new WaitForSeconds(seconds);

        taxes_pending = false;

        DemandTaxes();
    }

    internal void DemandTaxes() {
        if(!taxes_active) {
            return;
        }
        if(!taxes_paid) {
            SeizeProperty();
            return;
        }
        if(taxes_due == 12800) {
            TaxExempt();
            return;
        }
        taxes_due *= 2;
        taxes_paid = false;
        TaxmanCometh();
        StartCoroutine(TaxSchedule(TAX_TIME));
    }

    internal void SeizeProperty() {
        //Defeat!
        doing_activity = true;  //locks controls
        action_menu_layout.SetActive(true);
        action_text.text = "GAME OVER";
        basic_menu_layout.SetActive(false);
    }

    internal void TaxExempt() {
        //Victory!
        taxes_active = false;
    }

    internal void TaxmanCometh() {
        //Reactivate the taxman
    }

    internal void UpgradeFavor(string spirit) {
        if(spirit == "") {
            return;
        }
        UpdateFavor(spirit, UPGRADE_FAVOR_BONUS);
    }

    internal void UpdateFavor(string spirit, int value) {
        if(spirit == "") {
            return;
        }
        switch(spirit) {
            case "Produce":
                produce_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, produce_spirit_favor + value));
                break;
            case "Flesh":
                flesh_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, flesh_spirit_favor + value));
                break;
            case "Blood":
                blood_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, blood_spirit_favor + value));
                break;
            case "Food":
                food_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, food_spirit_favor + value));
                break;
            case "Drink":
                drink_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, drink_spirit_favor + value));
                break;
            case "Craft":
                craft_spirit_favor = System.Math.Min(MAX_FAVOR_LEVEL, System.Math.Max(0, craft_spirit_favor + value));
                break;
        }
    }

    internal bool CheckSpiritMaxed(string spirit) {
        if(spirit == "") {
            return true;
        }
        bool favor_maxed = false;
        switch(spirit) {
            case "Produce":
                if(produce_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
            case "Flesh":
                if(flesh_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
            case "Blood":
                if(blood_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
            case "Food":
                if(food_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
            case "Drink":
                if(drink_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
            case "Craft":
                if(craft_spirit_favor >= MAX_FAVOR_LEVEL) {
                    favor_maxed = true;
                }
                break;
        }
        return favor_maxed;
    }
}
