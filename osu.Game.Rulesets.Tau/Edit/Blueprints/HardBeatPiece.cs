using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Tau.Edit.Blueprints
{
    public class HardBeatPiece : CompositeDrawable
    {
        public HardBeatPiece()
        {
            Masking = true;
            BorderThickness = 5;
            BorderColour = Color4.Yellow;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            FillMode = FillMode.Fit;
            InternalChild = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Alpha = 0,
                AlwaysPresent = true
            };
        }
    }
}
