using UnityEngine;

public class EnemyStateMove : MonoBehaviour
{
    Enemy enemy;

    public EnemyStateMove(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {

    }
    public void Process()
    {
        if (enemy.target == null) return;
        Vector3 dir = enemy.target.transform.position - enemy.transform.position;
        if (dir.magnitude < 0.5f)
        {
            enemy.target = enemy.target.next;
        }
    }
    public void Exit()
    {

    }
}
