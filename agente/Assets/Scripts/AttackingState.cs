using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : FunctionsFSM
{
    public override void EnterState(Agente agent)
    {
        //Código para cuando entra al estado de atacar
        Debug.Log("Estato de Ataque");
        agent.agentStatus = AgentState.Attacking;

        agent.FireBullet(); 
    }

    public override void UpdateState(Agente agent)
    {
        //Código para cuando no se detecta al jugador
    }
}
