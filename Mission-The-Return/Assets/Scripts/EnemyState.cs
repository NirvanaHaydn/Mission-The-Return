using UnityEngine; //esse e o strategy, define os states (interface)

public interface EnemyState
{
    public void Enter();
    public void Exit();
    public void Process();

}
 