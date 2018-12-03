using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPen : Interactable_Object
{
    internal bool requires_feed = true;
    internal Product feed_product;
    internal bool is_fed = false;
    internal int fed_level = 0;

    internal bool is_maturing = false;

    internal float maturity_rate = 10;
    internal int mature_animals = 0;
    internal int max_mature_animals = 3;

    internal int maturity_progress = 0;
    internal const int MATURE_STAGE = 10;
    
    public GameObject my_counter;
    internal SpriteRenderer counter_sr;

    internal Product blood = new Blood();

	// Use this for initialization
	void Start () {
        object_name = "Animal Pen";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 4;
    }

    internal void UpdateCounter() {
        if(my_counter == null) {
            return;
        }
        if(counter_sr == null) {
            counter_sr = my_counter.GetComponent<SpriteRenderer>();
        }

        counter_sr.sprite = gm.counter_sprites[mature_animals];
    }

    internal IEnumerator MatureDelay(float seconds) {
        if(is_maturing) {
            yield break;
        }

        is_maturing = true;

        yield return new WaitForSeconds(seconds);

        is_maturing = false;

        AttemptMature();
    }

    internal void AttemptMature() {
        if(mature_animals == max_mature_animals) {
            return;
        }

        if(!is_fed && requires_feed) {
            return;
        }

        maturity_progress++;
        CheckGrowFavorBonus();

        if(maturity_progress >= MATURE_STAGE) {
            mature_animals++;
            maturity_progress = 0;
            fed_level--;
            CheckFedLevel();
        }

        UpdateCounter();
        StartCoroutine(MatureDelay(maturity_rate));
    }

    internal virtual void CheckGrowFavorBonus() {
        int flesh_favor = gm.flesh_spirit_favor;
        int blood_favor = gm.blood_spirit_favor;

        int spirit_bonus = 0;

        if(flesh_favor >= 400) {
            spirit_bonus += 25;
        } else if(flesh_favor <= 100) {
            spirit_bonus -= 25;
        }

        if(blood_favor >= 400) {
            spirit_bonus += 10;
        } else if(blood_favor <= 100) {
            spirit_bonus -= 10;
        }

        if(spirit_bonus == 0) {
            return;
        }

        //low favor can stunt growth
        if(spirit_bonus < 0) {
            if(100 + spirit_bonus <= (int)Random.Range(0, 100)) {
                maturity_progress--;
            }
            return;
        }

        //high favor can boost growth
        if(spirit_bonus >= (int)Random.Range(0, 100)) {
            maturity_progress++;
        }
    }

    internal virtual void FeedPen() {
        if(!requires_feed || fed_level == 100) {
            return;
        }
        inv.UpdateItemCount(feed_product, -1);
        fed_level++;
        CheckFedLevel();
    }

    internal void CheckFedLevel() {
        if(fed_level <= 0) {
            is_fed = false;
        } else {
            is_fed = true;
        }
        StartCoroutine(MatureDelay(maturity_rate));
    }

    internal virtual void ButcherAnimal(bool meddle = false) {
        if(mature_animals > 0) {
            mature_animals--;
        }
        UpdateCounter();
        StartCoroutine(MatureDelay(maturity_rate));
        gm.player.CloseMenu();
    }

}
