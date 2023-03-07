
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Game {
    public Ball Ball { get; set; }
    public PlayGround PlayGround {get;set;}
    public Referee Referee1 {get;set;}
    public Referee Referee2 {get;set;}
    public Referee Referee3 {get;set;}
    public Team Team1 {get;set;}
    public Team Team2 {get;set;}

    public Game() {
    }

}