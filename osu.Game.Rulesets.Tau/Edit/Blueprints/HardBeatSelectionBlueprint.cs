using osu.Framework.Graphics;
using osu.Framework.Graphics.Primitives;
using osu.Game.Rulesets.Tau.Objects;
using osu.Game.Rulesets.Tau.Objects.Drawables;
using osuTK;

namespace osu.Game.Rulesets.Tau.Edit.Blueprints
{
    public class HardBeatSelectionBlueprint : TauSelectionBlueprint<HardBeat>
    {
        protected new DrawableHardBeat DrawableObject => (DrawableHardBeat)base.DrawableObject;
        protected readonly HardBeatPiece SelectionPiece;

        public HardBeatSelectionBlueprint(HardBeat hitObject)
            : base(hitObject)
        {
            InternalChildren = new Drawable[]
            {
                SelectionPiece = new HardBeatPiece(),
            };
        }

        protected override void Update()
        {
            base.Update();
            // These are exact same.. I know...
            SelectionPiece.Size = DrawableObject.DrawSize;
        }

        public override Vector2 ScreenSpaceSelectionPoint => DrawableObject.Circle.ScreenSpaceDrawQuad.Centre;

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => SelectionPiece.ReceivePositionalInputAt(screenSpacePos);

        public override Quad SelectionQuad => DrawableObject.Circle.ScreenSpaceDrawQuad.AABB;
    }
}
