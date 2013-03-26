using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Side_Scrolling_StickMen
{
    public class GameObject
    {
        //The game objects position in the world
        public Vector2 position;

        //The current velocity of the game object.
        public Vector2 velocity;

        public Sprite sprite;
        public float scale = 1;

        public float acceleration;
        public float angle;
        public float radius;
        public double maxHP = 1;
        public double curHP = 1;

        //Determines direction the object is moving in where -1 is left, 0 is rest, and 1 is right.
        public int turnDir = 0;

        //This influences how fast a game object will decelerate to rest
        public float friction = 0.925f; 
        //This determines terminal velocity when an object is falling. 
        //Higher resistance means a lower terminal velocity.
        public float airResistance = 0.985f;
        //The strength of gravity applied to the game object.
        public float gravity = 15f;

        //This factor determines the game objects slowest speed. If x falls below slowest speed it is rounded down to 0.
        public float slowestXSpeed = 0.05f;
        public float slowestYSpeed = 0.1f;
        // Boolean deciding if the Object should be drawn or not
        public bool toDraw = true;

        //True iff the object is on a floor
        public bool onFloor = false;
        public float offFloorCt = 0;

        //This determines the amount of time a game object transition from floor to free fall. 
        //This creates a delayed falling effect similiar to what is seen in cartoons.
        public float offFloorTime = 0.2f;

        //True iff the game object has a hit box.
        public bool hasCollisionBox = false;

        //The polygonal hitbox of the game object
        public Polygon hitbox = null;

        public GameObject(Sprite sprite, Vector2 position)
        {
            this.position = position;
            this.sprite = sprite;
            acceleration = 100;
        }

        public void setHitbox(Polygon hitbox)
        {
            this.hitbox = hitbox;
            this.hasCollisionBox = true;
        }

        public void setHealth(double maxHP)
        {
            this.maxHP = maxHP;
            this.curHP = maxHP;
        }

        public virtual void Update(GameTime gameTime)
        {
            move(gameTime.ElapsedGameTime.Milliseconds / 1000f);
        }

        public void Animate()
        {
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (toDraw)
            {
                sprite.draw(spriteBatch, position, -angle);
            }
        }

        public virtual void applyGravity(float time)
        {
            this.velocity.Y += gravity * time;
            this.velocity.Y *= airResistance;
        }

        public void move(float time)
        {

            this.velocity.X += turnDir * acceleration * time;
            //this.position.Y += ...

            if (!onFloor)
            {
                applyGravity(time);
            }
            Side_Scrolling_StickMen.PhysicsEngine.PolygonCollisionResult result =
    PhysicsEngine.PolygonCollision(this.hitbox, StickGame.floor.hitbox, this.velocity);

            if (result.WillIntersect)
            {
                Vector2 translationVector = result.MinimumTranslationVector;
                translationVector.X *= 1.05f;
                translationVector.Y = (translationVector.Y + gravity/1000f)*1.10f;
                this.velocity += translationVector;

            }
            if (velocity.Y < slowestXSpeed && velocity.Y > 0)
            {
                this.onFloor = true;
                this.offFloorCt = 0;
                velocity.Y = 0;
            }
            else if (onFloor)
            {
                this.offFloorCt += time;
                if (this.offFloorCt > this.offFloorTime)
                {
                    this.onFloor = false;
                }
            }

            if (Math.Abs(velocity.X) < slowestXSpeed)
            {
                velocity.X = 0;
            }

            if (Math.Abs(velocity.Y) < slowestYSpeed)
            {
                velocity.Y = 0;
            }
            this.setPosition(this.position + velocity);


            if (hasCollisionBox)
            {
                this.hitbox.Offset(velocity);
                this.hitbox.BuildEdges();
            }
            velocity.X *= friction;
        }
        public void setPosition(Vector2 p)
        {
            if (hasCollisionBox)
            {
                this.position = p;
                this.hitbox.setPosition(p);
            }
        }
    }
}