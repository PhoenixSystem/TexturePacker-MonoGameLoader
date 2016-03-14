using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TexturePackerLoader
{
    public class SpriteSheetLoaderiOS : BaseSpriteSheetLoader
    {
        private readonly bool _supportRetina;

        public SpriteSheetLoaderiOS(ContentManager contentManager) : base(contentManager)
        {
            _supportRetina = MonoTouch.UIKit.UIScreen.MainScreen.Scale == 2.0f;
        }

        public override string[] ReadDataFile(string filePath)
        {
            var input = filePath;

            if (!_supportRetina) return File.ReadAllLines(input);

            var dataFile2X = Path.Combine(
                Path.GetDirectoryName(filePath),
                Path.GetFileNameWithoutExtension(filePath) + "@2x" + Path.GetExtension(filePath));

            if (File.Exists(dataFile2X))
            {
                input = dataFile2X;
            }

            return File.ReadAllLines(input);
        }
    }
}