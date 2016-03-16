using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TexturePackerLoader
{
    public class SpriteRender
    {
        private const float ClockwiseNinetyDegreeRotation = (float) (Math.PI/2.0f);

        private readonly SpriteBatch _spriteBatch;

        public SpriteRender(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        // <param name="position">This should be where you want the pivot point of the sprite image to be rendered.</param>
        public void Draw(
            SpriteFrame sprite,
            Vector2 position,
            Color? color = null,
            float rotation = 0,
            float scale = 1,
            SpriteEffects spriteEffects = SpriteEffects.None)
        {
            var origin = sprite.Origin;

            if (sprite.IsRotated)
            {
                rotation -= ClockwiseNinetyDegreeRotation;

                switch (spriteEffects)
                {
                    case SpriteEffects.FlipHorizontally:
                        spriteEffects = SpriteEffects.FlipVertically;
                        break;

                    case SpriteEffects.FlipVertically:
                        spriteEffects = SpriteEffects.FlipHorizontally;
                        break;

                    case SpriteEffects.None:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(spriteEffects), spriteEffects, null);
                }
            }

            switch (spriteEffects)
            {
                case SpriteEffects.FlipHorizontally:
                    origin.X = sprite.SourceRectangle.Width - origin.X;
                    break;

                case SpriteEffects.FlipVertically:
                    origin.Y = sprite.SourceRectangle.Height - origin.Y;
                    break;

                case SpriteEffects.None:
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(spriteEffects), spriteEffects, null);
            }

            _spriteBatch.Draw(sprite.Texture, position, sourceRectangle: sprite.SourceRectangle, color: color,
                rotation: rotation, origin: origin, scale: new Vector2(scale, scale), effects: spriteEffects);
        }
    }
}