using Microsoft.Xna.Framework;

namespace Side_Scrolling_StickMen
{
    //World object are objects that make up the world such as floors.
    //They have static hitboxes.
    public class WorldObject : GameObject
    {
        public WorldObject(Sprite sprite, Vector2 position)
            : base(sprite, position)
        {
            Polygon polygon = new Polygon();
            polygon.Points.Add(new Vector2(0, 0));
            polygon.Points.Add(new Vector2(sprite.frameWidth, 0));
            polygon.Points.Add(new Vector2(sprite.frameWidth, sprite.frameHeight));
            polygon.Points.Add(new Vector2(0, sprite.frameHeight));
            polygon.Offset(new Vector2(100,500));
            polygon.BuildEdges();
            this.position = polygon.Center;
            this.setHitbox(polygon);
        }
    }
}