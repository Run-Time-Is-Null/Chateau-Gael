using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

class DexCompare : IComparer<Entity>
{
    public int Compare(Entity x, Entity y)
    {
        if(x == null || y == null)
        {
            return 0;
        }
        return y.dex.GetStat().CompareTo(x.dex.GetStat());
    }
}

public class Combat_DM : MonoBehaviour
{

    public delegate void StartNextTurn();
    public delegate void CombatStart();
    public delegate void EndTurn();
    public delegate void Button1();
    public delegate void Button2();

    public static event StartNextTurn On_Turn_Start;
    public static event EndTurn On_Turn_End;
    public static event CombatStart On_Combat_Start;
    public static event Button1 On_Button1_Click;
    public static event Button2 On_Button2_Click;

    public List<Party_Member> party_members; //= new List<Party_Member>();
    public List<Enemy> enemies = new List<Enemy>();
    public List<Entity> turn_order = new List<Entity>();

    DexCompare dxc = new DexCompare();

    int turn;

    // Start is called before the first frame update
    void Start()
    {
        On_Combat_Start += StartCombat;
        On_Turn_Start += StartTurn;
        On_Combat_Start();
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();

    }

    public void SetTurnOrder()
    {
        turn_order.Clear();
        foreach(Party_Member party_member in party_members)
        {
            turn_order.Add(party_member);
        }
        foreach(Enemy enemy in enemies)
        {
            turn_order.Add(enemy);
        }

        DexCompare dxc = new DexCompare();

        turn_order.Sort(dxc);

        //turn_order.Sort((x, y) => x.dex.GetStat().CompareTo(y.dex.GetStat()));

    }

    void StartCombat()
    {
        var temp_members = FindObjectsOfType(typeof(Party_Member));
        var temp_enemies = FindObjectsOfType(typeof(Enemy));

        foreach (Party_Member pm in temp_members)
        {
            party_members.Add(pm);
            turn_order.Add(pm);
        }
        foreach (Enemy enemy in temp_enemies)
        {
            enemies.Add(enemy);
            turn_order.Add(enemy);
        }

        turn_order.Sort(dxc);

        turn = 0;
        On_Turn_Start();
    }

    void GetInput()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            On_Button1_Click();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            On_Button2_Click();
        }
    }

    void StartTurn()
    {
        Entity current_unit = turn_order[turn];
        if(current_unit is Party_Member)
        {
            Debug.Log(current_unit.name + "'s turn. Select Action");
            Debug.Log("[1] Attack");
            Debug.Log("[2] Ability");
            On_Button1_Click += SelectAttack;
            On_Button2_Click += ChooseSkill;
            

        }
    }

    void SelectAttack()
    {

        On_Button1_Click -= SelectAttack;
        On_Button2_Click -= ChooseSkill;

        int x = 1;
        Debug.Log("Select Target");
        foreach(Enemy enemy in enemies)
        {
            Debug.Log("Enemy [" + x + "]: " + enemy.name + "\n Health- " + enemy.current_health + "\n Physical Armor- " + enemy.equipment.current_p_armor + "\n Magical Armor- " + enemy.equipment.current_m_armor + "\n");
            x++;
        }
    }

    void Attack(Enemy enemy)
    {

    }

    void ChooseSkill()
    {

    }

}
