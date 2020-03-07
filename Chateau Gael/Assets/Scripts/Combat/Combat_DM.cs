using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public delegate void EndCurrentTurn();

    public static event StartNextTurn On_Turn_Start;
    public static event EndCurrentTurn On_Turn_End;
    public static event CombatStart On_Combat_Start;

    public List<Party_Member> party_members; //= new List<Party_Member>();
    public List<Enemy> enemies = new List<Enemy>();
    public List<Entity> turn_order = new List<Entity>();

    Entity current_unit;

    DexCompare dxc = new DexCompare();

    int turn;
    int turn_state;

    // Start is called before the first frame update
    void Start()
    {
        On_Combat_Start += StartCombat;
        On_Turn_Start += StartTurn;
        On_Turn_End += EndTurn;
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
        switch (turn_state)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    SelectAttack();
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    Attack(current_unit, enemies[0]);
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    Attack(current_unit, enemies[1]);
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    Attack(current_unit, enemies[2]);
                break;
        }      

    }

    void StartTurn()
    {
        Debug.Log("Turn " + turn);

        current_unit = turn_order[turn];
        if(current_unit is Party_Member && current_unit.current_health >= 1)
        {
            Debug.Log(current_unit.name + "'s turn. Select Action");
            Debug.Log("[1] Attack");
            Debug.Log("[2] Ability");

            turn_state = 1;
        }
        else if(current_unit is Enemy && current_unit.current_health >=1)
        {
            Debug.Log(current_unit.name + "'s turn");
            int target = UnityEngine.Random.Range(0,3);
            Debug.Log("Target is: " + target);
            Attack(current_unit, party_members[target]);
        }
        else
        {
            Debug.Log(current_unit.name + " is out cold!");
            On_Turn_End();
        }
    }
    void EndTurn()
    {
        turn++;
        if(turn >= turn_order.Count)
        {
            turn = 0;
            Debug.Log("New Round");
        }
        On_Turn_Start();
    }

    void SelectAttack()
    {

        int x = 1;
        Debug.Log("Select Target");
        foreach(Enemy enemy in enemies)
        {
            Debug.Log("Enemy [" + x + "]: " + enemy.name + "\n Health- " + enemy.current_health + "\n Physical Armor- " + enemy.equipment.current_p_armor + "\n Magical Armor- " + enemy.equipment.current_m_armor + "\n");
            x++;
        }
        turn_state = 2;
    }

    void Attack(Entity attacker, Entity target)
    {
        Debug.Log(attacker.name + " attacks " + target.name + "!");
        if (Hit(attacker.dex.GetStat(), target.dex.GetStat()))
            Damage(attacker.equipment.wpn1.damage, target);
        On_Turn_End();

    }

    void ChooseSkill()
    {

    }
    bool Hit(int attacker_dex, int target_dex)
    {
        if (attacker_dex >= target_dex)
        {
            Debug.Log("The attack hits!");
            return true;
        }
        Debug.Log("The attack fails!");
        return false;
    }
    void Damage(int damage, Entity target)
    {
        target.Damage(damage);
    }

}
