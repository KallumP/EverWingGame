using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace EverWing_Remake {
    class BatchSpawner {
        Game parentGame;

        Timer t;
        int interval;
        int counter;
        int timeToSpawn;



        //constructor | sets up the timer
        public BatchSpawner(int _interval, Game _parent) {
            interval = _interval;
            timeToSpawn = 1000;
            spawn = false;
            counter = 0;

            //gets the class that this is made into
            parentGame = _parent;

            //sets up the timer
            t = new Timer();
            t.Interval = _interval;
            t.AutoReset = true;
            t.Elapsed += tick;
            t.Start();
        }

        //checks to see is a batch should be spawned each tick
        void tick(Object source, ElapsedEventArgs e) {

            setSpawnSpeed();

            //adds on the time passed to the counter
            counter += interval;

            //if it is time to spawn a batch, then "spawn" is set to true, and the counter is reset
            if (counter >= timeToSpawn) {

                //spawns a monster batch into the game
                parentGame.spawnMonsters();

                //resets the counter ready for the next spawn
                counter = 0;
            }
        }

        //makes the spawner spawn 50 milliseconds faster
        public void setSpawnSpeed() {
            timeToSpawn = 1000 - parentGame.difficulty * 10;
        }



        //properties----------------------------------------------------------
        public bool spawn { get; set; } = false;
    }
}
