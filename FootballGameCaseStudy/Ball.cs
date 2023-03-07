
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ball {
    public static readonly Ball Instance = new Ball();
    public delegate void subject();
    public subject observers;
    private Ball() {
    }

    /// <summary>
    /// @param o
    /// </summary>
    public void Attach(Observer o) {
        observers += o.Update;
    }

    /// <summary>
    /// @param o
    /// </summary>
    public void Detach(Observer o) {
        observers -= o.Update;
    }

    public void Notify() {
        observers();
    }

}