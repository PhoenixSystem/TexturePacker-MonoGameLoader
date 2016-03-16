using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TexturePackerLoader
{
    public class SpriteSheetLoader : BaseSpriteSheetLoader
    {
        public SpriteSheetLoader(ContentManager contentManager) : base(contentManager)
        {
        }

        public override string[] ReadDataFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}