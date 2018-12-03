using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Base : Interactable_Object {

    internal List<Product> shop_sells = new List<Product>();
    internal List<Product> shop_buys = new List<Product>();

    internal string option1 = "";
    internal string option2 = "";
    internal string option3 = "";
    internal string option4 = "";
    internal string option5 = "";
    internal string option6 = "";

    internal int menu_cat = 1;
    internal int menu_page = 1;

    // Use this for initialization
    void Start () {
        object_name = "Shop";
	}
	
	internal override void SetupShop() {
        
    }

    internal virtual void BaseMenu() {
        option1 = "Buy";
        option2 = "Sell";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal virtual void BuyMenu1() {
        option1 = "Cancel Buy";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "Next Page";
    }

    internal virtual void BuyMenu2() {
        option1 = "Prev Page";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal virtual void BuyMenu3() {
        option1 = "Prev Page";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal virtual void SellMenu1() {
        option1 = "Cancel Sell";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "Next Page";
    }

    internal virtual void SellMenu2() {
        option1 = "Prev Page";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal virtual void SellMenu3() {
        option1 = "Prev Page";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal void AttemptSellToStore(int num) {
        if(num > shop_buys.Count) {
            return;
        }
        Product thing_to_sell = shop_buys[num - 1];
        if(thing_to_sell == null) {
            return;
        }
        inv.UpdateMoney(thing_to_sell.sell_value);
        inv.UpdateItemCount(thing_to_sell, -1);
        gm.player.CloseMenu();
    }

    internal virtual void AttemptSellToPlayer(int num) {
        if(num > shop_sells.Count) {
            return;
        }
        Product thing_to_buy = shop_sells[num - 1];
        if(thing_to_buy == null) {
            return;
        }
        int cost = inv.GetBuyCost(thing_to_buy);
        if(inv.money < cost) {
            return;
        }
        inv.UpdateMoney(cost * -1);
        inv.UpdateItemCount(thing_to_buy, 1);
        gm.player.CloseMenu();
    }

    internal override void HandleMenuOption(int option) {
        //base menu
        if(menu_cat == 1) {
            if(option == 1) {
                menu_cat = 2;
                menu_page = 1;
                UpdateMenu();
                return;
            }
            if(option == 2) {
                menu_cat = 3;
                menu_page = 1;
                UpdateMenu();
                return;
            }
        }
        //submenus (buy/sell)
        switch(option) {
            case 1:
                if(menu_page == 1) {
                    DoShopAction(1);
                } else {
                    //Prev Page
                    menu_page--;
                    UpdateMenu();
                }
                break;
            case 2:
                if(menu_page == 1) {
                    DoShopAction(2);
                } else if(menu_page == 2) {
                    DoShopAction(6);
                } else {
                    DoShopAction(10);
                }
                break;
            case 3:
                if(menu_page == 1) {
                    DoShopAction(3);
                } else if(menu_page == 2) {
                    DoShopAction(7);
                } else {
                    DoShopAction(11);
                }
                break;
            case 4:
                if(menu_page == 1) {
                    DoShopAction(4);
                } else if(menu_page == 2) {
                    DoShopAction(8);
                } else {
                    DoShopAction(12);
                }
                break;
            case 5:
                if(menu_page == 1) {
                    DoShopAction(5);
                } else if(menu_page == 2) {
                    DoShopAction(9);
                } else {
                    DoShopAction(13);
                }
                break;
            case 6:
                if(menu_page <= 2) {
                    //Next Page
                    menu_page++;
                    UpdateMenu();
                } else {
                    DoShopAction(14);
                }
                break;
        }
    }

    internal override void UpdateMenu() {
        if(menu_cat == 1) {
            BaseMenu();
        } else {
            switch(menu_page) {
                case 1:
                    if(menu_cat == 2) {
                        BuyMenu1();
                    } else {
                        SellMenu1();
                    }
                    break;
                case 2:
                    if(menu_cat == 2) {
                        BuyMenu2();
                    } else {
                        SellMenu2();
                    }
                    break;
                case 3:
                    if(menu_cat == 2) {
                        BuyMenu3();
                    } else {
                        SellMenu3();
                    }
                    break;

            }
        }
        base.UpdateMenu();
    }

    internal virtual void DoShopAction(int num) {
        if(menu_cat == 2) {
            //Buy
            AttemptSellToPlayer(num);
        }else if(menu_cat == 3) {
            //Sell
            AttemptSellToStore(num);
        }
        return;
    }

}
