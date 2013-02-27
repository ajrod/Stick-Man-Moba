using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Side_Scrolling_StickMen
{
    public class Shapes
    {

        public Shapes()
        {

        }
        public static void DrawLine(SpriteBatch batch, Texture2D blank,
              float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            batch.Draw(blank, point1, null, color,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }

        public static void DrawPolygon(SpriteBatch batch, Texture2D blank, float width, Color color, Vector2[] points)
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                DrawLine(batch, blank, width, color, points[i], points[i + 1]);
            }
            DrawLine(batch, blank, width, color, points[0], points[points.Length - 1]);
        }

        public static void DrawSquare(SpriteBatch batch, Texture2D blank, float lineWidth, Color color, Vector2 topLeft, int length)
        {
            DrawRectangle(batch, blank, lineWidth, color, topLeft, length, length);
        }

        public static void DrawRectangle(SpriteBatch batch, Texture2D blank, float lineWidth, Color color, Vector2 topLeft, int width, int length)
        {
            Vector2[] points = new Vector2[4];
            points[0] = topLeft;
            points[1] = new Vector2(topLeft.X + width, topLeft.Y);
            points[2] = new Vector2(topLeft.X + width, topLeft.Y + length);
            points[3] = new Vector2(topLeft.X, topLeft.Y + length);
            DrawPolygon(batch, blank, lineWidth, color, points);
        }
    }
}

