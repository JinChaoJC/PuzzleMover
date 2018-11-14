using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform[] Pos;
    public Mover[] Movers;
    private Command c1;
    private bool isFirstBack = false;

    private Stack<Command> Stack_Command = new Stack<Command>();

    // Use this for initialization 
    private void Start()
    {
        for (int i = 0; i < Movers.Length; i++)
        {
            Mover mr = Movers[(int)Random.Range(0, Movers.Length)];


            ShareData sd = new ShareData();
            int r = (int)Random.Range(0, 9);
            sd.v3 = Pos[r].position;
            sd.msg = "to : " + mr.gameObject.name + " : " + r.ToString();


            Command com = new Command1(mr, sd);
            Stack_Command.Push(com);
            Execute(com);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Mover mr = Movers[(int)Random.Range(0, Movers.Length)];


            ShareData sd = new ShareData();
            int r = (int)Random.Range(0, 9);
            sd.v3 = Pos[r].position;
            sd.msg ="to : "+mr.gameObject.name+" : "+r.ToString();


            Command com = new Command1(mr, sd);
            Stack_Command.Push(com);
            Execute(com);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Stack_Command.Count <= 0) return;
            if (!isFirstBack)
            {
                Stack_Command.Pop();
                isFirstBack = true;
            }
            Command lastCommand = Stack_Command.Pop();
            Execute(lastCommand);
        }
    }

    void Execute(Command com)
    {
        com.Execute();
    }

}

#region instance class

public class Command1 : Command
{
    public Command1(Recever r, ShareData sd) : base(r, sd) { }
}


#endregion

public struct ShareData
{
    public Vector3 v3;
    public string msg;
}
public abstract class Command
{
    internal ShareData m_ShareData;
    internal Recever m_Recever;
    public Command(Recever r, ShareData sd)
    {
        m_Recever = r;
        m_ShareData = sd;
    }
    public void Execute()
    {
        m_Recever.Execute(m_ShareData);
    }
    
}

public abstract class Recever : MonoBehaviour, IExecute
{
    public abstract void Execute(ShareData sd);
}


public interface IExecute
{
    void Execute(ShareData sd);
}
