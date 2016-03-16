using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TexturePackerLoader
{
    public class SpriteSheetLoaderAndroid : BaseSpriteSheetLoader
    {
        public SpriteSheetLoaderAndroid(ContentManager contentManager) : base(contentManager)
        {
        }

        public override string[] ReadDataFile(string filePath)
        {
            using (var ms = new MemoryStream())
            using (var s = Game.Activity.Assets.Open(filePath))
            {
                s.CopyTo(ms);
                return Encoding.Default.GetString(ms.ToArray()).Split(new [] {'\n'});
            }
        }
    }
}