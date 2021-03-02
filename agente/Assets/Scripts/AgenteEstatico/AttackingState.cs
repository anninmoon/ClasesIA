using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : FunctionsFSM
{
    float nextFire;         //Acumular el tiempo para el proximo disparo
    float rateFire = 1f;    //Cada cuanto tine que disparar

    public override void EnterState(Agente agent)
    {
        //Código para cuando entra al estado de atacar
        Debug.Log("Estato de Ataque");
        agent.agentStatus = AgentState.Attacking;

        //agent.FireBullet();
        nextFire = Time.time + rateFire;
    }

    public override void UpdateState(Agente agent)
    {
        if (agent.targetDetected) //Si el target sigue detectado
        {
            //Primero hacia que direccion esta el target, hacemos una resta entre las posiciones para obtenerla y guardarla en lookRotation
            var lookRotation = Quaternion.LookRotation(agent.targetObj.transform.position - agent.transform.position);
            //Realizaremos una rotacion suave a lo largo de la ejecucion, apuntando siempre al target en base a la direccion guardada de lookRotation
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, agent.speedRotation * Time.deltaTime);

            //Controlamos los disparos, si el tiempo acumulado es menor a Time.time, puede disparar
            //Time.time es una variable de la libreria de Unity, es el tiempo que esta transcurriendo en el juego
            if (nextFire < Time.time)
            {
                agent.FireBullet(); //Se  manda llamar el metodo de disparar
                nextFire = Time.time + rateFire; //Acumulamos el tiempo, para cuando toque disparar nuevamente
            }
        }
        else
        {
            agent.TransitionToState(agent.idleState);
        }
    }
}
