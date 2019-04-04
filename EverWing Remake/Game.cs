using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace EverWing_Remake {
    public partial class Game : Form {
        Menu m;

        PlayerInfo info;

        int timerInterval;

        public int difficulty = 5;
        int difficultyCounter = 0;
        int batchesToIncreaseDifficulty = 5;

        Player player;
        BatchSpawner spawner;

        List<Projectile> projectiles = new List<Projectile>();
        List<MonsterBatch> batches = new List<MonsterBatch>();
        bool started;


        //constructor
        public Game(Menu _m) {
            InitializeComponent();
            timerInterval = gameLoop.Interval;
            m = _m;
        }

        //makes the player fire a projectile
        void fire() {

            //creates a new projectile that starts at the center of the player's x value, and at the height of the player
            projectiles.Add(new Projectile(player.Coords.X, player.Coords.Y - player.Size / 2));
        }

        //checks to spawn a batch of monsters
        void checkToSpawn() {
            if (spawner.spawn == true) {
                spawnMonsters();
            }
        }

        //spawns the monsters
        public void spawnMonsters() {
            spawner.spawn = false;
            batches.Add(new MonsterBatch(difficulty));
        }

        //a method that checks to see if there was a collision between monsters and projectiles
        void checkForBulletCollision() {

            //variables used to store the two distances that must be measured to calculate a collision between circles
            int bothRadiuses = 0;
            int distanceBetween = 0;

            //makes sure that there are actually objects to check for collisions
            if (batches.Count != 0 && projectiles.Count != 0) {

                //loops through all of the monster batches backwards
                for (int i = batches.Count - 1; i >= 0; i--) {

                    //loops through the monsters within the batch backwards
                    for (int j = batches[i].monsters.Count - 1; j >= 0; j--) {

                        //loops through all of the projectiles fired by the enemy
                        for (int k = projectiles.Count - 1; k >= 0; k--) {

                            //sets the distance between the projectile and the monster being checked
                            distanceBetween = (int)Math.Sqrt(Math.Pow(batches[i].monsters[j].Coords.X - projectiles[k].Coords.X, 2) + Math.Pow(batches[i].monsters[j].Coords.Y - projectiles[k].Coords.Y, 2));

                            //sets the maximum distance for a collision
                            bothRadiuses = projectiles[k].size / 2 + batches[i].monsterSize / 2;

                            //if the distance between the two is smaller than the maximum distance
                            if (distanceBetween < bothRadiuses) {

                                //does the collision trigger each time a monster-projectile collision occurs
                                monsterProjectileCollisionTrigger(batches[i], batches[i].monsters[j], projectiles[k]);

                                break;
                            }
                        }
                    }
                }
            }
        }

        //the trigger that happens when a projectile collides with a monster
        void monsterProjectileCollisionTrigger(MonsterBatch b, Monster m, Projectile p) {

            //gets the amount of damage that was dealth during the collision
            int damageDealt = p.damage;

            //reduces the damage from the collided monster's health
            m.reduceHealth(damageDealt);

            //removes the projectile that collided with a monster
            projectiles.Remove(p);

            //if the monster died during the collision, the monster is removed
            if (m.dead == true)
                b.monsters.Remove(m);
        }

        //updates the labels for the game
        void updateLabels() {
            //difficulty_lbl.Text = difficulty.ToString();
        }






        //Form Functions----------------------------------------------------------

        //game loop
        void gameLoop_Tick(object sender, EventArgs e) {

            //makes sure that the game has actually started before doing any of the game loop stuff
            if (started == true) {

                updateLabels();

                //checks to spawn a new wave of monsters
                checkToSpawn();

                //only happens if there are projectiles to remove
                if (projectiles.Count != 0) {

                    //loops through all of the monsters
                    for (int i = projectiles.Count - 1; i < 0; i--) {

                        //checks to see if the monster has gone off the screen
                        if (projectiles[i].checkToRemove()) {

                            //removes projectiles that are off screen
                            projectiles.RemoveAt(i);
                        }
                    }

                }

                //makes each projectile in the list move up the screen
                foreach (Projectile p in projectiles)
                    p.move();

                //removes the projectiles if the go off the screen
                for (int i = 0; i < projectiles.Count(); i++)
                    if (projectiles[i].checkToRemove() == true)
                        projectiles.RemoveAt(i);

                //removes a batch of monsters if it goes off screen
                if (batches.Count != 0) {
                    if (batches[0].monsters.Count == 0 || batches[0].monsters[0].Coords.Y > Height) {

                        //removes the batch when there is nothing left in the batch
                        batches.RemoveAt(0);

                        //increases the difficulty counter
                        difficultyCounter++;

                        //only increases the difficulty after 5 rounds
                        if (difficultyCounter > batchesToIncreaseDifficulty) {

                            //resets the counter to be used for the next counting
                            difficultyCounter = 0;

                            //increases the difficulty
                            difficulty++;
                        }
                    }
                }

                //moves each monster
                foreach (MonsterBatch m in batches)
                    m.move();

                //only fires the gun when the player has cooled down enough
                if (player.checkToFire(gameLoop.Interval))
                    fire();

                //after all of the movement has happened, the game checks for any collisions
                checkForBulletCollision();
            }

            //draws the game out
            canvas_pic.Invalidate();
        }

        //draws out the game
        void canvas_pic_Paint(object sender, PaintEventArgs e) {

            //only draws if the game has started
            if (started == true) {

                //draws the player
                player.draw(e);


                //shows each projectile
                foreach (Projectile p in projectiles)
                    p.draw(e);


                //shows each of the monsters in the batch
                foreach (MonsterBatch m in batches)
                    m.draw(e);
            }
        }

        //allows the user to move the mouse to move the player
        void canvas_pic_MouseMove(object sender, MouseEventArgs e) {
            if (started == true) {
                player.Coords = new Point(e.X, e.Y);
            }
        }




        //Button Inputs----------------------------------------------------------

        //ends the game
        private void close_btn_Click(object sender, EventArgs e) {
            Close();
            m.Close();
        }

        //starts the game
        void start_btn_Click(object sender, EventArgs e) {

            //info = new PlayerInfo();

            //creates a spawner as soon as the game starts
            spawner = new BatchSpawner(timerInterval, this);

            //creates a new player with centered coordinates
            player = new Player(canvas_pic.Width / 2, canvas_pic.Height - 60, timerInterval);

            //spawns in the first monster
            spawnMonsters();

            //lets the program know that the game has started
            started = true;

            //stops the user from clicking the start button
            start_btn.Enabled = false;
            //stops the user from clicking the start button
        }
    }
}

/* to do
 *
 * 
 * when monster batch is fully cleared, increase difficulty by one, and increase spawn speed
 * 
 * 
 * make a shop system
 * 
 * open up the player info text file
 * 
 * let the user buy upgrades using coins
 * 
 * when starting the game
 * 
 * open up the player info text file to get the data about the player 
 * 
 * then start the game
 * 
 * when finishing the game, set the amount of coins gained mid game
 * 
 * 
 * 
 * 
 */
